#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TSound* snd = new TSound();

	//snd->SetType(TSoundType::Noise);
	//snd->SetVolume(255);
	snd->PlayMainSound("C4 100 P 1 D4 100 P 100 E4 100 P 200 F4 100 P 300 G4 100 P 400 A4 100 P 50 B4 200 P 1000");
	
	while (true) {
		//snd->PlaySubSound("C4 600");
		//SDL_Delay(1000);
	}
	/*
	int i = 0;
	while (true) {
		SDL_Delay(3875);
		snd->PlaySubSound("770 300");
		i++;
		if (i == 4)
			snd->StopMainSound();
	}
	*/
	return 0;
}
