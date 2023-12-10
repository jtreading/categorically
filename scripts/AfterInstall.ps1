# scripts/AfterInstall.ps1

# Navigate to the installation directory
cd C:\app

# Start the Blazor application
Start-Process "dotnet" -ArgumentList "Categorically.Web.dll" -NoNewWindow -Wait
