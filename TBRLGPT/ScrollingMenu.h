/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"
#include "Char.h"

namespace TBRLGPT
{
	class UIContext;
	class MenuItem;

	class TBRLGPT_API ScrollingMenu
	{
	public:
		ScrollingMenu(UIContext* ctx, int itemIndex = 0);
		~ScrollingMenu();

		bool IsEmpty();
		void AddItem(std::string text, void* object = NULL);
		void AddItem(std::string text, byte id);
		MenuItem* Show(int x, int y, int w, int h, bool drawWindow = true, bool printIndicator = true);
		MenuItem* Show(std::string title, int x, int y, int w, int h, bool drawWindow, bool printIndicator);
		int GetItemIndex();
		int GetKeyPressed();
		void SetHighlight(bool highlight);
		void SetCursorChar(int cursor);
		void SetCursorForeColor(int color);
		void SetCursorBackColor(int color);

	private:
		UIContext* Ctx;
		std::vector<MenuItem*>* Items;
		std::string Title;
		int ItemIndex;
		int X;
		int Y;
		int Width;
		int Height;
		int FirstItem;
		int MaxItems;
		int CursorHomeY;
		int CursorY;
		bool DrawWindow;
		bool PrintIndicator;
		int KeyPressed;
		bool Highlight;
		int CursorChar;
		int CursorForeColor;
		int CursorBackColor;

		void Draw();
	};
}
