﻿// <auto-generated />

using Backbone.Devices.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.SqlServer
{
    [DbContext(typeof(DevicesDbContext))]
    public partial class DevicesDbContextModel : RuntimeModel
    {
        static DevicesDbContextModel()
        {
            var model = new DevicesDbContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static DevicesDbContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
