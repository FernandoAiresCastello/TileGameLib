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
	wnd->SetPixelSize(4, 2);
	//wnd->DrawTileString("Hello World!", 15, 40, 0, 0, false, false);
	//wnd->DrawTileString("Hello World!", 14, 43, 1, 1, false, false);
	wnd->DrawTile('A', 15, 40, 1, 1, false, true);
	wnd->DrawTile('B', 15, 40, 2, 2, false, true);
	wnd->Update();
	TKey::WaitAny();

	wnd->EraseTile(1, 1, true);
	wnd->Update();
	TKey::WaitAny();

	wnd->EraseTile(2, 2, true);
	wnd->Update();
	TKey::WaitAny();

	delete wnd;
	return 0;
}
