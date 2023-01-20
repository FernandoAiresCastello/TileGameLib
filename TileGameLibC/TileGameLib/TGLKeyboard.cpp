/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLKeyboard.h"

bool TGLKeyboard::right()
{
	return TKey::IsPressed(SDL_SCANCODE_RIGHT);
}
bool TGLKeyboard::left()
{
	return TKey::IsPressed(SDL_SCANCODE_LEFT);
}
bool TGLKeyboard::down()
{
	return TKey::IsPressed(SDL_SCANCODE_DOWN);
}
bool TGLKeyboard::up()
{
	return TKey::IsPressed(SDL_SCANCODE_UP);
}
bool TGLKeyboard::space()
{
	return TKey::IsPressed(SDL_SCANCODE_SPACE);
}
bool TGLKeyboard::enter()
{
	return TKey::IsPressed(SDL_SCANCODE_RETURN);
}
bool TGLKeyboard::esc()
{
	return TKey::IsPressed(SDL_SCANCODE_ESCAPE);
}
bool TGLKeyboard::ins()
{
	return TKey::IsPressed(SDL_SCANCODE_INSERT);
}
bool TGLKeyboard::del()
{
	return TKey::IsPressed(SDL_SCANCODE_DELETE);
}
bool TGLKeyboard::pgup()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEUP);
}
bool TGLKeyboard::pgdn()
{
	return TKey::IsPressed(SDL_SCANCODE_PAGEDOWN);
}
bool TGLKeyboard::home()
{
	return TKey::IsPressed(SDL_SCANCODE_HOME);
}
bool TGLKeyboard::end()
{
	return TKey::IsPressed(SDL_SCANCODE_END);
}
bool TGLKeyboard::pause()
{
	return TKey::IsPressed(SDL_SCANCODE_PAUSE);
}
bool TGLKeyboard::prtscr()
{
	return TKey::IsPressed(SDL_SCANCODE_PRINTSCREEN);
}
bool TGLKeyboard::tab()
{
	return TKey::IsPressed(SDL_SCANCODE_TAB);
}
bool TGLKeyboard::bs()
{
	return TKey::IsPressed(SDL_SCANCODE_BACKSPACE);
}
bool TGLKeyboard::f1()
{
	return TKey::IsPressed(SDL_SCANCODE_F1);
}
bool TGLKeyboard::f2()
{
	return TKey::IsPressed(SDL_SCANCODE_F2);
}
bool TGLKeyboard::f3()
{
	return TKey::IsPressed(SDL_SCANCODE_F3);
}
bool TGLKeyboard::f4()
{
	return TKey::IsPressed(SDL_SCANCODE_F4);
}
bool TGLKeyboard::f5()
{
	return TKey::IsPressed(SDL_SCANCODE_F5);
}
bool TGLKeyboard::f6()
{
	return TKey::IsPressed(SDL_SCANCODE_F6);
}
bool TGLKeyboard::f7()
{
	return TKey::IsPressed(SDL_SCANCODE_F7);
}
bool TGLKeyboard::f8()
{
	return TKey::IsPressed(SDL_SCANCODE_F8);
}
bool TGLKeyboard::f9()
{
	return TKey::IsPressed(SDL_SCANCODE_F9);
}
bool TGLKeyboard::f10()
{
	return TKey::IsPressed(SDL_SCANCODE_F10);
}
bool TGLKeyboard::f11()
{
	return TKey::IsPressed(SDL_SCANCODE_F11);
}
bool TGLKeyboard::f12()
{
	return TKey::IsPressed(SDL_SCANCODE_F12);
}
bool TGLKeyboard::pressed(string keyname)
{
	return TKey::IsPressed(keyname_to_scancode(keyname));
}
bool TGLKeyboard::shift()
{
	return TKey::Shift();
}
bool TGLKeyboard::ctrl()
{
	return TKey::Ctrl();
}
bool TGLKeyboard::alt()
{
	return TKey::Alt();
}
bool TGLKeyboard::capslock()
{
	return TKey::CapsLock();
}
SDL_Scancode TGLKeyboard::keyname_to_scancode(string keyname)
{
	keyname = String::ToUpper(keyname);

	if (keyname == "RIGHT") return SDL_SCANCODE_RIGHT;
	if (keyname == "LEFT") return SDL_SCANCODE_LEFT;
	if (keyname == "UP") return SDL_SCANCODE_UP;
	if (keyname == "DOWN") return SDL_SCANCODE_DOWN;
	if (keyname == "SPACE") return SDL_SCANCODE_SPACE;
	if (keyname == "ENTER") return SDL_SCANCODE_RETURN;
	if (keyname == "RETURN") return SDL_SCANCODE_RETURN;
	if (keyname == "ESC") return SDL_SCANCODE_ESCAPE;
	if (keyname == "INS") return SDL_SCANCODE_INSERT;
	if (keyname == "DEL") return SDL_SCANCODE_DELETE;
	if (keyname == "PGUP") return SDL_SCANCODE_PAGEUP;
	if (keyname == "PGDN") return SDL_SCANCODE_PAGEDOWN;
	if (keyname == "HOME") return SDL_SCANCODE_HOME;
	if (keyname == "END") return SDL_SCANCODE_END;
	if (keyname == "PAUSE") return SDL_SCANCODE_PAUSE;
	if (keyname == "PRTSCR") return SDL_SCANCODE_PRINTSCREEN;
	if (keyname == "TAB") return SDL_SCANCODE_TAB;
	if (keyname == "BS") return SDL_SCANCODE_BACKSPACE;
	if (keyname == "F1") return SDL_SCANCODE_F1;
	if (keyname == "F2") return SDL_SCANCODE_F2;
	if (keyname == "F3") return SDL_SCANCODE_F3;
	if (keyname == "F4") return SDL_SCANCODE_F4;
	if (keyname == "F5") return SDL_SCANCODE_F5;
	if (keyname == "F6") return SDL_SCANCODE_F6;
	if (keyname == "F7") return SDL_SCANCODE_F7;
	if (keyname == "F8") return SDL_SCANCODE_F8;
	if (keyname == "F9") return SDL_SCANCODE_F9;
	if (keyname == "F10") return SDL_SCANCODE_F10;
	if (keyname == "F11") return SDL_SCANCODE_F11;
	if (keyname == "F12") return SDL_SCANCODE_F12;
	if (keyname == "A") return SDL_SCANCODE_A;
	if (keyname == "B") return SDL_SCANCODE_B;
	if (keyname == "C") return SDL_SCANCODE_C;
	if (keyname == "D") return SDL_SCANCODE_D;
	if (keyname == "E") return SDL_SCANCODE_E;
	if (keyname == "F") return SDL_SCANCODE_F;
	if (keyname == "G") return SDL_SCANCODE_G;
	if (keyname == "H") return SDL_SCANCODE_H;
	if (keyname == "I") return SDL_SCANCODE_I;
	if (keyname == "J") return SDL_SCANCODE_J;
	if (keyname == "K") return SDL_SCANCODE_K;
	if (keyname == "L") return SDL_SCANCODE_L;
	if (keyname == "M") return SDL_SCANCODE_M;
	if (keyname == "N") return SDL_SCANCODE_N;
	if (keyname == "O") return SDL_SCANCODE_O;
	if (keyname == "P") return SDL_SCANCODE_P;
	if (keyname == "Q") return SDL_SCANCODE_Q;
	if (keyname == "R") return SDL_SCANCODE_R;
	if (keyname == "S") return SDL_SCANCODE_S;
	if (keyname == "T") return SDL_SCANCODE_T;
	if (keyname == "U") return SDL_SCANCODE_U;
	if (keyname == "V") return SDL_SCANCODE_V;
	if (keyname == "W") return SDL_SCANCODE_W;
	if (keyname == "X") return SDL_SCANCODE_X;
	if (keyname == "Y") return SDL_SCANCODE_Y;
	if (keyname == "Z") return SDL_SCANCODE_Z;
	if (keyname == "0") return SDL_SCANCODE_0;
	if (keyname == "1") return SDL_SCANCODE_1;
	if (keyname == "2") return SDL_SCANCODE_2;
	if (keyname == "3") return SDL_SCANCODE_3;
	if (keyname == "4") return SDL_SCANCODE_4;
	if (keyname == "5") return SDL_SCANCODE_5;
	if (keyname == "6") return SDL_SCANCODE_6;
	if (keyname == "7") return SDL_SCANCODE_7;
	if (keyname == "8") return SDL_SCANCODE_8;
	if (keyname == "9") return SDL_SCANCODE_9;
	if (keyname == "=") return SDL_SCANCODE_EQUALS;
	if (keyname == "+") return SDL_SCANCODE_EQUALS;
	if (keyname == "-") return SDL_SCANCODE_MINUS;
	if (keyname == "*") return SDL_SCANCODE_KP_MULTIPLY;
	if (keyname == "/") return SDL_SCANCODE_SLASH;
	if (keyname == "\\") return SDL_SCANCODE_BACKSLASH;
	if (keyname == ",") return SDL_SCANCODE_COMMA;
	if (keyname == ";") return SDL_SCANCODE_SEMICOLON;
	if (keyname == ".") return SDL_SCANCODE_PERIOD;
	if (keyname == "'") return SDL_SCANCODE_APOSTROPHE;

	return SDL_SCANCODE_UNKNOWN;
}
