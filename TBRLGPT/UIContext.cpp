/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "UIContext.h"
#include "Graphics.h"
#include "Charset.h"
#include "Palette.h"

namespace TBRLGPT
{
	UIContext::UIContext(Graphics* gr, int forecolor, int backcolor)
	{
		Gr = gr;
		Chars = new Charset();
		Pal = new Palette();
		ForeColor = forecolor;
		BackColor = backcolor;
	}

	UIContext::~UIContext()
	{
		delete Pal;
		delete Chars;
	}

	void UIContext::Clear()
	{
		Gr->Clear(BackColor);
	}

	void UIContext::ClearRect(int x, int y, int w, int h)
	{
		ClearRect(Rect(x, y, w, h));
	}

	void UIContext::ClearRect(Rect rect)
	{
		Gr->ClearRect(rect.X, rect.Y, rect.Width, rect.Height, BackColor);
	}

	void UIContext::Update()
	{
		Gr->Update();
	}

	void UIContext::Print(int x, int y, std::string text)
	{
		Gr->Print(Chars, x, y, ForeColor, BackColor, text);
	}

	void UIContext::Print(int x, int y, int forecolor, std::string text)
	{
		int prevColor = ForeColor;
		ForeColor = forecolor;
		Print(x, y, text);
		ForeColor = prevColor;
	}

	void UIContext::PutChar(int ch, int x, int y)
	{
		Gr->PutChar(Chars, ch, x, y, ForeColor, BackColor);
	}

	void UIContext::PutChar(int ch, int x, int y, int forecolor)
	{
		Gr->PutChar(Chars, ch, x, y, forecolor, BackColor);
	}

	void UIContext::PutChar(int ch, int x, int y, int forecolor, int backcolor)
	{
		Gr->PutChar(Chars, ch, x, y, forecolor, backcolor);
	}

	void UIContext::PrintInvertColors(int x, int y, std::string text)
	{
		InvertColors();
		Print(x, y, text);
		InvertColors();
	}

	void UIContext::InvertColors()
	{
		int temp = ForeColor;
		ForeColor = BackColor;
		BackColor = temp;
	}

	void UIContext::SetColor(int forecolor, int backcolor)
	{
		ForeColor = forecolor;
		BackColor = backcolor;
	}
}
