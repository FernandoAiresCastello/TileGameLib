#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TGL_Internal
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
