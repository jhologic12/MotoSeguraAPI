# run-analysis.ps1

$token = "ff7bc45a709d4a49238c223d20ee7392e8d0f063"
$projectKey = "jhologic12_MotoSeguraAPI"
$organization = "jaofdev"
$solution = "MotoSegura.sln"
$coveragePath = "MotoSeguraAPI.Tests/coverage.opencover.xml"

Write-Host "Iniciando análisis SonarCloud..."

dotnet sonarscanner begin `
  /k:$projectKey `
  /o:$organization `
  /d:sonar.host.url="https://sonarcloud.io" `
  /d:sonar.login=$token

dotnet test $solution `
  /p:CollectCoverage=true `
  /p:CoverletOutputFormat=opencover `
  /p:CoverletOutput=$coveragePath

dotnet sonarscanner end /d:sonar.login=$token

Write-Host "Análisis completado."