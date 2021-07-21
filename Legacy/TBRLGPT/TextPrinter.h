/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class UIContext;

	class TBRLGPT_API TextPrinter
	{
	public:
		TextPrinter(UIContext* ctx);
		TextPrinter(UIContext* ctx, int fgcolor, int bgcolor);
		~TextPrinter();

		int GetForeColor();
		int GetBackColor();
		int GetCursorX();
		int GetCursorY();
		void Clear();
		void SetColor(int fgc, int bgc);
		void SetForeColor(int fgc);
		void SetBackColor(int bgc);
		void SetArrow(int arrow);
		void Locate(int x, int y);
		void PushCursor();
		void PopCursor();
		void InvertColors();
		void PutChar(int ch);
		void Print(std::string str);
		void Print(bool invertColors, std::string str);
		void Blink(int times, int delay, bool foregroundOnly, std::string str);
		void Colorize(std::string foreColors, int times, int delay, std::string str);
		void Type(int delay, std::string str);
		void Repeat(std::string str, int times);
		void Repeat(char ch, int times);
		void Printw(std::string text, int lineWidth, bool typewrite, int typewriteDelay = 50);
		void PrintPaged(std::string text, int lineWidth, int rows, bool showArrow, bool typewrite, int typewriteDelay);

	private:
		UIContext* Ctx;
		int ForeColor;
		int BackColor;
		int CursorX;
		int CursorY;
		int TempCursorX;
		int TempCursorY;
		int Arrow;
	};
}
