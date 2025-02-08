# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["myfinance-web-dotnet/myfinance-web-dotnet.csproj", "myfinance-web-dotnet/"]
COPY ["myfinance-web-dotnet-service/myfinance-web-dotnet-service.csproj", "myfinance-web-dotnet-service/"]
COPY ["myfinance-web-dotnet-domain/myfinance-web-dotnet-domain.csproj", "myfinance-web-dotnet-domain/"]
COPY ["myfinance-web-dotnet-infra/myfinance-web-dotnet-infra.csproj", "myfinance-web-dotnet-infra/"]
RUN dotnet restore "./myfinance-web-dotnet/myfinance-web-dotnet.csproj"
COPY . .
WORKDIR "/src/myfinance-web-dotnet"
RUN dotnet build "./myfinance-web-dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./myfinance-web-dotnet.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "myfinance-web-dotnet.dll"]