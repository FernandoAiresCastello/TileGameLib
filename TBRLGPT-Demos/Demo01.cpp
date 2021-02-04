#include "Demos.h"

void Demo01(UIContext* ctx)
{
	Project* proj = new Project();
	Palette* pal = proj->GetPalette();
	Charset* chr = proj->GetCharset();
	Graphics* gr = ctx->Gr;

	pal->Set(0, 0x000000);
	pal->Set(1, 0xff0000);
	pal->Set(2, 0x00ff00);
	pal->Set(3, 0x0000ff);
	pal->Set(4, 0x202020);
	pal->Set(5, 0xffffff);

	chr->SetChar(1,
		"11111111",
		"10000001",
		"10000001",
		"10000001",
		"10000001",
		"10000001",
		"10000001",
		"11111111");

	Map* map = new Map(proj, "test", 32, 24, 1);
	map->SetBackColor(3);
	Object oob = Object(ObjectChar(0, 0, 0));
	map->SetOutOfBoundsObject(oob);
	Object objTest = Object(ObjectChar(1, 2, 3));
	objTest.SetProperty("type", "test");
	map->SetObject(objTest, 5, 5, 0);
	ObjectController ctl = ObjectController(map, "type", "test");

	MapViewport* view = new MapViewport(ctx, map, 0, 0, 32, 24, 0, 0, 100);

	bool running = true;
	while (running) {
		view->Draw();
		gr->Update();

		SDL_Event e = { 0 };
		SDL_PollEvent(&e);

		if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (Key::Ctrl()) {
				if (key == SDLK_RIGHT) {
					view->ScrollView(1, 0);
				}
				else if (key == SDLK_LEFT) {
					view->ScrollView(-1, 0);
				}
				else if (key == SDLK_UP) {
					view->ScrollView(0, -1);
				}
				else if (key == SDLK_DOWN) {
					view->ScrollView(0, 1);
				}
			}
			else {
				if (key == SDLK_ESCAPE) {
					running = false;
				}
				else if (key == SDLK_RIGHT) {
					ctl.MoveDist(1, 0);
				}
				else if (key == SDLK_LEFT) {
					ctl.MoveDist(-1, 0);
				}
				else if (key == SDLK_UP) {
					ctl.MoveDist(0, -1);
				}
				else if (key == SDLK_DOWN) {
					ctl.MoveDist(0, 1);
				}
			}
		}
	}

	delete view;
	delete proj;
}
