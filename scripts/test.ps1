$ErrorActionPreference = "Stop"
$sln = Join-Path $PSScriptRoot "..\ARP-Spoofer-MITM-Attack.sln"
dotnet test $sln --configuration Release --verbosity normal
