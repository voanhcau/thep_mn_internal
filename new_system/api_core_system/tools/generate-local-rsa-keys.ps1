[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

$projectDirectory = [System.IO.Path]::GetFullPath(
    (Join-Path $PSScriptRoot '..\src\IntegrationHub.Api'))
$keyDirectory = Join-Path $projectDirectory '.secrets'
$privateKeyPath = Join-Path $keyDirectory 'local-token-private.pem'
$publicKeyPath = Join-Path $keyDirectory 'local-token-public.pem'

New-Item -ItemType Directory -Path $keyDirectory -Force | Out-Null

if ((Test-Path -LiteralPath $privateKeyPath) -or
    (Test-Path -LiteralPath $publicKeyPath)) {
    throw "Local key file already exists in $keyDirectory. Delete both files explicitly if you intend to rotate the local key pair."
}

$rsa = [System.Security.Cryptography.RSA]::Create(3072)
try {
    [System.IO.File]::WriteAllText(
        $privateKeyPath,
        $rsa.ExportPkcs8PrivateKeyPem(),
        [System.Text.UTF8Encoding]::new($false))
    [System.IO.File]::WriteAllText(
        $publicKeyPath,
        $rsa.ExportSubjectPublicKeyInfoPem(),
        [System.Text.UTF8Encoding]::new($false))
}
finally {
    $rsa.Dispose()
}

Write-Host "Created local private key: $privateKeyPath"
Write-Host "Created local public key:  $publicKeyPath"
Write-Host 'These files are under .secrets and must never be committed.'
