#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	TGL_Window wnd;
	wnd.Open(256, 192, 4, 3, 0x101010, true);
	wnd.SetTitle("TGL Demo");

	TGL_Image img;
	img.Load("tileset.bmp");
	wnd.DrawImage(&img, 0, 0);
	wnd.WaitClose();

	return 0;
}
