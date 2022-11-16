start "Build CourseWork.Models" /D"%~dp0src\CourseWork.Models" dotnet build
start "Build CourseWork.ComputingAPI" /D"%~dp0src\CourseWork.ComputingAPI" dotnet build
TIMEOUT 3
start "Run CourseWork.ComputingAPI_1" /D"%~dp0src\CourseWork.ComputingAPI" dotnet run --launch-profile "CourseWork.ComputingAPI" --urls "http://192.168.247.211:5002"
start "Run CourseWork.ComputingAPI_2" /D"%~dp0src\CourseWork.ComputingAPI" dotnet run --launch-profile "CourseWork.ComputingAPI" --urls "http://192.168.247.211:5003"
start "Run CourseWork.ComputingAPI_3" /D"%~dp0src\CourseWork.ComputingAPI" dotnet run --launch-profile "CourseWork.ComputingAPI" --urls "http://192.168.247.211:5004"
TIMEOUT 5
explorer "http://192.168.247.211:5002/swagger"
explorer "http://192.168.247.211:5003/swagger"
explorer "http://192.168.247.211:5004/swagger"
pause