#include "TGL_data.h"

dataset::dataset()
{
}
void dataset::set(string prop, string value)
{
	data.Set(prop, value);
}
void dataset::set(string prop, int value)
{
	data.Set(prop, value);
}
string dataset::get_s(string prop)
{
	return data.GetString(prop);
}
int dataset::get_n(string prop)
{
	return data.GetNumber(prop);
}
bool dataset::has(string prop)
{
	return data.Has(prop);
}
bool dataset::has(string prop, string value)
{
	return data.Has(prop, value);
}
bool dataset::has(string prop, int value)
{
	return data.Has(prop, value);
}
