#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TSound* snd = new TSound();

	snd->PlayMainSound("440 300 550 200 660 100");
	int i = 0;
	while (true) {
		SDL_Delay(3875);
		snd->PlaySubSound("770 300");
		i++;
		if (i == 4)
			snd->StopMainSound();
	}

	return 0;
}
