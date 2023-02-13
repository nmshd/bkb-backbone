﻿using Backbone.Modules.Files.Domain.Entities;

namespace Files.Jobs.SanityCheck.Infrastructure.Reporter
{
    public interface IReporter
    {
        void ReportOrphanedDatabaseId(FileId id);

        void ReportOrphanedBlobId(string id);

        void Complete();
    }
}