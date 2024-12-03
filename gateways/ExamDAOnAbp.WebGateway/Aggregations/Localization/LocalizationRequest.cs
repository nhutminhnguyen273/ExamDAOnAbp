using System.Collections.Generic;
using ExamDAOnAbp.WebGateway.Aggregations.Base;

namespace ExamDAOnAbp.WebGateway.Aggregations.Localization;

public class LocalizationRequest : IRequestInput
{
    public Dictionary<string, string> Endpoints { get; } = new();
    public string CultureName { get; set; }

    public LocalizationRequest(string cultureName)
    {
        CultureName = cultureName;
    }
}