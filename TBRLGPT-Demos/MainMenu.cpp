#include "MainMenu.h"
#include "Demo01.h"

void ShowMainMenu()
{
	bool running = true;

	ScrollingMenu* menu = new ScrollingMenu(Global::Ctx);
	menu->AddItem("Demo 01", 1);
	menu->AddItem("Quit", 99);

	while (running) {
		Global::Ctx->Clear();
		MenuItem* selected = menu->Show("TBRLGPT Demos", 0, 0, Global::Gr->Cols-3, Global::Gr->Rows-2, true, false);
		
		if (selected == NULL) {
			running = false;
			break;
		}

		switch (selected->GetId()) {
			case 1: Demo01(); break;
			case 99: running = false; break;
			default: break;
		}
	}

	delete menu;
}
