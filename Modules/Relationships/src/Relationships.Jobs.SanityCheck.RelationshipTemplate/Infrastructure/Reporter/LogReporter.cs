﻿using Backbone.Modules.Relationships.Domain.Ids;

namespace Backbone.Modules.Relationships.Jobs.SanityCheck.RelationshipTemplate.Infrastructure.Reporter;

public class LogReporter : IReporter
{
    private readonly ILogger<LogReporter> _logger;
    private readonly List<RelationshipTemplateId> _databaseIds;
    private readonly List<string> _blobIds;

    public LogReporter(ILogger<LogReporter> logger)
    {
        _logger = logger;

        _databaseIds = new List<RelationshipTemplateId>();
        _blobIds = new List<string>();
    }

    public void Complete()
    {
        foreach (var databaseId in _databaseIds)
        {
            _logger.LogError("no blob found for relationship template id: '{databaseId}'", databaseId);
        }

        foreach (var blobId in _blobIds)
        {
            _logger.LogError("no database entry found for blob id: '{blobId}'", blobId);
        }
    }

    public void ReportOrphanedBlobId(string id)
    {
        _blobIds.Add(id);
    }

    public void ReportOrphanedDatabaseId(RelationshipTemplateId id)
    {
        _databaseIds.Add(id);
    }
}
