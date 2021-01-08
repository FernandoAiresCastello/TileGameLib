/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"
#include "Rect.h"

namespace TBRLGPT
{
	class UIContext;
	class Charset;
	class Window;

	class TBRLGPT_API CharSelector2
	{
	public:
		CharSelector2(UIContext* ctx, Charset* chars, int x, int y, int w, int h);
		~CharSelector2();

		void SetDrawingArea(Rect area);
		int Select(int initialChar, bool allowEditing);

	private:
		UIContext* Ctx;
		Charset* CharsToSelect;
		Window* Win;
		Window* WinInd;
		Rect DrawingArea;
		int CharIndex;
		bool Running;
		int ClipbdCharIndex;
		int FirstViewCharIndex;

		void Draw();
		int GetFirstCharIndexInPage();
		void CopyChar();
		void PasteChar();
		void SaveCharset();
		void LoadCharset();
	};
}
