# =============================
# Build Stage
# =============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución y proyectos
COPY MotoSeguraAPI.sln ./
COPY *.csproj ./

# Restaurar dependencias
RUN dotnet restore MotoSeguraAPI.sln

# Copiar todo el código fuente
COPY . .

# Publicar
RUN dotnet publish MotoSeguraAPI.sln -c Release -o /app/publish --no-restore

# =============================
# Runtime Stage
# =============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "MotoSeguraAPI.dll"]
