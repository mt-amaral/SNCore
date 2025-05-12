# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8090
EXPOSE 8091


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Admin.App/Admin.App/Admin.App.csproj", "Admin.App/Admin.App/"]
COPY ["Admin.Domain/Admin.Domain.csproj", "Admin.Domain/"]
COPY ["Admin.Shared/Admin.Shared.csproj", "Admin.Shared/"]
COPY ["Admin.Infrustructure/Admin.Infrustructure.csproj", "Admin.Infrustructure/"]
COPY ["Admin.Application/Admin.Application.csproj", "Admin.Application/"]
COPY ["Admin.Connection/Admin.Connection.csproj", "Admin.Connection/"]
COPY ["Admin.Persistence/Admin.Persistence.csproj", "Admin.Persistence/"]
COPY ["Admin.App/Admin.App.Client/Admin.App.Client.csproj", "Admin.App/Admin.App.Client/"]
RUN dotnet restore "./Admin.App/Admin.App/Admin.App.csproj"
COPY . .
WORKDIR "/src/Admin.App/Admin.App"
RUN dotnet build "./Admin.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Admin.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS app
WORKDIR /app
COPY --from=publish /app/publish .
COPY Admin.App/Admin.App/https/localhost.pfx .
ENTRYPOINT ["dotnet", "Admin.App.dll"]