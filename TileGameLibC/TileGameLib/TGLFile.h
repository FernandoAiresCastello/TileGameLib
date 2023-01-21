/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLFile
{
	string cload(string file);
	void csave(string file, string data);
	vector<byte> bload(string file);
	void bsave(string file, vector<byte>& data);
	bool exists(string file);
};
