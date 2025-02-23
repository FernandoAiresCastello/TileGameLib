#include "TGL_Palette.h"

namespace TGL
{
	Palette::Palette()
	{
		InitDefault();
	}

	Palette::Palette(const Palette& other)
	{
		colors = other.colors;
	}

	void Palette::Add(const Color& color)
	{
		colors.push_back(color);
	}

	void Palette::Set(Index index, const Color& color)
	{
		colors[index] = color;
	}

	Color& Palette::Get(Index index)
	{
		return colors[index];
	}

	void Palette::RemoveAll()
	{
		colors.clear();
	}

	void Palette::InitDefault()
	{
		RemoveAll();

		for (int i = 0; i < 256; i++)
			Add(0x000000);

		Set(0, 0x000000);
		Set(1, 0xffffff);
	}
}
