/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
using namespace std;

void TILEGAMELIB();
void EXIT();
void HALT();
void SCREEN(int cols, int rows, int layers, int hstr, int vstr);
void TITLE(string title);
void PAL(int ix, int rgb);
void WCOL(int ix);
void CLS();
void VSYNC();
void LAYER(int layer);
void LOCATE(int x, int y);
void TRON();
void TROFF();
void COLOR(int fg, int bg);
void PRINT(string text);
void PAUSE(int ms);
void TILE_NEW(int ch, int fg, int bg);
void TILE_ADD(int ch, int fg, int bg);
void PUT();
