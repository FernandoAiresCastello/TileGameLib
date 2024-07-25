#include "TKey.h"

namespace TGL_Internal
{
	void TKey::Wait(SDL_Keycode key)
	{
		DiscardEvents();
		SDL_Event e;
		while (true) {
			SDL_WaitEvent(&e);
			if (e.type == SDL_KEYDOWN && e.key.keysym.sym == key)
				break;
		}
	}

	int TKey::WaitAny()
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

	bool TKey::IsPressed(SDL_Scancode key)
	{
		SDL_PumpEvents();
		const Uint8* state = SDL_GetKeyboardState(NULL);
		return state[key];
	}

	int TKey::GetKeyPressed()
	{
		static SDL_Event e;
		e = { 0 };
		SDL_PollEvent(&e);
		if (e.type == SDL_KEYDOWN)
			return e.key.keysym.sym;

		return 0;
	}

	void TKey::DiscardEvents()
	{
		SDL_PumpEvents();
		SDL_FlushEvent(SDL_KEYDOWN);
	}

	bool TKey::Shift()
	{
		return SDL_GetModState() & KMOD_SHIFT;
	}

	bool TKey::Ctrl()
	{
		return SDL_GetModState() & KMOD_CTRL;
	}

	bool TKey::Alt()
	{
		return SDL_GetModState() & KMOD_ALT;
	}

	bool TKey::CapsLock()
	{
		return SDL_GetModState() & KMOD_CAPS;
	}
}
