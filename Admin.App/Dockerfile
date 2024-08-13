FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Expose the port
EXPOSE 8091

# Copy project files and restore as distinct layers
COPY ["Admin.App/Admin.App.csproj", "Admin.App/"]
COPY ["Admin.Shared/Admin.Shared.csproj", "Admin.Shared/"]
COPY ["Admin.Validator/Admin.Validator.csproj", "Admin.Validator/"]
RUN dotnet restore "Admin.App/Admin.App.csproj"

# Copy the rest of the files and build
COPY . .
WORKDIR /src/Admin.App
RUN dotnet build "Admin.App.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "Admin.App.csproj" -c Release -o /app/publish

# Final image with NGINX
FROM nginx:alpine AS app
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Admin.App/nginx.conf /etc/nginx/nginx.conf
