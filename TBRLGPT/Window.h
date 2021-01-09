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
	class Charset;

	class TBRLGPT_API Window
	{
	public:
		int X;
		int Y;
		int Width;
		int Height;
		bool Border;

		int WchSpace = 32;
		int WchTop = 196;
		int WchBottom = 196;
		int WchLeft = 179;
		int WchRight = 179;
		int WchTopLeft = 218;
		int WchTopRight = 191;
		int WchBottomLeft = 192;
		int WchBottomRight = 217;

		Window();
		Window(UIContext* ctx, int x, int y, int w, int h, bool border = true);
		~Window();

		void Draw();
		void DrawBorder();
		void Print(int x, int y, std::string str);
		void Print(int x, int y, int forecolor, std::string str);
		void Print(int x, int y, int forecolor, int backcolor, std::string str);
		void PrintInvert(int x, int y, std::string str);
		void PutChar(int chr, int x, int y);
		void PutChar(int chr, int x, int y, int forecolor);
		void PutChar(int chr, int x, int y, int forecolor, int backcolor);
		void PutChar(int chr, int x, int y, int forecolor, int backcolor, Charset* chars);

	protected:
		UIContext* Ctx;

		void DrawWithBorder();
		void DrawWithoutBorder();
	};
}
