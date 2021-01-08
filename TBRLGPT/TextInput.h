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

	class TBRLGPT_API TextInput
	{
	public:
		int CursorChar;
		int PlaceholderChar;

		TextInput(UIContext* ctx);
		~TextInput();

		std::string ReadString(int x, int y, int length, bool showLine = false, bool allowAlpha = true);
		int ReadInteger(int x, int y, int length, bool showLine = false);
		bool HasEscaped();

	private:
		UIContext* Ctx;
		bool Escaped;
	};
}
