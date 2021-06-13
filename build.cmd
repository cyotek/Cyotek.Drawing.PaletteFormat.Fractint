@ECHO OFF

SETLOCAL

CALL %CTKBLDROOT%setupEnv.cmd

SET BASENAME=Cyotek.Drawing.PaletteFormat.Fractint
SET RELDIR=src\bin\Release\
SET PRJFILE=src\%BASENAME%.csproj
SET DLLNAME=%BASENAME%.dll

IF EXIST %RELDIR%*.nupkg  DEL /F %RELDIR%*.nupkg
IF EXIST %RELDIR%*.snupkg DEL /F %RELDIR%*.snupkg
IF EXIST %RELDIR%*.zip    DEL /F %RELDIR%*.zip

CALL update-ProjectVersionInfo %PRJFILE%

dotnet build %PRJFILE% --configuration Release
IF %ERRORLEVEL% NEQ 0 GOTO :failed

PUSHD %RELDIR%
CALL signcmd net35\%DLLNAME%
CALL signcmd net40\%DLLNAME%
CALL signcmd net452\%DLLNAME%
CALL signcmd net462\%DLLNAME%
CALL signcmd net472\%DLLNAME%
CALL signcmd net48\%DLLNAME%
CALL signcmd net5.0\%DLLNAME%
CALL signcmd netcoreapp2.1\%DLLNAME%
CALL signcmd netcoreapp3.1\%DLLNAME%
CALL signcmd netstandard2.1\%DLLNAME%

%zipexe% a %BASENAME%.x.x.%BUILD_NUMBER%.zip -r
POPD

dotnet pack %PRJFILE% --configuration Release --no-build
IF %ERRORLEVEL% NEQ 0 GOTO :failed

CALL sign-package %RELDIR%*.nupkg
CALL sign-package %RELDIR%*.snupkg

ENDLOCAL

GOTO :eof

:failed
CECHO {0c}ERROR  : Build failed{#}{\n}
EXIT /b 1

