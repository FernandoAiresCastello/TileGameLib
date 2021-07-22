/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdio>
#include "TPalette.h"

namespace TileGameLib
{
	TPalette::TPalette()
	{
		InitDefault();
	}

	TPalette::TPalette(const TPalette& other)
	{
		Colors.clear();
		for (auto& ch : other.Colors)
			Add(ch);
	}

	TPalette::~TPalette()
	{
	}

	std::vector<TColor>& TPalette::GetColors()
	{
		return Colors;
	}

	TColor& TPalette::Get(TPaletteIndex ix)
	{
		return Colors[ix];
	}

	TColorRGB TPalette::GetColorRGB(TPaletteIndex ix)
	{
		return Colors[ix].ToColorRGB();
	}

	int TPalette::GetSize()
	{
		return Colors.size();
	}

	void TPalette::Set(TPaletteIndex ix, TColorRGB rgb)
	{
		Colors[ix].Set(rgb);
	}

	void TPalette::Set(TPaletteIndex ix, int r, int g, int b)
	{
		Colors[ix].Set(r, g, b);
	}

	void TPalette::SetEqual(TPalette& other)
	{
		Colors.clear();
		for (auto& color : other.Colors)
			Add(color);
	}

	void TPalette::Clear()
	{
		for (int i = 0; i < Colors.size(); i++)
			Set(i, 0x000000);
	}

	void TPalette::DeleteAll()
	{
		Colors.clear();
	}

	void TPalette::AddBlank(int count)
	{
		for (int i = 0; i < count; i++)
			Add(TColor());
	}

	void TPalette::Add(TColor color)
	{
		Colors.push_back(color);
	}

	void TPalette::Add(int r, int g, int b)
	{
		Colors.push_back(TColor(r, g, b));
	}

	void TPalette::Add(TColorRGB rgb)
	{
		Colors.push_back(TColor(rgb));
	}

	void TPalette::InitDefault()
	{
		DeleteAll();

		Add(0x000000);
		Add(0xffffff);
		Add(0xff0000);
		Add(0xff8000);
		Add(0xffff00);
		Add(0x00ff00);
		Add(0x00ffff);
		Add(0x0000ff);
		Add(0x8000ff);
		Add(0xff00ff);
		Add(0x808080);
	}
}
