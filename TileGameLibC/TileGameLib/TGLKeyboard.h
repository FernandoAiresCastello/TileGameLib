/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TileGameLib.h"
using namespace std;
using namespace TileGameLib;

struct TGLKeyboard
{
	bool right();
	bool left();
	bool down();
	bool up();
	bool space();
	bool enter();
	bool esc();
	bool ins();
	bool del();
	bool pgup();
	bool pgdn();
	bool home();
	bool end();
	bool pause();
	bool prtscr();
	bool tab();
	bool bs();
	bool f1();
	bool f2();
	bool f3();
	bool f4();
	bool f5();
	bool f6();
	bool f7();
	bool f8();
	bool f9();
	bool f10();
	bool f11();
	bool f12();
	bool pressed(string keyname);
	bool shift();
	bool ctrl();
	bool alt();
	bool capslock();

	SDL_Scancode keyname_to_scancode(string keyname);
};
