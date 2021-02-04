/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "ObjectChar.h"
#include "Rect.h"

namespace TBRLGPT
{
	class UIContext;
	class Window;
	class Map;

	class TBRLGPT_API MapViewport
	{
	public:
		MapViewport(UIContext* ctx, class Map* map, int viewX, int viewY, int width, int height, int scrollX, int scrollY, int animationFrameDelay);
		~MapViewport();

		class Map* GetMap();
		void SetMap(class Map* map);
		void Draw();
		void DrawLayer(int index);
		void SetX(int x);
		void SetY(int y);
		void SetWidth(int w);
		void SetHeight(int h);
		int GetX();
		int GetY();
		int GetWidth();
		int GetHeight();
		void SetScroll(int x, int y);
		void ScrollView(int dx, int dy);
		void ClearBorder();
		void DrawBorder();
		void SetInvertedColorArea(Rect area);

	private:
		UIContext* Ctx;
		class Map* Map;
		Window* Win;
		int X;
		int Y;
		int Width;
		int Height;
		int ScrollX;
		int ScrollY;
		Rect InvertedColorArea;
		std::string AnimationTimerId;

		int GetMapWidth();
		int GetMapHeight();
	};
}
