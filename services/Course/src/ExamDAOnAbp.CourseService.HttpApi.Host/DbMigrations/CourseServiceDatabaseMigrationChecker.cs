using ExamDAOnAbp.CourseService.EntityFrameworkCore;
using ExamDAOnAbp.LearningOutcomeService;
using ExamDAOnAbp.Shared.Hosting.Microservices.DbMigrations.EfCore;
using System;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace ExamDAOnAbp.CourseService.DbMigrations;

public class CourseServiceDatabaseMigrationChecker
    : PendingEfCoreMigrationsChecker<CourseServiceDbContext>
{
    public CourseServiceDatabaseMigrationChecker(
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
            CourseServiceDbProperties.ConnectionStringName)
    {
    }
}