#pragma unmanaged

#include <stdio.h>
#include <Windows.h>
#include <string>
#include <iostream>

#include "config.hpp"
#include "Log.hpp"


BOOL ShouldCreateConsole = true;
BOOL DisableLoadingSRIVCharacter = false;
BOOL HookLuaDebugPrint = true;
BOOL EnableRadio = true;
BOOL PreventCharacterSwapOnCoopJoin = false;
BOOL PauseOnFocusLost = true;
BOOL CreateDebugWindow = false;

void ConfigLoad()
{
	std::wstring configPath(L"");

	wchar_t buffer[MAX_PATH];
	GetCurrentDirectory(MAX_PATH, buffer);

	configPath = buffer;
	configPath += L"\\RadioEnabler.ini";

	GetPrivateProfileString(L"general", L"create_console", L"1", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"false") == 0)
		ShouldCreateConsole = false;
	else if (_wcsicmp(buffer, L"0") == 0)
		ShouldCreateConsole = false;

	GetPrivateProfileString(L"hooks", L"hook_lua_debug_print", L"1", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"false") == 0)
		HookLuaDebugPrint = false;
	else if (_wcsicmp(buffer, L"0") == 0)
		HookLuaDebugPrint = false;

	GetPrivateProfileString(L"hooks", L"enable_radio", L"1", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"false") == 0)
		EnableRadio = false;
	else if (_wcsicmp(buffer, L"0") == 0)
		EnableRadio = false;


	GetPrivateProfileString(L"hooks", L"load_sriv_character", L"1", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"false") == 0)
		DisableLoadingSRIVCharacter = true;
	else if (_wcsicmp(buffer, L"0") == 0)
		DisableLoadingSRIVCharacter = true;

	GetPrivateProfileString(L"hooks", L"prevent_coop_join_character_swap", L"0", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"true") == 0)
		PreventCharacterSwapOnCoopJoin = true;
	else if (_wcsicmp(buffer, L"1") == 0)
		PreventCharacterSwapOnCoopJoin = true;

	GetPrivateProfileString(L"options", L"pause_on_focus_lost", L"1", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"false") == 0)
		PauseOnFocusLost = false;
	else if (_wcsicmp(buffer, L"0") == 0)
		PauseOnFocusLost = false;

	GetPrivateProfileString(L"options", L"create_debug_window", L"0", buffer, MAX_PATH, configPath.c_str());
	if (_wcsicmp(buffer, L"true") == 0)
		CreateDebugWindow = true;
	else if (_wcsicmp(buffer, L"1") == 0)
		CreateDebugWindow = true;
}