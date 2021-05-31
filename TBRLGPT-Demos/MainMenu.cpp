#include "MainMenu.h"
#include "Demos.h"

#define WINDOW_TITLE "TBRLGPT Demos"

Graphics* Gr = new Graphics(256, 192, 3 * 256, 3 * 192, false);
UIContext* Ctx = new UIContext(Gr, 0xffffff, 0x000000);

void ShowMainMenu()
{
	Gr->SetWindowTitle(WINDOW_TITLE);

	bool running = true;

	ScrollingMenu* menu = new ScrollingMenu(Ctx, 1, 1, 15, 10, true, false);
	menu->AddItem("Demo 01", 1);
	menu->AddItem("Demo 02", 2);
	menu->AddItem("Demo 03", 3);
	menu->AddItem("Demo 04", 4);
	menu->AddItem("Quit", 99);

	while (running) {
		Ctx->BackColor = 0x000000;
		Ctx->Clear();
		Ctx->BackColor = 0x000080;
		MenuItem* selected = menu->Show();
		
		if (selected == NULL) {
			running = false;
			break;
		}

		Ctx->Clear();
		Gr->Update();

		switch (selected->GetId()) {
			case 1: Demo01(Ctx); break;
			case 2: Demo02(Ctx); break;
			case 3: Demo03(Ctx); break;
			case 4: Demo04(Ctx); break;
			case 99: running = false; break;
			default: break;
		}
	}

	delete menu;
	delete Ctx;
	delete Gr;
}
