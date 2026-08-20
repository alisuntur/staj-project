@echo off
setlocal

echo Stopping TechOps local project processes...

powershell -NoProfile -ExecutionPolicy Bypass -Command "$ports = @(5162, 5173); foreach ($port in $ports) { $listeners = Get-NetTCPConnection -LocalPort $port -State Listen -ErrorAction SilentlyContinue; foreach ($listener in $listeners) { $ownerId = $listener.OwningProcess; $proc = Get-Process -Id $ownerId -ErrorAction SilentlyContinue; if ($proc -and ($proc.ProcessName -in @('dotnet', 'node', 'cmd'))) { Stop-Process -Id $ownerId -Force; Write-Output ('Stopped ' + $proc.ProcessName + ' on port ' + $port + ' (PID ' + $ownerId + ')') } } }"

echo Done. If a TechOps API or TechOps Frontend window is still open, close it manually.
pause
