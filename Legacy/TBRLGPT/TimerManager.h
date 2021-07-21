/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class Timer;

	class TBRLGPT_API TimerManager
	{
	public:
		static void Init();
		static void Destroy();
		static void SetThreadDelay(int ms);
		static void AddTimer(std::string id, int max, void(*onInterval)() = NULL);
		static void RemoveTimer(std::string id);
		static Timer* GetTimer(std::string id);
		static int GetTime(std::string id);
	};
}
