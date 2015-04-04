#pragma once

#include <Windows.h>

extern BOOL ShouldCreateConsole;
extern BOOL DisableLoadingSRIVCharacter;
extern BOOL HookLuaDebugPrint;
extern BOOL EnableRadio;
extern BOOL PreventCharacterSwapOnCoopJoin;

extern void ConfigLoad();