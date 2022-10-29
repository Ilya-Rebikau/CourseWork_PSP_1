start "Build CourseWork.Web" /D"%~dp0src\CourseWork.Web" dotnet build
start "Build CourseWork.DistributionAPI" /D"%~dp0src\CourseWork.DistributionAPI" dotnet build
start "Build CourseWork.ComputingAPI" /D"%~dp0src\CourseWork.ComputingAPI" dotnet build
TIMEOUT 3
start "Run CourseWork.Web" /D"%~dp0src\CourseWork.Web" dotnet run --launch-profile "CourseWork.Web"
start "Run CourseWork.DistributionAPI" /D"%~dp0src\CourseWork.DistributionAPI" dotnet run --launch-profile "CourseWork.DistributionAPI"
start "Run CourseWork.ComputingAPI" /D"%~dp0src\CourseWork.ComputingAPI" dotnet run --launch-profile "CourseWork.ComputingAPI"
TIMEOUT 5
explorer "http://localhost:5000"
explorer "http://localhost:5001/swagger"
explorer "http://localhost:5002/swagger"
pause