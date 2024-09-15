#include <TGL.h>

using namespace TGL;

int main(int argc, char* argv[])
{
	Window wnd;
	wnd.Open(Size(360, 200), 1, 0xffffff, true);
	wnd.SetTitle("TGL Demo");

	Ptr<Graphics> gr = wnd.GetGraphics();

	Image img;
	img.Load("tileset.bmp");

	String block =
		"11111111"
		"10000001"
		"10111101"
		"10100101"
		"10100101"
		"10111101"
		"10000001"
		"11111111";

	gr->DrawPixelBlock(block, Point(1, 1), 0xff0000, 0xffff00, false, false);

	wnd.WaitClose();

	return 0;
}
