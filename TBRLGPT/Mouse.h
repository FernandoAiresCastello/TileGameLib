/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class Graphics;

	class TBRLGPT_API Mouse
	{
	public:
		static int GetWinX();
		static int GetWinY();
		static int GetPixelX(Graphics* g);
		static int GetPixelY(Graphics* g);
		static int GetCharX(Graphics* g);
		static int GetCharY(Graphics* g);
		static bool LeftPressed();
		static bool RightPressed();
		static void Show(bool show);
	};
}
