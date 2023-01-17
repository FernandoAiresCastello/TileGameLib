/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGL.h"
#include "TGLImpl.h"

void TILEGAMELIB()
{
	TGL_Init();
}
void EXIT()
{
	TGL_Exit();
}
void HALT()
{
	TGL_Halt();
}
void SCREEN(int cols, int rows, int layers, int hstr, int vstr)
{
	TGL_CreateWindow(cols, rows, layers, hstr, vstr);
}
void TITLE(string title)
{
	TGL_SetWindowTitle(title);
}
void PAL(int ix, int rgb)
{
	TGL_SetPalette(ix, rgb);
}
void WCOL(int ix)
{
	TGL_SetWindowBackColor(ix);
}
void CLS()
{
	TGL_ClearAllBuffers();
}
void VSYNC()
{
	TGL_UpdateWindow();
}
void LAYER(int layer)
{
	TGL_SetCursorLayer(layer);
}
void LOCATE(int x, int y)
{
	TGL_SetCursorPos(x, y);
}
void TRON()
{
	TGL_SetTransparency(true);
}
void TROFF()
{
	TGL_SetTransparency(false);
}
void COLOR(int fg, int bg)
{
	TGL_SetTextForeColor(fg);
	TGL_SetTextBackColor(bg);
}
void PRINT(string text)
{
	TGL_Print(text);
}
void PAUSE(int ms)
{
	TGL_Pause(ms);
}
void TILE_NEW(int ch, int fg, int bg)
{
	TGL_InitWorkingTile(ch, fg, bg);
}
void TILE_ADD(int ch, int fg, int bg)
{
	TGL_AddFrameToWorkingTile(ch, fg, bg);
}
void PUT()
{
	TGL_PutWorkingTile();
}
