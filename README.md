# MotoSegura

## 🇪🇸 Descripción

**MotoSegura** es una API modular en ASP.NET Core para validar cascos de motocicleta en tiempo real. Incluye pruebas automatizadas con xUnit, validación con FluentValidation y cobertura de código con Coverlet y SonarCloud. Está diseñada para escalar hacia simuladores, trazabilidad y análisis de seguridad vial.

## 🇬🇧 Description

**MotoSegura** is a modular ASP.NET Core API that validates motorcycle helmets in real time. It includes automated testing with xUnit, validation via FluentValidation, and code coverage using Coverlet and SonarCloud. Designed to scale toward simulators, traceability, and road safety analysis.

---

## 🚀 Instalación / Installation

```bash
git clone https://github.com/jaofdev/MotoSegura.git
cd MotoSegura
dotnet restore MotoSegura.sln

Pruebas / Testing
dotnet test MotoSegura.sln



 Cobertura y análisis / Coverage & Analysis
dotnet sonarscanner begin /k:"jhologic12_MotoSeguraAPI" /o:"jaofdev" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="TU_TOKEN"

dotnet test MotoSegura.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=MotoSeguraAPI.Tests/coverage.opencover.xml

dotnet sonarscanner end /d:sonar.login="TU_TOKEN"


 Reemplaza "TU_TOKEN" por tu token personal de SonarCloud.

 Tabla de trazabilidad de pruebas
|  |  |  |  | 
|  | "Integral" | HelmetValidated = true | OkObjectResult | 
|  | "CascoDeCartón" | "El tipo de casco no es válido." | BadRequestObjectResult | 
|  | "" | "El nombre es obligatorio." | BadRequestObjectResult | 



🛡️ Badges
 

---
