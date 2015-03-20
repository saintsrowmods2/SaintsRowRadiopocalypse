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
}