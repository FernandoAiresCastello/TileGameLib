/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "AnimatedDialog.h"
#include "TextPrinter.h"
#include "Window.h"
#include "Keyboard.h"
#include "UIContext.h"
#include "Util.h"

namespace TBRLGPT
{
	AnimatedDialog::AnimatedDialog(UIContext* ctx, int x, int y, int w, int h)
	{
		Ctx = ctx;
		X = x;
		Y = y;
		Width = w;
		Height = h;
		Border = true;
		Arrow = true;
		WindowDelay = 25;
		TypeDelay = 50;
	}

	AnimatedDialog::~AnimatedDialog()
	{
	}

	void AnimatedDialog::Show(std::string text, int forecolor, int backcolor)
	{
		int prevForeColor = Ctx->ForeColor;
		int prevBackColor = Ctx->BackColor;
		Ctx->ForeColor = forecolor;
		Ctx->BackColor = backcolor;
		Show(text);
		Ctx->ForeColor = prevForeColor;
		Ctx->BackColor = prevBackColor;
	}

	void AnimatedDialog::ShowBorder(bool border)
	{
		Border = border;
	}

	void AnimatedDialog::ShowArrow(bool arrow)
	{
		Arrow = arrow;
	}

	void AnimatedDialog::SetDelay(int windowDelay, int typeDelay)
	{
		WindowDelay = windowDelay;
		TypeDelay = typeDelay;
	}

	void AnimatedDialog::Show(std::string text)
	{
		Window win(Ctx, X, Y, Width, 0, Border);
		while (win.Height <= Height) {
			win.Draw();
			win.Height++;
			Ctx->Update();
			Util::Pause(WindowDelay);
		}
		TextPrinter printer(Ctx);
		printer.Locate(Border ? X + 1 : X, Border ? Y + 1 : Y);
		printer.PrintPaged(text, Width - 1, Height, true, true, TypeDelay);
		Ctx->Update();
		Key::WaitAny();
	}
}
 