#pragma once
#include "TGL_Global.h"
#include "TGL_Index.h"

namespace TGL
{
	class TGLAPI CharTileFrame
	{
	public:
		Index Char;
		Index ForeColor;
		Index BackColor;

		CharTileFrame();
		CharTileFrame(const CharTileFrame& other);
		CharTileFrame(Index ch, Index foreColor, Index backColor);

		bool operator==(const CharTileFrame& other) const;
		CharTileFrame& operator=(const CharTileFrame& other);

		void Set(Index ch, Index foreColor, Index backColor);
	};
}
