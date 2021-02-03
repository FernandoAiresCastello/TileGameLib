#pragma once
#include <TBRLGPT.h>
using namespace TBRLGPT;
using namespace std;

#define USING_GLOBALS \
	Project* proj = Global::Proj; \
	Palette* pal = Global::Pal; \
	Charset* chr = Global::Chr; \
	Graphics* gr = Global::Gr; \
	UIContext* ctx = Global::Ctx; \

namespace Global
{
	extern Project* Proj;
	extern Palette* Pal;
	extern Charset* Chr;
	extern Graphics* Gr;
	extern UIContext* Ctx;

	void Init();
	void Destroy();
}
