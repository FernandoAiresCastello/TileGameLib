#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(320, 240, 1, 1, 0x101010, true);
	wnd.SetTitle("TGL Demo");

	Image img;
	img.Load("tileset.bmp");
	wnd.DrawImage(&img, 0, 0);
	wnd.WaitClose();

	return 0;
}
