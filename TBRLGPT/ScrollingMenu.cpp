/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "ScrollingMenu.h"
#include "Graphics.h"
#include "MenuItem.h"
#include "Window.h"
#include "StringUtils.h"
#include "UIContext.h"

namespace TBRLGPT
{
	ScrollingMenu::ScrollingMenu(UIContext* ctx, int itemIndex)
	{
		Ctx = ctx;
		Items = new std::vector<MenuItem*>();
		ItemIndex = itemIndex;
		FirstItem = 0;
		CursorY = 0;
		CursorHomeY = 0;
		KeyPressed = 0;
		Highlight = true;
		CursorChar = 0x1a;
		CursorForeColor = ctx->BackColor;
		CursorBackColor = ctx->ForeColor;
	}

	ScrollingMenu::~ScrollingMenu()
	{
		for (unsigned i = 0; i < Items->size(); i++)
			delete (*Items)[i];

		delete Items;
	}

	bool ScrollingMenu::IsEmpty()
	{
		return Items->empty();
	}

	void ScrollingMenu::AddItem(std::string text, void* object)
	{
		Items->push_back(new MenuItem(text, object));
	}

	void ScrollingMenu::AddItem(std::string text, byte id)
	{
		Items->push_back(new MenuItem(text, id));
	}

	int ScrollingMenu::GetItemIndex()
	{
		return ItemIndex;
	}

	int ScrollingMenu::GetKeyPressed()
	{
		return KeyPressed;
	}

	void ScrollingMenu::SetHighlight(bool highlight)
	{
		Highlight = highlight;
	}

	void ScrollingMenu::SetCursorChar(int cursor)
	{
		CursorChar = cursor;
	}

	void ScrollingMenu::SetCursorForeColor(int color)
	{
		CursorForeColor = color;
	}

	void ScrollingMenu::SetCursorBackColor(int color)
	{
		CursorBackColor = color;
	}

	MenuItem* ScrollingMenu::Show(int x, int y, int w, int h, bool drawWindow, bool printIndicator)
	{
		return Show("", x, y, w, h, drawWindow, printIndicator);
	}

	MenuItem* ScrollingMenu::Show(std::string title, int x, int y, int w, int h, bool drawWindow, bool printIndicator)
	{
		X = x;
		Y = y;
		Width = w;
		Height = h;
		DrawWindow = drawWindow;
		PrintIndicator = printIndicator;
		Title = title;
		MaxItems = (Title.empty() ? Height : Height - 2);
		CursorHomeY = (Title.empty() ? Y : Y + 2);
		CursorY = CursorHomeY;

		bool selecting = true;

		while (selecting) {
			
			Draw();
			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_KEYDOWN) {
				KeyPressed = e.key.keysym.sym;
				switch (KeyPressed) {
					case SDLK_UP: {
						if (ItemIndex > 0) {
							ItemIndex--;
							if (CursorY <= CursorHomeY)
								FirstItem--;
							else
								CursorY--;
						}
						break;
					}
					case SDLK_DOWN: {
						if (ItemIndex < (int)Items->size() - 1) {
							ItemIndex++;
							if (CursorY >= MaxItems + CursorHomeY - 1)
								FirstItem++;
							else
								CursorY++;
						}
						break;
					}
					case SDLK_ESCAPE: {
						ItemIndex = -1;
						selecting = false;
						break;
					}
					case SDLK_RETURN:
					default:
						selecting = false;
						break;
				}
			}
		}

		return ItemIndex == -1 || Items->empty() ? NULL : (*Items)[ItemIndex];
	}

	void ScrollingMenu::Draw()
	{
		int x = X;
		int y = Y;
		int contentOffset = DrawWindow ? 1 : 0;
		Window win(Ctx, x, y, Width + contentOffset, Height, DrawWindow);
		win.Draw();

		if (!Title.empty()) {
			Ctx->Print(x + contentOffset, y + contentOffset, Title);
			y += 2;
		}

		int lastItem = FirstItem + MaxItems;
		for (int i = FirstItem; i < lastItem; i++) {
			if (i >= (int)Items->size())
				break;

			std::string item = Items->at(i)->GetText().substr(0, Width);
			if (Highlight) {
				if (i == ItemIndex) {
					int fgc = Ctx->ForeColor;
					int bgc = Ctx->BackColor;
					Ctx->ForeColor = CursorForeColor;
					Ctx->BackColor = CursorBackColor;

					std::string blank = String::Repeat(" ", win.Width);
					Ctx->Print(x + contentOffset, contentOffset + y, blank);
					Ctx->Print(x + 1 + contentOffset, contentOffset + y++, item);

					Ctx->ForeColor = fgc;
					Ctx->BackColor = bgc;
				}
				else {
					Ctx->Print(x + 1 + contentOffset, contentOffset + y++, item);
				}
			}
			else {
				Ctx->Print(x + 1 + contentOffset, contentOffset + y++, item);
			}
		}

		if (DrawWindow && PrintIndicator) {
			std::string indicator = String::Format("%i/%i", ItemIndex + 1, Items->size());
			int indy = Y + Height + 1;
			int indx = (X + Width + 2) - indicator.size();
			Ctx->Print(indx, indy, indicator);
		}

		if (!Highlight) {
			int fgc = Ctx->ForeColor;
			int bgc = Ctx->BackColor;
			Ctx->ForeColor = CursorForeColor;
			Ctx->BackColor = CursorBackColor;

			Ctx->Gr->PutChar(Ctx->Chars, CursorChar, x + contentOffset,
				CursorY + contentOffset, Ctx->ForeColor, Ctx->BackColor);

			Ctx->ForeColor = fgc;
			Ctx->BackColor = bgc;
		}

		Ctx->Update();
	}
}
