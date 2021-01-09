/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Menu.h"
#include "Graphics.h"
#include "MenuItem.h"
#include "Window.h"
#include "UIContext.h"

namespace TBRLGPT
{
	Menu::Menu(UIContext* ctx)
	{
		Ctx = ctx;
		Items = new std::vector<MenuItem*>();
		ItemIndex = 0;
	}

	Menu::~Menu()
	{
		for (unsigned i = 0; i < Items->size(); i++)
			delete (*Items)[i];

		delete Items;
	}

	void Menu::AddItem(std::string text, void* object)
	{
		Items->push_back(new MenuItem(text, object));
	}

	void Menu::AddItem(std::string text, byte id)
	{
		Items->push_back(new MenuItem(text, id));
	}

	int Menu::GetItemIndex()
	{
		return ItemIndex;
	}

	MenuItem* Menu::Show(int x, int y, bool drawWindow)
	{
		return Show("", x, y, drawWindow);
	}

	MenuItem* Menu::Show(std::string title, int x, int y, bool drawWindow)
	{
		bool selecting = true;
		while (selecting) {
			Draw(title, x, y, drawWindow);
			SDL_Event e = { 0 };
			SDL_PollEvent(&e);
			if (e.type == SDL_KEYDOWN) {
				switch (e.key.keysym.sym) {
				case SDLK_ESCAPE:
					ItemIndex = -1;
					selecting = false;
					break;
				case SDLK_RETURN:
					selecting = false;
					break;
				case SDLK_UP:
					if (ItemIndex > 0)
						ItemIndex--;
					break;
				case SDLK_DOWN:
					if (ItemIndex < (int)Items->size() - 1)
						ItemIndex++;
					break;
				}
			}
		}

		return ItemIndex == -1 ? NULL : (*Items)[ItemIndex];
	}

	void Menu::Draw(std::string title, int x, int y, bool drawWindow)
	{
		unsigned w = 0;
		unsigned h = Items->size() + (title.empty() ? 0 : 2) + (drawWindow ? 0 : 1);
		for (unsigned i = 0; i < Items->size(); i++) {
			unsigned len = (*Items)[i]->GetText().size();
			if (len > w)
				w = len;
		}
		if (title.size() > w)
			w = title.size() - 1;

		if (!drawWindow) {
			w++;
			h--;
		}

		int contentOffset = drawWindow ? 1 : 0;
		Window win(Ctx, x, y, w + contentOffset, h, drawWindow);
		win.Draw();

		if (!title.empty()) {
			Ctx->Print(x + contentOffset, y + contentOffset, title);
			y += 2;
		}

		int py = y;
		for (unsigned i = 0; i < Items->size(); i++)
			Ctx->Print(x + 1 + contentOffset, contentOffset + y++, (*Items)[i]->GetText());

		int cursorX = x;
		int cursorY = py + ItemIndex;
		Ctx->Gr->PutChar(Ctx->Chars, 0x1a, cursorX + contentOffset, 
			cursorY + contentOffset, Ctx->ForeColor, Ctx->BackColor);
		Ctx->Update();
	}
}
