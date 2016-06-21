function Transform-Nuspec
{
    [CmdletBinding()]
	param
	(
		[parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[string] $Version,	
	    [parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[string] $DestinationPath,
	    [parameter(Mandatory=$false)]
		[ValidateNotNullOrEmpty()]
		[string] $SourcePath = ".\TestUnium.nuspec"	
	)

	BEGIN { }
	END { }
	PROCESS
	{
		(Get-Content $SourcePath).replace('${auto.version}', $Version) | Set-Content $DestinationPath
	}
}

Export-ModuleMember Transform-Nuspec