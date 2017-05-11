#pragma unmanaged

#include <stdio.h>
#include <Windows.h>

#include "gamedetect.hpp"
#include "game.hpp"
#include "Log.hpp"

#define UINT32(x) (*(unsigned int *)x)

INT SRVersion = 0;

VOID VersionDetect()
{
	if (UINT32(0x009424D7) == 1195412)
	{
		SRVersion = GAMEVER_PRERELEASE;
		WriteToLog(L"VersionDetect", L"Detected Saints Row: Gat out of Hell Prerelease.\n");
	}

	if (UINT32(0x007160FE) == 877048)
	{
		SRVersion = GAMEVER_STEAM_PATCH1;
		WriteToLog(L"VersionDetect", L"Detected Saints Row: Gat out of Hell Steam - Patch #1.\n");
	}

	if (UINT32(0x00715A6E) == 877048)
	{
		SRVersion = GAMEVER_STEAM_PATCH2;
		WriteToLog(L"VersionDetect", L"Detected Saints Row: Gat out of Hell Steam - Patch #2.\n");
	}

	if (UINT32(0x008F5F57) == 1116492)
	{
		SRVersion = GAMEVER_GOG;
		WriteToLog(L"VersionDetect", L"Detected Saints Row: Gat out of Hell GOG.\n");
	}
}