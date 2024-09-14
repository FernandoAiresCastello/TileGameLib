#pragma once
#include "TGL_Globals.h"
#include "TGL_String.h"

namespace TGL
{
	class TGLAPI Util
	{
	public:
		static int Rnd(int max);
		static int Rnd(int min, int max);
		static int RndByte();
		static String RndHex(int bytes);
		static String RndString(int length);
		static String RndString(int length, const String& alphabet);
		static bool Chance(int rate);
		static int Percent(int value, int percentage);
		static void IntToBytes(uint32_t val, uint8_t bytes[4]);
		static uint32_t BytesToInt(uint8_t bytes[4]);
		static void ShortToBytes(uint16_t val, uint8_t bytes[2]);
		static uint16_t BytesToShort(uint8_t bytes[2]);
		static uint32_t WrapAdd(uint32_t val, int dx, const uint32_t lower, const uint32_t upper);
		static int GetDigitCount(uint32_t number);
		static String XorEncrypt(const String& str, char xor_key);
		static String XorDecrypt(const String& str, char xor_key);
		static String SizeToString(uint64_t bytes);
		static String Datetime(const String& format);
		static String Datetime();
		static String Date();
		static String Time();
		static void SetClipboard(const String& text);
		static String GetClipboard();
		static int Distance(int x1, int y1, int x2, int y2);
		static float Distance(float x1, float y1, float x2, float y2);
	};
}
