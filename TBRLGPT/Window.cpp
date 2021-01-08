/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "Window.h"
#include "Graphics.h"
#include "UIContext.h"

namespace TBRLGPT
{
	Window::Window() :
		Ctx(NULL), X(0), Y(0), Width(0), Height(0), Border(false)
	{
	}
	
	Window::Window(UIContext* ctx, int x, int y, int w, int h, bool border) :
		Ctx(ctx), X(x), Y(y), Width(w), Height(h), Border(border)
	{
	}

	Window::~Window()
	{
	}

	void Window::Draw()
	{
		if (Border)
			DrawWithBorder();
		else
			DrawWithoutBorder();
	}

	void Window::DrawBorder()
	{
		// Draw top corner
		Ctx->Gr->PutChar(Ctx->Chars, WchTopLeft, X, Y, Ctx->ForeColor, Ctx->BackColor);
		Ctx->Gr->PutChar(Ctx->Chars, WchTopRight, X + Width + 1, Y, Ctx->ForeColor, Ctx->BackColor);
		for (int i = 0; i < Width; i++)
			Ctx->Gr->PutChar(Ctx->Chars, WchTop, X + i + 1, Y, Ctx->ForeColor, Ctx->BackColor);

		// Draw middle
		for (int row = 0; row < Height; row++) {
			Ctx->Gr->PutChar(Ctx->Chars, WchLeft, X, Y + row + 1, Ctx->ForeColor, Ctx->BackColor);
			Ctx->Gr->PutChar(Ctx->Chars, WchRight, X + Width + 1, Y + row + 1, Ctx->ForeColor, Ctx->BackColor);
		}

		// Draw bottom corner
		Ctx->Gr->PutChar(Ctx->Chars, WchBottomLeft, X, Y + Height + 1, Ctx->ForeColor, Ctx->BackColor);
		Ctx->Gr->PutChar(Ctx->Chars, WchBottomRight, X + Width + 1, Y + Height + 1, Ctx->ForeColor, Ctx->BackColor);
		for (int i = 0; i < Width; i++)
			Ctx->Gr->PutChar(Ctx->Chars, WchBottom, X + i + 1, Y + Height + 1, Ctx->ForeColor, Ctx->BackColor);
	}

	void Window::DrawWithBorder()
	{
		DrawBorder();
		for (int row = 0; row < Height; row++)
			for (int i = 0; i < Width; i++)
				Ctx->Gr->PutChar(Ctx->Chars, WchSpace, X + i + 1, Y + row + 1, Ctx->ForeColor, Ctx->BackColor);
	}

	void Window::DrawWithoutBorder()
	{
		for (int row = 0; row < Height; row++)
			for (int col = 0; col < Width; col++)
				Ctx->Gr->PutChar(Ctx->Chars, WchSpace, X + col, Y + row, Ctx->ForeColor, Ctx->BackColor);
	}

	void Window::Print(int x, int y, std::string str)
	{
		Print(x, y, Ctx->ForeColor, Ctx->BackColor, str);
	}

	void Window::Print(int x, int y, int forecolor, std::string str)
	{
		Print(x, y, forecolor, Ctx->BackColor, str);
	}

	void Window::Print(int x, int y, int forecolor, int backcolor, std::string str)
	{
		if (Border) {
			x++;
			y++;
		}

		Ctx->Gr->Print(Ctx->Chars, X + x, Y + y, forecolor, backcolor, str);
	}

	void Window::PrintInvert(int x, int y, std::string str)
	{
		Print(x, y, Ctx->BackColor, Ctx->ForeColor, str);
	}

	void Window::PutChar(int chr, int x, int y)
	{
		PutChar(chr, x, y, Ctx->ForeColor, Ctx->BackColor);
	}

	void Window::PutChar(int chr, int x, int y, int forecolor)
	{
		PutChar(chr, x, y, forecolor, Ctx->BackColor);
	}

	void Window::PutChar(int chr, int x, int y, int forecolor, int backcolor)
	{
		PutChar(chr, x, y, forecolor, backcolor, Ctx->Chars);
	}

	void Window::PutChar(int chr, int x, int y, int forecolor, int backcolor, Charset* chars)
	{
		if (Border) {
			x++;
			y++;
		}

		Ctx->Gr->PutChar(chars, chr, X + x, Y + y, forecolor, backcolor);
	}
}
