/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <cstdio>
#include "Palette.h"

namespace TBRLGPT
{
	const int Palette::Size = 256;

	Palette::Palette()
	{
		Colors = new Color[Size];
		InitDefaultColors();
	}

	Palette::~Palette()
	{
		delete[] Colors;
	}

	Color* Palette::Get(int index)
	{
		return &Colors[index];
	}

	void Palette::Set(int index, int rgb)
	{
		Colors[index].SetRGB(rgb);
	}

	void Palette::Set(int index, int r, int g, int b)
	{
		Colors[index].SetRGB(r, g, b);
	}

	void Palette::Clear()
	{
		for (int i = 0; i < Size; i++)
			Set(i, 0x000000);
	}

	void Palette::Save(std::string filename)
	{
		FILE* fp = fopen(filename.c_str(), "wb");

		for (int i = 0; i < Size; i++)
		{
			Color* color = Get(i);
			fputc(color->R, fp);
			fputc(color->G, fp);
			fputc(color->B, fp);
		}

		fflush(fp);
		fclose(fp);
	}

	void Palette::Load(std::string filename)
	{
		FILE* fp = fopen(filename.c_str(), "rb");

		if (fp) {
			for (int i = 0; i < Size; i++) {
				Color* color = Get(i);
				color->R = fgetc(fp);
				color->G = fgetc(fp);
				color->B = fgetc(fp);
			}

			fclose(fp);
		}
		else {
			InitDefaultColors();
		}
	}

	void Palette::InitDefaultColors()
	{
		int i = 0;

		Clear();

		Set(i++, 0x000000);
		Set(i++, 0xffffff);
		Set(i++, 0xe0e0e0);
		Set(i++, 0xc0c0c0);
		Set(i++, 0x808080);
		Set(i++, 0x505050);
		Set(i++, 0x303030);
		Set(i++, 0x101010);
		Set(i++, 0x500000);
		Set(i++, 0x800000);
		Set(i++, 0xc00000);
		Set(i++, 0xff0000);
		Set(i++, 0xff5050);
		Set(i++, 0xff8080);
		Set(i++, 0xffc0c0);
		Set(i++, 0xffe0e0);
		Set(i++, 0xc02000);
		Set(i++, 0xff5000);
		Set(i++, 0xff8000);
		Set(i++, 0xffc000);
		Set(i++, 0xffc050);
		Set(i++, 0xffc080);
		Set(i++, 0xffa050);
		Set(i++, 0x808050);
		Set(i++, 0x505000);
		Set(i++, 0x808000);
		Set(i++, 0xc0c000);
		Set(i++, 0xffff00);
		Set(i++, 0xffff50);
		Set(i++, 0xffff80);
		Set(i++, 0xffffc0);
		Set(i++, 0xc0c080);
		Set(i++, 0x005000);
		Set(i++, 0x008000);
		Set(i++, 0x00c000);
		Set(i++, 0x00ff00);
		Set(i++, 0x80ff00);
		Set(i++, 0x80ff80);
		Set(i++, 0xc0ff00);
		Set(i++, 0xc0ff80);
		Set(i++, 0x005050);
		Set(i++, 0x008080);
		Set(i++, 0x00c0c0);
		Set(i++, 0x00ffff);
		Set(i++, 0x80e0ff);
		Set(i++, 0x00ffc0);
		Set(i++, 0x00ff80);
		Set(i++, 0x00ff50);
		Set(i++, 0x000050);
		Set(i++, 0x000080);
		Set(i++, 0x0000c0);
		Set(i++, 0x0000ff);
		Set(i++, 0x0050ff);
		Set(i++, 0x0080ff);
		Set(i++, 0x00a0ff);
		Set(i++, 0x00c0ff);
		Set(i++, 0x200050);
		Set(i++, 0x300050);
		Set(i++, 0x500080);
		Set(i++, 0x8000ff);
		Set(i++, 0x8050ff);
		Set(i++, 0xc080ff);
		Set(i++, 0xc0a0ff);
		Set(i++, 0xc0c0ff);
		Set(i++, 0x500050);
		Set(i++, 0x800080);
		Set(i++, 0xc000c0);
		Set(i++, 0xff00ff);
		Set(i++, 0xff50ff);
		Set(i++, 0xff80ff);
		Set(i++, 0xffc0ff);
		Set(i++, 0xffe0ff);
	}
}
