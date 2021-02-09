#include "Demos.h"

void Demo03(UIContext* ctx)
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
	MapViewport* view = new MapViewport(ctx, map, 0, 0, 32, 24, 0, 0, 100);

	ObjectController ctlPlayer = ObjectController(map, "type", "player");
	ObjectController ctlEnemy = ObjectController(map, "type", "enemy");

	bool enemyTurn = false;
	bool running = true;
	while (running) {

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
				ctlPlayer.MoveDist(1, 0);
				enemyTurn = true;
			}
			else if (key == SDLK_LEFT) {
				ctlPlayer.MoveDist(-1, 0);
				enemyTurn = true;
			}
			else if (key == SDLK_UP) {
				ctlPlayer.MoveDist(0, -1);
				enemyTurn = true;
			}
			else if (key == SDLK_DOWN) {
				ctlPlayer.MoveDist(0, 1);
				enemyTurn = true;
			}
		}

		if (enemyTurn) {
			if (Util::RandomChance(10)) {
				ctlEnemy.MoveDist(-1, 0);
			}
			else if (Util::RandomChance(10)) {
				ctlEnemy.MoveDist(1, 0);
			}
			else if (Util::RandomChance(10)) {
				ctlEnemy.MoveDist(0, -1);
			}
			else if (Util::RandomChance(10)) {
				ctlEnemy.MoveDist(0, 1);
			}
			enemyTurn = false;
		}
	}

	delete view;
	delete proj;
}
