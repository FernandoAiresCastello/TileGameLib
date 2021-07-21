/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <SDL.h>
#include <map>
#include "TimerManager.h"
#include "Timer.h"

namespace TBRLGPT
{
	std::map<std::string, Timer> Timers;
	SDL_Thread* Thread = NULL;
	bool TimersRunning;
	int ThreadDelay = 1;

	int Tick(void* data)
	{
		while (TimersRunning) {
			for (auto it = Timers.begin(); it != Timers.end(); it++)
				it->second.Step();

			SDL_Delay(ThreadDelay);
		}

		return 0;
	}

	void TimerManager::Init()
	{
		if (!TimersRunning) {
			TimersRunning = true;
			Timers = std::map<std::string, Timer>();
			Thread = SDL_CreateThread(Tick, "Tick", NULL);
		}
	}

	void TimerManager::Destroy()
	{
		TimersRunning = false;
		Timers.clear();
		SDL_DetachThread(Thread);
		Thread = NULL;
	}

	void TimerManager::SetThreadDelay(int ms)
	{
		ThreadDelay = ms;
	}

	void TimerManager::AddTimer(std::string id, int max, void(*onInterval)())
	{
		Timers[id] = Timer(max, onInterval);
	}

	void TimerManager::RemoveTimer(std::string id)
	{
		auto timer = Timers.find(id);
		Timers.erase(timer);
	}

	Timer* TimerManager::GetTimer(std::string id)
	{
		return &(Timers[id]);
	}

	int TimerManager::GetTime(std::string id)
	{
		return Timers[id].GetTime();
	}
}
