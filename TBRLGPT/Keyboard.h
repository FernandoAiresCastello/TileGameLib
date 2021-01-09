/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <SDL.h>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Key
	{
	public:
		static void Wait(int key);
		static int WaitAny();
		static bool Pressed(int key);
		static int GetKeyPressed();
		static void DiscardEvents();
		static void PumpEvents();
		static bool Shift();
		static bool Ctrl();
		static bool Alt();
		static bool CapsLock();
	};
}
