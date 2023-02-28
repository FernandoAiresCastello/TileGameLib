#include "TGLString.h"

string TGLString::trim(string src)
{
	return String::Trim(src);
}
vector<string> TGLString::split(string src, string delim, bool trim)
{
	return String::Split(src, delim, trim);
}
string TGLString::to_string(int src)
{
	return String::ToString(src);
}
int TGLString::to_int(string src)
{
	return String::ToInt(src);
}
float TGLString::to_float(string src)
{
	return String::ToFloat(src);
}
string TGLString::hex(int src, bool ucase)
{
	return String::IntToHex(src, ucase);
}
string TGLString::bin(uint src, int digits)
{
	return String::IntToBinary(src, digits);
}
bool TGLString::start(string src, string prefix)
{
	return String::StartsWith(src, prefix);
}
bool TGLString::end(string src, string suffix)
{
	return String::EndsWith(src, suffix);
}
bool TGLString::has(string src, string search)
{
	return String::Contains(src, search);
}
string TGLString::sub(string src, int begin, int end)
{
	if (end >= 0)
		return String::Substring(src, begin, end);
	else
		return String::Substring(src, begin);
}
string TGLString::replace(string src, string search, string dst)
{
	return String::Replace(src, search, dst);
}
string TGLString::ucase(string src)
{
	return String::ToUpper(src);
}
string TGLString::lcase(string src)
{
	return String::ToLower(src);
}
string TGLString::repeat(string src, int times)
{
	return String::Repeat(src, times);
}
string TGLString::join(vector<string>& src, string delim)
{
	return String::Join(src, delim);
}
int TGLString::ix(string src, char ch, uint offset)
{
	return String::IndexOf(src, ch, offset);
}
bool TGLString::is_numeric(string src)
{
	return String::IsNumber(src);
}
string TGLString::padz(int src, int digits)
{
	return String::PadZero(src, digits);
}
