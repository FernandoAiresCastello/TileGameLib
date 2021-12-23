#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TPalette* pal = new TPalette();
	pal->LoadFromImage("palette.bmp", 300, 157);
	delete pal;
	return 0;
}
