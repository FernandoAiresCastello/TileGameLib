/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <map>
#include <string>
#include <vector>
#include "TGlobal.h"
#include "TRegion.h"
#include "TTile.h"

namespace TileGameLib
{
	class TCharset;
	class TPalette;
	class TImage;
	class TPanel;
	
	class TWindow
	{
	public:
		static const int DefaultWidth = 1280;
		static const int DefaultHeight = 720;

		TWindow();
		TWindow(int width, int height);
		~TWindow();

		void* GetHandle();
		TCharset* GetCharset();
		TPalette* GetPalette();
		int GetWidth();
		int GetHeight();
		void Hide();
		void Show();
		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetTitle(std::string title);
		void SetBordered(bool bordered);
		void SetIcon(std::string iconfile);
		void SaveScreenshot(std::string file);
		void SetBackColor(PaletteIndex bg);
		int GetBackColor();
		TRegion GetBounds();
		TPanel* AddPanel();
		void RemovePanel(TPanel* panel);
		int GetPanelCount();
		void SetAnimationSpeed(int speed);
		void EnableAnimation(bool enable);
		bool IsAnimationEnabled();
		void Update();
		void ClearAllPanels();
		void DrawImage(TImage* img, int x, int y, int pw, int ph);
		void EraseImage(TImage* img, int x, int y, int pw, int ph);

	private:
		const int Width;
		const int Height;
		const int PixelFormat;
		const int BufferLength;

		RGB* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* Scrtx;
		TCharset* Chr;
		TPalette* Pal;
		PaletteIndex BackColor;
		int PixelWidth;
		int PixelHeight;
		TRegion Clip;
		bool Grid;
		bool TransparentTiles;
		std::vector<TPanel*> Panels;

		TWindow(const TWindow& other) = delete;
		
		void ClearBackground();
		void ClearToRGB(RGB rgb);
		void SetPixel(int x, int y, RGB rgb);
		void SetPixelSize(int w, int h);
		void SetClip(int x1, int y1, int x2, int y2);
		void FillClip(PaletteIndex ix);
		void RemoveClip();
		void DestroyAllPanels();
		void EraseTile(int x, int y);
		void DrawTile(TTile& tile, int x, int y);
		void DrawTile(CharsetIndex chix, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawTileString(std::string str, PaletteIndex fgcix, PaletteIndex bgcix, int x, int y);
		void DrawPanel(TPanel* panel);
		void DrawVisiblePanels();
	};
}
