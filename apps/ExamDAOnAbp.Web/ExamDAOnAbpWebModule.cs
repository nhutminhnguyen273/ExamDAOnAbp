using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using ExamDAOnAbp.Shared.Hosting.AspNetCore;
using ExamDAOnAbp.Shared.Localization;
using ExamDAOnAbp.Shared.Localization.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Http.Client.IdentityModel.Web;
using ExamDAOnAbp.LearningOutcomeService;
using ExamDAOnAbp.CourseService;
using ExamDAOnAbp.QuestionBankService;
using ExamDAOnAbp.ExamService;
using Volo.Abp.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Security.Claims;
using System;
using Volo.Abp.Caching;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Http.Client;
using Volo.Abp.MultiTenancy;
using Yarp.ReverseProxy.Transforms;
using Polly;
using System.Net.Http.Headers;
using System.Linq;
using ExamDAOnAbp.Web.HealthChecks;
using Volo.Abp.UI.Navigation;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using ExamDAOnAbp.Web.Menus;

namespace ExamDAOnAbp.Web;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpAspNetCoreMvcClientModule),
    typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(ExamDAOnAbpSharedHostingAspNetCoreModule),
    typeof(ExamDAOnAbpSharedLocalizationModule),
    typeof(LearningOutcomeServiceHttpApiClientModule),
    typeof(CourseServiceHttpApiClientModule),
    typeof(QuestionBankServiceHttpApiClientModule),
    typeof(ExamServiceHttpApiClientModule),
    typeof(AbpAspNetCoreSignalRModule),
    typeof(AbpAutoMapperModule)
    )]
public class ExamDAOnAbpWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(ExamDAOnAbpResource),
                typeof(ExamDAOnAbpWebModule).Assembly
            );
        });

        PreConfigure<AbpHttpClientBuilderOptions>(options =>
        {
            options.ProxyClientBuildActions.Add((remoteServiceName, clientBuilder) =>
            {
                clientBuilder.AddTransientHttpErrorPolicy(policyBuilder =>
                    policyBuilder.WaitAndRetryAsync(
                        3,
                        i => TimeSpan.FromSeconds(Math.Pow(2, i))
                    )
                );
            });
        });

        //FeatureConfigurer.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
        var configuration = context.Services.GetConfiguration();

        context.Services.AddHttpForwarderWithServiceDiscovery();

        ConfigureBasketHttpClient(context);

        context.Services.AddAutoMapperObjectMapper<ExamDAOnAbpWebModule>();
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<ExamDAOnAbpWebModule>(validate: true); });

        //Configure<AbpLayoutHookOptions>(options =>
        //{
        //    options.Add(
        //        LayoutHooks.Body.Last,
        //        typeof(FooterComponent)
        //    );
        //});

        //Configure<AbpBundlingOptions>(options =>
        //{
        //    options.StyleBundles.Configure(
        //        LeptonXLiteThemeBundles.Styles.Global,
        //        bundle =>
        //        {
        //            bundle.AddContributors(typeof(CartWidgetStyleContributor));
        //            bundle.AddFiles("/global.css");
        //        }
        //    );
        //});

        context.Services.Configure<AbpRemoteServiceOptions>(options =>
        {
            options.RemoteServices.Default =
                new RemoteServiceConfiguration(configuration["RemoteServices:Default:BaseUrl"]);
        });

        Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = true; });

        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "ExamDAOnAbp:"; });

        Configure<AppUrlOptions>(options => { options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]; });

        //ConfigurePayment(configuration);

        context.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
        })
            .AddCookie("Cookies")
            .AddAbpOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.ClientId = configuration["AuthServer:ClientId"];
                options.MetadataAddress = configuration["AuthServer:MetaAddress"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("phone");
                options.Scope.Add("roles");
                options.Scope.Add("offline_access");

                options.Scope.Add("AdministrationService");
                options.Scope.Add("LearningOutcomeService");
                options.Scope.Add("IdentityService");
                options.Scope.Add("CourseService");
                options.Scope.Add("QuestionBankService");
                options.Scope.Add("ExamService");

                options.SaveTokens = true;

                //SameSite is needed for Chrome/Firefox, as they will give http error 500 back, if not set to unspecified.
                // options.NonceCookie.SameSite = SameSiteMode.Unspecified;
                // options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
                //
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = ClaimTypes.Role,
                    ValidateIssuer = true
                };

                options.Events.OnAuthorizationCodeReceived = async (authContext) =>
                {
                    var userLoggedInEto = CreateUserLoggedInEto(authContext.Principal, authContext.HttpContext);
                    if (userLoggedInEto != null)
                    {
                        var eventBus =
                            authContext.HttpContext.RequestServices.GetRequiredService<IDistributedEventBus>();
                        await eventBus.PublishAsync(userLoggedInEto);
                    }
                };

                if (AbpClaimTypes.UserName != "preferred_username")
                {
                    options.ClaimActions.MapJsonKey(AbpClaimTypes.UserName, "preferred_username");
                    options.ClaimActions.DeleteClaim("preferred_username");
                    options.ClaimActions.RemoveDuplicate(AbpClaimTypes.UserName);
                }
            });

        if (Convert.ToBoolean(configuration["AuthServer:IsOnProd"]))
        {
            context.Services.Configure<OpenIdConnectOptions>("oidc", options =>
            {
                options.MetadataAddress = configuration["AuthServer:MetaAddress"].EnsureEndsWith('/') +
                                          ".well-known/openid-configuration";

                var previousOnRedirectToIdentityProvider = options.Events.OnRedirectToIdentityProvider;
                options.Events.OnRedirectToIdentityProvider = async ctx =>
                {
                    // Intercept the redirection so the browser navigates to the right URL in your host
                    ctx.ProtocolMessage.IssuerAddress = configuration["AuthServer:Authority"].EnsureEndsWith('/') +
                                                        "protocol/openid-connect/auth";

                    if (previousOnRedirectToIdentityProvider != null)
                    {
                        await previousOnRedirectToIdentityProvider(ctx);
                    }
                };
                var previousOnRedirectToIdentityProviderForSignOut =
                    options.Events.OnRedirectToIdentityProviderForSignOut;
                options.Events.OnRedirectToIdentityProviderForSignOut = async ctx =>
                {
                    // Intercept the redirection for signout so the browser navigates to the right URL in your host
                    ctx.ProtocolMessage.IssuerAddress = configuration["AuthServer:Authority"].EnsureEndsWith('/') +
                                                        "protocol/openid-connect/logout";

                    if (previousOnRedirectToIdentityProviderForSignOut != null)
                    {
                        await previousOnRedirectToIdentityProviderForSignOut(ctx);
                    }
                };
            });
        }

        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        context.Services
            .AddDataProtection()
            .PersistKeysToStackExchangeRedis(redis, "ExamDAOnAbp-Protection-Keys")
            .SetApplicationName("ExamDAOnAbp-Web");

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ExamDAOnAbpMenuContributor(configuration));
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new ExamDAOnAbpToolbarContributor());
        });

        context.Services
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"))
            .AddTransforms(builderContext =>
            {
                builderContext.AddRequestTransform(async (transformContext) =>
                {
                    transformContext.ProxyRequest.Headers
                        .Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        await transformContext.HttpContext.GetTokenAsync("access_token")
                    );
                });
            });

        context.Services.AddExamDAOnAbpHealthChecks();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.Use((ctx, next) =>
        {
            ctx.Request.Scheme = "https";
            return next();
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAbpSerilogEnrichers();
        app.UseAuthorization();
        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy();
            endpoints.MapForwarder("*/product-images/{name}", "http://catalog:8080/product-images", "/{name}");
            endpoints.MapForwarder("/products/product-images/{name}", "http://catalog:8080/product-images", "/{name}");
        });
    }

    private void ConfigureBasketHttpClient(ServiceConfigurationContext context)
    {
        //context.Services.AddStaticHttpClientProxies(
        //    typeof(BasketServiceContractsModule).Assembly,
        //    remoteServiceConfigurationName: BasketServiceConstants.RemoteServiceName
        //);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ExamDAOnAbpWebModule>();
        });
    }

    //private void ConfigurePayment(IConfiguration configuration)
    //{
    //    Configure<ExamDAOnAbpPublicWebPaymentOptions>(options =>
    //    {
    //        options.PaymentSuccessfulCallbackUrl =
    //            configuration["App:SelfUrl"].EnsureEndsWith('/') + "PaymentCompleted";
    //    });

    //    Configure<PaymentMethodUiOptions>(options =>
    //    {
    //        options.ConfigureIcon(PaymentMethodNames.PayPal, "fa-cc-paypal paypal");
    //    });
    //}

    private UserLoggedInEto CreateUserLoggedInEto(ClaimsPrincipal principal, HttpContext httpContext)
    {
        var logger = httpContext.RequestServices.GetRequiredService<ILogger<ExamDAOnAbpWebModule>>();

        if (principal == null)
        {
            logger.LogWarning($"AuthorizationCode does not contain principal to create/update user!");
            return null;
        }

        var claims = principal.Claims.ToList();

        var userNameClaim = claims.FirstOrDefault(x => x.Type == "preferred_username");
        var emailClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
        var isEmailVerified = claims.FirstOrDefault(x => x.Type == "email_verified")?.Value == "true";
        var phoneNumberClaim = claims.FirstOrDefault(x => x.Type == "phone");
        var userIdString = claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;

        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            logger.LogWarning(
                $"Handling UserLoggedInEvent... User creation failed! {userIdString} can not be parsed!");
            return null;
        }

        return new UserLoggedInEto
        {
            Id = userId,
            Email = emailClaim?.Value,
            UserName = userNameClaim?.Value,
            Phone = phoneNumberClaim?.Value,
            IsEmailVerified = isEmailVerified
        };
    }
}
