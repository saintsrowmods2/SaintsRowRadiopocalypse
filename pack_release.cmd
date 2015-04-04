@echo off
if [%1]==[] goto missingRevision

echo Packaging revision %1...
rmdir /s /q packaging_temp 1>NUL 2>NUL
mkdir packaging_temp 1>NUL 2>NUL
cd packaging_temp
mkdir SaintsRowRadiopocalypse-rev%1 1>NUL 2>NUL
copy ..\license.txt SaintsRowRadiopocalypse-rev%1\ 1>NUL 2>NUL

mkdir SaintsRowRadiopocalypse-rev%1\RadioSwapper 1>NUL 2>NUL
copy /y ..\bin\Release\*.exe SaintsRowRadiopocalypse-rev%1\RadioSwapper\ 1>NUL 2>NUL
copy /y ..\bin\Release\*.dll SaintsRowRadiopocalypse-rev%1\RadioSwapper\ 1>NUL 2>NUL
copy /y ..\bin\Release\*.template SaintsRowRadiopocalypse-rev%1\RadioSwapper\ 1>NUL 2>NUL
xcopy /y /c /i /s /e ..\bin\Release\wwise SaintsRowRadiopocalypse-rev%1\RadioSwapper\wwise 1>NUL 2>NUL

mkdir SaintsRowRadiopocalypse-rev%1\RadioEnabler 1>NUL 2>NUL
copy ..\RadioEnabler\bin\Release\*.dll SaintsRowRadiopocalypse-rev%1\RadioEnabler\ 1>NUL 2>NUL
copy ..\RadioEnabler\RadioEnabler.ini SaintsRowRadiopocalypse-rev%1\RadioEnabler\ 1>NUL 2>NUL

"C:\Program Files\7-Zip\7z.exe" a ..\SaintsRowRadiopocalypse-rev%1.zip SaintsRowRadiopocalypse-rev%1
cd ..
rmdir /s /q packaging_temp 1>NUL 2>NUL
echo Done!

GOTO end

:missingRevision
echo No revision number specified.

:end 