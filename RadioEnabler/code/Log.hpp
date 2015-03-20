#pragma once

#include <Windows.h>

extern HANDLE hLogFile;

BOOL WINAPI OpenLog();
VOID WINAPI WriteToLog(WCHAR*, WCHAR*, ...);
VOID WINAPI CloseLog();
