@echo off
echo ========================================
echo    Ice Cream Shop Management System
echo    نظام ادارة محل الايس كريم
echo ========================================
echo.

echo جاري تشغيل البرنامج...
echo Starting the application...
echo.

cd /d "%~dp0"

if exist "IceCreamShop.WPF\bin\Release\net6.0-windows\IceCreamShop.WPF.exe" (
    echo تشغيل من الملف المبني...
    echo Running from built executable...
    start "" "IceCreamShop.WPF\bin\Release\net6.0-windows\IceCreamShop.WPF.exe"
    if %errorlevel% equ 0 (
        echo تم تشغيل البرنامج بنجاح!
        echo Application started successfully!
    ) else (
        echo فشل في تشغيل البرنامج
        echo Failed to start application
        echo جاري المحاولة من الكود المصدري...
        echo Trying to run from source code...
        goto RunFromSource
    )
) else (
    :RunFromSource
    echo تشغيل من الكود المصدري...
    echo Running from source code...
    echo قد تظهر بعض التحذيرات - يمكن تجاهلها
    echo Some warnings may appear - you can ignore them
    echo.
    dotnet run --project IceCreamShop.WPF
    if %errorlevel% equ 0 (
        echo تم تشغيل البرنامج بنجاح!
        echo Application started successfully!
    ) else (
        echo فشل في تشغيل البرنامج
        echo Failed to start application
        echo.
        echo تشخيص المشكلة:
        echo Troubleshooting:
        echo 1. تأكد من تثبيت .NET 6.0 Runtime
        echo    Make sure .NET 6.0 Runtime is installed
        echo 2. تأكد من وجود جميع الملفات
        echo    Make sure all files are present
        echo 3. جرب تشغيل الأمر التالي يدوياً:
        echo    Try running this command manually:
        echo    dotnet run --project IceCreamShop.WPF
        echo.
        echo للمساعدة، راجع ملف README.md
        echo For help, check README.md file
    )
)

echo.
echo بيانات تسجيل الدخول:
echo Login credentials:
echo    اسم المستخدم / Username: admin
echo    كلمة المرور / Password: admin123
echo.
echo يمكنك اغلاق هذه النافذة الان
echo You can close this window now
echo.
pause
