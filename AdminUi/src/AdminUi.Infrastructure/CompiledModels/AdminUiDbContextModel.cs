﻿// <auto-generated />
using AdminUi.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace AdminUi.Infrastructure.CompiledModels
{
    [DbContext(typeof(AdminUiDbContext))]
    public partial class AdminUiDbContextModel : RuntimeModel
    {
        static AdminUiDbContextModel()
        {
            var model = new AdminUiDbContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static AdminUiDbContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
