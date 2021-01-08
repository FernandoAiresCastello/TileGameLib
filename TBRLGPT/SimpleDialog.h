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

	class TBRLGPT_API SimpleDialog
	{
	public:
		SimpleDialog(UIContext* ctx);
		SimpleDialog(UIContext* ctx, int y);
		SimpleDialog(UIContext* ctx, int y, int w);
		~SimpleDialog();

		int GetFirstRow();
		void DrawWindow(bool border);
		void ShowMessage(std::string msg);
		void ShowMessage(std::string msg, int color);
		std::string ReadString(std::string msg, int length);
		std::string ReadString(std::string msg);
		int ReadInteger(std::string msg, int length);
		int ReadInteger(std::string msg);
		bool HasEscaped();

	private:
		UIContext* Ctx;
		bool Escaped;
		int FirstRow;
		int LastRow;
		int Width;

		void Clear();
	};
}
