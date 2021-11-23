/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TKey
	{
	public:
		static void Wait(SDL_Keycode key);
		static int WaitAny();
		static bool IsPressed(SDL_Scancode key);
		static int GetKeyPressed();
		static void DiscardEvents();
		static bool Shift();
		static bool Ctrl();
		static bool Alt();
		static bool CapsLock();
	};
}
