#include "TGLKeyboard.h"

bool TGLKeyboard::right()
{
	return key(SDL_SCANCODE_RIGHT);
}
bool TGLKeyboard::left()
{
	return key(SDL_SCANCODE_LEFT);
}
bool TGLKeyboard::down()
{
	return key(SDL_SCANCODE_DOWN);
}
bool TGLKeyboard::up()
{
	return key(SDL_SCANCODE_UP);
}
bool TGLKeyboard::space()
{
	return key(SDL_SCANCODE_SPACE);
}
bool TGLKeyboard::enter()
{
	return key(SDL_SCANCODE_RETURN);
}
bool TGLKeyboard::esc()
{
	return key(SDL_SCANCODE_ESCAPE);
}
bool TGLKeyboard::ins()
{
	return key(SDL_SCANCODE_INSERT);
}
bool TGLKeyboard::del()
{
	return key(SDL_SCANCODE_DELETE);
}
bool TGLKeyboard::pgup()
{
	return key(SDL_SCANCODE_PAGEUP);
}
bool TGLKeyboard::pgdn()
{
	return key(SDL_SCANCODE_PAGEDOWN);
}
bool TGLKeyboard::home()
{
	return key(SDL_SCANCODE_HOME);
}
bool TGLKeyboard::end()
{
	return key(SDL_SCANCODE_END);
}
bool TGLKeyboard::pause()
{
	return key(SDL_SCANCODE_PAUSE);
}
bool TGLKeyboard::prtscr()
{
	return key(SDL_SCANCODE_PRINTSCREEN);
}
bool TGLKeyboard::tab()
{
	return key(SDL_SCANCODE_TAB);
}
bool TGLKeyboard::bs()
{
	return key(SDL_SCANCODE_BACKSPACE);
}
bool TGLKeyboard::f1()
{
	return key(SDL_SCANCODE_F1);
}
bool TGLKeyboard::f2()
{
	return key(SDL_SCANCODE_F2);
}
bool TGLKeyboard::f3()
{
	return key(SDL_SCANCODE_F3);
}
bool TGLKeyboard::f4()
{
	return key(SDL_SCANCODE_F4);
}
bool TGLKeyboard::f5()
{
	return key(SDL_SCANCODE_F5);
}
bool TGLKeyboard::f6()
{
	return key(SDL_SCANCODE_F6);
}
bool TGLKeyboard::f7()
{
	return key(SDL_SCANCODE_F7);
}
bool TGLKeyboard::f8()
{
	return key(SDL_SCANCODE_F8);
}
bool TGLKeyboard::f9()
{
	return key(SDL_SCANCODE_F9);
}
bool TGLKeyboard::f10()
{
	return key(SDL_SCANCODE_F10);
}
bool TGLKeyboard::f11()
{
	return key(SDL_SCANCODE_F11);
}
bool TGLKeyboard::f12()
{
	return key(SDL_SCANCODE_F12);
}
bool TGLKeyboard::shift()
{
	return key_mod(KMOD_RSHIFT) || key_mod(KMOD_LSHIFT);
}
bool TGLKeyboard::ctrl()
{
	return key_mod(KMOD_RCTRL) || key_mod(KMOD_LCTRL);
}
bool TGLKeyboard::alt()
{
	return key_mod(KMOD_RALT) || key_mod(KMOD_LALT);
}
bool TGLKeyboard::caps()
{
	return key_mod(KMOD_CAPS);
}
int TGLKeyboard::last_kcode()
{
	return key_get_last_code(true);
}
string TGLKeyboard::last_kname()
{
	return key_get_last_name(true);
}
bool TGLKeyboard::last_kname(string name)
{
	string key_lower = String::ToLower(last_kname());
	string name_lower = String::ToLower(name);
	return key_lower == name_lower;
}
void TGLKeyboard::clear_last()
{
	last_key_pressed = 0;
}
bool TGLKeyboard::key(SDL_Scancode key)
{
	SDL_PumpEvents();
	return SDL_GetKeyboardState(NULL)[key];
}

bool TGLKeyboard::key_mod(SDL_Keymod key)
{
	return SDL_GetModState() & key;
}

void TGLKeyboard::key_store_last(SDL_Keycode key)
{
	last_key_pressed = key;
}

int TGLKeyboard::key_get_last_code(bool keep)
{
	SDL_Keycode key = last_key_pressed;
	if (!keep) 
		last_key_pressed = 0;

	return key;
}

string TGLKeyboard::key_get_last_name(bool keep)
{
	SDL_Keycode key = key_get_last_code(keep);

	switch (key) {
		case 0: return "NONE";
		case SDLK_RIGHT: return "RIGHT";
		case SDLK_LEFT: return "LEFT";
		case SDLK_UP: return "UP";
		case SDLK_DOWN: return "DOWN";
		case SDLK_SPACE: return "SPACE";
		case SDLK_RETURN: 
		case SDLK_RETURN2: 
		case SDLK_KP_ENTER: return "ENTER";
		case SDLK_LCTRL:
		case SDLK_RCTRL: return "CTRL";
		case SDLK_LSHIFT:
		case SDLK_RSHIFT: return "SHIFT";
		case SDLK_LALT:
		case SDLK_RALT: return "ALT";
		case SDLK_CAPSLOCK: return "CAPS";
		case SDLK_TAB: return "TAB";
		case SDLK_BACKSPACE: return "BS";
		case SDLK_INSERT: return "INS";
		case SDLK_DELETE: return "DEL";
		case SDLK_HOME: return "HOME";
		case SDLK_END: return "END";
		case SDLK_PAGEUP: return "PGUP";
		case SDLK_PAGEDOWN: return "PGDN";
		case SDLK_ESCAPE: return "ESC";
		case SDLK_F1: return "F1";
		case SDLK_F2: return "F2";
		case SDLK_F3: return "F3";
		case SDLK_F4: return "F4";
		case SDLK_F5: return "F5";
		case SDLK_F6: return "F6";
		case SDLK_F7: return "F7";
		case SDLK_F8: return "F8";
		case SDLK_F9: return "F9";
		case SDLK_F10: return "F10";
		case SDLK_F11: return "F11";
		case SDLK_F12: return "F12";
		case SDLK_a: return "A";
		case SDLK_b: return "B";
		case SDLK_c: return "C";
		case 231: return "Ç";
		case SDLK_d: return "D";
		case SDLK_e: return "E";
		case SDLK_f: return "F";
		case SDLK_g: return "G";
		case SDLK_h: return "H";
		case SDLK_i: return "I";
		case SDLK_j: return "J";
		case SDLK_k: return "K";
		case SDLK_l: return "L";
		case SDLK_m: return "M";
		case SDLK_n: return "N";
		case SDLK_o: return "O";
		case SDLK_p: return "P";
		case SDLK_q: return "Q";
		case SDLK_r: return "R";
		case SDLK_s: return "S";
		case SDLK_t: return "T";
		case SDLK_u: return "U";
		case SDLK_v: return "V";
		case SDLK_w: return "W";
		case SDLK_x: return "X";
		case SDLK_y: return "Y";
		case SDLK_z: return "Z";
		case SDLK_0: 
		case SDLK_KP_0: return "0";
		case SDLK_1: 
		case SDLK_KP_1: return "1";
		case SDLK_2: 
		case SDLK_KP_2: return "2";
		case SDLK_3: 
		case SDLK_KP_3: return "3";
		case SDLK_4: 
		case SDLK_KP_4: return "4";
		case SDLK_5: 
		case SDLK_KP_5: return "5";
		case SDLK_6: 
		case SDLK_KP_6: return "6";
		case SDLK_7: 
		case SDLK_KP_7: return "7";
		case SDLK_8: 
		case SDLK_KP_8: return "8";
		case SDLK_9: 
		case SDLK_KP_9: return "9";
		case SDLK_PLUS:
		case SDLK_EQUALS:
		case SDLK_KP_PLUS: return "+";
		case SDLK_MINUS:
		case SDLK_KP_MINUS: return "-";
		case SDLK_SLASH:
		case SDLK_QUESTION:
		case SDLK_KP_DIVIDE: return "/";
		case SDLK_KP_MULTIPLY: return "*";
		case SDLK_COMMA:
		case SDLK_KP_PERIOD: return ",";
		case SDLK_BACKSLASH: return "\\";
		case SDLK_COLON:
		case SDLK_SEMICOLON: return ";";
		case SDLK_PERIOD: return ".";
		case SDLK_QUOTE: return "'";
		case SDLK_LEFTBRACKET: return "[";
		case SDLK_RIGHTBRACKET: return "]";
		case 180: return "´";
		case 126: return "~";
	}

	return "UNKNOWN";
}
