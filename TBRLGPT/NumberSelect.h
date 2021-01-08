/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include "Global.h"

namespace TBRLGPT
{
	class Window;
	class UIContext;

	class TBRLGPT_API NumberSelect
	{
	public:
		NumberSelect(UIContext* ctx, int x, int y);
		NumberSelect(UIContext* ctx, int x, int y, int w, int h);
		~NumberSelect();

		int Select(int max);
		int Select(int min, int max);
		int Select(int initialNumber, int min, int max);

		void SetZeroPadding(bool padZero);
		void SetWrapAround(bool wrap);
		bool HasEscaped();

	private:
		UIContext* Ctx;
		Window* Win;
		int Number;
		int Min;
		int Max;
		bool PadZero;
		bool Wrap;
		bool Escaped;

		void Draw();
	};
}
