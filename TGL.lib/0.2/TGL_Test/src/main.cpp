#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(Size(640, 480), 0, 0x101010, true);
	wnd.SetTitle("TGL Demo");

	Image img;
	img.Load("tileset.bmp");
	wnd.DrawImageTile(&img, Rect(0, 0, 15, 15), Point(0, 0));
	//wnd.DrawImage(&img, Point(0, 0));
	wnd.WaitClose();

	return 0;
}
