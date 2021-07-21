/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <sstream>
#include "TChar.h"
#include "TString.h"
#include "TString.h"

namespace TileGameLib
{
	const int TChar::Width = 8;
	const int TChar::Height = 8;
	const int TChar::Size = Width * Height;

	TChar::TChar()
	{
		Clear();
	}

	TChar::TChar(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7)
	{
		SetFromBytes(row0, row1, row2, row3, row4, row5, row6, row7);
	}

	TChar::TChar(const TChar& other)
	{
		PixelRow0 = other.PixelRow0;
		PixelRow1 = other.PixelRow1;
		PixelRow2 = other.PixelRow2;
		PixelRow3 = other.PixelRow3;
		PixelRow4 = other.PixelRow4;
		PixelRow5 = other.PixelRow5;
		PixelRow6 = other.PixelRow6;
		PixelRow7 = other.PixelRow7;
	}

	TChar::~TChar()
	{
	}

	bool TChar::Equals(TChar& ch)
	{
		return
			PixelRow0 == ch.PixelRow0 &&
			PixelRow1 == ch.PixelRow1 &&
			PixelRow2 == ch.PixelRow2 &&
			PixelRow3 == ch.PixelRow3 &&
			PixelRow4 == ch.PixelRow4 &&
			PixelRow5 == ch.PixelRow5 &&
			PixelRow6 == ch.PixelRow6 &&
			PixelRow7 == ch.PixelRow7;
	}

	void TChar::SetEqual(TChar& other)
	{
		PixelRow0 = other.PixelRow0;
		PixelRow1 = other.PixelRow1;
		PixelRow2 = other.PixelRow2;
		PixelRow3 = other.PixelRow3;
		PixelRow4 = other.PixelRow4;
		PixelRow5 = other.PixelRow5;
		PixelRow6 = other.PixelRow6;
		PixelRow7 = other.PixelRow7;
	}

	void TChar::Clear()
	{
		PixelRow0 = 0;
		PixelRow1 = 0;
		PixelRow2 = 0;
		PixelRow3 = 0;
		PixelRow4 = 0;
		PixelRow5 = 0;
		PixelRow6 = 0;
		PixelRow7 = 0;
	}

	std::vector<byte> TChar::GetBytes()
	{
		std::vector<byte> bytes;
		bytes.push_back(PixelRow0);
		bytes.push_back(PixelRow1);
		bytes.push_back(PixelRow2);
		bytes.push_back(PixelRow3);
		bytes.push_back(PixelRow4);
		bytes.push_back(PixelRow5);
		bytes.push_back(PixelRow6);
		bytes.push_back(PixelRow7);
		return bytes;
	}

	void TChar::SetFromBytes(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7)
	{
		PixelRow0 = row0;
		PixelRow1 = row1;
		PixelRow2 = row2;
		PixelRow3 = row3;
		PixelRow4 = row4;
		PixelRow5 = row5;
		PixelRow6 = row6;
		PixelRow7 = row7;
	}

	void TChar::SetFromBytes(std::vector<byte> bytes)
	{
		PixelRow0 = bytes[0];
		PixelRow1 = bytes[1];
		PixelRow2 = bytes[2];
		PixelRow3 = bytes[3];
		PixelRow4 = bytes[4];
		PixelRow5 = bytes[5];
		PixelRow6 = bytes[6];
		PixelRow7 = bytes[7];
	}

	void TChar::SetFromBinaryString(std::string binary)
	{
		const auto rows = TString::SplitIntoEqualSizedStrings(binary, TChar::Width);
		
		PixelRow0 = TString::BinaryToInt(rows[0]);
		PixelRow1 = TString::BinaryToInt(rows[1]);
		PixelRow2 = TString::BinaryToInt(rows[2]);
		PixelRow3 = TString::BinaryToInt(rows[3]);
		PixelRow4 = TString::BinaryToInt(rows[4]);
		PixelRow5 = TString::BinaryToInt(rows[5]);
		PixelRow6 = TString::BinaryToInt(rows[6]);
		PixelRow7 = TString::BinaryToInt(rows[7]);
	}

	void TChar::SetFromBinaryString(char* binary)
	{
		SetFromBinaryString(std::string(binary));
	}

	std::string TChar::ToBinaryString()
	{
		std::stringstream buf;

		buf << TString::IntToBinary(PixelRow0, TChar::Width);
		buf << TString::IntToBinary(PixelRow1, TChar::Width);
		buf << TString::IntToBinary(PixelRow2, TChar::Width);
		buf << TString::IntToBinary(PixelRow3, TChar::Width);
		buf << TString::IntToBinary(PixelRow4, TChar::Width);
		buf << TString::IntToBinary(PixelRow5, TChar::Width);
		buf << TString::IntToBinary(PixelRow6, TChar::Width);
		buf << TString::IntToBinary(PixelRow7, TChar::Width);

		return buf.str();
	}

	void TChar::ToBinaryString(char* dest)
	{
		std::string binary = ToBinaryString();
		for (int i = 0; i < binary.length(); i++)
			dest[i] = binary[i];
	}
}
