#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(Size(360, 200), 1, 0xffffff, true);
	wnd.SetTitle("TGL Demo");

	Ptr<Graphics> gr = wnd.GetGraphics();

	TiledImage img;
	img.Load("tileset.bmp");
	img.GenerateTiles(Size(16, 16));
	
	gr->DrawImage(img.GetTile(img.GetTileCount() - 1), Point(100, 100));

	wnd.WaitClose();

	return 0;
}
