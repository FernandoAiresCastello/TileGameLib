/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <map>
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TTile.h"
#include "TTileSeq.h"
#include "TTileBuffer.h"
#include "TWindowBase.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TCharset;
	class TPalette;

	class TBufferedWindow : public TWindowBase
	{
	public:
		const int LayerCount;
		const int Cols;
		const int Rows;
		const int LastCol;
		const int LastRow;
		const int PixelWidth;
		const int PixelHeight;

		TBufferedWindow(int layerCount, int cols, int rows, int pixelWidth, int pixelHeight);
		virtual ~TBufferedWindow();
		virtual void Update();

		TCharset* GetCharset();
		TPalette* GetPalette();
		TTileBuffer* GetBuffer();
		int GetCols();
		int GetRows();
		void SetAnimationSpeed(int speed);
		void EnableAnimation(bool enable);
		bool IsAnimationEnabled();

	private:
		TCharset* Chr;
		TPalette* Pal;
		TTileBuffer* TileBuf;

		virtual void SetPixel(int x, int y, RGB rgb);
		void DrawTile(TTile& tile, int x, int y, bool transparent);
		void DrawTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y, bool transparent);
		void DrawByteAsPixels(byte value, int x, int y, PaletteIndex fg, PaletteIndex bg, bool transparent);
		void DrawTileBuffer();
	};
}
