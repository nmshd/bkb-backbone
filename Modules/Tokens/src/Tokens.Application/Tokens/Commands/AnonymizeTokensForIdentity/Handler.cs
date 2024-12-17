﻿using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Tokens.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Tokens.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace Backbone.Modules.Tokens.Application.Tokens.Commands.AnonymizeTokensForIdentity;

public class Handler : IRequestHandler<AnonymizeTokensForIdentityCommand>
{
    private readonly ITokensRepository _tokensRepository;
    private readonly ApplicationOptions _applicationOptions;

    public Handler(ITokensRepository tokensRepository, IOptions<ApplicationOptions> applicationOptions)
    {
        _tokensRepository = tokensRepository;
        _applicationOptions = applicationOptions.Value;
    }

    public async Task Handle(AnonymizeTokensForIdentityCommand request, CancellationToken cancellationToken)
    {
        var tokens = (await _tokensRepository.FindTokens(Token.IsFor(IdentityAddress.Parse(request.IdentityAddress)), cancellationToken)).ToList();

        foreach (var token in tokens)
            token.AnonymizeForIdentity(_applicationOptions.DidDomainName);

        await _tokensRepository.Update(tokens, cancellationToken);
    }
}
