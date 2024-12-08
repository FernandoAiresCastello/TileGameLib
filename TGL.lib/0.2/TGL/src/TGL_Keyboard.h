#pragma once
#include "TGL_Global.h"
#include "TGL_List.h"

namespace TGL
{
	using Keycode = SDL_Keycode;
	using Scancode = SDL_Scancode;

	class TGLAPI Keyboard
	{
	public:
		bool IsPressed(Scancode code);
		void AddToBuffer(Keycode key);
		Keycode GetKey();

		bool Alt();
		bool Ctrl();
		bool Shift();
		bool CapsLock();

	private:
		List<Keycode> buffer;
	};
}
