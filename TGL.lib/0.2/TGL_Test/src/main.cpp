#include <TGL.h>
#include <SDL3/SDL_main.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Application app("TGL Demo");
	Window* wnd = app.GetWindow();
	wnd->Open(Size(360, 200), 2, 0xffffff, true);

	Graphics* gr = wnd->GetGraphics();

	TiledImage tileset;
	tileset.Load("tileset.bmp", 0xffffff);
	tileset.GenerateTiles(Size(16, 16));

	TileMap map;
	map.SetTileset(&tileset);
	map.SetSize(Size(23, 13));
	//map.SetPos(Point(11, 11));
	map.Fill(18);
	map.SetTileIndex(Point(0, 0), 3);

	Image img;
	img.Load("player.bmp", 0xffffff);

	Sprite spr;
	//spr.SetSingleImage(&img);
	spr.SetTileset(&tileset);
	spr.SetFrameSequence({1, 2});
	spr.SetPos(Point(100, 100));

	Charset chr;

	while (wnd->IsOpen()) {

		map.Draw(gr);
		spr.Draw(gr);
		spr.NextFrame();
		gr->DrawString(&chr, "Hello World!", Point(20, 20), Color(255, 0, 0), Color(255, 255, 0), false, false);
		
		app.Update();
	}

	return 0;
}
