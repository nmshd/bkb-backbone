﻿using Backbone.Modules.Devices.Application.Infrastructure.Persistence.Repository;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications;
using Backbone.Modules.Devices.Infrastructure.Persistence.Database;
using Enmeshed.BuildingBlocks.Infrastructure.Exceptions;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Backbone.Modules.Devices.Infrastructure.Persistence.Repository;

public class PnsRegistrationRepository : IPnsRegistrationRepository
{
    private readonly DbSet<PnsRegistration> _registrations;
    private readonly IQueryable<PnsRegistration> _readonlyRegistrations;
    private readonly DevicesDbContext _dbContext;

    public PnsRegistrationRepository(DevicesDbContext dbContext)
    {
        _registrations = dbContext.PnsRegistrations;
        _readonlyRegistrations = dbContext.PnsRegistrations.AsNoTracking();
        _dbContext = dbContext;
    }

    public async Task Add(PnsRegistration registration, CancellationToken cancellationToken)
    {
        try
        {
            await _registrations.AddAsync(registration, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException exception)
        {
            if (exception.GetBaseException() is SqlException { Number: 2627 }) // violation in unique key index
                throw new InfrastructureException(InfrastructureErrors.ConcurrentDeviceRegistrationCreationViolatesPrimaryKeyConstraint(registration.DeviceId));
        }
    }

    public async Task<IEnumerable<PnsRegistration>> FindWithAddress(IdentityAddress address, CancellationToken cancellationToken, bool track = false)
    {
        return await (track ? _registrations : _readonlyRegistrations)
            .Where(registration => registration.IdentityAddress == address).ToListAsync(cancellationToken);
    }

    public async Task<PnsRegistration> FindByDeviceId(DeviceId deviceId, CancellationToken cancellationToken, bool track = false)
    {
        return await (track ? _registrations : _readonlyRegistrations)
            .FirstOrDefaultAsync(registration => registration.DeviceId == deviceId, cancellationToken);
    }

    public async Task Update(PnsRegistration registration, CancellationToken cancellationToken)
    {
        _registrations.Update(registration);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
