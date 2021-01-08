/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Util
	{
	public:
		static void Randomize();
		static int Random(int max);
		static byte RandomByte();
		static std::string RandomHex(int length);
		static bool RandomChance(int rate);
		static int Percent(int value, int percentage);
		static void Pause(int ms = 1, bool pumpEvents = true);
		static void PumpEvents();
		static void Error(std::string message);
		static void FatalError(std::string message);
		static void IntToBytes(uint val, byte bytes[4]);
		static uint BytesToInt(byte bytes[4]);
		static void ShortToBytes(ushort val, byte bytes[2]);
		static ushort BytesToShort(byte bytes[2]);
		static std::string DateTime();
		static unsigned WrapAdd(unsigned val, int dx, const unsigned lower, const unsigned upper);
		static int GetDigitCount(unsigned number);
		static std::string GenerateId();
		static void Beep(int freq, int duration);
	};
}
