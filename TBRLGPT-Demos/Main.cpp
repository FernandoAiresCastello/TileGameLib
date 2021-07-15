#include <SDL.h>
#include <TBRLGPT.h>
#include "MainMenu.h"
#include "Demos.h"

using namespace TBRLGPT;

Graphics* Gr = new Graphics(256, 192, 3 * 256, 3 * 192, false);
UIContext* Ctx = new UIContext(Gr, 0xffffff, 0x000000);

int main(int argc, char** args)
{
	TimerManager::Init();
	//ShowMainMenu(Ctx);
	Demo05(Ctx);
	TimerManager::Destroy();

	delete Ctx;
	delete Gr;

	return 0;
}
