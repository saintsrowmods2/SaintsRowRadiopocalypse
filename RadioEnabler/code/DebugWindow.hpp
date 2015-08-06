#pragma once

#include <Windows.h>

extern BOOL __stdcall SetForegroundWindow_Hook(HWND hWnd);
extern void InitialiseDebugWindow(INT srVersion);
extern void UpdateDebugWindow(void);