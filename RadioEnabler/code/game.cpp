/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

#include <windows.h>
#include <shlwapi.h>
#include <stdio.h>
#include <string.h>

#include "game.hpp"
#include "patch.hpp"
#include "crc.hpp"
#include "lua.hpp"

static unsigned char radioFixup[] = {
	0x8A, 0x45, 0x08, // MOV al, [ebp+enable]
	0xA2, 0x1C, 0xEC, 0x66, 0x01, // MOV onfoot_radio_enabled, al
	0x90, 0x90, 0x90, 0x90, 0x90 // reserved for inserted JMP
};

BOOL HookGame(void)
{
	switch (EXE_CRC)
	{
		case CRC_STEAM_PATCH_1:
			return HookGame_SteamPatch1();
			break;
	}

	return false;
}

BOOL HookGame_SteamPatch1(void)
{
	wprintf(L"Loading hooks and patches for Steam patch #1:\n");
	BOOL success = false;

	wprintf(L" - setting up Lua hooks... ");
	unsigned int luaDebugPrintAddress = (unsigned int)&Lua_DebugPrint;
	PatchCode(0x1010020, &luaDebugPrintAddress, 4);
	lua_gettop = (LUA_GETTOP)0x109c820;
	lua_tolstring = (LUA_TOLSTRING)0x109cc10;
	wprintf(L"done.\n");

	wprintf(L" - patching radio... ");

	DWORD old = 0;

	success = PatchJump(0x00591E2B, (unsigned int)&radioFixup);
	if (!success)
		return false;

	success = PatchJump(((unsigned int)&radioFixup) + 0x08, 0x00591E32);
	if (!success)
		return false;

	success = VirtualProtect(&radioFixup, sizeof(radioFixup), PAGE_EXECUTE_READWRITE, &old);
	if (!success)
		return false;

	wprintf(L"done.\n");

	return true;
}

BOOL GameAttach(void)
{
	CheckExecutable();

	return HookGame();
}

void GameDetach(void)
{
}
