#pragma once
#include "t_string.h"

namespace tgl
{
	class t_util
	{
	public:
		static int rnd(int max);
		static int rnd(int min, int max);
		static int rnd_byte();
		static t_string rnd_hex(int bytes);
		static t_string rnd_string(int length);
		static t_string rnd_string(int length, t_string alphabet);
		static bool chance(int rate);
		static int percent(int value, int percentage);
		static void int_to_bytes(uint32_t val, uint8_t bytes[4]);
		static uint32_t bytes_to_int(uint8_t bytes[4]);
		static void short_to_bytes(uint16_t val, uint8_t bytes[2]);
		static uint16_t bytes_to_short(uint8_t bytes[2]);
		static uint32_t wrap_add(uint32_t val, int dx, const uint32_t lower, const uint32_t upper);
		static int get_digit_count(uint32_t number);
		static t_string xor_encrypt(t_string str, char xor_key);
		static t_string xor_decrypt(t_string str, char xor_key);
		static t_string size_to_string(uint64_t bytes);
		static t_string datetime(t_string format);
		static t_string datetime();
		static t_string date();
		static t_string time();
		static void set_clipboard(t_string text);
		static t_string get_clipboard();
		static int distance(int x1, int y1, int x2, int y2);
		static float distance(float x1, float y1, float x2, float y2);
	};
}
