﻿using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Backbone.BuildingBlocks.API.Extensions;
using Backbone.BuildingBlocks.Application.QuotaCheck;
using Backbone.Infrastructure.EventBus;
using Backbone.Job.IdentityDeletion;
using Backbone.Modules.Devices.Application.Identities.Commands.CancelStaleIdentityDeletionProcesses;
using Backbone.Modules.Devices.ConsumerApi;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Settings.Configuration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Creating app...");

    var app = CreateHostBuilder(args);

    Log.Information("App created.");
    Log.Information("Starting app...");

    await app.Build().RunAsync();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostContext, configuration) =>
        {
            configuration.Sources.Clear();
            var env = hostContext.HostingEnvironment;

            configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.override.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                configuration.AddUserSecrets(appAssembly, optional: true);
            }

            configuration.AddEnvironmentVariables();
            configuration.AddCommandLine(args);
        })
        .ConfigureServices((hostContext, services) =>
        {
            var configuration = hostContext.Configuration;
            services.AddHostedService<CancelIdentityDeletionProcessWorker>();

            services.AddMediatR(c => c
                .RegisterServicesFromAssemblyContaining<CancelStaleIdentityDeletionProcessesCommand>());

            services.AddModule<DevicesModule>(configuration);

            services.AddTransient<IQuotaChecker, AlwaysSuccessQuotaChecker>();
            services.AddFluentValidationAutoValidation(config => { config.DisableDataAnnotationsValidation = true; });

            services.AddCustomIdentity(hostContext.HostingEnvironment);

            services.ConfigureAndValidate<DeletionProcessJobConfiguration>(configuration.Bind);

#pragma warning disable ASP0000 // We retrieve the BackboneConfiguration via IOptions here so that it is validated
            var parsedConfiguration =
                services.BuildServiceProvider().GetRequiredService<IOptions<DeletionProcessJobConfiguration>>().Value;
#pragma warning restore ASP0000

            services.AddEventBus(parsedConfiguration.Infrastructure.EventBus);
        })
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .UseSerilog((context, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration, new ConfigurationReaderOptions { SectionName = "Logging" })
            .Enrich.WithDemystifiedStackTraces()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("service", "jobs.identitydeletion")
            .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                .WithDefaultDestructurers()
                .WithDestructurers(new[] { new DbUpdateExceptionDestructurer() }))
        )
        .UseServiceProviderFactory(new AutofacServiceProviderFactory());
}
