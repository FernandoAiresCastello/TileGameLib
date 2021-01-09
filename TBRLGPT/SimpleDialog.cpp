/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "SimpleDialog.h"
#include "UIContext.h"
#include "Graphics.h"
#include "TextInput.h"
#include "Keyboard.h"
#include "Window.h"

namespace TBRLGPT
{
	SimpleDialog::SimpleDialog(UIContext* ctx)
	{
		Ctx = ctx;
		Escaped = false;
		FirstRow = ctx->Gr->Rows - 3;
		LastRow = ctx->Gr->Rows - 1;
		Width = Ctx->Gr->Cols;
	}

	SimpleDialog::SimpleDialog(UIContext* ctx, int y)
	{
		Ctx = ctx;
		Escaped = false;
		FirstRow = y;
		LastRow = y + 2;
		Width = Ctx->Gr->Cols;
	}

	SimpleDialog::SimpleDialog(UIContext * ctx, int y, int w)
	{
		Ctx = ctx;
		Escaped = false;
		FirstRow = y;
		LastRow = y + 2;
		Width = w;
	}

	SimpleDialog::~SimpleDialog()
	{
	}

	std::string SimpleDialog::ReadString(std::string msg)
	{
		return ReadString(msg, Width - 2);
	}

	int SimpleDialog::GetFirstRow()
	{
		return FirstRow;
	}

	void SimpleDialog::DrawWindow(bool border)
	{
		if (border) {
			Window win(Ctx, 0, FirstRow, Width, LastRow - FirstRow + 1);
			win.Draw();
		}
		else {
			Clear();
		}
	}

	void SimpleDialog::ShowMessage(std::string msg)
	{
		ShowMessage(msg, Ctx->ForeColor);
	}

	void SimpleDialog::ShowMessage(std::string msg, int color)
	{
		Clear();
		Ctx->Gr->Print(Ctx->Chars, 1, FirstRow, color, Ctx->BackColor, msg);
		Ctx->Update();
		Key::WaitAny();
	}

	std::string SimpleDialog::ReadString(std::string msg, int length)
	{
		Clear();
		Ctx->Print(1, FirstRow, msg);
		TextInput input(Ctx);
		std::string str = input.ReadString(1, FirstRow + 1, length, false);
		Escaped = input.HasEscaped();
		Clear();
		return str;
	}

	int SimpleDialog::ReadInteger(std::string msg)
	{
		return ReadInteger(msg, Width - 2);
	}

	int SimpleDialog::ReadInteger(std::string msg, int length)
	{
		Clear();
		Ctx->Print(1, FirstRow, msg);
		TextInput input(Ctx);
		int integer = input.ReadInteger(1, FirstRow + 1, length, false);
		Escaped = input.HasEscaped();
		Clear();
		return integer;
	}

	bool SimpleDialog::HasEscaped()
	{
		return Escaped;
	}

	void SimpleDialog::Clear()
	{
		Ctx->ClearRect(0, FirstRow, Width, LastRow - FirstRow + 1);
	}
}
