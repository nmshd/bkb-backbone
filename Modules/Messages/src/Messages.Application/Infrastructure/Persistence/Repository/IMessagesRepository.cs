﻿using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.Persistence.Database;
using Backbone.BuildingBlocks.Application.Pagination;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Messages.Domain.Entities;
using Backbone.Messages.Domain.Ids;

namespace Backbone.Messages.Application.Infrastructure.Persistence.Repository;
public interface IMessagesRepository
{
    Task<DbPaginationResult<Message>> FindMessagesWithIds(IEnumerable<MessageId> ids, IdentityAddress requiredParticipant, PaginationFilter paginationFilter, CancellationToken cancellationToken, bool track = false);
    Task<Message> Find(MessageId id, IdentityAddress requiredParticipant, CancellationToken cancellationToken, bool track = false, bool fillBody = true);
    Task Add(Message message, CancellationToken cancellationToken);
    Task<int> CountUnreceivedMessagesFromSenderToRecipient(IdentityAddress sender, IdentityAddress recipient, CancellationToken cancellationToken);
    Task Update(Message message);
    Task Update(IEnumerable<Message> messages);
}
