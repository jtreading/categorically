# scripts/AfterInstall.ps1
Write-Host "AfterInstall started."

# Navigate to the directory where your application is located
cd "C:\CategoricallyApp"

# Define the path to your main application DLL
$applicationDll = "C:\CategoricallyApp\Categorically.Web.dll"

# Check if the DLL file exists
if (Test-Path $applicationDll) {
    # Start the application using dotnet
    Start-Process "dotnet" -ArgumentList $applicationDll -NoNewWindow -Wait
} else {
    Write-Host "Error: Application DLL not found at $applicationDll"
}
