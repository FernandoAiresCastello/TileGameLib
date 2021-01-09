/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <SDL.h>
#include "NumericMenu.h"
#include "Graphics.h"
#include "Window.h"
#include "StringUtils.h"
#include "UIContext.h"

namespace TBRLGPT
{
	NumericMenu::NumericMenu(UIContext* ctx)
	{
		Ctx = ctx;
	}

	NumericMenu::~NumericMenu()
	{
	}

	int NumericMenu::WaitSelection(int itemCount)
	{
		SDL_Event e;
		while (true)
		{
			SDL_WaitEvent(&e);
			if (e.type == SDL_KEYDOWN) {
				SDL_Keycode key = e.key.keysym.sym;
				if (key >= 0 && key <= 255 && isdigit(key)) {
					std::string keystr;
					keystr.push_back(key);
					int item = String::ToInt(keystr);
					if (item > 0 && item <= itemCount) {
						return item;
					}
				}
			}
		}

		return 0;
	}

	int NumericMenu::ShowMenuScreen(std::string items)
	{
		return ShowMenuScreen("", items);
	}

	int NumericMenu::ShowMenuScreen(std::string title, std::string items)
	{
		Ctx->Clear();

		int x = 1;
		int y = title.empty() ? 1 : 3;
		std::vector<std::string> menu = String::Split(items, ',');

		if (!title.empty())
			Ctx->Print(x, 1, title);
		for (unsigned i = 0; i < menu.size(); i++)
			Ctx->Print(x, y++, String::ToString(i + 1) + ". " + menu[i]);

		Ctx->Update();

		return WaitSelection(menu.size());
	}

	int NumericMenu::ShowMenu(std::string title, std::string items, int x, int y, bool drawWindow)
	{
		std::vector<std::string> menu = String::Split(items, ',');

		unsigned indicatorLength = menu.size() < 10 ? 3 : 4;
		unsigned h = menu.size() + 2 + (drawWindow ? 0 : 1);
		unsigned w = 0;

		for (unsigned i = 0; i < menu.size(); i++) {
			if (menu[i].size() > w)
				w = menu[i].size();
		}
		if (title.size() > w)
			w = title.size() - indicatorLength;

		Window win(Ctx, x, y, w + indicatorLength, h, drawWindow);
		win.Draw();

		int contentOffset = drawWindow ? 1 : 0;
		Ctx->Print(x + contentOffset, y + contentOffset, title);
		y += 3;

		for (unsigned i = 0; i < menu.size(); i++)
			Ctx->Print(x + contentOffset, y++, String::ToString(i + 1) + ". " + menu[i]);

		Ctx->Update();
		return WaitSelection(menu.size());
	}
}
