#include <Windows.h>
#include <random>
#include <sstream>
#include <chrono>
#include "t_util.h"

namespace tgl
{
	std::random_device rd;
	std::mt19937 mt(rd());

	int t_util::rnd(int max)
	{
		return std::uniform_int_distribution<int>(0, max)(mt);
	}

	int t_util::rnd(int min, int max)
	{
		return std::uniform_int_distribution<int>(min, max)(mt);
	}
	
	int t_util::rnd_byte()
	{
		return rnd(0, 255);
	}

	t_string t_util::rnd_hex(int bytes)
	{
		std::stringstream ss;

		for (auto i = 0; i < bytes; i++) {
			auto rc = rnd_byte();
			std::stringstream hexstream;
			hexstream << std::hex << int(rc);
			auto hex = hexstream.str();
			ss << (hex.length() < 2 ? '0' + hex : hex);
		}

		return ss.str();
	}

	t_string t_util::rnd_string(int length)
	{
		return rnd_string(length, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
	}

	t_string t_util::rnd_string(int length, t_string alphabet)
	{
		std::stringbuf sb;

		for (auto i = 0; i < length; i++) {
			char ch = alphabet[rnd((int)alphabet.length()) - 1];
			sb.sputc(ch);
		}

		return sb.str();

	}

	bool t_util::chance(int rate)
	{
		if (rate >= 100)
			return true;
		if (rate > 0)
			return rnd(100) <= rate;

		return false;
	}

	int t_util::percent(int value, int percentage)
	{
		return value * percentage / 100;
	}

	void t_util::int_to_bytes(uint32_t val, uint8_t bytes[4])
	{
		uint32_t uval = val;
		bytes[0] = uval;
		bytes[1] = uval >> 8;
		bytes[2] = uval >> 16;
		bytes[3] = uval >> 24;
	}

	uint32_t t_util::bytes_to_int(uint8_t bytes[4])
	{
		uint32_t u0 = bytes[0], u1 = bytes[1], u2 = bytes[2], u3 = bytes[3];
		uint32_t uval = u0 | (u1 << 8) | (u2 << 16) | (u3 << 24);
		return uval;
	}

	void t_util::short_to_bytes(uint16_t val, uint8_t bytes[2])
	{
		uint8_t int_bytes[4];
		int_to_bytes(val, int_bytes);
		bytes[0] = int_bytes[0];
		bytes[1] = int_bytes[1];
	}

	uint16_t t_util::bytes_to_short(uint8_t bytes[2])
	{
		uint8_t int_bytes[4];
		int_bytes[0] = bytes[0];
		int_bytes[1] = bytes[1];
		return bytes_to_int(int_bytes);
	}
	
	uint32_t t_util::wrap_add(uint32_t val, int dx, const uint32_t lower, const uint32_t upper)
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

	int t_util::get_digit_count(uint32_t number)
	{
		return number > 0 ? (int)log10((double)number) + 1 : 1;
	}

	t_string t_util::xor_encrypt(t_string str, char xor_key)
	{
		std::string encrypted = str;

		for (int i = 0; i < str.length(); i++)
			encrypted[i] = str[i] ^ xor_key;

		return encrypted;
	}

	t_string t_util::xor_decrypt(t_string str, char xor_key)
	{
		return xor_encrypt(str, xor_key);
	}

	t_string t_util::size_to_string(uint64_t bytes)
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
		sprintf(output, "%.02lf %s", dblBytes, suffix[i]);
		return output;
	}

	t_string t_util::datetime(t_string format)
	{
		auto now = std::chrono::system_clock::now();
		auto in_time_t = std::chrono::system_clock::to_time_t(now);

		std::stringstream ss;
		ss << std::put_time(std::localtime(&in_time_t), format.c_str());
		return ss.str();
	}

	t_string t_util::datetime()
	{
		return datetime("%Y-%m-%d %H:%M:%S");
	}

	t_string t_util::date()
	{
		return datetime("%Y-%m-%d");
	}

	t_string t_util::time()
	{
		return datetime("%H:%M:%S");
	}

	void t_util::set_clipboard(t_string text)
	{
		bool ok = OpenClipboard(nullptr);
		if (ok) {
			ok = EmptyClipboard();
			const char* text_chars = text.c_str();
			int length = (int)strlen(text_chars);
			HGLOBAL clipboard_data = GlobalAlloc(GMEM_MOVEABLE, length + 1);
			if (clipboard_data != nullptr) {
				char* text_chars_copy = (char*)GlobalLock(clipboard_data);
				if (text_chars_copy != nullptr) {
					strcpy(text_chars_copy, LPCSTR(text_chars));
				}
				GlobalUnlock(clipboard_data);
				SetClipboardData(CF_TEXT, clipboard_data);
			}
			ok = CloseClipboard();
		}
	}

	t_string t_util::get_clipboard()
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

	int t_util::distance(int x1, int y1, int x2, int y2)
	{
		int delta_x = x2 - x1;
		int delta_y = y2 - y1;
		return static_cast<int>(std::round(std::sqrt(delta_x * delta_x + delta_y * delta_y)));
	}

	float t_util::distance(float x1, float y1, float x2, float y2)
	{
		float delta_x = x2 - x1;
		float delta_y = y2 - y1;
		return std::sqrt(delta_x * delta_x + delta_y * delta_y);
	}
}
