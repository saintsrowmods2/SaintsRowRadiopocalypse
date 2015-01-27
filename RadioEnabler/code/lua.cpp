#include <stdio.h>
#include <Windows.h>

#include "lua.hpp"

LUA_GETTOP lua_gettop = NULL;
LUA_TOLSTRING lua_tolstring = NULL;

int __cdecl Lua_DebugPrint(void *luaState)
{
	const char *msg = "";

	wprintf(L"LUA: ");

	int top = lua_gettop(luaState);
	for (int i = 1; i <= top; i++)
	{
		msg = lua_tolstring(luaState, i, NULL);
		WCHAR* msgW = NULL;
		DWORD msgLen = MultiByteToWideChar(CP_ACP, 0, msg, -1, NULL, 0);
		msgW = (WCHAR*)GlobalAlloc(0, msgLen * sizeof(WCHAR));
		MultiByteToWideChar(CP_ACP, 0, msg, -1, (LPWSTR)msgW, msgLen);
		if (i < top)
			wprintf(L"%s ", msgW);
		else
			wprintf(L"%s", msgW);
		GlobalFree(msgW);
	}
	
	return 0;
}