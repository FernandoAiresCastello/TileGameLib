/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdio>
#include "TPalette.h"
#include "TFile.h"

namespace TileGameLib
{
	TPalette* TPalette::Default = new TPalette();

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

	void TPalette::Load(std::string filename)
	{
		DeleteAll();
		auto bytes = TFile::ReadBytes(filename);
		for (int i = 0; i < bytes.size(); i += 3)
			Add(bytes[i + 0], bytes[i + 1], bytes[i + 2]);
	}

	void TPalette::Save(std::string filename)
	{
		std::vector<int> bytes;

		for (auto& color : Colors) {
			bytes.push_back(color.R);
			bytes.push_back(color.G);
			bytes.push_back(color.B);
		}

		TFile::WriteBytes(filename, bytes);
	}

	void TPalette::InitDefault()
	{
		DeleteAll();

		Add(0x000000);
		Add(0x111111);
		Add(0x222222);
		Add(0x333333);
		Add(0x444444);
		Add(0x555555);
		Add(0x666666);
		Add(0x777777);
		Add(0x888888);
		Add(0x999999);
		Add(0xaaaaaa);
		Add(0xbbbbbb);
		Add(0xcccccc);
		Add(0xdddddd);
		Add(0xeeeeee);
		Add(0xffffff);
		Add(0x1e0500);
		Add(0x2f1700);
		Add(0x412800);
		Add(0x523a00);
		Add(0x644b00);
		Add(0x765d00);
		Add(0x876f00);
		Add(0x988100);
		Add(0xa99100);
		Add(0xbaa20a);
		Add(0xcbb31b);
		Add(0xdcc42c);
		Add(0xedd53d);
		Add(0xfee64e);
		Add(0xfff863);
		Add(0xffff7b);
		Add(0x3c0000);
		Add(0x500000);
		Add(0x611200);
		Add(0x732300);
		Add(0x843500);
		Add(0x964700);
		Add(0xa75800);
		Add(0xb86902);
		Add(0xc97a13);
		Add(0xda8b24);
		Add(0xeb9c35);
		Add(0xfcad46);
		Add(0xffbe57);
		Add(0xffd06f);
		Add(0xffe289);
		Add(0xfff5a2);
		Add(0x4b0000);
		Add(0x5f0000);
		Add(0x720000);
		Add(0x841000);
		Add(0x952101);
		Add(0xa63212);
		Add(0xb74323);
		Add(0xc85434);
		Add(0xd96545);
		Add(0xea7656);
		Add(0xfb8767);
		Add(0xff9878);
		Add(0xffaa8f);
		Add(0xffbda8);
		Add(0xffcfc1);
		Add(0xffe1d9);
		Add(0x4a0005);
		Add(0x5e0013);
		Add(0x730021);
		Add(0x840331);
		Add(0x951442);
		Add(0xa62553);
		Add(0xb73664);
		Add(0xc84775);
		Add(0xd95886);
		Add(0xea6997);
		Add(0xfb7aa8);
		Add(0xff8bb9);
		Add(0xff9dd0);
		Add(0xffb0e9);
		Add(0xffc2f4);
		Add(0xffd5f7);
		Add(0x380048);
		Add(0x4c0055);
		Add(0x600062);
		Add(0x720173);
		Add(0x831284);
		Add(0x942395);
		Add(0xa534a6);
		Add(0xb645b7);
		Add(0xc756c8);
		Add(0xd867d9);
		Add(0xe978ea);
		Add(0xfa89f2);
		Add(0xff9bee);
		Add(0xffadf0);
		Add(0xffc0f3);
		Add(0xffd3f6);
		Add(0x190079);
		Add(0x2d0087);
		Add(0x410095);
		Add(0x5208a6);
		Add(0x6319b7);
		Add(0x742ac8);
		Add(0x853bd9);
		Add(0x964cea);
		Add(0xa75dfb);
		Add(0xb86eff);
		Add(0xca80ff);
		Add(0xdc92ff);
		Add(0xeda3fa);
		Add(0xffb5f6);
		Add(0xffc7f2);
		Add(0xffdaf8);
		Add(0x000090);
		Add(0x0a009f);
		Add(0x1b08af);
		Add(0x2c19c0);
		Add(0x3d2ad1);
		Add(0x4e3be2);
		Add(0x5f4cf3);
		Add(0x705dff);
		Add(0x816eff);
		Add(0x937fff);
		Add(0xa491ff);
		Add(0xb6a2ff);
		Add(0xc7b4ff);
		Add(0xd9c5ff);
		Add(0xebd7ff);
		Add(0xfce9fc);
		Add(0x00007c);
		Add(0x000c93);
		Add(0x001fac);
		Add(0x0730bd);
		Add(0x1841ce);
		Add(0x2952df);
		Add(0x3a63f0);
		Add(0x4b74ff);
		Add(0x5c85ff);
		Add(0x6d96ff);
		Add(0x7fa7ff);
		Add(0x91b9ff);
		Add(0xa2caff);
		Add(0xb4dcff);
		Add(0xc5eeff);
		Add(0xd7ffff);
		Add(0x000f50);
		Add(0x002269);
		Add(0x003482);
		Add(0x00469b);
		Add(0x0058ad);
		Add(0x0e69be);
		Add(0x1f7acf);
		Add(0x308be0);
		Add(0x419cf1);
		Add(0x52adff);
		Add(0x63beff);
		Add(0x74cfff);
		Add(0x86e1ff);
		Add(0x97f2ff);
		Add(0xa9ffff);
		Add(0xbdffff);
		Add(0x002114);
		Add(0x00332c);
		Add(0x004545);
		Add(0x00585e);
		Add(0x006a75);
		Add(0x007b86);
		Add(0x118c97);
		Add(0x229da8);
		Add(0x33aeb9);
		Add(0x44bfca);
		Add(0x55d0db);
		Add(0x66e1ec);
		Add(0x77f2fd);
		Add(0x89ffff);
		Add(0x9cffff);
		Add(0xb1ffff);
		Add(0x002a07);
		Add(0x003d0a);
		Add(0x00500f);
		Add(0x00621f);
		Add(0x007433);
		Add(0x068544);
		Add(0x179655);
		Add(0x28a766);
		Add(0x39b877);
		Add(0x4ac988);
		Add(0x5bda99);
		Add(0x6cebaa);
		Add(0x7dfcbb);
		Add(0x8effcb);
		Add(0xa3ffd9);
		Add(0xb7ffe7);
		Add(0x002a07);
		Add(0x003d0a);
		Add(0x00500f);
		Add(0x00620d);
		Add(0x0a7409);
		Add(0x1c8504);
		Add(0x2d9615);
		Add(0x3ea726);
		Add(0x4fb837);
		Add(0x60c948);
		Add(0x71da59);
		Add(0x82eb6a);
		Add(0x93fc7b);
		Add(0xa5ff8c);
		Add(0xb9ff9a);
		Add(0xcdffa7);
		Add(0x002106);
		Add(0x003409);
		Add(0x084504);
		Add(0x1a5700);
		Add(0x2b6900);
		Add(0x3d7a00);
		Add(0x4f8c00);
		Add(0x609d00);
		Add(0x71ae0a);
		Add(0x82bf1b);
		Add(0x93d02c);
		Add(0xa4e13d);
		Add(0xb5f24e);
		Add(0xc6ff5f);
		Add(0xd9ff6d);
		Add(0xeeff7b);
		Add(0x0d0f00);
		Add(0x1e2100);
		Add(0x303200);
		Add(0x414400);
		Add(0x535500);
		Add(0x646700);
		Add(0x767900);
		Add(0x878a00);
		Add(0x989b00);
		Add(0xa9ac08);
		Add(0xbabd19);
		Add(0xcbce2a);
		Add(0xdcdf3b);
		Add(0xedf04c);
		Add(0xfeff5d);
		Add(0xffff71);
		Add(0x300000);
		Add(0x420a00);
		Add(0x541c00);
		Add(0x652d00);
		Add(0x773f00);
		Add(0x885000);
		Add(0x9a6200);
		Add(0xab7300);
		Add(0xbc8402);
		Add(0xcd9513);
		Add(0xdea624);
		Add(0xefb735);
		Add(0xffc846);
		Add(0xffda5a);
		Add(0xffec73);
		Add(0xfffe8c);
	}
}
