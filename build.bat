@echo off
echo ========================================
echo    بناء نظام إدارة محل الآيس كريم
echo ========================================
echo.

cd /d "%~dp0"

echo جاري استعادة الحزم...
dotnet restore
if %errorlevel% neq 0 (
    echo خطأ في استعادة الحزم!
    pause
    exit /b 1
)

echo.
echo جاري بناء المشروع...
dotnet build --configuration Release
if %errorlevel% neq 0 (
    echo خطأ في بناء المشروع!
    pause
    exit /b 1
)

echo.
echo جاري إنشاء الملف التنفيذي...
dotnet publish IceCreamShop.WPF -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o "Release"
if %errorlevel% neq 0 (
    echo خطأ في إنشاء الملف التنفيذي!
    pause
    exit /b 1
)

echo.
echo ========================================
echo تم بناء البرنامج بنجاح!
echo ========================================
echo.
echo الملف التنفيذي متوفر في مجلد: Release
echo اسم الملف: IceCreamShop.WPF.exe
echo.
echo يمكنك الآن نسخ مجلد Release إلى أي مكان وتشغيل البرنامج
echo.
pause
