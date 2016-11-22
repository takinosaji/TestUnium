function Transform-Nuspec
{
    [CmdletBinding()]
	param
	(
		[parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Params,	
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
        $content = Get-Content $SourcePath
        for ($i=0; $i -lt $Params.Count; $i++)
        {
            $content = $content.replace("{$i}", $params[$i])    
        }
        $content | Set-Content $DestinationPath
	}
}

Export-ModuleMember Transform-Nuspec