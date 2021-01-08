/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"
#include "Window.h"

namespace TBRLGPT
{
	class UIContext;
	class Charset;

	class TBRLGPT_API CharSelector
	{
	public:
		CharSelector(UIContext* ctx, Charset* chars, int x, int y);
		~CharSelector();

		int Select(int initialChar, bool allowEditing);

	private:
		UIContext* Ctx;
		Charset* CharsToSelect;
		Window Win;
		Window WinInd;
		Window WinClipbd;
		int CharIndex;
		bool Running;
		int X;
		int Y;
		int ClipbdCharIndex;

		void Clear();
		void Draw();
		int GetFirstCharIndexInPage();
		void CopyChar();
		void PasteChar();
		void SaveCharset();
		void LoadCharset();
	};
}
