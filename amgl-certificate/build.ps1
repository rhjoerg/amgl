
# re-ceate output directory
if (Test-Path "./out") { Remove-Item -Path "./out" -Recurse }
$null = New-Item -Path "." -Name "out" -ItemType "directory" -Force

# delete existing AMGL certificates
Get-ChildItem Cert:\CurrentUser\My | Where-Object { $_.Subject -match 'AMGL' } | Remove-Item

# create and export a new AMGL certificate
$pass = ConvertTo-SecureString -String "amgl" -Force –AsPlainText
$date = (Get-Date).AddYears(10)

$cert = New-SelfSignedCertificate -Subject "AMGL" -Type CodeSigning -CertStoreLocation "cert:\CurrentUser\My" -NotAfter $date
$null = Export-PfxCertificate -Cert "cert:\CurrentUser\My\$($cert.Thumbprint)" -FilePath "./out/amgl-private.pfx" -Password $pass
$null = Export-Certificate -Cert "cert:\CurrentUser\My\$($cert.Thumbprint)" -FilePath "./out/amgl-public.crt"

# cleanup
Get-ChildItem "Cert:\CurrentUser\My\$($cert.Thumbprint)" | Remove-Item
