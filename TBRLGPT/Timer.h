/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Timer
	{
	public:
		Timer(int max, void(*callback)() = NULL);
		~Timer();

		int GetTime();
		void Step();
		void OnInterval(void(*callback)());

	private:
		int Time;
		int MaxTime;
		void(*Callback)();
	};
}
