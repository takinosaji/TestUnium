param (
    [Parameter(Mandatory=$True)]
    $version
)
$datetime = Get-Date
"$($dateTime.ToUniversalTime().ToString()) : $version" >> .\.version
