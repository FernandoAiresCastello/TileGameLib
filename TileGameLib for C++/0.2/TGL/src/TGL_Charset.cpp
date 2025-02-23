#include "TGL_Charset.h"

namespace TGL
{
	Charset::Charset()
	{
		InitDefault();
	}

	Charset::Charset(const Charset& other)
	{
		chars = other.chars;
	}

	void Charset::Add(const BitPattern& block)
	{
		chars.push_back(block);
	}

	void Charset::Set(Index index, const BitPattern& block)
	{
		chars[index] = block;
	}

	BitPattern& Charset::Get(Index index)
	{
		return chars[index];
	}

	void Charset::RemoveAll()
	{
		chars.clear();
	}

	void Charset::InitDefault()
	{
		RemoveAll();

		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");

		Add("0000000000000000000000000000000000000000000000000000000000000000"); // 32	whitespace
		Add("0000000000011000000110000001100000011000000000000001100000000000"); // 33
		Add("0000000001100110011001100110011000000000000000000000000000000000"); // 34
		Add("0000000001100110111111110110011001100110111111110110011000000000"); // 35
		Add("0001100000111110011000000011110000000110011111000001100000000000"); // 36
		Add("0000000001100110011011000001100000110000011001100100011000000000"); // 37
		Add("0001110000110110000111000011100001101111011001100011101100000000"); // 38
		Add("0000000000011000000110000001100000000000000000000000000000000000"); // 39
		Add("0000000000001110000111000001100000011000000111000000111000000000"); // 40
		Add("0000000001110000001110000001100000011000001110000111000000000000"); // 41
		Add("0000000001100110001111001111111100111100011001100000000000000000"); // 42
		Add("0000000000011000000110000111111000011000000110000000000000000000"); // 43
		Add("0000000000000000000000000000000000000000000110000001100000110000"); // 44
		Add("0000000000000000000000000111111000000000000000000000000000000000"); // 45
		Add("0000000000000000000000000000000000000000000110000001100000000000"); // 46
		Add("0000000000000110000011000001100000110000011000000100000000000000"); // 47
		Add("0000000000111100011001100110111001110110011001100011110000000000"); // 48
		Add("0000000000011000001110000001100000011000000110000111111000000000"); // 49
		Add("0000000000111100011001100000110000011000001100000111111000000000"); // 50
		Add("0000000001111110000011000001100000001100011001100011110000000000"); // 51
		Add("0000000000001100000111000011110001101100011111100000110000000000"); // 52
		Add("0000000001111110011000000111110000000110011001100011110000000000"); // 53
		Add("0000000000111100011000000111110001100110011001100011110000000000"); // 54
		Add("0000000001111110000001100000110000011000001100000011000000000000"); // 55
		Add("0000000000111100011001100011110001100110011001100011110000000000"); // 56
		Add("0000000000111100011001100011111000000110000011000011100000000000"); // 57
		Add("0000000000000000000110000001100000000000000110000001100000000000"); // 58
		Add("0000000000000000000110000001100000000000000110000001100000110000"); // 59
		Add("0000011000001100000110000011000000011000000011000000011000000000"); // 60
		Add("0000000000000000011111100000000000000000011111100000000000000000"); // 61
		Add("0110000000110000000110000000110000011000001100000110000000000000"); // 62
		Add("0000000000111100011001100000110000011000000000000001100000000000"); // 63
		Add("0000000000111100011001100110111001101110011000000011111000000000"); // 64
		Add("0000000000011000001111000110011001100110011111100110011000000000"); // 65
		Add("0000000001111100011001100111110001100110011001100111110000000000"); // 66
		Add("0000000000111100011001100110000001100000011001100011110000000000"); // 67
		Add("0000000001111000011011000110011001100110011011000111100000000000"); // 68
		Add("0000000001111110011000000111110001100000011000000111111000000000"); // 69
		Add("0000000001111110011000000111110001100000011000000110000000000000"); // 70
		Add("0000000000111110011000000110000001101110011001100011111000000000"); // 71
		Add("0000000001100110011001100111111001100110011001100110011000000000"); // 72
		Add("0000000001111110000110000001100000011000000110000111111000000000"); // 73
		Add("0000000000000110000001100000011000000110011001100011110000000000"); // 74
		Add("0000000001100110011011000111100001111000011011000110011000000000"); // 75
		Add("0000000001100000011000000110000001100000011000000111111000000000"); // 76
		Add("0000000001100011011101110111111101101011011000110110001100000000"); // 77
		Add("0000000001100110011101100111111001111110011011100110011000000000"); // 78
		Add("0000000000111100011001100110011001100110011001100011110000000000"); // 79
		Add("0000000001111100011001100110011001111100011000000110000000000000"); // 80
		Add("0000000000111100011001100110011001100110011011000011011000000000"); // 81
		Add("0000000001111100011001100110011001111100011011000110011000000000"); // 82
		Add("0000000000111100011000000011110000000110000001100011110000000000"); // 83
		Add("0000000001111110000110000001100000011000000110000001100000000000"); // 84
		Add("0000000001100110011001100110011001100110011001100111111000000000"); // 85
		Add("0000000001100110011001100110011001100110001111000001100000000000"); // 86
		Add("0000000001100011011000110110101101111111011101110110001100000000"); // 87
		Add("0000000001100110011001100011110000111100011001100110011000000000"); // 88
		Add("0000000001100110011001100011110000011000000110000001100000000000"); // 89
		Add("0000000001111110000011000001100000110000011000000111111000000000"); // 90
		Add("0000000000011110000110000001100000011000000110000001111000000000"); // 91
		Add("0000000001000000011000000011000000011000000011000000011000000000"); // 92
		Add("0000000001111000000110000001100000011000000110000111100000000000"); // 93
		Add("0000000000000010000100100011001001111110001100000001000000000000"); // 94	enter symbol
		Add("0000000000000000000000000000000000000000000000001111111100000000"); // 95
		Add("0000000001111100110000101001111010011110110000100111110000000000"); // 96	copyright symbol
		Add("0000000000000000001111000000011000111110011001100011111000000000"); // 97
		Add("0000000001100000011000000111110001100110011001100111110000000000"); // 98
		Add("0000000000000000001111000110000001100000011000000011110000000000"); // 99
		Add("0000000000000110000001100011111001100110011001100011111000000000"); // 100
		Add("0000000000000000001111000110011001111110011000000011110000000000"); // 101
		Add("0000000000001110000110000011111000011000000110000001100000000000"); // 102
		Add("0000000000000000001111100110011001100110001111100000011001111100"); // 103
		Add("0000000001100000011000000111110001100110011001100110011000000000"); // 104
		Add("0000000000011000000000000011100000011000000110000011110000000000"); // 105
		Add("0000000000000110000000000000011000000110000001100000011000111100"); // 106
		Add("0000000001100000011000000110110001111000011011000110011000000000"); // 107
		Add("0000000000111000000110000001100000011000000110000011110000000000"); // 108
		Add("0000000000000000011001100111111101111111011010110110001100000000"); // 109
		Add("0000000000000000011111000110011001100110011001100110011000000000"); // 110
		Add("0000000000000000001111000110011001100110011001100011110000000000"); // 111
		Add("0000000000000000011111000110011001100110011111000110000001100000"); // 112
		Add("0000000000000000001111100110011001100110001111100000011000000110"); // 113
		Add("0000000000000000011111000110011001100000011000000110000000000000"); // 114
		Add("0000000000000000001111100110000000111100000001100111110000000000"); // 115
		Add("0000000000011000011111100001100000011000000110000000111000000000"); // 116
		Add("0000000000000000011001100110011001100110011001100011111000000000"); // 117
		Add("0000000000000000011001100110011001100110001111000001100000000000"); // 118
		Add("0000000000000000011000110110101101111111001111100011011000000000"); // 119
		Add("0000000000000000011001100011110000011000001111000110011000000000"); // 120
		Add("0000000000000000011001100110011001100110001111100000110001111000"); // 121
		Add("0000000000000000011111100000110000011000001100000111111000000000"); // 122
		Add("0000111000011000000110000011000000011000000110000000111000000000"); // 123
		Add("0001100000011000000110000001100000011000000110000001100000000000"); // 124
		Add("0111000000011000000110000000110000011000000110000111000000000000"); // 125
		Add("1100000011000000110000001100000011000000110000001100000011000000"); // 126	half cursor
		Add("1111111111111111111111111111111111111111111111111111111111111111"); // 127	cursor

		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
		Add("0000000000000000000000000000000000000000000000000000000000000000");
	}
}
