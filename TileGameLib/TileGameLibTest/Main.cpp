#include <SDL.h>
#include <TileGameLib.h>
#include <CppUtils.h>
using namespace TileGameLib;
using namespace CppUtils;

int main(int argc, char* argv[])
{
	TCharset* chars = new TCharset();
	chars->LoadFromImage("chars.bmp");
	delete chars;
	return 0;
}
