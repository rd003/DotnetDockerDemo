FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DotnetDockerDemo.Api/*.csproj ./DotnetDockerDemo.Api/
RUN dotnet restore

# copy everything else and build app
COPY DotnetDockerDemo.Api/. ./DotnetDockerDemo.Api/
WORKDIR /source/DotnetDockerDemo.Api
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "DotnetDockerDemo.Api.dll"]
