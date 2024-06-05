#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=8.0-jammy
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src

# Create this "restore-solution" section by running ./Create-DockerfileSolutionRestore.ps1, to optimize build cache reuse
COPY ["src/BuildingBlocks/EventBus/EventBus.csproj", "src/BuildingBlocks/EventBus/"]
COPY ["src/BuildingBlocks/Healthchecks/Healthchecks.csproj", "src/BuildingBlocks/Healthchecks/"]
COPY ["src/Services/FakeOracleFetchApi/FakeOracleFetchApi.csproj", "src/Services/FakeOracleFetchApi/"]
COPY ["src/Web/Webstatus/Webstatus.csproj", "src/Web/Webstatus/"]

# Inrelevante Containers
COPY ["src/Services/EmailApi/src/Web/Web.csproj", "src/Services/EmailApi/src/Web/"]
COPY ["src/Services/OracleFetchApi/OracleFetchApi.csproj", "src/Services/OracleFetchApi/"]
COPY ["src/Services/EmailApi/src/Infrastructure/Infrastructure.csproj", "src/Services/EmailApi/src/Infrastructure/"]
COPY ["src/Services/EmailApi/src/Domain/Domain.csproj", "src/Services/EmailApi/src/Domain/"]
COPY ["src/Services/EmailApi/src/Application/Application.csproj", "src/Services/EmailApi/src/Application/"]

COPY ["NuGet.config", "./"]
COPY ["EmailProcessorSystem.sln", "./"]
RUN dotnet restore "EmailProcessorSystem.sln"

COPY . .
WORKDIR "/src/src/Services/EmailApi/src/Web"
# RUN dotnet build "EmailApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore "EmailApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailApi.dll"]
