Write-Host "Starting Ice Cream Shop Management System..." -ForegroundColor Green
Write-Host "Login: admin / admin123" -ForegroundColor Yellow
Write-Host ""

Set-Location $PSScriptRoot
dotnet run --project IceCreamShop.WPF

Write-Host ""
Write-Host "Press any key to continue..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
