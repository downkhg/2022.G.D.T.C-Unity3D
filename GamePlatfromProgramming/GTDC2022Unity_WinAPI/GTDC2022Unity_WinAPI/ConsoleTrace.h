#pragma once

#include <Windows.h>
#include <stdio.h>
#include <conio.h>
#include <crtdbg.h>
#include <stdarg.h>
#include <string.h>

void ConsoleInit()
{
	AllocConsole();
}

void ConsoleRelease()
{
	FreeConsole();
}

void ConsoleTRACE(const char* format, ...)
{
	char szBuf[1024];
	va_list args;
	va_start(args, format);
	_vsnprintf_s(szBuf, sizeof(szBuf), format, args);
	va_end(args);

	_cprintf(szBuf);
}