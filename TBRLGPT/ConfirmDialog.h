/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class UIContext;

	class TBRLGPT_API ConfirmDialog
	{
	public:
		ConfirmDialog(UIContext* ctx);
		ConfirmDialog(UIContext* ctx, int y);
		ConfirmDialog(UIContext* ctx, int y, int w);
		~ConfirmDialog();

		bool Confirm(std::string message);

	private:
		UIContext* Ctx;
		int Y;
		int Width;
	};
}
