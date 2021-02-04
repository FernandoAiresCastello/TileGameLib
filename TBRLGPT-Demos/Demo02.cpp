#include "Demos.h"

void Demo02(UIContext* ctx)
{
	Project* proj = new Project();
	Palette* pal = proj->GetPalette();
	Charset* chr = proj->GetCharset();
	Graphics* gr = ctx->Gr;

	gr->Clear(0x000000);
	gr->Print(ctx->Chars, 1, 1, 0xffffff, 0x000000, "Loading...");
	gr->Update();
	proj->Load("data/demos.tgpro");

	auto maps = proj->GetMaps();
	int mapIndex = 0;
	MapViewport* view = new MapViewport(ctx, maps[mapIndex], 0, 1, gr->Cols, gr->Rows-1, 0, 0, 100);

	bool running = true;
	while (running) {
		ctx->SetColor(0xffffff, 0x000000);
		ctx->Print(0, 0, view->GetMap()->GetName());
		view->Draw();
		gr->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);

		if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				running = false;
			}
			else if (key == SDLK_RIGHT) {
				if (mapIndex < maps.size() - 1)
					mapIndex++;
				else
					mapIndex = 0;
			}
			else if (key == SDLK_LEFT) {
				if (mapIndex > 0)
					mapIndex--;
				else
					mapIndex = maps.size() - 1;
			}
			view->SetMap(maps[mapIndex]);
		}
	}

	delete view;
	delete proj;
}
