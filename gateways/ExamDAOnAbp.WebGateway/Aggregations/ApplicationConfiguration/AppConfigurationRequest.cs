using System.Collections.Generic;
using ExamDAOnAbp.WebGateway.Aggregations.Base;

namespace ExamDAOnAbp.WebGateway.Aggregations.ApplicationConfiguration;

public class AppConfigurationRequest : IRequestInput
{
    public Dictionary<string, string> Endpoints { get; } = new();
}