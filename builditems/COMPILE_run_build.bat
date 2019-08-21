@echo off
:SETUP
::=================================================================
:: Change these settings!

:: Path to server. NO backslash at the end. Path can contain spaces
set server_path=tModLoaderServer.exe

:: Path to mod sources. NO backslash at the end. Path can contain spaces
set mod_sources_path=..

:: Your internal mod name. must correspond to your Mod class name.
set mod_name=prismmod

:: Edit-and-continue, yes or no. Possible values: y/n
set compile_with_eac=y

:: Set this to y to make logs. Can be useful if build fails. Possible values: y/n
:: Make sure to add 'COMPILE_*.txt'
set make_logs=n
::=================================================================
:: DO NOT EDIT BELOW HERE
:CONTROL
verify OTHER 2>nul
setlocal ENABLEEXTENSIONS
if errorlevel 1 (
	echo Unable to enable extensions
	goto STERR
)

set err=n
if not defined server_path ( 
	echo Server path not defined
	set err=y
) else (
	set server_path=^"%server_path%^"
	
	if not exist "%server_path%" (
			echo Server path does not exist
			set err=y
	)
)

if not defined mod_sources_path (
	echo Mod sources path not defined
	set err=y
) else (

	if defined mod_name (
		set mod_path=%mod_sources_path%\%mod_name%
	)
	
	set mod_sources_path=^"%mod_sources_path%^"
	
	if not exist "%mod_sources_path%" (
			echo Mod sources path does not exist
			set err=y
	)
)

if not defined mod_name (
	echo Mod name not defined
	set err=y
) else (

	if defined mod_path (
		if not exist "%mod_path%" (
			echo Path to mod source does not exist
			set err=y
		)
	)
)

if not defined compile_with_eac (
	echo Compile with eac option not defined
	set err=y
) else (
	if "%compile_with_eac%" neq "y" (
		if "%compile_with_eac%" neq "n" (
			echo compile_with_eac MUST be 'y' or 'n'
			set err=y
		)
	)
)

if not defined make_logs (
	echo Make logs option not defined
	set err=y
) else (
	if "%make_logs%" neq "y" (
		if "%make_logs%" neq "n" (
			echo make_logs MUST be 'y' or 'n'
			set err=y
		)
	)
)

if "%err%"=="y" goto STERR
endlocal

:LAUNCH
echo Preparing to build your mod.
set "launch_dir=%~dp0"
set "caller_dir=%CD%"
echo Launch dir: %launch_dir%
echo Caller dir: %caller_dir%
if not "%caller_dir%" == "%launch_dir%" goto SWAPDIR

:LISTTREE
echo Listing found files in mod source

if defined make_logs (
	if "%make_logs%" equ "y" (
		dir /a:d /b > COMPILE_found_folders.txt
		dir /s /b > COMPILE_found_dirs.txt
	)
)
call "COMPILE_do_build.bat" "%server_path%" "%mod_sources_path%" "%mod_name%" "%compile_with_eac%" "%make_logs%"
pause
goto EOF

:SWAPDIR
echo Swapping working directory to launch dir using Pushd
REM setlocal
pushd "%launch_dir%"
echo %0
echo Verifying...
REM popd
if not "%~dp0" == "%launch_dir%" pushd "%launch_dir%"
goto LISTTREE

:STERR
echo Error in setup.
echo Please check your settings
pause
goto EOF

:DeQuote
for /f "delims=" %%A in ('echo %%%1%%') do set %1=%%~A
Goto EOF

:EOF
