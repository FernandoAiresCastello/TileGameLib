/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include "TGlobal.h"

namespace TileGameLib
{
	class TGBWindow;

	class TTileGameBoy
	{
	public:
		TGBWindow* Wnd = nullptr;
		bool AllowEscapeKeyToExit = false;

		TTileGameBoy();
		~TTileGameBoy();

		void Run();
		void Exit();
		void Halt();

		void SetWindowTitle(std::string title);

		void DefineButtonA(SDL_Scancode key);
		void DefineButtonB(SDL_Scancode key);
		void DefineButtonStart(SDL_Scancode key);
		void DefineButtonSelect(SDL_Scancode key);
		void DefineButtonUp(SDL_Scancode key);
		void DefineButtonDown(SDL_Scancode key);
		void DefineButtonLeft(SDL_Scancode key);
		void DefineButtonRight(SDL_Scancode key);

		void OnGameLoop(void (*callback)());
		void OnExit(void (*callback)());
		void OnPressA(void (*callback)());
		void OnPressB(void (*callback)());
		void OnReleaseA(void (*callback)());
		void OnReleaseB(void (*callback)());
		void OnPressStart(void (*callback)());
		void OnPressSelect(void (*callback)());
		void OnPressUp(void (*callback)());
		void OnPressDown(void (*callback)());
		void OnPressLeft(void (*callback)());
		void OnPressRight(void (*callback)());
		void OnReleaseUp(void (*callback)());
		void OnReleaseDown(void (*callback)());
		void OnReleaseLeft(void (*callback)());
		void OnReleaseRight(void (*callback)());

		bool APressed();
		bool BPressed();
		bool StartPressed();
		bool SelectPressed();
		bool UpPressed();
		bool DownPressed();
		bool LeftPressed();
		bool RightPressed();

	private:
		bool Running = false;
		bool Halted = false;

		SDL_Scancode ButtonA = SDL_SCANCODE_Z;
		SDL_Scancode ButtonB = SDL_SCANCODE_X;
		SDL_Scancode ButtonStart = SDL_SCANCODE_C;
		SDL_Scancode ButtonSelect = SDL_SCANCODE_V;
		SDL_Scancode ButtonUp = SDL_SCANCODE_UP;
		SDL_Scancode ButtonDown = SDL_SCANCODE_DOWN;
		SDL_Scancode ButtonLeft = SDL_SCANCODE_LEFT;
		SDL_Scancode ButtonRight = SDL_SCANCODE_RIGHT;

		void (*CallbackOnGameLoop)() = nullptr;
		void (*CallbackOnExit)() = nullptr;
		void (*CallbackOnPressA)() = nullptr;
		void (*CallbackOnPressB)() = nullptr;
		void (*CallbackOnReleaseA)() = nullptr;
		void (*CallbackOnReleaseB)() = nullptr;
		void (*CallbackOnPressStart)() = nullptr;
		void (*CallbackOnPressSelect)() = nullptr;
		void (*CallbackOnPressUp)() = nullptr;
		void (*CallbackOnPressDown)() = nullptr;
		void (*CallbackOnPressLeft)() = nullptr;
		void (*CallbackOnPressRight)() = nullptr;
		void (*CallbackOnReleaseUp)() = nullptr;
		void (*CallbackOnReleaseDown)() = nullptr;
		void (*CallbackOnReleaseLeft)() = nullptr;
		void (*CallbackOnReleaseRight)() = nullptr;
	};
}
