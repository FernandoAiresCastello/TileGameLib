#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(Size(360, 200), 1, 0x201080, true);
	wnd.SetTitle("TGL Demo");

	Graphics* gr = wnd.GetGraphics();

	TiledImage img;
	img.Load("tileset.bmp");
	img.GenerateTiles(Size(16, 16));

	TileMap map;
	map.SetTileset(&img);
	map.SetSize(Size(21, 11));
	map.SetPos(Point(11, 11));
	map.Fill(18);
	map.SetTileIndex(Point(0, 0), 3);
	map.Draw(gr);

	wnd.WaitClose();

	return 0;
}
