param (
    [Parameter(Mandatory=$false)] 
    [string] $BuildConfiguration = 'Release',
    [parameter(Mandatory=$true, HelpMessage="Specify package version.")]
	[ValidateNotNullOrEmpty()]
	[string] $Version,	
	[parameter(Mandatory=$true, HelpMessage="Specify path to target project file.")]
	[ValidateNotNullOrEmpty()]
	[string] $ProjectFilePath,
	[parameter(Mandatory=$true, HelpMessage="Specify destination path for nuspec file.")]
	[ValidateNotNullOrEmpty()]
	[string] $NuspecDestinationPath,
	[parameter(Mandatory=$true, HelpMessage="Specify source path for nuspec file.")]
	[ValidateNotNullOrEmpty()]
	[string] $NuspecSourcePath,
	[parameter(Mandatory=$false)]
	[ValidateNotNullOrEmpty()]
	[string] $VersionFilePath = "..\.version"
)
$env:PsModulePath += ";$PsScriptRoot\Modules"

Import-Module Invoke-MsBuild -Verbose
Import-Module Transform-Nuspec -Verbose
Import-Module Bump-Version -Verbose

try
{
    Transform-Nuspec -Version $Version -SourcePath $NuspecSourcePath -DestinationPath $NuspecDestinationPath
   
    $buildResult = Invoke-MsBuild -Path "..\TestUnium.sln" -Verbose -Params "/target:Clean;Build /property:Configuration=Release"
    if ($buildResult.BuildSucceeded -eq $true)
    { 
        Write-Host "Build completed successfully." 
    }
    ElseIf (!$buildResult.BuildSucceeded -eq $false)
    { 
        Write-Host "Build failed. Check the build log file $($buildResult.BuildLogFilePath) for errors." 
    }
    ElseIf ($buildResult.BuildSucceeded -eq $null)
    { 
        Write-Host "Unsure if build passed or failed: $($buildResult.Message)" 
    }

    Start-Process -FilePath $PSScriptRoot\nuget.exe -ArgumentList "pack $ProjectFilePath -IncludeReferencedProjects -Verbose -Prop Configuration=$BuildConfiguration"

    Bump-Version -FilePath $VersionFilePath -Version $Version
}
catch [Exception]
{
    Write-Host $_.Exception.Message
}


