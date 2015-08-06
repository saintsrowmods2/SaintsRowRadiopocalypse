#pragma unmanaged

#include <Windows.h>

#include <stdio.h>

#include "config.hpp"
#include "PerFrame.hpp"
#include "Log.hpp"
#include "DebugWindow.hpp"

unsigned char* Option_PauseOnFocusLost = NULL;
GAME_DO_FRAME game_do_frame = NULL;

#define UINT32(x) (*(unsigned int *)x)

BOOL __cdecl perFrameHook(void)
{
	BOOL retVal = game_do_frame();

	*Option_PauseOnFocusLost = (char)(PauseOnFocusLost ? 1 : 0);

	UpdateDebugWindow();

	// hack radio controls
	//unsigned int playerAddress = UINT32(0x2E597FC);
	//if (playerAddress)
	//{
		//unsigned int* orbsBanked = (unsigned int*)(playerAddress + 0x36EC);
		//unsigned int* controls_general_allowed = (unsigned int*)(playerAddress + 0x2E38);
		//unsigned int* radioTimestamp = (unsigned int*)(playerAddress + 0x254C);
		//unsigned int* timestampTicker = (unsigned int*)(0x016b5040);
		//unsigned char* radioStationId = (unsigned char*)(playerAddress + 0x2A7A);
		//wprintf(L"radio_station_id: %hhd\n", *radioStationId);
	//}

	return retVal;
}