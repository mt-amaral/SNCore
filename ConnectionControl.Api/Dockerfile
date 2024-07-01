#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Admin.Domain/Admin.Domain.csproj", "Admin.Domain/"]
COPY ["Admin.Persistence/Admin.Persistence.csproj", "Admin.Persistence/"]
COPY ["ConnectionControl.Infrustructure/ConnectionControl.Infrustructure.csproj", "ConnectionControl.Infrustructure/"]
COPY ["ConnectionControl.Application/ConnectionControl.Application.csproj", "ConnectionControl.Application/"]
COPY ["ConnectionsControl.ConnectionLibrary/ConnectionsControl.ConnectionLibrary.csproj", "ConnectionsControl.ConnectionLibrary/"]
COPY ["ConnectionControl.Api/ConnectionControl.Api.csproj", "ConnectionControl.Api/"]
RUN dotnet restore "./ConnectionControl.Api/ConnectionControl.Api.csproj"
COPY . .
WORKDIR "/src/ConnectionControl.Api"
RUN dotnet build "./ConnectionControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConnectionControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS api_connection
WORKDIR /app
COPY --from=publish /app/publish .
COPY Admin.Api/https/. .
ENTRYPOINT ["dotnet", "ConnectionControl.Api.dll"]