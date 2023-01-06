/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <vector>
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	class TGamepad
	{
	public:
		int Number;

		TGamepad();
		~TGamepad();

		int CountAvailable();
		int CountOpen();
		bool Open(int gamepadNumber = 0);
		int GetAxis(int gamepadNumber, SDL_GameControllerAxis axis);
		int GetButton(int gamepadNumber, SDL_GameControllerButton button);
		
		int AxisLX() { return GetAxis(Number, SDL_CONTROLLER_AXIS_LEFTX); }
		int AxisLY() { return GetAxis(Number, SDL_CONTROLLER_AXIS_LEFTY); }
		int AxisRX() { return GetAxis(Number, SDL_CONTROLLER_AXIS_RIGHTX); }
		int AxisRY() { return GetAxis(Number, SDL_CONTROLLER_AXIS_RIGHTY); }
		int AxisLT() { return GetAxis(Number, SDL_CONTROLLER_AXIS_TRIGGERLEFT); }
		int AxisRT() { return GetAxis(Number, SDL_CONTROLLER_AXIS_TRIGGERRIGHT); }

		bool A() { return GetButton(Number, SDL_CONTROLLER_BUTTON_A); }
		bool B() { return GetButton(Number, SDL_CONTROLLER_BUTTON_B); }
		bool X() { return GetButton(Number, SDL_CONTROLLER_BUTTON_X); }
		bool Y() { return GetButton(Number, SDL_CONTROLLER_BUTTON_Y); }
		bool L() { return GetButton(Number, SDL_CONTROLLER_BUTTON_LEFTSHOULDER); }
		bool R() { return GetButton(Number, SDL_CONTROLLER_BUTTON_RIGHTSHOULDER); }
		bool LStick() { return GetButton(Number, SDL_CONTROLLER_BUTTON_LEFTSTICK); }
		bool RStick() { return GetButton(Number, SDL_CONTROLLER_BUTTON_RIGHTSTICK); }
		bool Up() { return GetButton(Number, SDL_CONTROLLER_BUTTON_DPAD_UP); }
		bool Down() { return GetButton(Number, SDL_CONTROLLER_BUTTON_DPAD_DOWN); }
		bool Right() { return GetButton(Number, SDL_CONTROLLER_BUTTON_DPAD_RIGHT); }
		bool Left() { return GetButton(Number, SDL_CONTROLLER_BUTTON_DPAD_LEFT); }
		bool Start() { return GetButton(Number, SDL_CONTROLLER_BUTTON_START); }
		bool Select() { return GetButton(Number, SDL_CONTROLLER_BUTTON_BACK); }
		bool Extra() { return GetButton(Number, SDL_CONTROLLER_BUTTON_GUIDE); }

	private:
		std::vector<SDL_GameController*> Gamepads;
	};
}
