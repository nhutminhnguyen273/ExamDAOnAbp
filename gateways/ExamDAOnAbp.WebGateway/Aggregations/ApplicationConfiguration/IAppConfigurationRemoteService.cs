using ExamDAOnAbp.WebGateway.Aggregations.Base;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;

namespace ExamDAOnAbp.WebGateway.Aggregations.ApplicationConfiguration;

public interface IAppConfigurationRemoteService : IAggregateRemoteService<ApplicationConfigurationDto>;