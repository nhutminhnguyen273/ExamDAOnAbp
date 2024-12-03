using ExamDAOnAbp.ExamService.EntityFrameworkCore;
using ExamDAOnAbp.Shared.Hosting.Microservices.DbMigrations.EfCore;
using System;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace ExamDAOnAbp.ExamService.DbMigrations;

public class ExamServiceDatabaseMigrationChecker
    : PendingEfCoreMigrationsChecker<ExamServiceDbContext>
{
    public ExamServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            ExamServiceDbProperties.ConnectionStringName)
    {
    }
}
