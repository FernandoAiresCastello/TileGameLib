/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"
#include "Char.h"
#include "Rect.h"

namespace TBRLGPT
{
	class Graphics;
	class Charset;
	class Palette;

	class TBRLGPT_API UIContext
	{
	public:
		Graphics* Gr;
		Charset* Chars;
		Palette* Pal;
		int ForeColor;
		int BackColor;

		UIContext(Graphics* gr, int forecolor, int backcolor);
		~UIContext();

		void Clear();
		void ClearRect(int x, int y, int w, int h);
		void ClearRect(Rect rect);
		void Update();
		void Print(int x, int y, std::string text);
		void Print(int x, int y, int forecolor, std::string text);
		void PutChar(int ch, int x, int y);
		void PutChar(int ch, int x, int y, int forecolor);
		void PutChar(int ch, int x, int y, int forecolor, int backcolor);
		void PrintInvertColors(int x, int y, std::string text);
		void InvertColors();
		void SetColor(int forecolor, int backcolor);
	};
}
