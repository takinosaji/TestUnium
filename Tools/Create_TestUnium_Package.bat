powershell.exe -file .\CreatePackageFlow.ps1 -Version %1 -BuildConfiguration Release -NuspecDestinationPath "..\src\TestUnium\TestUnium.nuspec" -VersionFilePath "..\src\TestUnium\.version
pause