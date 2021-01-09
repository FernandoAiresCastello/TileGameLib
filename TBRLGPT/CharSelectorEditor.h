/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class UIContext;
	class Charset;

	class TBRLGPT_API CharSelectorEditor
	{
	public:
		CharSelectorEditor(UIContext* ctx, Charset* chars, int intialChar, int x, int y, int w, int h);

		void Run();

	private:
		UIContext* Ctx;
		Charset* CharsToSelectEdit;
		int CharIndex;
		int X;
		int Y;
		int Width;
		int Height;
	};
}
