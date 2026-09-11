FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY TechOpsManagementSystem.sln ./
COPY TechOps.Api/TechOps.Api.csproj TechOps.Api/
RUN dotnet restore TechOps.Api/TechOps.Api.csproj

COPY TechOps.Api/ TechOps.Api/
WORKDIR /src/TechOps.Api
RUN dotnet publish TechOps.Api.csproj -c Release -o /app/publish -p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TechOps.Api.dll"]
