@echo off
:: DO NOT change anything in this file
:: This file handles the building of the mod against the server
:: The params sent must be: server path, path to mod sources, mod name and compile with eac or not
call :[CLR] White DarkRed "Beginning batch build"

call :[CLR] White DarkRed "Incoming vars..."
echo %1
echo %2
echo %3
echo %4
echo %5

call :[CLR] White DarkRed "Setting vars..."
set serv_path=%1
set source_path=%2
set mod_name=%3
set with_eac=%4
set make_logs=%5

call :[CLR] White DarkRed "Clearing vars of illegal characters"
echo %serv_path%
call :dequote serv_path
echo %serv_path%
echo %source_path%
call :dequote source_path
echo %source_path%
echo %mod_name%
call :dequote mod_name
echo %mod_name%
echo %with_eac%
call :dequote with_eac
echo %with_eac%
echo %make_logs%
call :dequote make_logs
echo %make_logs%

call :[CLR] White DarkRed "Setting up combined path.."
set comb_path=%source_path%\%mod_name%
echo %comb_path%
call :[CLR] White DarkRed "Setting up execution command.."
if %with_eac%=="n" (
	set exec=call "%serv_path%" -build "%comb_path%" -language "en-US"
) else (
	set exec=call "%serv_path%" -build "%comb_path%" -eac "%comb_path%\bin\debug\%mod_name%.dll" -language "en-US"
)
call :[CLR] White DarkRed "Checking exec..."
echo %exec%
call :[CLR] White DarkRed "Attempting to compile mod"
echo Given arguments:
echo Server path: %serv_path%
echo Mod sources path: %source_path%
echo Mod name: %mod_name%
echo Edit-and-continue: %with_eac%
echo Make logs: %make_logs%
echo Combined path: %comb_path%
echo.
call :[CLR] White DarkRed "Compiling..."
call :[CLR] White DarkRed "Starting server"
call :[CLR] White DarkRed "The following logs are server compile logs"
:: IF buildIgnore
::%exec% > COMPILE_Log.txt 2>&1
if defined make_logs (
	if "%make_logs%" equ "y" (
		break > COMPILE_log.txt
	)
)
::echo %exec%
for /f "tokens=*" %%G in ('call %exec%') do (
	call :[CLR] White DarkBlue "%%G"
	::echo %%G
	if defined make_logs (
		if "%make_logs%" equ "y" (
			echo %%G >> COMPILE_log.txt
		)
	)
)
::%exec% > call :[CLR] White DarkRed
::type COMPILE_Log.txt
pause
exit

:[CLR]
echo off
set fg=%1
set bg=%2
set args=%3
powershell -Command Write-Host %args% -foreground "%fg%" -background "%bg%"
goto :eof

:DeQuote
for /f "delims=" %%A in ('echo %%%1%%') do set %1=%%~A
Goto :eof

:eof