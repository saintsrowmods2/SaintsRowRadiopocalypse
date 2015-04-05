#include <Windows.h>

#include <stdio.h>

#include "config.hpp"
#include "PerFrame.hpp"
#include "Log.hpp"

unsigned char* Option_PauseOnFocusLost = NULL;
GAME_DO_FRAME game_do_frame = NULL;

#define UINT32(x) (*(unsigned int *)x)

BOOL __cdecl perFrameHook(void)
{
	BOOL retVal = game_do_frame();

	*Option_PauseOnFocusLost = (char)(PauseOnFocusLost ? 1 : 0);
	
	return retVal;
}