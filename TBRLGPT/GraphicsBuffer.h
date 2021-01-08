/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Global.h"
#include "Graphics.h"
#include "Charset.h"
#include "Palette.h"
#include "GraphicsBufferChar.h"

namespace TBRLGPT
{
	class TBRLGPT_API GraphicsBuffer
	{
	public:
		GraphicsBuffer(int width, int height);
		~GraphicsBuffer();

		int GetWidth();
		int GetHeight();
		int GetSize();
		void Put(GraphicsBufferChar ch, int x, int y);
		void Put(int ix, int fgc, int bgc, int x, int y);
		GraphicsBufferChar* Get(int x, int y);
		void Fill(GraphicsBufferChar ch);
		void Fill(int ix, int fgc, int bgc);

	private:
		std::vector<GraphicsBufferChar> Buffer;
		const int Width;
		const int Height;
		const int Size;
	};
}
