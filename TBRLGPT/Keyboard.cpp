/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "Keyboard.h"

namespace TBRLGPT
{
	void Key::Wait(int key)
	{
		DiscardEvents();
		SDL_Event e;
		while (true) {
			SDL_WaitEvent(&e);
			if (e.type == SDL_KEYDOWN && e.key.keysym.sym == key)
				break;
		}
	}

	int Key::WaitAny()
	{
		DiscardEvents();
		SDL_Event e;
		while (true) {
			SDL_WaitEvent(&e);
			if (e.type == SDL_KEYDOWN)
				return e.key.keysym.sym;
		}

		return 0;
	}

	bool Key::Pressed(int key)
	{
		SDL_PumpEvents();
		const Uint8* state = SDL_GetKeyboardState(NULL);
		return state[key];
	}

	int Key::GetKeyPressed()
	{
		static SDL_Event e;
		e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_KEYDOWN)
			return e.key.keysym.sym;

		return 0;
	}

	void Key::DiscardEvents()
	{
		SDL_PumpEvents();
		SDL_FlushEvent(SDL_KEYDOWN);
	}

	void Key::PumpEvents()
	{
		SDL_PumpEvents();
	}

	bool Key::Shift()
	{
		return SDL_GetModState() & KMOD_SHIFT;
	}
	bool Key::Ctrl()
	{
		return SDL_GetModState() & KMOD_CTRL;
	}
	bool Key::Alt()
	{
		return SDL_GetModState() & KMOD_ALT;
	}
	bool Key::CapsLock()
	{
		return SDL_GetModState() & KMOD_CAPS;
	}
}
