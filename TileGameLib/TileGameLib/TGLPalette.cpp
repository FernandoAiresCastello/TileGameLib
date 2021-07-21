/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdio>
#include "TGLPalette.h"

namespace TileGameLib
{
	TGLPalette::TGLPalette()
	{
		InitDefault();
	}

	TGLPalette::TGLPalette(const TGLPalette& other)
	{
		Colors.clear();
		for (auto& ch : other.Colors)
			Add(ch);
	}

	TGLPalette::~TGLPalette()
	{
	}

	std::vector<TGLColor>& TGLPalette::GetColors()
	{
		return Colors;
	}

	TGLColor& TGLPalette::Get(TGLPaletteIndex ix)
	{
		return Colors[ix];
	}

	TGLColorRGB TGLPalette::GetColorRGB(TGLPaletteIndex ix)
	{
		return Colors[ix].ToColorRGB();
	}

	int TGLPalette::GetSize()
	{
		return Colors.size();
	}

	void TGLPalette::Set(TGLPaletteIndex ix, TGLColorRGB rgb)
	{
		Colors[ix].Set(rgb);
	}

	void TGLPalette::Set(TGLPaletteIndex ix, int r, int g, int b)
	{
		Colors[ix].Set(r, g, b);
	}

	void TGLPalette::SetEqual(TGLPalette& other)
	{
		Colors.clear();
		for (auto& color : other.Colors)
			Add(color);
	}

	void TGLPalette::Clear()
	{
		for (int i = 0; i < Colors.size(); i++)
			Set(i, 0x000000);
	}

	void TGLPalette::DeleteAll()
	{
		Colors.clear();
	}

	void TGLPalette::AddBlank(int count)
	{
		for (int i = 0; i < count; i++)
			Add(TGLColor());
	}

	void TGLPalette::Add(TGLColor color)
	{
		Colors.push_back(color);
	}

	void TGLPalette::Add(int r, int g, int b)
	{
		Colors.push_back(TGLColor(r, g, b));
	}

	void TGLPalette::Add(TGLColorRGB rgb)
	{
		Colors.push_back(TGLColor(rgb));
	}

	void TGLPalette::InitDefault()
	{
		DeleteAll();

		Add(0x000000);
		Add(0xffffff);
		Add(0xe0e0e0);
		Add(0xc0c0c0);
		Add(0x808080);
		Add(0x505050);
		Add(0x303030);
		Add(0x101010);
		Add(0x500000);
		Add(0x800000);
		Add(0xc00000);
		Add(0xff0000);
		Add(0xff5050);
		Add(0xff8080);
		Add(0xffc0c0);
		Add(0xffe0e0);
		Add(0xc02000);
		Add(0xff5000);
		Add(0xff8000);
		Add(0xffc000);
		Add(0xffc050);
		Add(0xffc080);
		Add(0xffa050);
		Add(0x808050);
		Add(0x505000);
		Add(0x808000);
		Add(0xc0c000);
		Add(0xffff00);
		Add(0xffff50);
		Add(0xffff80);
		Add(0xffffc0);
		Add(0xc0c080);
		Add(0x005000);
		Add(0x008000);
		Add(0x00c000);
		Add(0x00ff00);
		Add(0x80ff00);
		Add(0x80ff80);
		Add(0xc0ff00);
		Add(0xc0ff80);
		Add(0x005050);
		Add(0x008080);
		Add(0x00c0c0);
		Add(0x00ffff);
		Add(0x80e0ff);
		Add(0x00ffc0);
		Add(0x00ff80);
		Add(0x00ff50);
		Add(0x000050);
		Add(0x000080);
		Add(0x0000c0);
		Add(0x0000ff);
		Add(0x0050ff);
		Add(0x0080ff);
		Add(0x00a0ff);
		Add(0x00c0ff);
		Add(0x200050);
		Add(0x300050);
		Add(0x500080);
		Add(0x8000ff);
		Add(0x8050ff);
		Add(0xc080ff);
		Add(0xc0a0ff);
		Add(0xc0c0ff);
		Add(0x500050);
		Add(0x800080);
		Add(0xc000c0);
		Add(0xff00ff);
		Add(0xff50ff);
		Add(0xff80ff);
		Add(0xffc0ff);
		Add(0xffe0ff);
	}
}
