#include <SDL.h>
#include <TBRLGPT.h>

using namespace TBRLGPT;

int main(int argc, char** args)
{
	Project* proj = new Project();
	proj->Load("data/demos.tgpro");
	auto maps = proj->GetMaps();
	int mapIndex = 0;
	Map* map = maps[mapIndex];
	int zoom = 3;
	Graphics* gr = new Graphics(256, 192, zoom * 256, zoom * 192, false);
	UIContext* ctx = new UIContext(gr, 0xffffff, 0x000000);
	MapViewport* view = new MapViewport(ctx, map, 0, 0, 32, 24, 0, 0, 10);

	bool running = true;
	while (running) {
		view->Draw();
		gr->Update();
		
		SDL_Event e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_QUIT) {
			running = false;
		}
		else if (e.type == SDL_KEYDOWN) {
			auto key = e.key.keysym.sym;
			if (key == SDLK_ESCAPE) {
				running = false;
			}
			else if (key == SDLK_RIGHT) {
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
	}

	return 0;
}
