﻿// <auto-generated />

using Backbone.Modules.Challenges.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Challenges.Infrastructure.CompiledModels.SqlServer
{
    [DbContext(typeof(ChallengesDbContext))]
    public partial class ChallengesDbContextModel : RuntimeModel
    {
        static ChallengesDbContextModel()
        {
            var model = new ChallengesDbContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static ChallengesDbContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
