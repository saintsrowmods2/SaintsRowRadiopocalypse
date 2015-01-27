#pragma once

#include <Windows.h>

#define CRC_STEAM_PATCH_1 0x0EAEEFB7

extern BOOL CheckExecutable();
extern INT EXE_CRC;

extern ULONG crc32_table[256];  // Lookup table array 
extern VOID Init_CRC32_Table();  // Builds lookup table array 
extern ULONG Reflect(ULONG ref, CHAR ch);  // Reflects CRC bits in the lookup table 
extern INT Get_CRC(CHAR* text, INT len);