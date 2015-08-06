#include <Windows.h>
#include "gamedetect.hpp"
#include "DebugWindow.hpp"

#using <mscorlib.dll>
#using <DebugWindow.dll>

using namespace System;
using namespace DebugWindow;

BOOL __stdcall SetForegroundWindow_Hook(HWND hWnd)
{
	BOOL result = SetForegroundWindow(hWnd);

	InitialiseDebugWindow(SRVersion);

	return result;
}

void InitialiseDebugWindow(INT srVersion)
{
	UnmanagedInterface::CreateDebugWindow(srVersion);
}

void UpdateDebugWindow(void)
{
	UnmanagedInterface::UpdateWindow();
}