using ExamDAOnAbp.WebGateway.Aggregations.Base;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;

namespace ExamDAOnAbp.WebGateway.Aggregations.Localization;

public interface ILocalizationRemoteService : IAggregateRemoteService<ApplicationLocalizationDto>;