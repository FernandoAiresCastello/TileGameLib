/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"
#include "Char.h"

namespace TBRLGPT
{
	class UIContext;
	class MenuItem;

	class TBRLGPT_API Menu
	{
	public:
		Menu(UIContext* ctx);
		~Menu();

		void AddItem(std::string text, void* object = NULL);
		void AddItem(std::string text, byte id);
		MenuItem* Show(int x, int y, bool drawWindow);
		MenuItem* Show(std::string title, int x, int y, bool drawWindow);
		int GetItemIndex();

	private:
		UIContext* Ctx;
		std::vector<MenuItem*>* Items;
		int ItemIndex;

		void Draw(std::string title, int x, int y, bool drawWindow);
	};
}
