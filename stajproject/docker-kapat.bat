@echo off
setlocal

set "SCRIPT_DIR=%~dp0"
for %%I in ("%SCRIPT_DIR%..") do set "ROOT=%%~fI"
set "COMPOSE_FILE=%ROOT%\docker-compose.yml"
set "DOWN_ARGS=down"

if /I "%~1"=="-v" set "DOWN_ARGS=down -v"
if /I "%~1"=="--volumes" set "DOWN_ARGS=down -v"

echo Stopping TechOps Docker containers...
echo.

if not exist "%COMPOSE_FILE%" (
  echo docker-compose.yml not found: "%COMPOSE_FILE%"
  pause
  exit /b 1
)

where docker > nul 2>&1
if errorlevel 1 (
  echo Docker CLI not found.
  pause
  exit /b 1
)

docker info > nul 2>&1
if errorlevel 1 (
  echo Docker is installed but the daemon is not reachable.
  echo Start Docker Desktop if containers are still running.
  pause
  exit /b 1
)

pushd "%ROOT%" > nul
docker compose %DOWN_ARGS%
set "EXIT_CODE=%ERRORLEVEL%"
popd > nul

if not "%EXIT_CODE%"=="0" (
  echo Docker Compose could not stop the project cleanly.
  pause
  exit /b %EXIT_CODE%
)

echo Done.
echo Use "docker-kapat.bat -v" to remove the PostgreSQL Docker volume too.
pause
