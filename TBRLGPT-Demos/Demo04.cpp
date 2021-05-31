#include "Demos.h"

void Demo04(UIContext* ctx)
{
	Project* proj = new Project();
	Palette* pal = proj->GetPalette();
	Charset* chr = proj->GetCharset();
	Graphics* gr = ctx->Gr;

	gr->Clear(0x000000);
	gr->Print(ctx->Chars, 1, 1, 0xffffff, 0x000000, "Loading...");
	gr->Update();
	proj->Load("data/demos.tgpro");

	Map* map = proj->FindMapByName("demo03");
	Map* stats = proj->FindMapByName("stats");
	MapViewport* mapView = new MapViewport(ctx, map, 0, 0, 32, 24, 0, 0, 10);
	MapViewport* statsView = new MapViewport(ctx, stats, 0, 20, 32, 4, 0, 0, 100);

	bool running = true;
	while (running) {

		mapView->Draw();
		statsView->Draw();
		gr->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);

		if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				running = false;
			}
		}
	}

	delete mapView;
	delete statsView;
	delete proj;
}
