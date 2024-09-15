#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(Size(360, 200), 1, 0xffffff, true);
	wnd.SetTitle("TGL Demo");

	Graphics* gr = wnd.GetGraphics();

	TiledImage img;
	img.Load("tileset.bmp");
	img.GenerateTiles(Size(16, 16));
	
	Sprite spr;
	spr.SetTileset(&img);
	spr.SetFrameSequence({0, 7, 3});
	spr.NextFrame();
	spr.Draw(gr);

	wnd.WaitClose();

	return 0;
}
