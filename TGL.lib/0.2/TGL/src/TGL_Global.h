#pragma once
#include <SDL3/SDL.h>
#include <memory>

#ifdef TGLEXPORTS
	#define TGLAPI __declspec(dllexport)
#else
	#define TGLAPI __declspec(dllimport)
#endif

namespace TGL
{
}
