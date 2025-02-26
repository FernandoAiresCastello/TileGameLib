#pragma once
#include "TGL_Global.h"
#include "TGL_CharTile.h"
#include "TGL_Properties.h"
#include "TGL_List.h"
#include "TGL_Size.h"
#include "TGL_Point.h"

namespace TGL
{
	class TGLAPI CharTileMap
	{
	public:
		CharTileMap();
		~CharTileMap();

		void SetCharset(Charset* charset);
		void SetPalette(Palette* palette);
		void SetCharsetAndPalette(Charset* charset, Palette* palette);
		void SetCellCount(const Size& size);
		void SetTile(const Point& pos, const CharTile& tile);
		CharTile& GetTile(const Point& pos);
		void Fill(const CharTile& tile);
		void Draw(Graphics* gr, const Point& pos);

	private:
		Charset* charset = nullptr;
		Palette* palette = nullptr;
		int cols = 0;
		int rows = 0;
		int cellCount = 0;
		bool visible = true;
		List<CharTile> cells;
	};
}
