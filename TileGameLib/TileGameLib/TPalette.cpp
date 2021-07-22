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
		Add(0x381400);
		Add(0x441804);
		Add(0x481404);
		Add(0x040468);
		Add(0x280478);
		Add(0x340888);
		Add(0x041c80);
		Add(0x0c0488);
		Add(0x1c2858);
		Add(0x2c4000);
		Add(0x084008);
		Add(0x044008);
		Add(0x00340c);
		Add(0x243000);
		Add(0x401800);
		Add(0x383838);
		Add(0x803008);
		Add(0x9c241c);
		Add(0xb01c14);
		Add(0x702070);
		Add(0x580c90);
		Add(0x500cd0);
		Add(0x082cc8);
		Add(0x382cb4);
		Add(0x1c4890);
		Add(0x446000);
		Add(0x10680c);
		Add(0x046410);
		Add(0x0c481c);
		Add(0x204004);
		Add(0x702408);
		Add(0x787878);
		Add(0xc85c24);
		Add(0xc85020);
		Add(0xdc241c);
		Add(0xa430a4);
		Add(0x8838a8);
		Add(0x7844d0);
		Add(0x444cdc);
		Add(0x584cd8);
		Add(0x1c70c4);
		Add(0x3c9420);
		Add(0x149010);
		Add(0x088814);
		Add(0x4c7420);
		Add(0x806830);
		Add(0xa8501c);
		Add(0xa8a8a8);
		Add(0xfc901c);
		Add(0xfc801c);
		Add(0xf85054);
		Add(0xcc3ccc);
		Add(0xc048dc);
		Add(0xa050d8);
		Add(0x5868fc);
		Add(0x6864fc);
		Add(0x4898d8);
		Add(0x54a838);
		Add(0x1cb814);
		Add(0x08ac1c);
		Add(0x649028);
		Add(0xac9838);
		Add(0xbc7430);
		Add(0xcccccc);
		Add(0xfcc41c);
		Add(0xfc982c);
		Add(0xfc706c);
		Add(0xe850e8);
		Add(0xe05cfc);
		Add(0xbc60fc);
		Add(0x7080fc);
		Add(0x8884fc);
		Add(0x54b4fc);
		Add(0x60d070);
		Add(0x20d818);
		Add(0x84d820);
		Add(0xa0b034);
		Add(0xd4b440);
		Add(0xe09044);
		Add(0xe4e4e4);
		Add(0xfcd84c);
		Add(0xfcc444);
		Add(0xfc8c8c);
		Add(0xfc6cfc);
		Add(0xf07cfc);
		Add(0xcc74fc);
		Add(0x90a0fc);
		Add(0x9898fc);
		Add(0x8cd8fc);
		Add(0x70f484);
		Add(0x6cf040);
		Add(0x98f824);
		Add(0xb0d040);
		Add(0xe0c838);
		Add(0xf8ac58);
		Add(0xf0f0f0);
		Add(0xfcf454);
		Add(0xfcc46c);
		Add(0xfca8ac);
		Add(0xfc84f8);
		Add(0xfc98fc);
		Add(0xd490fc);
		Add(0x9cb0fc);
		Add(0xb0acfc);
		Add(0x98dcfc);
		Add(0x84fc94);
		Add(0x80fc58);
		Add(0xb4fc58);
		Add(0xd4e048);
		Add(0xe0e434);
		Add(0xfcc060);
		Add(0xfcfcfc);
		Add(0xfcfc98);
		Add(0xfce4a0);
		Add(0xfcc4cc);
		Add(0xfca4fc);
		Add(0xfca8fc);
		Add(0xdca8fc);
		Add(0xc0c8fc);
		Add(0xc0c0fc);
		Add(0xc0e8fc);
		Add(0xacfcb4);
		Add(0xb0fc98);
		Add(0xdcfc80);
		Add(0xf0fc50);
		Add(0xf8fc7c);
	}
}
