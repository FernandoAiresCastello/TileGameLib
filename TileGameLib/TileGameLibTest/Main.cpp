#include <SDL.h>
#include <TileGameLib.h>
using namespace TileGameLib;

int main(int argc, char* argv[])
{
	TWindow* wnd = new TWindow(256, 192, 3, false);
	wnd->SetBackColor(14);
	wnd->Clear();

	int x = 0;
	int y = 0;

	for (int i = 0; i < TPalette::Default->GetSize(); i++) {
		wnd->DrawTile('G', i, 0, x * 8, y * 8, false);
		x++;
		if (x >= 16) {
			x = 0;
			y++;
		}
	}

	wnd->Update();

	TKey::WaitAny();

	delete wnd;
	return 0;
}
