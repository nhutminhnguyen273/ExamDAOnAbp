﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamDAOnAbp.IdentityService.Keycloak.Service;
using Keycloak.Net;
using Keycloak.Net.Models.Clients;
using Keycloak.Net.Models.ClientScopes;
using Keycloak.Net.Models.ProtocolMappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace ExamDAOnAbp.IdentityService.DbMigrations;

public class KeyCloakDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly KeycloakClient _keycloakClient;
    private readonly KeycloakClientOptions _keycloakOptions;
    private readonly ILogger<KeyCloakDataSeeder> _logger;
    private readonly IConfiguration _configuration;

    public KeyCloakDataSeeder(IOptions<KeycloakClientOptions> keycloakClientOptions, ILogger<KeyCloakDataSeeder> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _keycloakOptions = keycloakClientOptions.Value;

        _keycloakClient = new KeycloakClient(
            _keycloakOptions.Url,
            _keycloakOptions.AdminUserName,
            _keycloakOptions.AdminPassword
        );
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        //await UpdateRealmSettingsAsync();
        //await UpdateAdminUserAsync();
        //await CreateRoleMapperAsync();
        //await CreateClientScopesAsync();
        //await CreateClientsAsync();
    }

    //private async Task UpdateRealmSettingsAsync()
    //{
    //    var masterRealm = await _keycloakClient.GetRealmAsync(_keycloakOptions.RealmName);
    //    if (masterRealm.AccessTokenLifespan != 30 * 60)
    //    {
    //        masterRealm.AccessTokenLifespan = 30 * 60;
    //        await _keycloakClient.UpdateRealmAsync(_keycloakOptions.RealmName, masterRealm);
    //    }
    //}

    //private async Task CreateRoleMapperAsync()
    //{
    //    var roleScope = (await _keycloakClient.GetClientScopesAsync(_keycloakOptions.RealmName))
    //        .FirstOrDefault(q => q.Name == "roles");
    //    if (roleScope == null)
    //        return;

    //    if (!roleScope.ProtocolMappers.Any(q => q.Name == "roles"))
    //    {
    //        await _keycloakClient.CreateProtocolMapperAsync(_keycloakOptions.RealmName, roleScope.Id,
    //            new ProtocolMapper()
    //            {
    //                Name = "roles",
    //                Protocol = "openid-connect",
    //                _ProtocolMapper = "oidc-usermodel-realm-role-mapper",
    //                Config = new Dictionary<string, string>()
    //                {
    //                    { "access.token.claim", "true" },
    //                    { "id.token.claim", "true" },
    //                    { "claim.name", "role" },
    //                    { "multivalued", "true" },
    //                    { "userinfo.token.claim", "true" },
    //                }
    //            });
    //    }
    //}

    //private async Task CreateClientScopesAsync()
    //{
    //    await CreateScopeAsync("AdministrationService");
    //    await CreateScopeAsync("IdentityService");
    //    await CreateScopeAsync("LearningOutcomeService");
    //    await CreateScopeAsync("CourseService");
    //    await CreateScopeAsync("QuestionBankService");
    //    await CreateScopeAsync("ExamService");
    //}

    //private async Task CreateScopeAsync(string scopeName)
    //{
    //    var scope = (await _keycloakClient.GetClientScopesAsync(_keycloakOptions.RealmName))
    //        .FirstOrDefault(q => q.Name == scopeName);

    //    if (scope == null)
    //    {
    //        scope = new ClientScope
    //        {
    //            Name = scopeName,
    //            Description = scopeName + " scope",
    //            Protocol = "openid-connect",
    //            Attributes = new Attributes
    //            {
    //                ConsentScreenText = scopeName,
    //                DisplayOnConsentScreen = "true",
    //                IncludeInTokenScope = "true"
    //            },
    //            ProtocolMappers = new List<ProtocolMapper>()
    //            {
    //                new ProtocolMapper()
    //                {
    //                    Name = scopeName,
    //                    Protocol = "openid-connect",
    //                    _ProtocolMapper = "oidc-audience-mapper",
    //                    Config =
    //                        new
    //                            Dictionary<string, string>
    //                            {
    //                                { "id.token.claim", "false" },
    //                                { "access.token.claim", "true" },
    //                                { "included.custom.audience", scopeName }
    //                            }
    //                }
    //            }
    //        };

    //        await _keycloakClient.CreateClientScopeAsync(_keycloakOptions.RealmName, scope);
    //    }
    //}

    //private async Task CreateClientsAsync()
    //{
    //    await CreatePublicWebClientAsync();
    //    await CreateSwaggerClientAsync();
    //    await CreateWebClientAsync();
    //}

    //private async Task CreateAdministrationClientAsync()
    //{
    //    var administrationClient =
    //        (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName,
    //            clientId: "ExamDAOnAbp_AdministrationService"))
    //        .FirstOrDefault();

    //    if (administrationClient == null)
    //    {
    //        administrationClient = new Client()
    //        {
    //            ClientId = "ExamDAOnAbp_AdministrationService",
    //            Name = "Administration service client",
    //            Protocol = "openid-connect",
    //            PublicClient = false,
    //            ImplicitFlowEnabled = false,
    //            AuthorizationServicesEnabled = false,
    //            StandardFlowEnabled = false,
    //            DirectAccessGrantsEnabled = false,
    //            ServiceAccountsEnabled = true,
    //            Secret = "1q2w3e*"
    //        };

    //        administrationClient.Attributes = new Dictionary<string, object>()
    //        {
    //            { "oauth2.device.authorization.grant.enabled", false },
    //            { "oidc.ciba.grant.enabled", false }
    //        };

    //        await _keycloakClient.CreateClientAsync(_keycloakOptions.RealmName, administrationClient);

    //        await AddOptionalClientScopesAsync(
    //            "ExamDAOnAbp_AdministrationService",
    //            new List<string>
    //            {
    //                "IdentityService"
    //            }
    //        );

    //        var insertedClient =
    //            (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName, clientId: "ExamDAOnAbp_AdministrationService"))
    //            .First();

    //        var clientIdProtocolMapper = insertedClient.ProtocolMappers.First(q => q.Name == "Client ID");

    //        clientIdProtocolMapper.Config["claim.name"] = "client_id";

    //        var result = await _keycloakClient.UpdateClientAsync(_keycloakOptions.RealmName, insertedClient.Id,
    //            insertedClient);
    //    }
    //}

    //private async Task CreateWebClientAsync()
    //{
    //    var webClient = (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName, clientId: "Web"))
    //        .FirstOrDefault();

    //    if (webClient == null)
    //    {
    //        var webRootUrl = _configuration[$"Clients:Web:RootUrl"];
    //        webClient = new Client
    //        {
    //            ClientId = "Web",
    //            Name = "Angular Back-Office Web Application",
    //            Protocol = "openid-connect",
    //            Enabled = true,
    //            BaseUrl = webRootUrl,
    //            RedirectUris = new List<string>
    //            {
    //                $"{webRootUrl.TrimEnd('/')}"
    //            },
    //            FrontChannelLogout = true,
    //            PublicClient = true
    //        };
    //        webClient.Attributes = new Dictionary<string, object>
    //        {
    //            { "post.logout.redirect.uris", $"{webRootUrl.TrimEnd('/')}" }
    //        };

    //        await _keycloakClient.CreateClientAsync(_keycloakOptions.RealmName, webClient);

    //        await AddOptionalClientScopesAsync(
    //            "Web",
    //            new List<string>
    //            {
    //                "AdministrationService", "IdentityService",
    //                "LearningOutcomeService", "CourseService",
    //                "QuestionBankService", "ExamService"
    //            }
    //        );
    //    }
    //}

    //private async Task CreateSwaggerClientAsync()
    //{
    //    var swaggerClient =
    //        (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName, clientId: "SwaggerClient"))
    //        .FirstOrDefault();

    //    if (swaggerClient == null)
    //    {
    //        var webGatewaySwaggerRootUrl = _configuration[$"Clients:WebGateway:RootUrl"].TrimEnd('/');
    //        var publicWebGatewayRootUrl = _configuration[$"Clients:PublicWebGateway:RootUrl"].TrimEnd('/');
    //        var accountServiceRootUrl = _configuration[$"Clients:AccountService:RootUrl"].TrimEnd('/');
    //        var identityServiceRootUrl = _configuration[$"Clients:IdentityService:RootUrl"].TrimEnd('/');
    //        var administrationServiceRootUrl = _configuration[$"Clients:AdministrationService:RootUrl"].TrimEnd('/');
    //        var learningOutcomeServiceRootUrl = _configuration[$"Clients:LearningOutcomeService:RootUrl"].TrimEnd('/');
    //        var courseServiceRootUrl = _configuration[$"Clients:CourseService:RootUrl"].TrimEnd('/');
    //        var questionBankServiceRootUrl = _configuration[$"Clients:QuestionBankService:RootUrl"].TrimEnd('/');
    //        var examServiceRootUrl = _configuration[$"Clients:ExamService:RootUrl"].TrimEnd('/');

    //        swaggerClient = new Client
    //        {
    //            ClientId = "SwaggerClient",
    //            Name = "Swagger Client Application",
    //            Protocol = "openid-connect",
    //            Enabled = true,
    //            RedirectUris = new List<string>
    //            {
    //                $"{webGatewaySwaggerRootUrl}/swagger/oauth2-redirect.html",
    //                $"{publicWebGatewayRootUrl}/swagger/oauth2-redirect.html",
    //                $"{accountServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{identityServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{administrationServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{learningOutcomeServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{courseServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{questionBankServiceRootUrl}/swagger/oauth2-redirect.html",
    //                $"{examServiceRootUrl}/swagger/oauth2-redirect.html",
    //            },
    //            FrontChannelLogout = true,
    //            PublicClient = true
    //        };

    //        await _keycloakClient.CreateClientAsync(_keycloakOptions.RealmName, swaggerClient);

    //        await AddOptionalClientScopesAsync(
    //            "SwaggerClient",
    //            new List<string>
    //            {
    //                "AdministrationService", "IdentityService",
    //                "LearningOutcomeService", "CourseService",
    //                "QuestionBankService", "ExamService"
    //            }
    //        );
    //    }
    //}

    //private async Task CreatePublicWebClientAsync()
    //{
    //    var publicWebClient = (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName, clientId: "PublicWeb"))
    //        .FirstOrDefault();

    //    if (publicWebClient == null)
    //    {
    //        var publicWebRootUrl = _configuration[$"Clients:PublicWeb:RootUrl"];
    //        publicWebClient = new Client
    //        {
    //            ClientId = "PublicWeb",
    //            Name = "Public Web Application",
    //            Protocol = "openid-connect",
    //            Enabled = true,
    //            BaseUrl = publicWebRootUrl,
    //            RedirectUris = new List<string>
    //            {
    //                $"{publicWebRootUrl.TrimEnd('/')}/signin-oidc"
    //            },
    //            FrontChannelLogout = true,
    //            PublicClient = true,
    //            ImplicitFlowEnabled = true // for hybrid flow
    //        };
    //        publicWebClient.Attributes = new Dictionary<string, object>
    //        {
    //            { "post.logout.redirect.uris", $"{publicWebRootUrl.TrimEnd('/')}/signout-callback-oidc" }
    //        };

    //        await _keycloakClient.CreateClientAsync(_keycloakOptions.RealmName, publicWebClient);

    //        await AddOptionalClientScopesAsync(
    //            "PublicWeb",
    //            new List<string>
    //            {
    //                "AdministrationService", "IdentityService",
    //                "LearningOutcomeService", "CourseService",
    //                "QuestionBankService", "ExamService"
    //            }
    //        );
    //    }
    //}

    //private async Task AddOptionalClientScopesAsync(string clientName, List<string> scopes)
    //{
    //    var client = (await _keycloakClient.GetClientsAsync(_keycloakOptions.RealmName, clientId: clientName))
    //        .FirstOrDefault();
    //    if (client == null)
    //    {
    //        _logger.LogError($"Couldn't find {clientName}! Could not seed optional scopes!");
    //        return;
    //    }

    //    var clientOptionalScopes =
    //        (await _keycloakClient.GetOptionalClientScopesAsync(_keycloakOptions.RealmName, client.Id)).ToList();

    //    var clientScopes = (await _keycloakClient.GetClientScopesAsync(_keycloakOptions.RealmName)).ToList();

    //    foreach (var scope in scopes)
    //    {
    //        if (!clientOptionalScopes.Any(q => q.Name == scope))
    //        {
    //            var serviceScope = clientScopes.First(q => q.Name == scope);
    //            _logger.LogInformation($"Seeding {scope} scope to {clientName}.");
    //            await _keycloakClient.UpdateOptionalClientScopeAsync(_keycloakOptions.RealmName, client.Id,
    //                serviceScope.Id);
    //        }
    //    }
    //}

    //private async Task UpdateAdminUserAsync()
    //{
    //    var users = await _keycloakClient.GetUsersAsync(_keycloakOptions.RealmName, username: "admin");
    //    var adminUser = users.FirstOrDefault();
    //    if (adminUser == null)
    //    {
    //        throw new Exception(
    //            "Keycloak admin user is not provided, check if KEYCLOAK_ADMIN environment variable is passed properly.");
    //    }

    //    if (string.IsNullOrEmpty(adminUser.Email))
    //    {
    //        adminUser.Email = "admin@abp.io";
    //        adminUser.FirstName = "admin";
    //        adminUser.EmailVerified = true;

    //        _logger.LogInformation("Updating admin user with email and first name...");
    //        await _keycloakClient.UpdateUserAsync(_keycloakOptions.RealmName, adminUser.Id, adminUser);
    //    }
    //}
}