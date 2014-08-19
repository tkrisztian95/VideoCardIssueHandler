@ echo off
echo "A video kartya freqvencia kezelo segedprogram telepitese folyamatban.."
start /wait %~dp0AMDGPUClockTool_installer.exe
echo "A video kartya freqvencia kezelo szolgaltatas regisztralasa folyamatban.."
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\installutil.exe "%~dp0VideoCardHandler.exe"
pause