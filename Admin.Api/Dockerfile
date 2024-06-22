#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Admin.Api/Admin.Api.csproj", "Admin.Api/"]
COPY ["Admin.Domain/Admin.Domain.csproj", "Admin.Domain/"]
COPY ["Admin.Application/Admin.Application.csproj", "Admin.Application/"]
COPY ["Admin.Persistence/Admin.Persistence.csproj", "Admin.Persistence/"]
COPY ["Admin.Infrustructure/Admin.Infrustructure.csproj", "Admin.Infrustructure/"]

RUN dotnet restore "./Admin.Api/Admin.Api.csproj"
COPY . .
WORKDIR "/src/Admin.Api"
RUN dotnet build "./Admin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Admin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Api
FROM base AS api
WORKDIR /app
COPY --from=publish /app/publish .
COPY Admin.Api/https/. .
ENTRYPOINT ["dotnet", "Admin.Api.dll"]
