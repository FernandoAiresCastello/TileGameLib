#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TSound* snd = new TSound();

	snd->SetType(TSoundType::Noise);
	//snd->SetVolume(255);
	snd->PlayMainSound("C4 300 D4 300 E4 300 F4 300 G4 300 A4 300 B4 300");
	
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
