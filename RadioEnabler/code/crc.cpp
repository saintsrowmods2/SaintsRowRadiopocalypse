#include <stdio.h>
#include <Windows.h>

#include "crc.hpp"

ULONG crc32_table[256];
INT EXE_CRC = 0;

BOOL CheckExecutable()
{

	HMODULE module = GetModuleHandle(NULL);
	WCHAR fileName[MAX_PATH];
	GetModuleFileNameW(module, fileName, MAX_PATH);
	HANDLE fp = CreateFileW(fileName, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL);
	DWORD exeLength = GetFileSize(fp, NULL);
	LPVOID* buffer = (LPVOID*)GlobalAlloc(0, exeLength);
	
	DWORD totalBytesRead = 0, bytesRead = 0;
	while (totalBytesRead < exeLength)
	{
		if (!ReadFile(fp, buffer + totalBytesRead, exeLength - totalBytesRead, &bytesRead, NULL))
		{
			CloseHandle(fp);
			return false;
		}
		totalBytesRead += bytesRead;
	}
	CloseHandle(fp);

	Init_CRC32_Table();
	EXE_CRC = Get_CRC((char*)buffer, exeLength);
	GlobalFree(buffer);
	
	switch (EXE_CRC)
	{
		case CRC_STEAM_PATCH_1:
			wprintf(L"Detected Gat Out Of Hell Steam - Patch #1.\n");
			return true;
	}

	wprintf(L"Unknown EXE CRC: 0x%08X\n", EXE_CRC);
	return false;
}

VOID Init_CRC32_Table()
{// Call this function only once to initialize the CRC table. 

	// This is the official polynomial used by CRC-32 
	// in PKZip, WinZip and Ethernet. 
	ULONG ulPolynomial = 0x04c11db7;

	// 256 values representing ASCII character codes. 
	for (int i = 0; i <= 0xFF; i++)
	{
		crc32_table[i] = Reflect(i, 8) << 24;
		for (int j = 0; j < 8; j++)
			crc32_table[i] = (crc32_table[i] << 1) ^ (crc32_table[i] & (1 << 31) ? ulPolynomial : 0);
		crc32_table[i] = Reflect(crc32_table[i], 32);
	}
}

ULONG Reflect(ULONG ref, CHAR ch)
{// Used only by Init_CRC32_Table(). 

	ULONG value(0);

	// Swap bit 0 for bit 7 
	// bit 1 for bit 6, etc. 
	for (int i = 1; i < (ch + 1); i++)
	{
		if (ref & 1)
			value |= 1 << (ch - i);
		ref >>= 1;
	}
	return value;
}

INT Get_CRC(CHAR* text, INT len)
{// Pass a text string to this function and it will return the CRC. 

	// Once the lookup table has been filled in by the two functions above, 
	// this function creates all CRCs using only the lookup table. 

	// Be sure to use unsigned variables, 
	// because negative values introduce high bits 
	// where zero bits are required. 

	// Start out with all bits set high. 
	ULONG  ulCRC(0xffffffff);
	UCHAR* buffer;

	// Save the text in the buffer. 
	buffer = (UCHAR*)text;
	// Perform the algorithm on each character 
	// in the string, using the lookup table values. 
	while (len--)
		ulCRC = (ulCRC >> 8) ^ crc32_table[(ulCRC & 0xFF) ^ *buffer++];
	// Exclusive OR the result with the beginning value. 
	return ulCRC ^ 0xffffffff;
}