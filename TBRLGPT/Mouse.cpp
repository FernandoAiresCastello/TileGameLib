/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include <SDL.h>
#include "Mouse.h"
#include "Graphics.h"

namespace TBRLGPT
{
	int Mouse::GetWinX()
	{
		int x = -1;
		SDL_GetMouseState(&x, NULL);
		return x;
	}

	int Mouse::GetWinY()
	{
		int y = -1;
		SDL_GetMouseState(NULL, &y);
		return y;
	}

	int Mouse::GetPixelX(Graphics* g)
	{
		int x = -1;
		SDL_GetMouseState(&x, NULL);
		return x / (g->WindowWidth / g->ScreenWidth);
	}

	int Mouse::GetPixelY(Graphics* g)
	{
		int y = -1;
		SDL_GetMouseState(NULL, &y);
		return y / (g->WindowHeight / g->ScreenHeight);
	}

	int Mouse::GetCharX(Graphics* g)
	{
		int x = -1;
		SDL_GetMouseState(&x, NULL);
		return (x / (g->WindowWidth / g->ScreenWidth)) / 8;
	}

	int Mouse::GetCharY(Graphics* g)
	{
		int y = -1;
		SDL_GetMouseState(NULL, &y);
		return (y / (g->WindowHeight / g->ScreenHeight)) / 8;
	}

	bool Mouse::LeftPressed()
	{
		return SDL_GetMouseState(NULL, NULL) &
			SDL_BUTTON(SDL_BUTTON_LEFT);
	}

	bool Mouse::RightPressed()
	{
		return SDL_GetMouseState(NULL, NULL) &
			SDL_BUTTON(SDL_BUTTON_RIGHT);
	}

	void Mouse::Show(bool show)
	{
		SDL_ShowCursor(show ? SDL_ENABLE : SDL_DISABLE);
	}
}
