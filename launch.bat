@echo off
title Ice Cream Shop

echo Starting Ice Cream Shop Management System...
echo.

cd /d "%~dp0"
dotnet run --project IceCreamShop.WPF

echo.
echo Login: admin / admin123
echo.
pause
