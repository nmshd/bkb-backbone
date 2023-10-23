﻿// <auto-generated />

using Backbone.Synchronization.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Synchronization.Infrastructure.CompiledModels.SqlServer
{
    [DbContext(typeof(SynchronizationDbContext))]
    public partial class SynchronizationDbContextModel : RuntimeModel
    {
        static SynchronizationDbContextModel()
        {
            var model = new SynchronizationDbContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static SynchronizationDbContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
