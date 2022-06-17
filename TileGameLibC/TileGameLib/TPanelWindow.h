/*=============================================================================

	 TileGameLib
	 2018-2022 Developed by Fernando Aires Castello
	 
=============================================================================*/
#pragma once
#include <SDL.h>
#include <map>
#include <string>
#include <vector>
#include <CppUtils.h>
#include "TGlobal.h"
#include "TRegion.h"
#include "TTile.h"
#include "TWindowBase.h"

using byte = CppUtils::byte;

namespace TileGameLib
{
	class TCharset;
	class TPalette;
	class TImage;
	class TPanel;
	
	class TPanelWindow : public TWindowBase
	{
	public:
		static const int DefaultWidth = 1280;
		static const int DefaultHeight = 720;

		TPanelWindow();
		TPanelWindow(int width, int height);
		virtual ~TPanelWindow();

		virtual void Update();
		TCharset* GetCharset();
		TPalette* GetPalette();
		TRegion GetBounds();
		TPanel* AddPanel();
		void RemovePanel(TPanel* panel);
		int GetPanelCount();
		void SetAnimationSpeed(int speed);
		void EnableAnimation(bool enable);
		bool IsAnimationEnabled();
		void ClearAllPanels();
		void DrawImage(TImage* img, int x, int y, int pw, int ph);
		void EraseImage(TImage* img, int x, int y, int pw, int ph);

	private:
		TCharset* Chr;
		TPalette* Pal;
		int PixelWidth;
		int PixelHeight;
		TRegion Clip;
		bool Grid;
		bool TransparentTiles;
		std::vector<TPanel*> Panels;

		virtual void SetPixel(int x, int y, RGB rgb);
		void SetPixelSize(int w, int h);
		void SetClip(int x1, int y1, int x2, int y2);
		void FillClip(PaletteIndex ix);
		void RemoveClip();
		void DestroyAllPanels();
		void DrawTile(TTile& tile, int x, int y);
		void DrawTile(CharsetIndex ch, PaletteIndex fg, PaletteIndex bg, int x, int y);
		void DrawTileString(std::string str, PaletteIndex fg, PaletteIndex bg, int x, int y);
		void DrawByteAsPixels(byte value, int x, int y, PaletteIndex fg, PaletteIndex bg);
		void DrawVisiblePanels();
		void DrawPanel(TPanel* panel);
	};
}
