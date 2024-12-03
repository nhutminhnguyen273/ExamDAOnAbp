using ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore;
using ExamDAOnAbp.Shared.Hosting.Microservices.DbMigrations.EfCore;
using System;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace ExamDAOnAbp.LearningOutcomeService.DbMigrations;

public class LearningOutcomeServiceDatabaseMigrationChecker
    : PendingEfCoreMigrationsChecker<LearningOutcomeServiceDbContext>
{
    public LearningOutcomeServiceDatabaseMigrationChecker(
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
            LearningOutcomeServiceDbProperties.ConnectionStringName)
    {
    }
}