#pragma once

#include <Windows.h>

typedef int(__cdecl *LUA_GETTOP)(void *);
typedef const char * (__cdecl *LUA_TOLSTRING)(void *, int, size_t *);

extern LUA_GETTOP lua_gettop;
extern LUA_TOLSTRING lua_tolstring;

extern int __cdecl Lua_DebugPrint(void *luaState);