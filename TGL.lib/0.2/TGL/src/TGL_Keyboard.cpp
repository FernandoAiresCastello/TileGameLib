#include "TGL_Keyboard.h"

namespace TGL
{
	bool Keyboard::IsPressed(Scancode code)
	{
		return SDL_GetKeyboardState(nullptr)[code];
	}

	void Keyboard::AddToBuffer(Keycode key)
	{
		buffer.push_back(key);
	}

	Keycode Keyboard::GetKey()
	{
		if (buffer.empty())
			return 0;

		Keycode key = buffer.back();
		buffer.pop_back();
		return key;
	}

	bool Keyboard::Alt()
	{
		return SDL_GetModState() & SDL_KMOD_ALT;
	}

	bool Keyboard::Ctrl()
	{
		return SDL_GetModState() & SDL_KMOD_CTRL;
	}

	bool Keyboard::Shift()
	{
		return SDL_GetModState() & SDL_KMOD_SHIFT;
	}
	bool Keyboard::CapsLock()
	{
		return SDL_GetModState() & SDL_KMOD_CAPS;
	}
}
