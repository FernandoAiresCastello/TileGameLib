#pragma once
#include <SDL.h>

#ifdef TGLEXPORTS
	#define TGLAPI __declspec(dllexport)
#else
	#define TGLAPI __declspec(dllimport)
#endif
