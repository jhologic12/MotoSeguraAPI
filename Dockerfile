# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

# Copiar csproj y restaurar
COPY *.sln .
COPY MotoSeguraAPI/*.csproj ./MotoSeguraAPI/
RUN dotnet restore

# Copiar todo y publicar
COPY . .
WORKDIR /src/MotoSeguraAPI
RUN dotnet publish -c Release -o /app --no-restore

# Etapa runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app ./

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "MotoSeguraAPI.dll"]
