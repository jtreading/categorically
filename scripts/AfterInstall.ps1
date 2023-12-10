# scripts/AfterInstall.ps1

# Navigate to the installation directory
cd C:\CategoricallyApplication

# Start the Blazor application
Start-Process "dotnet" -ArgumentList "Categorically.dll" -NoNewWindow -Wait
