FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "ExamDAOnAbp.sln" "ExamDAOnAbp.sln"

# Applications
COPY "apps/ExamDAOnAbp.Web/ExamDAOnAbp.Web.csproj" "apps/ExamDAOnAbp.Web/ExamDAOnAbp.Web.csproj"

# Shared
COPY "shared/ExamDAOnAbp.Shared.Hosting/ExamDAOnAbp.Shared.Hosting.csproj" "shared/ExamDAOnAbp.Shared.Hosting/ExamDAOnAbp.Shared.Hosting.csproj"
COPY "shared/ExamDAOnAbp.Shared.Hosting.AspNetCore/ExamDAOnAbp.Shared.Hosting.AspNetCore.csproj" "shared/ExamDAOnAbp.Shared.Hosting.AspNetCore/ExamDAOnAbp.Shared.Hosting.AspNetCore.csproj"
COPY "shared/ExamDAOnAbp.Shared.Hosting.Gateways/ExamDAOnAbp.Shared.Hosting.Gateways.csproj" "shared/ExamDAOnAbp.Shared.Hosting.Gateways/ExamDAOnAbp.Shared.Hosting.Gateways.csproj"
COPY "shared/ExamDAOnAbp.Shared.Hosting.Microservices/ExamDAOnAbp.Shared.Hosting.Microservices.csproj" "shared/ExamDAOnAbp.Shared.Hosting.Microservices/ExamDAOnAbp.Shared.Hosting.Microservices.csproj"
COPY "shared/ExamDAOnAbp.Shared.Localization/ExamDAOnAbp.Shared.Localization.csproj" "shared/ExamDAOnAbp.Shared.Localization/ExamDAOnAbp.Shared.Localization.csproj"

# Microservices
COPY "services/Administration/src/ExamDAOnAbp.AdministrationService.HttpApi.Host/ExamDAOnAbp.AdministrationService.HttpApi.Host.csproj" "services/Administration/src/ExamDAOnAbp.AdministrationService.HttpApi.Host/ExamDAOnAbp.AdministrationService.HttpApi.Host.csproj"
COPY "services/Identity/src/ExamDAOnAbp.IdentityService.HttpApi.Host/ExamDAOnAbp.IdentityService.HttpApi.Host.csproj" "services/Identity/src/ExamDAOnAbp.IdentityService.HttpApi.Host/ExamDAOnAbp.IdentityService.HttpApi.Host.csproj"
COPY "services/LearningOutcome/ExamDAOnAbp.LearningOutcomeService.HttpApi.Host/ExamDAOnAbp.LearningOutcomeService.HttpApi.Host.csproj" "services/LearningOutcome/ExamDAOnAbp.LearningOutcomeService.HttpApi.Host/ExamDAOnAbp.LearningOutcomeService.HttpApi.Host.csproj"
COPY "services/Course/ExamDAOnAbp.CourseService.HttpApi.HostApi.Host/ExamDAOnAbp.CourseService.HttpApi.Host.csproj" "services/Course/ExamDAOnAbp.CourseService.HttpApi.HostApi.Host/ExamDAOnAbp.CourseService.HttpApi.Host.csproj"
COPY "services/QuestionBank/ExamDAOnAbp.QuestionBankService.HttpApi.Host/ExamDAOnAbp.CourseService.HttpApi.Host.csproj" "services/QuestionBank/ExamDAOnAbp.QuestionBankService.HttpApi.Host/ExamDAOnAbp.CourseService.HttpApi.Host.csproj"
COPY "services/Exam/ExamDAOnAbp.ExamService.HttpApi.Host/ExamDAOnAbp.ExamService.HttpApi.Host.csproj" "services/Exam/ExamDAOnAbp.ExamService.HttpApi.Host/ExamDAOnAbp.ExamService.HttpApi.Host.csproj"

# Gateways
COPY "gateways/ExamDAOnAbp.WebGateway/ExamDAOnAbp.WebGateway.csproj" "gateways/ExamDAOnAbp.WebGateway/ExamDAOnAbp.WebGateway.csproj"
COPY "gateways/ExamDAOnAbp.WebPublicGateway/ExamDAOnAbp.WebPublicGateway.csproj" "gateways/ExamDAOnAbp.WebPublicGateway/ExamDAOnAbp.WebPublicGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "ExamDAOnAbp.sln"
COPY . .

WORKDIR "/services/Administration/src/ExamDAOnAbp.AdministrationService.HttpApi.Host"
RUN dotnet publish -c Release -o /app 
# RUN dotnet publish --no-restore -c Release -o /app 

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExamDAOnAbp.AdministrationService.HttpApi.Host.dll"]