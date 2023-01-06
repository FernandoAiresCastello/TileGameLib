/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TTileGameBoy.h"
#include "TGBWindow.h"
#include "TKey.h"

namespace TileGameLib
{
	TTileGameBoy::TTileGameBoy()
	{
		Wnd = new TGBWindow(4, 4);
		Wnd->Show();
	}

	TTileGameBoy::~TTileGameBoy()
	{
		delete Wnd;
	}

	void TTileGameBoy::Run()
	{
		Running = true;
		Halted = false;

		while (Running) {
			if (CallbackOnGameLoop && !Halted)
				CallbackOnGameLoop();

			Wnd->Update();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);
			if (e.type == SDL_QUIT) {
				Exit();
			}

			if (Halted)
				continue;
			
			if (e.type == SDL_KEYDOWN) {
				const auto key = e.key.keysym.sym;
				if (TKey::Alt() && key == SDLK_RETURN) {
					Wnd->ToggleFullscreen();
				} else if (key == SDLK_ESCAPE && AllowEscapeKeyToExit) {
					Exit();
				}
			} else if (e.type == SDL_KEYUP) {
				const auto button = e.key.keysym.scancode;
				if (button == ButtonA && CallbackOnReleaseA) CallbackOnReleaseA();
				if (button == ButtonB && CallbackOnReleaseB) CallbackOnReleaseB();
				if (button == ButtonUp && CallbackOnReleaseUp) CallbackOnReleaseUp();
				if (button == ButtonDown && CallbackOnReleaseDown) CallbackOnReleaseDown();
				if (button == ButtonLeft && CallbackOnReleaseLeft) CallbackOnReleaseLeft();
				if (button == ButtonRight && CallbackOnReleaseRight) CallbackOnReleaseRight();
			}
			if (TKey::IsPressed(ButtonA) && CallbackOnPressA) CallbackOnPressA();
			if (TKey::IsPressed(ButtonB) && CallbackOnPressB) CallbackOnPressB();
			if (TKey::IsPressed(ButtonStart) && CallbackOnPressStart) CallbackOnPressStart();
			if (TKey::IsPressed(ButtonSelect) && CallbackOnPressSelect) CallbackOnPressSelect();
			if (TKey::IsPressed(ButtonUp) && CallbackOnPressUp) CallbackOnPressUp();
			if (TKey::IsPressed(ButtonDown) && CallbackOnPressDown) CallbackOnPressDown();
			if (TKey::IsPressed(ButtonLeft) && CallbackOnPressLeft) CallbackOnPressLeft();
			if (TKey::IsPressed(ButtonRight) && CallbackOnPressRight) CallbackOnPressRight();
		}
	}

	void TTileGameBoy::Exit()
	{
		if (CallbackOnExit) CallbackOnExit();
		Running = false;
		exit(0);
	}

	void TTileGameBoy::Halt()
	{
		Halted = true;
	}

	void TTileGameBoy::SetWindowTitle(std::string title)
	{
		Wnd->SetTitle(title);
	}

	void TTileGameBoy::DefineButtonA(SDL_Scancode key) { ButtonA = key; }
	void TTileGameBoy::DefineButtonB(SDL_Scancode key) { ButtonB = key; }
	void TTileGameBoy::DefineButtonStart(SDL_Scancode key) { ButtonStart = key; }
	void TTileGameBoy::DefineButtonSelect(SDL_Scancode key) { ButtonSelect = key; }
	void TTileGameBoy::DefineButtonUp(SDL_Scancode key) { ButtonUp = key; }
	void TTileGameBoy::DefineButtonDown(SDL_Scancode key) { ButtonDown = key; }
	void TTileGameBoy::DefineButtonLeft(SDL_Scancode key) { ButtonLeft = key; }
	void TTileGameBoy::DefineButtonRight(SDL_Scancode key) { ButtonRight = key; }
	
	void TTileGameBoy::OnGameLoop(void(*callback)()) { CallbackOnGameLoop = callback; }
	void TTileGameBoy::OnExit(void(*callback)()) { CallbackOnExit = callback; }
	void TTileGameBoy::OnPressA(void(*callback)()) { CallbackOnPressA = callback; }
	void TTileGameBoy::OnPressB(void(*callback)()) { CallbackOnPressB = callback; }
	void TTileGameBoy::OnReleaseA(void(*callback)()) { CallbackOnReleaseA = callback; }
	void TTileGameBoy::OnReleaseB(void(*callback)()) { CallbackOnReleaseB = callback; }
	void TTileGameBoy::OnPressStart(void(*callback)()) { CallbackOnPressStart = callback; }
	void TTileGameBoy::OnPressSelect(void(*callback)()) { CallbackOnPressSelect = callback; }
	void TTileGameBoy::OnPressUp(void(*callback)()) { CallbackOnPressUp = callback; }
	void TTileGameBoy::OnPressDown(void(*callback)()) { CallbackOnPressDown = callback; }
	void TTileGameBoy::OnPressLeft(void(*callback)()) { CallbackOnPressLeft = callback; }
	void TTileGameBoy::OnPressRight(void(*callback)()) { CallbackOnPressRight = callback; }
	void TTileGameBoy::OnReleaseUp(void(*callback)()) { CallbackOnReleaseUp = callback; }
	void TTileGameBoy::OnReleaseDown(void(*callback)()) { CallbackOnReleaseDown = callback; }
	void TTileGameBoy::OnReleaseLeft(void(*callback)()) { CallbackOnReleaseLeft = callback; }
	void TTileGameBoy::OnReleaseRight(void(*callback)()) { CallbackOnReleaseRight = callback; }

	bool TTileGameBoy::APressed() { return TKey::IsPressed(ButtonA); }
	bool TTileGameBoy::BPressed() { return TKey::IsPressed(ButtonB); }
	bool TTileGameBoy::StartPressed() { return TKey::IsPressed(ButtonStart); }
	bool TTileGameBoy::SelectPressed() { return TKey::IsPressed(ButtonSelect); }
	bool TTileGameBoy::UpPressed() { return TKey::IsPressed(ButtonUp); }
	bool TTileGameBoy::DownPressed() { return TKey::IsPressed(ButtonDown); }
	bool TTileGameBoy::LeftPressed() { return TKey::IsPressed(ButtonLeft); }
	bool TTileGameBoy::RightPressed() { return TKey::IsPressed(ButtonRight); }
}
