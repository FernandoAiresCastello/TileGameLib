/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello

=============================================================================*/
#include "TPixelBlock.h"

namespace TileGameLib
{
	TPixelBlock::TPixelBlock(int w, int h) 
		: Width(w), Height(h), Size(w * h)
	{
		for (int i = 0; i < w * h; i++)
			Colors.push_back(TPixelBlock::Transparent);
	}

	TPixelBlock::TPixelBlock(int w, int h, std::vector<int>& colors) 
		: Width(w), Height(h), Size(w* h)
	{
		for (auto& color : colors)
			Colors.push_back(color);
	}

	TPixelBlock::~TPixelBlock()
	{
	}

	void TPixelBlock::SetPixel(int x, int y, int color)
	{
		Colors[y * Width + x] = color;
	}

	int TPixelBlock::GetPixel(int x, int y)
	{
		return Colors[y * Width + x];
	}

	void TPixelBlock::Fill(int color)
	{
		for (int i = 0; i < Size; i++)
			Colors[i] = color;
	}
}
