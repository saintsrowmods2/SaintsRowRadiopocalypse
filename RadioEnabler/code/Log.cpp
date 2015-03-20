#include <Windows.h>

#include <stdio.h>
#include <varargs.h>

#include "Log.hpp"

HANDLE hLogFile;

BOOL WINAPI OpenLog()
{
	hLogFile = CreateFileW(TEXT("RadioEnabler.log"), GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

	if (!hLogFile)
		return FALSE;

	WriteToLog(L"RadioEnabler", L"Opened log file.\n");

	return TRUE;
}

VOID WINAPI WriteToLog(WCHAR* source, WCHAR* string, ...)
{
	DWORD charsRequired;
	WCHAR* message = NULL;
	WCHAR* fullMessage = NULL;

	va_list argptr;
	va_start(argptr, string);

	charsRequired = sizeof(WCHAR) * (_vscwprintf(string, argptr) + 1);
	message = (WCHAR*)GlobalAlloc(0, charsRequired);
	_vswprintf(message, string, argptr);

	va_end(argptr);

	charsRequired = sizeof(WCHAR) * (_scwprintf(L"[%s] %s", source, message) + 1);
	fullMessage = (WCHAR*)GlobalAlloc(0, charsRequired);
	_swprintf(fullMessage, L"[%s] %s", source, message);

	wprintf(fullMessage);

	DWORD bytesWritten = 0;

	WriteFile(hLogFile, fullMessage, charsRequired - sizeof(WCHAR), &bytesWritten, NULL);
	GlobalFree(fullMessage);
	GlobalFree(message);
}

VOID WINAPI CloseLog()
{
	CloseHandle(hLogFile);
}