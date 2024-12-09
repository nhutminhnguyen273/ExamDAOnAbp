using ExamDAOnAbp.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var profile = "http";

// Microservices
//var administrationService = builder.AddProject<Projects.ExamDAOnAbp_AdministrationService_HttpApi_Host>("administrationService", profile);
//var identityService = builder.AddProject<Projects.ExamDAOnAbp_IdentityService_HttpApi_Host>("identityService", profile);
//var learningOutcomeService = builder.AddProject<Projects.ExamDAOnAbp_LearningOutcomeService_HttpApi_Host>("learningOutcomeService", (string?)null)
//    .WithHttpEndpoint(name: "http", port: 5004, isProxied: false)
//    .WithEndpoint();
//var courseService = builder.AddProject<Projects.ExamDAOnAbp_CourseService_HttpApi_Host>("courseService", (string?)null)
//    .WithHttpEndpoint(name: "http", port: 5005, isProxied: false)
//    .WithEndpoint();
//var questionBankService = builder.AddProject<Projects.ExamDAOnAbp_QuestionBankService_HttpApi_Host>("questionBankService", (string?)null)
//    .WithHttpEndpoint(name: "http", port: 5006, isProxied: false)
//    .WithEndpoint();
//var examService = builder.AddProject<Projects.ExamDAOnAbp_ExamService_HttpApi_Host>("examService", (string?)null)
//    .WithHttpEndpoint(name: "http", port: 5007, isProxied: false)
//    .WithEndpoint();

//// Gateway
//var webGateway = builder.AddProject<Projects.ExamDAOnAbp_WebGateway>("webGateway")
//    .WithReference(administrationService)
//    .WithReference(identityService)
//    .WithReference(learningOutcomeService)
//    .WithReference(courseService)
//    .WithReference(questionBankService)
//    .WithReference(examService);

//var web = builder.AddProject<Projects.ExamDAOnAbp_Web>("web")
//    .WithExternalHttpEndpoints()
//    .WithReference(learningOutcomeService)
//    .WithReference(courseService)
//    .WithReference(questionBankService)
//    .WithReference(examService)
//    .WithReference(webGateway);

builder.Build().Run();
