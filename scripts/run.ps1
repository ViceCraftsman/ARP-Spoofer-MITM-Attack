$ErrorActionPreference = "Stop"
$project = Join-Path $PSScriptRoot "..\src\ARP-Spoofer-MITM-Attack\ARP-Spoofer-MITM-Attack.csproj"
dotnet run --project $project -- @args
