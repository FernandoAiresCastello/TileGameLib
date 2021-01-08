/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "ConfirmDialog.h"
#include "Graphics.h"
#include "TextInput.h"
#include "Charset.h"
#include "UIContext.h"

namespace TBRLGPT
{
	ConfirmDialog::ConfirmDialog(UIContext* ctx)
	{
		Ctx = ctx;
		Y = Ctx->Gr->Rows - 3;
		Width = Ctx->Gr->Cols;
	}

	ConfirmDialog::ConfirmDialog(UIContext * ctx, int y)
	{
		Ctx = ctx;
		Y = y;
		Width = Ctx->Gr->Cols;
	}

	ConfirmDialog::ConfirmDialog(UIContext * ctx, int y, int w)
	{
		Ctx = ctx;
		Y = y;
		Width = w;
	}

	ConfirmDialog::~ConfirmDialog()
	{
	}

	bool ConfirmDialog::Confirm(std::string message)
	{
		const int row = Y;

		Ctx->ClearRect(0, row, Width, row + 2);
		Ctx->Print(1, row, message + " (Y/N)?");
		TextInput input(Ctx);
		std::string cmdline = input.ReadString(1, row + 1, 1, false);
		Ctx->ClearRect(0, row, Width, row + 2);

		return cmdline[0] == 'Y' || cmdline[0] == 'y';
	}
}
