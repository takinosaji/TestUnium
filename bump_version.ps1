param (
    [Parameter(Mandatory=$True)]
    $version
)
Set-Content .\.version $version
