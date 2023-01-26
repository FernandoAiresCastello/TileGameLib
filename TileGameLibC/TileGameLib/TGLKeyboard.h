/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

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
	bool shift();
	bool ctrl();
	bool alt();
	bool caps();
	int last_kcode();
	string last_kname();
	bool last_kname(string name);
	void clear_last();

private:
	friend class TGL;

	SDL_Keycode last_key_pressed = 0;

	bool key(SDL_Scancode key);
	bool key_mod(SDL_Keymod key);
	void key_store_last(SDL_Keycode key);
	int key_get_last_code(bool keep);
	string key_get_last_name(bool keep);
};
