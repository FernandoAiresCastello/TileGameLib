/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <iostream>
#include <iterator>
#include <fstream>
#include <chrono>
#include <random>
#include <algorithm>
#include <ctime>
#include <sstream>
#include <iomanip>
#include <cstdarg>
#include <cstdlib>
#include <ctime>
#include <tchar.h>
#include <sys/stat.h>
#include "CppUtil.h"
#include "CppMsgBox.h"
#include "CppString.h"

namespace CppUtils
{
	void Util::Randomize()
	{
		srand((unsigned int)time(nullptr));
	}

	int Util::Random(int max)
	{
		max++;

		static unsigned long long seed = 0;
		unsigned long long value;

		if (seed == 0)
			seed = time(nullptr) + clock();

		seed = seed * 1664525 + 1013904223;
		value = (seed & 0xFFFFFFFF) * max / 0xFFFFFFFF;

		return (unsigned int)value;
	}

	int Util::Random(int min, int max)
	{
		std::random_device rd;
		std::mt19937 gen(rd());
		std::uniform_int_distribution<> dis(min, max);
		return static_cast<int>(dis(gen));
	}

	byte Util::RandomByte()
	{
		std::random_device rd;
		std::mt19937 gen(rd());
		std::uniform_int_distribution<> dis(0, 255);
		return static_cast<byte>(dis(gen));
	}

	std::string Util::RandomHex(int bytes)
	{
		std::stringstream ss;
		for (auto i = 0; i < bytes; i++) {
			auto rc = RandomByte();
			std::stringstream hexstream;
			hexstream << std::hex << int(rc);
			auto hex = hexstream.str();
			ss << (hex.length() < 2 ? '0' + hex : hex);
		}
		return ss.str();
	}

	std::string Util::RandomString(int length)
	{
		return RandomString(length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
	}

	std::string Util::RandomString(int length, std::string alphabet)
	{
		std::stringbuf sb;
		for (auto i = 0; i < length; i++) {
			char ch = alphabet[Random(alphabet.length() - 1)];
			sb.sputc(ch);
		}
		return sb.str();
	}

	std::string Util::RandomLetters(int length, int characterCasing)
	{
		if (characterCasing == 0) {
			return RandomString(length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}
		else if (characterCasing == 1) {
			return RandomString(length, "abcdefghijklmnopqrstuvwxyz");
		}
		else if (characterCasing == 2) {
			return RandomString(length, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		}
		
		return "";
	}

	std::string Util::RandomDigits(int length)
	{
		return RandomString(length, "0123456789");
	}

	bool Util::RandomChance(int rate)
	{
		if (rate >= 100)
			return true;
		if (rate > 0)
			return Random(100) <= rate;

		return false;
	}

	int Util::Percent(int value, int percentage)
	{
		return value * percentage / 100;
	}

	void Util::Abort(std::string message)
	{
		MsgBox::Error(message);
		exit(EXIT_FAILURE);
	}

	void Util::IntToBytes(uint val, byte bytes[4])
	{
		uint32_t uval = val;
		bytes[0] = uval;
		bytes[1] = uval >> 8;
		bytes[2] = uval >> 16;
		bytes[3] = uval >> 24;
	}

	uint Util::BytesToInt(byte bytes[4])
	{
		uint32_t u0 = bytes[0], u1 = bytes[1], u2 = bytes[2], u3 = bytes[3];
		uint32_t uval = u0 | (u1 << 8) | (u2 << 16) | (u3 << 24);
		return uval;
	}

	void Util::ShortToBytes(ushort val, byte bytes[2])
	{
		byte intBytes[4];
		IntToBytes(val, intBytes);
		bytes[0] = intBytes[0];
		bytes[1] = intBytes[1];
	}

	ushort Util::BytesToShort(byte bytes[2])
	{
		byte intBytes[4];
		intBytes[0] = bytes[0];
		intBytes[1] = bytes[1];
		return BytesToInt(intBytes);
	}

	std::string Util::DateTime()
	{
		auto now = std::chrono::system_clock::now();
		auto in_time_t = std::chrono::system_clock::to_time_t(now);

		std::stringstream ss;
		ss << std::put_time(std::localtime(&in_time_t), "%Y-%m-%d %X");
		return ss.str();
	}

	unsigned Util::WrapAdd(unsigned val, int dx, const unsigned lower, const unsigned upper)
	{
		while (dx < 0) {
			if (val == lower)
				val = upper;
			else
				--val;
			++dx;
		}
		while (dx > 0) {
			if (val == upper)
				val = lower;
			else
				++val;
			--dx;
		}
		return val;
	}

	int Util::GetDigitCount(unsigned number)
	{
		return number > 0 ? (int)log10((double)number) + 1 : 1;
	}

	std::string Util::XorEncrypt(std::string str, char xor_key)
	{
		std::string encrypted = str;
		
		for (int i = 0; i < str.length(); i++)
			encrypted[i] = str[i] ^ xor_key;

		return encrypted;
	}

	std::string Util::XorDecrypt(std::string str, char xor_key)
	{
		return XorEncrypt(str, xor_key);
	}
	
	std::string Util::FormatNumberOfBytes(uint64_t bytes)
	{
		const char* suffix[] = { "B", "KB", "MB", "GB", "TB" };
		const char length = sizeof(suffix) / sizeof(suffix[0]);

		int i = 0;
		double dblBytes = bytes;

		if (bytes > 1024) {
			for (i = 0; (bytes / 1024) > 0 && i < length - 1; i++, bytes /= 1024)
				dblBytes = bytes / 1024.0;
		}

		char output[100];
		sprintf(output, "%.02lf %s", dblBytes, suffix[i]);
		return output;
	}

	std::string Util::CurrentDate()
	{
		SYSTEMTIME time;
		GetLocalTime(&time);
		return String::Format("%02i/%02i/%04i", time.wMonth, time.wDay, time.wYear);
	}

	std::string Util::CurrentTime()
	{
		SYSTEMTIME time;
		GetLocalTime(&time);
		return String::Format("%02i:%02i:%02i", time.wHour, time.wMinute, time.wSecond);
	}
}
