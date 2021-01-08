/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include <SDL.h>
#include "TimerManager.h"
#include "Timer.h"

namespace TBRLGPT
{
	int TimerManager::CycleDelay = 10;
	std::map<std::string, Timer*>* TimerManager::Timers = new std::map<std::string, Timer*>();
	SDL_Thread* Thread;
	bool Running = false;
	bool Detached = false;

	static int Tick(void* data)
	{
		while (!Detached) {
			if (Running) {
				for (auto it = TimerManager::Timers->begin(); it != TimerManager::Timers->end(); it++)
					it->second->Step();

				SDL_Delay(TimerManager::CycleDelay);
			}
		}

		return 0;
	}

	TimerManager::TimerManager() : TimerManager(0)
	{
	}

	TimerManager::TimerManager(int cycleDelay)
	{
		CycleDelay = cycleDelay;
		Thread = SDL_CreateThread(Tick, "Tick", NULL);
	}

	TimerManager::~TimerManager()
	{
		SDL_DetachThread(Thread);
		Detached = true;

		for (auto it = TimerManager::Timers->begin(); it != TimerManager::Timers->end(); it++)
			delete it->second;

		delete TimerManager::Timers;
	}

	void TimerManager::Start()
	{
		Running = true;
	}

	void TimerManager::Stop()
	{
		Running = false;
	}

	void TimerManager::AddTimer(std::string id, int max, void(*onInterval)())
	{
		(*Timers)[id] = new Timer(max, onInterval);
	}

	Timer* TimerManager::GetTimer(std::string id)
	{
		return (*Timers)[id];
	}

	int TimerManager::GetTime(std::string id)
	{
		return (*Timers)[id]->GetTime();
	}

	void TimerManager::SetDelay(int ms)
	{
		CycleDelay = ms >= 0 ? ms : 0;
	}
}
