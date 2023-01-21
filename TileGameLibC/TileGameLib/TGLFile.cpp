/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLFile.h"

string TGLFile::cload(string file)
{
	return File::ReadText(file);
}
void TGLFile::csave(string file, string data)
{
	File::WriteText(file, data);
}
vector<byte> TGLFile::bload(string file)
{
	return File::ReadBytes(file);
}
void TGLFile::bsave(string file, vector<byte>& data)
{
	File::WriteBytes(file, data);
}
bool TGLFile::exists(string file)
{
	return File::Exists(file);
}
void TGLFile::del(string file)
{
	File::Delete(file);
}
void TGLFile::copy(string src, string dst)
{
	File::Duplicate(src, dst);
}
