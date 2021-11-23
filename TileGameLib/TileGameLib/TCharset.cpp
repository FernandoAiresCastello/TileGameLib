/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdio>
#include "TCharset.h"
#include "TChar.h"
#include <CppUtils.h>
#include "TFile.h"

using namespace CppUtils;

namespace TileGameLib
{
	TCharset* TCharset::Default = new TCharset();

	TCharset::TCharset()
	{
		InitDefault();
	}

	TCharset::TCharset(const TCharset& other)
	{
		Chars.clear();
		for (auto& ch : other.Chars)
			Add(ch);
	}

	TCharset::~TCharset()
	{
	}

	std::vector<TChar>& TCharset::GetChars()
	{
		return Chars;
	}

	TChar& TCharset::Get(TCharsetIndex ix)
	{
		return Chars[ix];
	}

	std::vector<byte> TCharset::GetBytes(TCharsetIndex ix)
	{
		return Chars[ix].GetBytes();
	}

	int TCharset::GetSize()
	{
		return Chars.size();
	}

	void TCharset::Clear()
	{
		for (unsigned i = 0; i < Chars.size(); i++)
			Set(i, 0, 0, 0, 0, 0, 0, 0, 0);
	}

	void TCharset::DeleteAll()
	{
		Chars.clear();
	}

	void TCharset::Add(TChar ch)
	{
		Chars.push_back(ch);
	}

	void TCharset::AddBlank(int count)
	{
		for (int i = 0; i < count; i++)
			Add(TChar());
	}

	void TCharset::Add(int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7)
	{
		Add(TChar(row0, row1, row2, row3, row4, row5, row6, row7));
	}

	void TCharset::Set(TCharsetIndex ix, int row0, int row1, int row2, int row3, int row4, int row5, int row6, int row7)
	{
		TChar& chars = Get(ix);

		chars.PixelRow0 = row0;
		chars.PixelRow1 = row1;
		chars.PixelRow2 = row2;
		chars.PixelRow3 = row3;
		chars.PixelRow4 = row4;
		chars.PixelRow5 = row5;
		chars.PixelRow6 = row6;
		chars.PixelRow7 = row7;
	}

	void TCharset::Set(TCharsetIndex ix,
		std::string row0, std::string row1, std::string row2, std::string row3, 
		std::string row4, std::string row5, std::string row6, std::string row7)
	{
		Set(ix, 
			String::ToInt(row0),
			String::ToInt(row1), 
			String::ToInt(row2), 
			String::ToInt(row3), 
			String::ToInt(row4), 
			String::ToInt(row5), 
			String::ToInt(row6), 
			String::ToInt(row7));
	}

	void TCharset::Set(TCharsetIndex ix, TChar& ch)
	{
		Get(ix).SetEqual(ch);
	}

	void TCharset::Set(TCharsetIndex ix, int rowIndex, int rowData)
	{
		TChar& ch = Get(ix);

		switch (rowIndex)
		{
			case 0: ch.PixelRow0 = rowData; break;
			case 1: ch.PixelRow1 = rowData; break;
			case 2: ch.PixelRow2 = rowData; break;
			case 3: ch.PixelRow3 = rowData; break;
			case 4: ch.PixelRow4 = rowData; break;
			case 5: ch.PixelRow5 = rowData; break;
			case 6: ch.PixelRow6 = rowData; break;
			case 7: ch.PixelRow7 = rowData; break;

			default:
				break;
		}
	}

	void TCharset::CopyChar(TCharsetIndex dstix, TCharsetIndex srcix)
	{
		TChar& src = Get(srcix);
		TChar& dst = Get(dstix);
		dst.SetEqual(src);
	}

	void TCharset::SetEqual(TCharset& other)
	{
		Chars.clear();
		for (auto& ch : other.Chars)
			Add(ch);
	}

	void TCharset::Load(std::string filename)
	{
		DeleteAll();
		auto bytes = TFile::ReadBytes(filename);
		for (int i = 0; i < bytes.size(); i += 8) {
			Add(bytes[i + 0], bytes[i + 1], bytes[i + 2], bytes[i + 3],
				bytes[i + 4], bytes[i + 5], bytes[i + 6], bytes[i + 7]);
		}
	}

	void TCharset::Save(std::string filename)
	{
		std::vector<int> bytes;

		for (auto& ch : Chars) {
			bytes.push_back(ch.PixelRow0);
			bytes.push_back(ch.PixelRow1);
			bytes.push_back(ch.PixelRow2);
			bytes.push_back(ch.PixelRow3);
			bytes.push_back(ch.PixelRow4);
			bytes.push_back(ch.PixelRow5);
			bytes.push_back(ch.PixelRow6);
			bytes.push_back(ch.PixelRow7);
		}

		TFile::WriteBytes(filename, bytes);
	}

	void TCharset::InitDefault()
	{
		DeleteAll();
		
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x7e, 0x81, 0xa5, 0x81, 0xbd, 0x99, 0x81, 0x7e);
		Add(0x7e, 0xff, 0xdb, 0xff, 0xc3, 0xe7, 0xff, 0x7e);
		Add(0x6c, 0xfe, 0xfe, 0xfe, 0x7c, 0x38, 0x10, 0x00);
		Add(0x10, 0x38, 0x7c, 0xfe, 0x7c, 0x38, 0x10, 0x00);
		Add(0x38, 0x7c, 0x38, 0xfe, 0xfe, 0xd6, 0x10, 0x38);
		Add(0x10, 0x10, 0x38, 0x7c, 0xfe, 0x7c, 0x10, 0x38);
		Add(0x00, 0x00, 0x18, 0x3c, 0x3c, 0x18, 0x00, 0x00);
		Add(0xff, 0xff, 0xe7, 0xc3, 0xc3, 0xe7, 0xff, 0xff);
		Add(0x00, 0x3c, 0x66, 0x42, 0x42, 0x66, 0x3c, 0x00);
		Add(0xff, 0xc3, 0x99, 0xbd, 0xbd, 0x99, 0xc3, 0xff);
		Add(0x0f, 0x07, 0x0f, 0x7d, 0xcc, 0xcc, 0xcc, 0x78);
		Add(0x3c, 0x66, 0x66, 0x66, 0x3c, 0x18, 0x7e, 0x18);
		Add(0x3f, 0x33, 0x3f, 0x30, 0x30, 0x30, 0xf0, 0xf0);
		Add(0x7f, 0x63, 0x7f, 0x63, 0x63, 0x67, 0xe7, 0xe0);
		Add(0x99, 0x5a, 0x3c, 0xe7, 0xe7, 0x3c, 0x5a, 0x99);
		Add(0x80, 0xe0, 0xf8, 0xfe, 0xf8, 0xe0, 0x80, 0x00);
		Add(0x01, 0x07, 0x1f, 0x7f, 0x1f, 0x07, 0x01, 0x00);
		Add(0x18, 0x3c, 0x7e, 0x18, 0x18, 0x7e, 0x3c, 0x18);
		Add(0x66, 0x66, 0x66, 0x66, 0x66, 0x00, 0x66, 0x00);
		Add(0x7f, 0xdb, 0xdb, 0x7b, 0x1b, 0x1b, 0x1b, 0x00);
		Add(0x7e, 0xc3, 0x78, 0xcc, 0xcc, 0x78, 0x8c, 0xf8);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x7e, 0x7e, 0x00);
		Add(0x18, 0x3c, 0x7e, 0x18, 0x7e, 0x3c, 0x18, 0xff);
		Add(0x18, 0x3c, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x00);
		Add(0x18, 0x18, 0x18, 0x18, 0x7e, 0x3c, 0x18, 0x00);
		Add(0x00, 0x18, 0x0c, 0xfe, 0x0c, 0x18, 0x00, 0x00);
		Add(0x00, 0x30, 0x60, 0xfe, 0x60, 0x30, 0x00, 0x00);
		Add(0x00, 0x00, 0xc0, 0xc0, 0xc0, 0xfe, 0x00, 0x00);
		Add(0x00, 0x24, 0x66, 0xff, 0x66, 0x24, 0x00, 0x00);
		Add(0x00, 0x18, 0x3c, 0x7e, 0xff, 0xff, 0x00, 0x00);
		Add(0x00, 0xff, 0xff, 0x7e, 0x3c, 0x18, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x18, 0x3c, 0x3c, 0x18, 0x18, 0x00, 0x18, 0x00);
		Add(0x6c, 0x6c, 0x6c, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x6c, 0x6c, 0xfe, 0x6c, 0xfe, 0x6c, 0x6c, 0x00);
		Add(0x18, 0x3e, 0x60, 0x3c, 0x06, 0x7c, 0x18, 0x00);
		Add(0x00, 0xc6, 0xcc, 0x18, 0x30, 0x66, 0xc6, 0x00);
		Add(0x38, 0x6c, 0x38, 0x76, 0xdc, 0xcc, 0x76, 0x00);
		Add(0x70, 0x30, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x18, 0x30, 0x60, 0x60, 0x60, 0x30, 0x18, 0x00);
		Add(0x60, 0x30, 0x18, 0x18, 0x18, 0x30, 0x60, 0x00);
		Add(0x00, 0x66, 0x3c, 0xff, 0x3c, 0x66, 0x00, 0x00);
		Add(0x00, 0x30, 0x30, 0xfc, 0x30, 0x30, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x30, 0x60);
		Add(0x00, 0x00, 0x00, 0xfc, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x30, 0x00);
		Add(0x06, 0x0c, 0x18, 0x30, 0x60, 0xc0, 0x80, 0x00);
		Add(0x78, 0xcc, 0xdc, 0xfc, 0xec, 0xcc, 0x78, 0x00);
		Add(0x30, 0xf0, 0x30, 0x30, 0x30, 0x30, 0xfc, 0x00);
		Add(0x78, 0xcc, 0x0c, 0x38, 0x60, 0xcc, 0xfc, 0x00);
		Add(0x78, 0xcc, 0x0c, 0x78, 0x0c, 0xcc, 0x78, 0x00);
		Add(0x1c, 0x3c, 0x6c, 0xcc, 0xfe, 0x0c, 0x0c, 0x00);
		Add(0xfc, 0xc0, 0xf8, 0x0c, 0x0c, 0xcc, 0x78, 0x00);
		Add(0x38, 0x60, 0xc0, 0xf8, 0xcc, 0xcc, 0x78, 0x00);
		Add(0xfc, 0xcc, 0x0c, 0x18, 0x30, 0x60, 0x60, 0x00);
		Add(0x78, 0xcc, 0xcc, 0x78, 0xcc, 0xcc, 0x78, 0x00);
		Add(0x78, 0xcc, 0xcc, 0x7c, 0x0c, 0x18, 0x70, 0x00);
		Add(0x00, 0x00, 0x30, 0x30, 0x00, 0x30, 0x30, 0x00);
		Add(0x00, 0x00, 0x30, 0x30, 0x00, 0x70, 0x30, 0x60);
		Add(0x0c, 0x18, 0x30, 0x60, 0x30, 0x18, 0x0c, 0x00);
		Add(0x00, 0x00, 0x7e, 0x00, 0x7e, 0x00, 0x00, 0x00);
		Add(0x60, 0x30, 0x18, 0x0c, 0x18, 0x30, 0x60, 0x00);
		Add(0x78, 0xcc, 0x0c, 0x18, 0x30, 0x00, 0x30, 0x00);
		Add(0x7c, 0xc6, 0xde, 0xd6, 0xde, 0xc0, 0x78, 0x00);
		Add(0x18, 0x3c, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x00);
		Add(0xfc, 0x66, 0x66, 0x7c, 0x66, 0x66, 0xfc, 0x00);
		Add(0x3c, 0x66, 0xc0, 0xc0, 0xc0, 0x66, 0x3c, 0x00);
		Add(0xf8, 0x6c, 0x66, 0x66, 0x66, 0x6c, 0xf8, 0x00);
		Add(0xfe, 0x62, 0x68, 0x78, 0x68, 0x62, 0xfe, 0x00);
		Add(0xfe, 0x62, 0x68, 0x78, 0x68, 0x60, 0xf0, 0x00);
		Add(0x3c, 0x66, 0xc0, 0xc0, 0xce, 0x66, 0x3e, 0x00);
		Add(0x66, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x66, 0x00);
		Add(0x3c, 0x18, 0x18, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x1e, 0x0c, 0x0c, 0x0c, 0xcc, 0xcc, 0x78, 0x00);
		Add(0xe6, 0x66, 0x6c, 0x78, 0x6c, 0x66, 0xe6, 0x00);
		Add(0xf0, 0x60, 0x60, 0x60, 0x62, 0x66, 0xfe, 0x00);
		Add(0xc6, 0xee, 0xfe, 0xd6, 0xc6, 0xc6, 0xc6, 0x00);
		Add(0xc6, 0xe6, 0xf6, 0xde, 0xce, 0xc6, 0xc6, 0x00);
		Add(0x38, 0x6c, 0xc6, 0xc6, 0xc6, 0x6c, 0x38, 0x00);
		Add(0xfc, 0x66, 0x66, 0x7c, 0x60, 0x60, 0xf0, 0x00);
		Add(0x38, 0x6c, 0xc6, 0xc6, 0xce, 0x6c, 0x3e, 0x00);
		Add(0xfc, 0x66, 0x66, 0x7c, 0x78, 0x6c, 0xe6, 0x00);
		Add(0x7c, 0xc6, 0xc0, 0x7c, 0x06, 0xc6, 0x7c, 0x00);
		Add(0xfe, 0xba, 0x38, 0x38, 0x38, 0x38, 0x7c, 0x00);
		Add(0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x6c, 0x38, 0x00);
		Add(0xc6, 0xc6, 0xc6, 0xd6, 0xfe, 0xee, 0xc6, 0x00);
		Add(0xc6, 0xc6, 0x6c, 0x38, 0x6c, 0xc6, 0xc6, 0x00);
		Add(0xc6, 0xc6, 0xc6, 0x7c, 0x38, 0x38, 0x7c, 0x00);
		Add(0xfe, 0xcc, 0x98, 0x30, 0x62, 0xc6, 0xfe, 0x00);
		Add(0x78, 0x60, 0x60, 0x60, 0x60, 0x60, 0x78, 0x00);
		Add(0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x02, 0x00);
		Add(0x78, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78, 0x00);
		Add(0x10, 0x38, 0x6c, 0xc6, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff);
		Add(0x38, 0x30, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0xe0, 0x60, 0x60, 0x7c, 0x66, 0x66, 0xfc, 0x00);
		Add(0x00, 0x00, 0x7c, 0xc6, 0xc0, 0xc6, 0x7c, 0x00);
		Add(0x1c, 0x0c, 0x0c, 0x7c, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x00, 0x00, 0x7c, 0xc6, 0xfe, 0xc0, 0x7c, 0x00);
		Add(0x3c, 0x66, 0x60, 0xf8, 0x60, 0x60, 0xf8, 0x00);
		Add(0x00, 0x00, 0x7e, 0xcc, 0xcc, 0x7c, 0x0c, 0xf8);
		Add(0xe0, 0x60, 0x60, 0x7c, 0x66, 0x66, 0xe6, 0x00);
		Add(0x18, 0x00, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x0c, 0x00, 0x1e, 0x06, 0x06, 0x66, 0x3c, 0x00);
		Add(0xe0, 0x60, 0x66, 0x6c, 0x78, 0x6c, 0xe6, 0x00);
		Add(0x38, 0x18, 0x18, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x00, 0x00, 0xec, 0xfe, 0xda, 0xda, 0xda, 0x00);
		Add(0x00, 0x00, 0xfc, 0x66, 0x66, 0x66, 0x66, 0x00);
		Add(0x00, 0x00, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x00, 0x00, 0xfc, 0x66, 0x66, 0x7c, 0x60, 0xf0);
		Add(0x00, 0x00, 0x7e, 0xcc, 0xcc, 0x7c, 0x0c, 0x1e);
		Add(0x00, 0x00, 0xfc, 0x66, 0x66, 0x60, 0xf0, 0x00);
		Add(0x00, 0x00, 0x7e, 0xc0, 0x7c, 0x06, 0xfc, 0x00);
		Add(0x20, 0x60, 0xfc, 0x60, 0x60, 0x66, 0x3c, 0x00);
		Add(0x00, 0x00, 0xcc, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x00, 0x00, 0xc6, 0xc6, 0xc6, 0x7c, 0x38, 0x00);
		Add(0x00, 0x00, 0xda, 0xda, 0xda, 0xda, 0x74, 0x00);
		Add(0x00, 0x00, 0xc6, 0x6c, 0x38, 0x6c, 0xc6, 0x00);
		Add(0x00, 0x00, 0xc6, 0xc6, 0x7e, 0x06, 0xfc, 0x00);
		Add(0x00, 0x00, 0xfe, 0x18, 0x30, 0x62, 0xfe, 0x00);
		Add(0x0e, 0x18, 0x18, 0x70, 0x18, 0x18, 0x0e, 0x00);
		Add(0x18, 0x18, 0x18, 0x00, 0x18, 0x18, 0x18, 0x00);
		Add(0x70, 0x18, 0x18, 0x0e, 0x18, 0x18, 0x70, 0x00);
		Add(0x76, 0xdc, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x10, 0x38, 0x6c, 0xc6, 0xc6, 0xc6, 0xfe, 0x00);
		Add(0x7c, 0xc6, 0xc0, 0xc0, 0xc6, 0x7c, 0x18, 0x30);
		Add(0x00, 0xcc, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x18, 0x30, 0x7c, 0xc6, 0xfe, 0xc0, 0x7c, 0x00);
		Add(0x30, 0x48, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0xcc, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0x60, 0x30, 0x78, 0x0c, 0xfc, 0xcc, 0x7e, 0x00);
		Add(0x30, 0x48, 0x78, 0x0c, 0xfc, 0xcc, 0x7e, 0x00);
		Add(0x00, 0x7c, 0xc6, 0xc0, 0xc6, 0x7c, 0x18, 0x30);
		Add(0x30, 0x48, 0x7c, 0xc6, 0xfe, 0xc0, 0x7c, 0x00);
		Add(0xcc, 0x00, 0x7c, 0xc6, 0xfe, 0xc0, 0x7c, 0x00);
		Add(0x60, 0x30, 0x7c, 0xc6, 0xfe, 0xc0, 0x7c, 0x00);
		Add(0x6c, 0x00, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x38, 0x44, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x30, 0x18, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0xcc, 0x30, 0x78, 0xcc, 0xcc, 0xfc, 0xcc, 0x00);
		Add(0x30, 0x48, 0x78, 0xcc, 0xcc, 0xfc, 0xcc, 0x00);
		Add(0x18, 0x30, 0xfc, 0x60, 0x78, 0x60, 0xfc, 0x00);
		Add(0x00, 0x00, 0x7e, 0x09, 0x7f, 0xc8, 0x7e, 0x00);
		Add(0x3f, 0x6c, 0xcc, 0xff, 0xcc, 0xcc, 0xcf, 0x00);
		Add(0x00, 0x38, 0x44, 0x7c, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x00, 0xc6, 0x00, 0x7c, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x60, 0x30, 0x00, 0x7c, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x30, 0x48, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x60, 0x30, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0xcc, 0x00, 0xc6, 0xc6, 0x7e, 0x06, 0x7c, 0x00);
		Add(0xc6, 0x00, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0xcc, 0x00, 0xcc, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x00, 0x00, 0x7c, 0xce, 0xd6, 0xe6, 0x7c, 0x00);
		Add(0x38, 0x6c, 0x64, 0xf0, 0x60, 0x66, 0xfc, 0x00);
		Add(0x3a, 0x6c, 0xce, 0xd6, 0xe6, 0x6c, 0xb8, 0x00);
		Add(0x00, 0x00, 0xc6, 0x7c, 0x38, 0x7c, 0xc6, 0x00);
		Add(0x0e, 0x1b, 0x18, 0x7e, 0x18, 0xd8, 0x70, 0x00);
		Add(0x18, 0x30, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0x0c, 0x18, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x0c, 0x18, 0x00, 0x7c, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x18, 0x30, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x76, 0xdc, 0x00, 0xfc, 0x66, 0x66, 0x66, 0x00);
		Add(0x76, 0xdc, 0x00, 0xe6, 0xf6, 0xde, 0xce, 0x00);
		Add(0x70, 0xd0, 0x78, 0x00, 0xf8, 0x00, 0x00, 0x00);
		Add(0x70, 0xd8, 0x70, 0x00, 0xf8, 0x00, 0x00, 0x00);
		Add(0x30, 0x00, 0x30, 0x60, 0xc0, 0xcc, 0x78, 0x00);
		Add(0x3c, 0x42, 0xb9, 0xa5, 0xb9, 0xa5, 0x42, 0x3c);
		Add(0x00, 0x00, 0x00, 0xfe, 0x06, 0x06, 0x00, 0x00);
		Add(0xc6, 0x4c, 0x58, 0x36, 0x69, 0xc2, 0x84, 0x0f);
		Add(0xc6, 0x4c, 0x58, 0x36, 0x6a, 0xdf, 0x82, 0x02);
		Add(0x18, 0x00, 0x18, 0x18, 0x3c, 0x3c, 0x18, 0x00);
		Add(0x00, 0x33, 0x66, 0xcc, 0x66, 0x33, 0x00, 0x00);
		Add(0x00, 0xcc, 0x66, 0x33, 0x66, 0xcc, 0x00, 0x00);
		Add(0x22, 0x88, 0x22, 0x88, 0x22, 0x88, 0x22, 0x88);
		Add(0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55);
		Add(0xdd, 0x77, 0xdd, 0x77, 0xdd, 0x77, 0xdd, 0x77);
		Add(0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18);
		Add(0x18, 0x18, 0x18, 0xf8, 0xf8, 0x18, 0x18, 0x18);
		Add(0x18, 0x30, 0x7c, 0xc6, 0xc6, 0xfe, 0xc6, 0x00);
		Add(0x38, 0x44, 0x7c, 0xc6, 0xc6, 0xfe, 0xc6, 0x00);
		Add(0x60, 0x30, 0x7c, 0xc6, 0xc6, 0xfe, 0xc6, 0x00);
		Add(0x3c, 0x42, 0x99, 0xa1, 0xa1, 0x99, 0x42, 0x3c);
		Add(0x24, 0x24, 0xe4, 0x04, 0x04, 0xe4, 0x24, 0x24);
		Add(0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24, 0x24);
		Add(0x00, 0x00, 0xfc, 0x04, 0x04, 0xe4, 0x24, 0x24);
		Add(0x24, 0x24, 0xe4, 0x04, 0x04, 0xfc, 0x00, 0x00);
		Add(0x18, 0x18, 0x7e, 0xc0, 0xc0, 0x7e, 0x18, 0x18);
		Add(0x66, 0x3c, 0x18, 0x7e, 0x18, 0x7e, 0x18, 0x18);
		Add(0x00, 0x00, 0x00, 0xf0, 0xf8, 0x38, 0x18, 0x18);
		Add(0x18, 0x18, 0x1c, 0x1f, 0x0f, 0x00, 0x00, 0x00);
		Add(0x18, 0x18, 0x18, 0xff, 0xff, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0xff, 0xff, 0x18, 0x18, 0x18);
		Add(0x18, 0x18, 0x18, 0x1f, 0x1f, 0x18, 0x18, 0x18);
		Add(0x00, 0x00, 0x00, 0xff, 0xff, 0x00, 0x00, 0x00);
		Add(0x18, 0x18, 0x18, 0xff, 0xff, 0x18, 0x18, 0x18);
		Add(0x76, 0xdc, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0x76, 0xdc, 0x7c, 0xc6, 0xc6, 0xfe, 0xc6, 0x00);
		Add(0x24, 0x24, 0x27, 0x20, 0x20, 0x3f, 0x00, 0x00);
		Add(0x00, 0x00, 0x3f, 0x20, 0x20, 0x27, 0x24, 0x24);
		Add(0x24, 0x24, 0xe7, 0x00, 0x00, 0xff, 0x00, 0x00);
		Add(0x00, 0x00, 0xff, 0x00, 0x00, 0xe7, 0x24, 0x24);
		Add(0x24, 0x24, 0x27, 0x20, 0x20, 0x27, 0x24, 0x24);
		Add(0x00, 0x00, 0xff, 0x00, 0x00, 0xff, 0x00, 0x00);
		Add(0x24, 0x24, 0xe7, 0x00, 0x00, 0xe7, 0x24, 0x24);
		Add(0x00, 0x82, 0xfe, 0x6c, 0xfe, 0x82, 0x00, 0x00);
		Add(0x90, 0x60, 0x98, 0x0c, 0x7c, 0xcc, 0x7e, 0x00);
		Add(0xf8, 0x6c, 0x66, 0xf6, 0x66, 0x6c, 0xf8, 0x00);
		Add(0x38, 0x44, 0xfe, 0x60, 0x7c, 0x60, 0xfe, 0x00);
		Add(0xc6, 0x00, 0xfe, 0x60, 0x7c, 0x60, 0xfe, 0x00);
		Add(0x30, 0x18, 0xfe, 0x60, 0x7c, 0x60, 0xfe, 0x00);
		Add(0x60, 0x20, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x0c, 0x18, 0x3c, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x18, 0x24, 0x3c, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x6c, 0x00, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0x18, 0x18, 0x38, 0xf8, 0xf0, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x0f, 0x1f, 0x1c, 0x18, 0x18);
		Add(0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff);
		Add(0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff);
		Add(0x18, 0x18, 0x18, 0x00, 0x18, 0x18, 0x18, 0x00);
		Add(0x30, 0x18, 0x3c, 0x18, 0x18, 0x18, 0x3c, 0x00);
		Add(0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00);
		Add(0x18, 0x30, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x7c, 0xc6, 0xc6, 0xfc, 0xc6, 0xc6, 0xdc, 0xc0);
		Add(0x38, 0x44, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x60, 0x30, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x76, 0xdc, 0x00, 0x7c, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x76, 0xdc, 0x7c, 0xc6, 0xc6, 0xc6, 0x7c, 0x00);
		Add(0x00, 0x00, 0x66, 0x66, 0x66, 0x7c, 0x60, 0xc0);
		Add(0x00, 0x70, 0x3c, 0x36, 0x3c, 0x30, 0x78, 0x00);
		Add(0xf0, 0x60, 0x7c, 0x66, 0x7c, 0x60, 0xf0, 0x00);
		Add(0x18, 0x30, 0xcc, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x30, 0x48, 0x00, 0xcc, 0xcc, 0xcc, 0x78, 0x00);
		Add(0x60, 0x30, 0xcc, 0xcc, 0xcc, 0xcc, 0x7e, 0x00);
		Add(0x18, 0x30, 0x00, 0xc6, 0xc6, 0x7e, 0x06, 0x7c);
		Add(0x18, 0x30, 0xc6, 0xc6, 0x7c, 0x38, 0x7c, 0x00);
		Add(0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x18, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0xfc, 0x00, 0x00, 0x00, 0x00);
		Add(0x18, 0x18, 0x7e, 0x18, 0x18, 0x00, 0x7e, 0x00);
		Add(0x00, 0x00, 0xfe, 0x00, 0xfe, 0x00, 0x00, 0x00);
		Add(0xe6, 0x2c, 0xf8, 0x36, 0xea, 0xdf, 0x82, 0x02);
		Add(0x7f, 0xdb, 0xdb, 0x7b, 0x1b, 0x1b, 0x1b, 0x00);
		Add(0x7e, 0xc3, 0x78, 0xcc, 0xcc, 0x78, 0x8c, 0xf8);
		Add(0x30, 0x30, 0x00, 0xfc, 0x00, 0x30, 0x30, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x60);
		Add(0x38, 0x6c, 0x6c, 0x38, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x66, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00);
		Add(0x18, 0x78, 0x18, 0x18, 0x7e, 0x00, 0x00, 0x00);
		Add(0x78, 0x0c, 0x38, 0x0c, 0x78, 0x00, 0x00, 0x00);
		Add(0x78, 0x0c, 0x38, 0x60, 0x7c, 0x00, 0x00, 0x00);
		Add(0x00, 0x00, 0x3c, 0x3c, 0x3c, 0x3c, 0x00, 0x00);
		Add(0xff, 0x81, 0x81, 0x81, 0x81, 0x81, 0x81, 0xff);
	}
}
