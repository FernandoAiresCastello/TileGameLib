#include <CppUtils.h>
#include "TGamepad.h"

using namespace CppUtils;

namespace TGL_Internal
{
	TGamepad::TGamepad()
	{
		Number = -1;
		SDL_Init(SDL_INIT_JOYSTICK);
	}

	TGamepad::~TGamepad()
	{
		CloseAll();
	}

	int TGamepad::CountAvailable()
	{
		return SDL_NumJoysticks();
	}
	
	int TGamepad::CountOpen()
	{
		return Gamepads.size();
	}

	bool TGamepad::Open(int gamepadNumber)
	{
		SDL_GameController* gamepad = SDL_GameControllerOpen(gamepadNumber);
		if (gamepad) {
			Gamepads.push_back(gamepad);
			if (Number < 0)
				Number = 0;
		}
		else {
			MsgBox::Error(String::Format("Could not open gamepad number %i.\n\n%s", gamepadNumber, SDL_GetError()));
			return false;
		}
		return true;
	}

	int TGamepad::OpenAllAvailable()
	{
		CloseAll();

		for (int i = 0; i < CountAvailable(); i++) {
			Open(i);
		}
		return CountOpen();
	}

	void TGamepad::CloseAll()
	{
		for (auto& gpad : Gamepads) {
			if (SDL_GameControllerGetAttached(gpad)) {
				SDL_GameControllerClose(gpad);
			}
			gpad = nullptr;
		}
		Gamepads.clear();
	}

	int TGamepad::GetAxis(int gamepadNumber, SDL_GameControllerAxis axis)
	{
		return SDL_GameControllerGetAxis(Gamepads[gamepadNumber], axis);
	}

	int TGamepad::GetButton(int gamepadNumber, SDL_GameControllerButton button)
	{
		return SDL_GameControllerGetButton(Gamepads[gamepadNumber], button);
	}
}
