param (
    [parameter(Mandatory=$true, HelpMessage="Specify package version.")]
    [ValidatePattern("^(\d+\.)?(\d+\.)?(\*|\d+)$")]
	[string] $Version,	
	[parameter(Mandatory=$true, HelpMessage="Specify path to target solution file.")]
	[ValidateNotNullOrEmpty()]
	[string] $SolutionFilePath,
	[parameter(Mandatory=$true, HelpMessage="Specify path to target project file.")]
	[ValidateNotNullOrEmpty()]
	[string] $ProjectFilePath,
	[parameter(Mandatory=$true, HelpMessage="Specify destination path for nuspec file.")]
	[ValidateNotNullOrEmpty()]
	[string] $NuspecDestinationPath,
	[parameter(Mandatory=$true, HelpMessage="Specify source path for nuspec file.")]
	[ValidateNotNullOrEmpty()]
	[string] $NuspecSourcePath,
	[parameter(Mandatory=$true)]
	[ValidateNotNullOrEmpty()]
	[string] $VersionFilePath = "..\.version",
    [switch] $NuGetPackageFromNuSpec,
    [switch] $RebuildSolution,
    [Parameter(Mandatory=$false)] 
    [string] $BuildConfiguration = "Release"
)
$env:PsModulePath += ";$PsScriptRoot\Modules"

Import-Module Invoke-MsBuild -Verbose
Import-Module Transform-Nuspec -Verbose
Import-Module Bump-Version -Verbose

try
{
    if($RebuildSolution)
    {   
        Write-Host "Rebuilding project in $BuildConfiguration configuration."
        Build-Solution -SolutionFilePath $SolutionFilePath -BuildConfiguration $BuildConfiguration
    }

    Transform-Nuspec -Version $Version -SourcePath $NuspecSourcePath -DestinationPath $NuspecDestinationPath
   
    if($NuGetPackageFromNuSpec)
    {
        Start-Process -FilePath $PSScriptRoot\nuget.exe -ArgumentList "pack $NuspecDestinationPath -IncludeReferencedProjects -Symbols -Verbose"
    }
    else
    {
        Start-Process -FilePath $PSScriptRoot\nuget.exe -ArgumentList "pack $ProjectFilePath -IncludeReferencedProjects -Symbols -Verbose -Prop Configuration=`"$BuildConfiguration`""
    }

    Bump-Version -FilePath $VersionFilePath -Version $Version
}
catch [Exception]
{
    Write-Host $_.Exception.Message
}


