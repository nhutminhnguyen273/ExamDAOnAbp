﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ExamDAOnAbp.Shared.Hosting.Gateways;

public static class GatewayHostBuilderExtension
{
    public const string AppYarpJsonPath = "yarp.json";

    public static IHostBuilder AddYarpJson(
        this IHostBuilder hostBuilder,
        bool optional = true,
        bool reloadOnChange = true,
        string path = AppYarpJsonPath)
    {
        return hostBuilder.ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddJsonFile(
                    path: AppYarpJsonPath,
                    optional: optional,
                    reloadOnChange: reloadOnChange
                )
                .AddEnvironmentVariables();
        });
    }
}