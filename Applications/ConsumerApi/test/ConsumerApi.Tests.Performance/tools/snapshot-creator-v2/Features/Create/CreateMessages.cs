﻿using Backbone.ConsumerApi.Sdk;
using Backbone.ConsumerApi.Sdk.Authentication;
using Backbone.ConsumerApi.Sdk.Endpoints.Messages.Types.Requests;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Shared.Models;
using Backbone.Crypto;
using MediatR;

namespace Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create;

public record CreateMessages
{
    public record Command(
        List<DomainIdentity> Identities,
        List<RelationshipAndMessages> RelationshipAndMessages,
        string BaseUrlAddress,
        ClientCredentials ClientCredentials) : IRequest<List<DomainIdentity>>;

    // ReSharper disable once UnusedMember.Global - Invoked via IMediator 
    public record CommandHandler : IRequestHandler<Command, List<DomainIdentity>>
    {
        public async Task<List<DomainIdentity>> Handle(Command request, CancellationToken cancellationToken)
        {
            foreach (var senderIdentity in request.Identities)
            {
                var recipientsRelationshipIds = request.RelationshipAndMessages
                    .Where(relationship =>
                        senderIdentity.PoolAlias == relationship.SenderPoolAlias &&
                        senderIdentity.ConfigurationIdentityAddress == relationship.SenderIdentityAddress)
                    .Select(r =>
                    (
                        r.RecipientIdentityAddress,
                        r.RecipientPoolAlias
                    ))
                    .ToList();


                var recipientIdentities = request.Identities
                    .Where(recipient => recipientsRelationshipIds.Any(relationship =>
                        relationship.RecipientPoolAlias == recipient.PoolAlias &&
                        relationship.RecipientIdentityAddress == recipient.ConfigurationIdentityAddress))
                    .ToList();


                foreach (var recipientIdentity in recipientIdentities)
                {
                    var sdkClient = Client.CreateForExistingIdentity(request.BaseUrlAddress, request.ClientCredentials, senderIdentity.UserCredentials);

                    var messageResponse = await sdkClient.Messages.SendMessage(new SendMessageRequest
                    {
                        Recipients =
                        [
                            new SendMessageRequestRecipientInformation
                            {
                                Address = recipientIdentity.IdentityAddress,
                                EncryptedKey = ConvertibleString.FromUtf8(new string('A', 152)).BytesRepresentation
                            }
                        ],
                        Attachments = [],
                        Body = ConvertibleString.FromUtf8("Message body").BytesRepresentation
                    });

                    if (messageResponse.Result is null) continue;

                    senderIdentity.Messages.Add((messageResponse.Result.Id, recipientIdentity));
                }
            }

            return request.Identities;
        }
    }
}
