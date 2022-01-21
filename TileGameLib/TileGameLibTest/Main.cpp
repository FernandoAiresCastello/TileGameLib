#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TWindow* wnd = new TWindow(640, 480, 1, false);
	wnd->SetBackColor(50);
	wnd->Clear();
	wnd->SetPixelSize(4, 4);
	wnd->DrawTileString("Hello World!", 15, 40, 0, 0, false);
	
	TPixelBlock block(10, 4);
	block.Fill(205);

	wnd->DrawPixelBlock(&block, 10, 10);
	wnd->Update();

	TKey::WaitAny();
	delete wnd;
	return 0;
}
