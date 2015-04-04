@echo off
if [%1]==[] goto missingRevision

echo Packaging revision %1...
rmdir /s /q packaging_temp 1>NUL 2>NUL
mkdir packaging_temp 1>NUL 2>NUL
cd packaging_temp
mkdir SaintsRowRadiopocalpyse-rev%1 1>NUL 2>NUL
copy ..\license.txt SaintsRowRadiopocalpyse-rev%1\ 1>NUL 2>NUL

mkdir SaintsRowRadiopocalpyse-rev%1\RadioSwapper 1>NUL 2>NUL
copy /y ..\bin\Release\*.exe SaintsRowRadiopocalpyse-rev%1\RadioSwapper\ 1>NUL 2>NUL
copy /y ..\bin\Release\*.dll SaintsRowRadiopocalpyse-rev%1\RadioSwapper\ 1>NUL 2>NUL
copy /y ..\bin\Release\*.template SaintsRowRadiopocalpyse-rev%1\RadioSwapper\ 1>NUL 2>NUL
xcopy /y /c /i /s /e ..\bin\Release\wwise SaintsRowRadiopocalpyse-rev%1\RadioSwapper\wwise 1>NUL 2>NUL

mkdir SaintsRowRadiopocalpyse-rev%1\RadioEnabler 1>NUL 2>NUL
copy ..\RadioEnabler\bin\Release\*.dll SaintsRowRadiopocalpyse-rev%1\RadioEnabler\ 1>NUL 2>NUL
copy ..\RadioEnabler\RadioEnabler.ini SaintsRowRadiopocalpyse-rev%1\RadioEnabler\ 1>NUL 2>NUL

"C:\Program Files\7-Zip\7z.exe" a ..\SaintsRowRadiopocalpyse-rev%1.zip SaintsRowRadiopocalpyse-rev%1
cd ..
rmdir /s /q packaging_temp 1>NUL 2>NUL
echo Done!

GOTO end

:missingRevision
echo No revision number specified.

:end 