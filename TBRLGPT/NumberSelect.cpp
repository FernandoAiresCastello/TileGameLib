/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "NumberSelect.h"
#include "Window.h"
#include "UIContext.h"
#include "StringUtils.h"
#include "Keyboard.h"
#include "Util.h"

namespace TBRLGPT
{
	NumberSelect::NumberSelect(UIContext * ctx, int x, int y) : NumberSelect(ctx, x, y, 0, 1)
	{
	}

	NumberSelect::NumberSelect(UIContext* ctx, int x, int y, int w, int h)
	{
		Ctx = ctx;
		Win = new Window(ctx, x, y, w, h);
		Escaped = false;
		PadZero = true;
		Wrap = true;
		Number = 0;
		Min = 0;
		Max = 0;
	}

	NumberSelect::~NumberSelect()
	{
		delete Win;
	}

	int NumberSelect::Select(int max)
	{
		return Select(0, 0, max);
	}

	int NumberSelect::Select(int min, int max)
	{
		return Select(min, min, max);
	}

	int NumberSelect::Select(int initialNumber, int min, int max)
	{
		Number = initialNumber;
		Min = min;
		Max = max;

		if (Win->Width == 0) {
			Win->Width = Util::GetDigitCount(max);
		}

		bool running = true;
		while (running) {
			Draw();
			int key = Key::WaitAny();
			switch (key) {
			case SDLK_ESCAPE:
				Number = initialNumber;
				Escaped = true;
				running = false;
				break;
			case SDLK_RETURN:
				running = false;
				break;
			case SDLK_UP:
				if (Number < max)
					Number++;
				else if (Wrap)
					Number = min;
				break;
			case SDLK_DOWN:
				if (Number > min)
					Number--;
				else if (Wrap)
					Number = max;
				break;
			}
		}

		return Number;
	}

	void NumberSelect::SetZeroPadding(bool padZero)
	{
		PadZero = padZero;
	}

	void NumberSelect::SetWrapAround(bool wrap)
	{
		Wrap = wrap;
	}

	bool NumberSelect::HasEscaped()
	{
		return Escaped;
	}

	void NumberSelect::Draw()
	{
		Win->Draw();
		Win->Print(0, 0, PadZero ? String::PadZero(Number, Util::GetDigitCount(Max)) : String::ToString(Number));
		Ctx->Update();
	}
}
