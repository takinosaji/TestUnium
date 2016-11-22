function Transform-Nuspec
{
    [CmdletBinding()]
	param
	(
		[parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $params,	
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
        for ($i=0; $i -le $params.Count; $i++)
        {
            $content.replace("{$i}", $params[$i])    
        }
        $content | Set-Content $DestinationPath
	}
}

Export-ModuleMember Transform-Nuspec