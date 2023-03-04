#pragma once
#include "TGLGlobal.h"

struct TGLFile
{
	string cload(string file);
	void csave(string file, string data);
	vector<byte> bload(string file);
	void bsave(string file, vector<byte>& data);
	bool exists(string file);
	void del(string file);
	void copy(string src, string dst);
};