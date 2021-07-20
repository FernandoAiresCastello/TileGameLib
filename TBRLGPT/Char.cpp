/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <sstream>
#include "Char.h"
#include "StringUtils.h"

namespace TBRLGPT
{
	const int Char::Width = 8;
	const int Char::Height = 8;
	const int Char::Size = Width * Height;

	Char::Char()
	{
		Clear();
	}

	Char::~Char()
	{
	}

	void Char::Clear()
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

	void Char::SetEqual(Char& ch)
	{
		PixelRow0 = ch.PixelRow0;
		PixelRow1 = ch.PixelRow1;
		PixelRow2 = ch.PixelRow2;
		PixelRow3 = ch.PixelRow3;
		PixelRow4 = ch.PixelRow4;
		PixelRow5 = ch.PixelRow5;
		PixelRow6 = ch.PixelRow6;
		PixelRow7 = ch.PixelRow7;
	}

	std::vector<byte> Char::GetBytes(int index)
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

	void Char::SetFromBytes(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7)
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

	void Char::SetFromBytes(std::vector<byte> bytes)
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

	void Char::SetFromBinaryString(std::string binary)
	{
		const auto rows = String::SplitIntoEqualSizedStrings(binary, Char::Width);
		
		PixelRow0 = String::BinaryToInt(rows[0]);
		PixelRow1 = String::BinaryToInt(rows[1]);
		PixelRow2 = String::BinaryToInt(rows[2]);
		PixelRow3 = String::BinaryToInt(rows[3]);
		PixelRow4 = String::BinaryToInt(rows[4]);
		PixelRow5 = String::BinaryToInt(rows[5]);
		PixelRow6 = String::BinaryToInt(rows[6]);
		PixelRow7 = String::BinaryToInt(rows[7]);
	}

	void Char::SetFromBinaryString(char* binary)
	{
		SetFromBinaryString(std::string(binary));
	}

	std::string Char::ToBinaryString()
	{
		std::stringstream buf;

		buf << String::IntToBinary(PixelRow0, Char::Width);
		buf << String::IntToBinary(PixelRow1, Char::Width);
		buf << String::IntToBinary(PixelRow2, Char::Width);
		buf << String::IntToBinary(PixelRow3, Char::Width);
		buf << String::IntToBinary(PixelRow4, Char::Width);
		buf << String::IntToBinary(PixelRow5, Char::Width);
		buf << String::IntToBinary(PixelRow6, Char::Width);
		buf << String::IntToBinary(PixelRow7, Char::Width);

		return buf.str();
	}

	void Char::ToBinaryString(char* dest)
	{
		std::string binary = ToBinaryString();
		for (int i = 0; i < binary.length(); i++)
			dest[i] = binary[i];
	}
}
