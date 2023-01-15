/*=============================================================================

	 TileGameLib
	 2018-2023 Developed by Fernando Aires Castello

=============================================================================*/
#include "TGLImpl.h"
#include "TileGameLib.h"
using namespace TileGameLib;

TBufferedWindow* wnd = nullptr;
TPalette* pal = nullptr;
map<string, TTileBuffer*> buffers;
TTileBuffer* selected_buf = nullptr;

struct {
	int layer = 0;
	int x = 0;
	int y = 0;
} csr;

struct {
	int fg = 1;
	int bg = 0;
} txt_color;

bool transparency = false;

void TGL_Init()
{
	SDL_Init(SDL_INIT_EVERYTHING);
}
void TGL_Exit()
{
	delete wnd;
	SDL_Quit();
	exit(0);
}
void TGL_Halt()
{
	while (true) {
		if (wnd) {
			wnd->Update();
		}
		TGL_ProcGlobalEvents();
	}
}
void TGL_ProcGlobalEvents()
{
	SDL_Event e;
	SDL_PollEvent(&e);
	if (e.type == SDL_QUIT) {
		TGL_Exit();
	}
	else if (e.type == SDL_KEYDOWN) {
		auto key = e.key.keysym.sym;
		if (key == SDLK_ESCAPE) {
			TGL_Exit();
		}
		else if (TKey::Alt() && key == SDLK_RETURN && wnd) {
			wnd->ToggleFullscreen();
		}
	}
}
void TGL_CreateWindow(int cols, int rows, int layers, int hstr, int vstr)
{
	wnd = new TBufferedWindow(layers, cols, rows, hstr, vstr);
	
	pal = wnd->GetPalette();
	pal->DeleteAll();
	pal->AddBlank(256);

	selected_buf = wnd->GetBuffer(0);
	buffers["default"] = selected_buf;

	wnd->Show();
}
void TGL_SetWindowTitle(string title)
{
	wnd->SetTitle(title);
}
void TGL_SetPalette(int ix, int rgb)
{
	pal->Set(ix, rgb);
}
int TGL_GetPalette(int ix)
{
	return pal->GetColorRGB(ix);
}
void TGL_SetWindowBackColor(int ix)
{
	wnd->SetBackColor(TGL_GetPalette(ix));
}
void TGL_ClearAllBuffers()
{
	for (auto buf : wnd->GetAllBuffers()) {
		buf->ClearAllLayers();
	}
}
void TGL_UpdateWindow()
{
	wnd->Update();
}
void TGL_SetCursorLayer(int layer)
{
	csr.layer = layer;
}
void TGL_SetCursorPos(int x, int y)
{
	csr.x = x;
	csr.y = y;
}
void TGL_SetTransparency(bool transp)
{
	transparency = transp;
}
void TGL_SetTextForeColor(int color)
{
	txt_color.fg = color;
}
void TGL_SetTextBackColor(int color)
{
	txt_color.bg = color;
}
void TGL_Print(string text)
{
	selected_buf->Print(text, csr.layer, csr.x, csr.y, txt_color.fg, txt_color.bg, transparency);
}
