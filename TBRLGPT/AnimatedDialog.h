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
	
	class TBRLGPT_API AnimatedDialog
	{
	public:
		AnimatedDialog(UIContext* ctx, int x, int y, int w, int h);
		~AnimatedDialog();

		void Show(std::string text);
		void Show(std::string text, int forecolor, int backcolor);
		void ShowBorder(bool border);
		void ShowArrow(bool arrow);
		void SetDelay(int windowDelay, int typeDelay);

	private:
		UIContext* Ctx;
		int X;
		int Y;
		int Width;
		int Height;
		bool Border;
		bool Arrow;
		int WindowDelay;
		int TypeDelay;
	};
}
