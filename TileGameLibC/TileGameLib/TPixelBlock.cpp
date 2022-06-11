#include "TPixelBlock.h"

namespace TileGameLib
{
	TPixelBlock::TPixelBlock()
	{
		Width = 0;
		Height = 0;
	}

	TPixelBlock::TPixelBlock(const TPixelBlock& other)
	{
		Width = other.Width;
		Height = other.Height;
		Colors = other.Colors;
	}

	bool TPixelBlock::operator==(const TPixelBlock& other)
	{
		return 
			Width == other.Width &&
			Height == other.Height &&
			Colors == other.Colors;
	}

	bool TPixelBlock::operator!=(const TPixelBlock& other)
	{
		return !operator==(other);
	}
	
	void TPixelBlock::SetSize(int width, int height)
	{
		Width = width;
		Height = height;
		
		Colors.clear();
		Colors.resize(width * height);
	}

	int TPixelBlock::GetWidth()
	{
		return Width;
	}

	int TPixelBlock::GetHeight()
	{
		return Height;
	}

	void TPixelBlock::SetColors(std::vector<RGB> colors)
	{
		Colors = colors;
	}

	std::vector<RGB>& TPixelBlock::GetColors()
	{
		return Colors;
	}

	RGB TPixelBlock::GetColor(int index)
	{
		return Colors[index];
	}
	
	RGB TPixelBlock::GetColor(int x, int y)
	{
		return Colors[y * Width + x];
	}

	void TPixelBlock::SetColor(int index, RGB rgb)
	{
		Colors[index] = rgb;
	}
	
	void TPixelBlock::SetColor(int x, int y, RGB rgb)
	{
		Colors[y * Width + x] = rgb;
	}
}
