#pragma once
#include "TGLGlobal.h"

struct TGLString
{
	string trim(string src);
	vector<string> split(string src, string delim, bool trim = false);
	string to_string(int src);
	int to_int(string src);
	float to_float(string src);
	string hex(int src, bool ucase = false);
	string bin(uint src, int digits);
	bool start(string src, string prefix);
	bool end(string src, string suffix);
	bool has(string src, string search);
	string sub(string src, int begin, int end = -1);
	string replace(string src, string search, string dst);
	string ucase(string src);
	string lcase(string src);
	string repeat(string src, int times);
	string join(vector<string>& src, string delim = "");
	int ix(string src, char ch, uint offset = 0U);
	bool is_numeric(string src);
	string padz(int src, int digits);
};
