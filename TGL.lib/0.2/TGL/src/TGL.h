#pragma once
#include <raylib.h>

#ifdef TGLEXPORTS
	#define TGLAPI __declspec(dllexport)
#else
	#define TGLAPI __declspec(dllimport)
#endif

class TGLAPI TGL
{
public:
	TGL();
	~TGL();

	void Test();
};
