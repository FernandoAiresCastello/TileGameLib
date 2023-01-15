/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include <string>
#include <vector>
#include <map>
using namespace std;

void TGL_Init();
void TGL_Exit();
void TGL_Halt();
void TGL_ProcGlobalEvents();
void TGL_CreateWindow(int cols, int rows, int layers, int hstr, int vstr);
void TGL_SetWindowTitle(string title);
void TGL_SetPalette(int ix, int rgb);
int TGL_GetPalette(int ix);
void TGL_SetWindowBackColor(int rgb);
void TGL_ClearAllBuffers();
void TGL_UpdateWindow();
void TGL_SetCursorLayer(int layer);
void TGL_SetCursorPos(int x, int y);
void TGL_SetTransparency(bool transp);
void TGL_SetTextForeColor(int color);
void TGL_SetTextBackColor(int color);
void TGL_Print(string text);
