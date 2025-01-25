#include <Windows.h>
#include <random>
#include <sstream>
#include <chrono>
#include "TGL_Util.h"

namespace TGL
{
	std::random_device rd;
	std::mt19937 mt(rd());

	int Util::Rnd(int max)
	{
		return std::uniform_int_distribution<int>(0, max)(mt);
	}

	int Util::Rnd(int min, int max)
	{
		return std::uniform_int_distribution<int>(min, max)(mt);
	}

	int Util::RndByte()
	{
		return Rnd(0, 255);
	}

	String Util::RndHex(int bytes)
	{
		std::stringstream ss;

		for (auto i = 0; i < bytes; i++) {
			auto rc = RndByte();
			std::stringstream hexstream;
			hexstream << std::hex << int(rc);
			auto hex = hexstream.str();
			ss << (hex.length() < 2 ? '0' + hex : hex);
		}

		return ss.str();
	}

	String Util::RndString(int length)
	{
		return RndString(length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
	}

	String Util::RndString(int length, const String& alphabet)
	{
		std::stringbuf sb;

		for (auto i = 0; i < length; i++) {
			char ch = alphabet[Rnd((int)alphabet.Length()) - 1];
			sb.sputc(ch);
		}

		return sb.str();

	}

	bool Util::Chance(int rate)
	{
		if (rate >= 100)
			return true;
		if (rate > 0)
			return Rnd(100) <= rate;

		return false;
	}

	int Util::Percent(int value, int percentage)
	{
		return value * percentage / 100;
	}

	void Util::IntToBytes(uint32_t val, uint8_t bytes[4])
	{
		uint32_t uval = val;
		bytes[0] = uval;
		bytes[1] = uval >> 8;
		bytes[2] = uval >> 16;
		bytes[3] = uval >> 24;
	}

	uint32_t Util::BytesToInt(uint8_t bytes[4])
	{
		uint32_t u0 = bytes[0], u1 = bytes[1], u2 = bytes[2], u3 = bytes[3];
		uint32_t uval = u0 | (u1 << 8) | (u2 << 16) | (u3 << 24);
		return uval;
	}

	void Util::ShortToBytes(uint16_t val, uint8_t bytes[2])
	{
		uint8_t int_bytes[4];
		IntToBytes(val, int_bytes);
		bytes[0] = int_bytes[0];
		bytes[1] = int_bytes[1];
	}

	uint16_t Util::BytesToShort(uint8_t bytes[2])
	{
		uint8_t int_bytes[4];
		int_bytes[0] = bytes[0];
		int_bytes[1] = bytes[1];
		return BytesToInt(int_bytes);
	}

	uint32_t Util::WrapAdd(uint32_t val, int dx, const uint32_t lower, const uint32_t upper)
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

	int Util::GetDigitCount(uint32_t number)
	{
		return number > 0 ? (int)log10((double)number) + 1 : 1;
	}

	String Util::XorEncrypt(const String& str, char xor_key)
	{
		std::string encrypted = str;

		for (int i = 0; i < str.Length(); i++)
			encrypted[i] = str[i] ^ xor_key;

		return encrypted;
	}

	String Util::XorDecrypt(const String& str, char xor_key)
	{
		return XorEncrypt(str, xor_key);
	}

	String Util::SizeToString(uint64_t bytes)
	{
		const char* suffix[] = { "B", "KB", "MB", "GB", "TB" };
		const char length = sizeof(suffix) / sizeof(suffix[0]);

		int i = 0;
		double dblBytes = (double)bytes;

		if (bytes > 1024) {
			for (i = 0; (bytes / 1024) > 0 && i < length - 1; i++, bytes /= 1024)
				dblBytes = bytes / 1024.0;
		}

		char output[100];
		sprintf_s(output, "%.02lf %s", dblBytes, suffix[i]);
		return output;
	}

	String Util::Datetime(const String& format)
	{
		auto now = std::chrono::system_clock::now();
		auto in_time_t = std::chrono::system_clock::to_time_t(now);

		std::stringstream ss;
		ss << std::put_time(std::localtime(&in_time_t), format.Cstr());
		return ss.str();
	}

	String Util::Datetime()
	{
		return Datetime("%Y-%m-%d %H:%M:%S");
	}

	String Util::Date()
	{
		return Datetime("%Y-%m-%d");
	}

	String Util::Time()
	{
		return Datetime("%H:%M:%S");
	}

	void Util::SetClipboard(const String& text)
	{
		bool ok = OpenClipboard(nullptr);
		if (ok) {
			ok = EmptyClipboard();
			const char* text_chars = text.Cstr();
			int length = (int)strlen(text_chars);
			HGLOBAL clipboard_data = GlobalAlloc(GMEM_MOVEABLE, length + 1);
			if (clipboard_data != nullptr) {
				char* text_chars_copy = (char*)GlobalLock(clipboard_data);
				if (text_chars_copy != nullptr) {
					strcpy_s(text_chars_copy, length, LPCSTR(text_chars));
				}
				GlobalUnlock(clipboard_data);
				SetClipboardData(CF_TEXT, clipboard_data);
			}
			ok = CloseClipboard();
		}
	}

	String Util::GetClipboard()
	{
		bool ok = OpenClipboard(nullptr);
		if (ok) {
			HANDLE clipboard_data = GetClipboardData(CF_TEXT);
			char* text_chars = (char*)GlobalLock(clipboard_data);
			if (text_chars != nullptr) {
				std::string text(text_chars);
				GlobalUnlock(clipboard_data);
				return text;
			}
		}
		return "";
	}

	int Util::Distance(int x1, int y1, int x2, int y2)
	{
		int delta_x = x2 - x1;
		int delta_y = y2 - y1;
		return static_cast<int>(std::round(std::sqrt(delta_x * delta_x + delta_y * delta_y)));
	}

	float Util::Distance(float x1, float y1, float x2, float y2)
	{
		float delta_x = x2 - x1;
		float delta_y = y2 - y1;
		return std::sqrt(delta_x * delta_x + delta_y * delta_y);
	}
}
