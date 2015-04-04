#pragma once

#include <Windows.h>

extern BOOL __cdecl perFrameHook(void);

typedef BOOL (__cdecl *GAME_DO_FRAME)(void);
extern GAME_DO_FRAME game_do_frame;

extern unsigned char* Option_PauseOnFocusLost;