/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class UIContext;

	class TBRLGPT_API NumericMenu
	{
	public:
		NumericMenu(UIContext* ctx);
		~NumericMenu();

		int ShowMenuScreen(std::string items);
		int ShowMenuScreen(std::string title, std::string items);
		int ShowMenu(std::string title, std::string items, int x, int y, bool drawWindow);

	private:
		UIContext* Ctx;

		int WaitSelection(int itemCount);
	};
}
