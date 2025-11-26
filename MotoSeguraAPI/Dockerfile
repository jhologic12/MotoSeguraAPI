# -------------------------
# 1) Build stage (SDK, no-alpine)
# -------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar primero para cachear dependencias
COPY *.sln ./
COPY */*.csproj ./
RUN dotnet restore

# Copiar el resto y publicar
COPY . .
RUN dotnet publish -c Release -o /app/publish \
    /p:PublishTrimmed=true \
    /p:PublishReadyToRun=true \
    /p:InvariantGlobalization=true

# -------------------------
# 2) Runtime stage (Alpine)
# -------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app

# Crear usuario no-root por seguridad
RUN addgroup -S appgroup && adduser -S appuser -G appgroup
# Copiar artefactos del build
COPY --from=build /app/publish ./

# Exponer puerto (documental; el binding real lo hace docker/run)
EXPOSE 8080

# Variables recomendadas para producción
ENV DOTNET_URLS=http://0.0.0.0:8080 \
    ASPNETCORE_ENVIRONMENT=Production \
    TZ=UTC

# Cambiar propietario y ejecutar como no-root
RUN chown -R appuser:appgroup /app
USER appuser

# Healthcheck simple (opcional)
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
  CMD wget --spider --quiet http://127.0.0.1:8080/ || exit 1

ENTRYPOINT ["dotnet", "MotoSeguraAPI.dll"]
