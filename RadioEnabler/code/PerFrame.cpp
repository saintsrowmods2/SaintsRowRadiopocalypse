#include <Windows.h>

#include <stdio.h>

#include "config.hpp"
#include "PerFrame.hpp"
#include "Log.hpp"

unsigned char* Option_PauseOnFocusLost = NULL;
GAME_DO_FRAME game_do_frame = NULL;

bool hasSetPauseOnFocusLost = false;

BOOL __cdecl perFrameHook(void)
{
	BOOL retVal = game_do_frame();

	if (!hasSetPauseOnFocusLost)
	{
		*Option_PauseOnFocusLost = (char)(PauseOnFocusLost ? 1 : 0);
		//hasSetPauseOnFocusLost = true;
		//WriteToLog(L"PerFrameHook", L"Set PauseOnFocusLost = %hhu\n", PauseOnFocusLost);
	}

	return game_do_frame();
}