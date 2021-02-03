#include <SDL.h>
#include "Global.h"
#include "MainMenu.h"

int main(int argc, char** args)
{
	Global::Init();
	ShowMainMenu();
	Global::Destroy();
	return 0;
}
