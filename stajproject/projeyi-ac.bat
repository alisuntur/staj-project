@echo off
setlocal

set "ROOT=%~dp0"
set "BACKEND=%ROOT%back\TechOps.Api"
set "FRONTEND=%ROOT%front"
set "API_URL=http://localhost:5162"
set "FRONTEND_URL=http://127.0.0.1:5173"

echo TechOps local project launcher
echo.

if not exist "%BACKEND%\TechOps.Api.csproj" (
  echo Backend project not found: "%BACKEND%\TechOps.Api.csproj"
  pause
  exit /b 1
)

if not exist "%FRONTEND%\package.json" (
  echo Frontend project not found: "%FRONTEND%\package.json"
  pause
  exit /b 1
)

echo Starting backend on %API_URL% ...
start "TechOps API" /D "%BACKEND%" cmd /k dotnet run --launch-profile http

echo Starting frontend on %FRONTEND_URL% with API %API_URL% ...
start "TechOps Frontend" /D "%FRONTEND%" cmd /k "set VITE_API_BASE_URL=%API_URL%&& npm run dev -- --host 127.0.0.1 --port 5173"

echo Opening browser shortly...
ping 127.0.0.1 -n 9 > nul
start "" "%FRONTEND_URL%"

echo.
echo Backend:  %API_URL%
echo Frontend: %FRONTEND_URL%
echo.
echo Close the opened API and Frontend command windows to stop the project.
pause
