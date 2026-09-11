@echo off
setlocal

set "SCRIPT_DIR=%~dp0"
for %%I in ("%SCRIPT_DIR%..") do set "ROOT=%%~fI"
set "COMPOSE_FILE=%ROOT%\docker-compose.yml"
set "FRONTEND_URL=http://localhost:5173"
set "API_HEALTH_URL=http://localhost:5162/api/health"

echo TechOps Docker launcher
echo.

if not exist "%COMPOSE_FILE%" (
  echo docker-compose.yml not found: "%COMPOSE_FILE%"
  pause
  exit /b 1
)

where docker > nul 2>&1
if errorlevel 1 (
  echo Docker CLI not found. Install Docker Desktop and try again.
  pause
  exit /b 1
)

docker info > nul 2>&1
if errorlevel 1 (
  echo Docker is installed but the daemon is not reachable.
  echo Start Docker Desktop, wait until it is ready, then run this file again.
  pause
  exit /b 1
)

pushd "%ROOT%" > nul

echo Building and starting TechOps containers...
docker compose up --build -d
if errorlevel 1 (
  popd > nul
  echo Docker Compose could not start the project.
  pause
  exit /b 1
)

echo Waiting for API health check...
powershell -NoProfile -ExecutionPolicy Bypass -Command "$deadline = (Get-Date).AddSeconds(90); do { try { $response = Invoke-WebRequest -Uri '%API_HEALTH_URL%' -UseBasicParsing -TimeoutSec 3; if ($response.StatusCode -eq 200) { exit 0 } } catch { }; Start-Sleep -Seconds 3 } while ((Get-Date) -lt $deadline); exit 1"
if errorlevel 1 (
  echo API is not healthy yet. Containers may still be starting.
  echo Check logs with: docker compose logs -f api
) else (
  echo API is healthy.
)

echo.
echo Frontend: %FRONTEND_URL%
echo API:      http://localhost:5162
echo Swagger:  http://localhost:5162/swagger/index.html
echo.
start "" "%FRONTEND_URL%"

popd > nul
pause
