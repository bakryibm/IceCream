@echo off
title Ice Cream Shop Management System

echo.
echo Ice Cream Shop Management System
echo نظام ادارة محل الايس كريم
echo ================================
echo.
echo جاري التشغيل...
echo Starting...

cd /d "%~dp0"
dotnet run --project IceCreamShop.WPF

if %errorlevel% neq 0 (
    echo.
    echo فشل في التشغيل
    echo Failed to start
    echo جرب تشغيل run.bat للحصول على تفاصيل اكثر
    echo Try running run.bat for more details
    pause
)
