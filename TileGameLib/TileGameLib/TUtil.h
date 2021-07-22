/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#include <string>
#include <vector>
#include "TGlobal.h"
#include "TClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TUtil : TClass
	{
	public:
		static void Randomize();
		static int Random(int max);
		static int Random(int min, int max);
		static byte RandomByte();
		static std::string RandomHex(int bytes);
		static std::string RandomString(int length);
		static std::string RandomString(int length, std::string alphabet);
		static std::string RandomLetters(int length, int characterCasing = 0);
		static std::string RandomDigits(int length);
		static bool RandomChance(int rate);
		static int Percent(int value, int percentage);
		static void Pause(int ms = 1, bool pumpEvents = true);
		static void PumpEvents();
		static void Error(std::string message);
		static void Abort(std::string message);
		static void IntToBytes(uint val, byte bytes[4]);
		static uint BytesToInt(byte bytes[4]);
		static void ShortToBytes(ushort val, byte bytes[2]);
		static ushort BytesToShort(byte bytes[2]);
		static std::string DateTime();
		static unsigned WrapAdd(unsigned val, int dx, const unsigned lower, const unsigned upper);
		static int GetDigitCount(unsigned number);
	};
}
