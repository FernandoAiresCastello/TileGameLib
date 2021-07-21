/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <Windows.h>
#include <SDL.h>
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
#include <sys/stat.h>
#include "Util.h"

namespace TBRLGPT
{
	void Util::Randomize()
	{
		srand((unsigned int)time(NULL));
	}

	int Util::Random(int max)
	{
		max++;

		static unsigned long long seed = 0;
		unsigned long long value;

		if (seed == 0)
			seed = time(NULL) + clock();

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

	void Util::Pause(int ms, bool pumpEvents)
	{
		SDL_Delay(ms);
		if (pumpEvents)
			PumpEvents();
	}

	void Util::PumpEvents()
	{
		SDL_PumpEvents();
	}

	void Util::Error(std::string message)
	{
		//SDL_ShowSimpleMessageBox(SDL_MESSAGEBOX_ERROR, "Error", message.c_str(), NULL);
		MessageBox(NULL, message.c_str(), "Error", 
			MB_OK | MB_ICONERROR | MB_TASKMODAL | MB_SETFOREGROUND);
	}

	void Util::FatalError(std::string message)
	{
		Error(message);
		SDL_Quit();
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

	std::string Util::GenerateId()
	{
		return GenerateId(4);
	}

	std::string Util::GenerateId(int length)
	{
		return RandomHex(length);
	}

	void Util::Beep(int freq, int duration)
	{
		::Beep(freq, duration);
	}
}
