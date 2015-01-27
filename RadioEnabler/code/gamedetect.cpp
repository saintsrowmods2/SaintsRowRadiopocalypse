#include <stdio.h>
#include <Windows.h>

#include "gamedetect.hpp"

#define UINT32(x) (*(unsigned int *)x)

INT SRVersion = 0;

VOID VersionDetect()
{
	if (UINT32(0x007160FE) == 877048)
	{
		SRVersion = 877048;
		wprintf(L"Detected Saints Row: Gat out of Hell Steam - Patch #1.\n");
	}
}