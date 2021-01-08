/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include <SDL.h>
#include "TextInput.h"
#include "Graphics.h"
#include "StringUtils.h"
#include "UIContext.h"

namespace TBRLGPT
{
	TextInput::TextInput(UIContext* ctx)
	{
		Ctx = ctx;
		Escaped = false;
		CursorChar = 0xDB;
		PlaceholderChar = '_';
	}

	TextInput::~TextInput()
	{
	}

	std::string TextInput::ReadString(int x, int y, int length, bool showLine, bool allowAlpha)
	{
		std::string inputLine = std::string(length, showLine ? PlaceholderChar : ' ');
		std::string inputStr = std::string(length + 1, ' ');

		int strix = 0;
		int csrx = x;
		bool ok = false;

		while (!ok) {
			Ctx->Print(x, y, inputLine);
			Ctx->Print(x, y, inputStr);
			Ctx->Gr->PutChar(Ctx->Chars, CursorChar, csrx, y, Ctx->ForeColor, Ctx->BackColor);
			Ctx->Update();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_KEYDOWN) {
				bool ctrl = SDL_GetModState() & KMOD_CTRL;
				bool shift = SDL_GetModState() & KMOD_SHIFT;
				bool caps = SDL_GetModState() & KMOD_CAPS;
				SDL_Keycode key = e.key.keysym.sym;
				switch (key) {
				case SDLK_RETURN:
					ok = true;
					Escaped = false;
					break;
				case SDLK_ESCAPE:
					Escaped = true;
					return "";
				case SDLK_RIGHT:
				case SDLK_UP:
				case SDLK_DOWN:
					continue;
				case SDLK_LEFT:
				case SDLK_BACKSPACE:
					if (csrx > x) {
						inputStr[--strix] = ' ';
						Ctx->Gr->PutChar(Ctx->Chars, 0, x + csrx - 1, y, Ctx->ForeColor, Ctx->BackColor);
						csrx--;
					}
					break;
				}

				if (csrx < (x + length) && strix < length) {
					if ((key < 0 || key > 255) || (!allowAlpha && key == SDLK_SPACE))
						continue;
					if (allowAlpha && (isalnum(key) || isgraph(key) || key == SDLK_SPACE) || (!allowAlpha && isdigit(key))) {
						if (isgraph(key) && shift)
							key = String::ShiftChar(key);

						inputStr[strix++] = caps || shift ? toupper(key) : tolower(key);
						inputStr[strix] = ' ';
						csrx++;
					}
				}
			}
		}

		return String::Trim(inputStr);
	}

	int TextInput::ReadInteger(int x, int y, int length, bool showLine)
	{
		std::string str = ReadString(x, y, length, showLine, false);
		if (str.empty())
			return -1;

		return String::ToInt(str);
	}

	bool TextInput::HasEscaped()
	{
		return Escaped;
	}
}
