function Bump-Version
{
    [CmdletBinding()]
	param
	(
	    [Parameter(Mandatory=$True, HelpMessage="Version which will be recorded in file.")]
        $Version,
        [Parameter(Mandatory=$True, HelpMessage="Path to version file.")]
        $FilePath
	)

	BEGIN { }
	END { }
	PROCESS
	{
		$datetime = Get-Date
        "$($dateTime.ToUniversalTime().ToString()) : $Version" >> $FilePath
	}
}

Export-ModuleMember Bump-Version