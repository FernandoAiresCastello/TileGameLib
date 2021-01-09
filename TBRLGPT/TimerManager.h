/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <map>
#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class Timer;

	class TBRLGPT_API TimerManager
	{
	public:
		static std::map<std::string, Timer*>* Timers;
		static int CycleDelay;
		
		TimerManager();
		TimerManager(int cycleDelay);
		~TimerManager();

		void AddTimer(std::string id, int max, void(*onInterval)() = NULL);
		Timer* GetTimer(std::string id);
		int GetTime(std::string id);
		void SetDelay(int ms);
		void Start();
		void Stop();
	};
}
