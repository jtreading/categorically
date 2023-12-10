# scripts/AfterInstall.ps1
Write-Host "AfterInstall started."

# Navigate to the installation directory
cd C:/CategoricallyApp

# Start the Blazor application
Start-Process "dotnet" -ArgumentList "/publish/Categorically.Web.dll" -NoNewWindow -Wait
