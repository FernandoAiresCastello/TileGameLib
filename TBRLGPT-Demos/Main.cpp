#include <SDL.h>
#include <TBRLGPT.h>
#include "MainMenu.h"

using namespace TBRLGPT;

int main(int argc, char** args)
{
	TimerManager::Init();
	ShowMainMenu();
	TimerManager::Destroy();

	return 0;
}
