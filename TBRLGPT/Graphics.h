/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <SDL.h>
#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class Charset;

	class TBRLGPT_API Graphics
	{
	public:
		const int PixelFormat;
		const int ScreenWidth;
		const int ScreenHeight;
		const int BufferLength;
		const int WindowWidth;
		const int WindowHeight;
		const int Cols;
		const int Rows;

		Graphics(int screenWidth, int screenHeight, int windowWidth, int windowHeight, bool fullscreen);
		~Graphics();

		void SetFullscreen(bool full);
		void ToggleFullscreen();
		void SetWindowTitle(std::string title);
		void SetWindowBordered(bool bordered);
		void SetWindowIcon(std::string iconfile);
		bool WindowClosed();
		void SaveScreenshot(std::string file);
		void Update();
		void Clear(int color);
		void ClearTile(int x, int y, int color);
		void ClearRow(int row, int color);
		void ClearRows(int first, int last, int color);
		void ClearRect(int x, int y, int w, int h, int color);
		void SetPixel(int x, int y, int color);
		void Fill(Charset* charset, int index, int forecolor, int backcolor);
		void PutChar(Charset* charset, int index, int x, int y, int forecolor, int backcolor);
		void DrawChar(Charset* charset, int index, int x, int y, int forecolor, int backcolor);
		void Print(Charset* charset, int x, int y, int forecolor, int backcolor, std::string str);

	private:
		int* Buffer;
		SDL_Window* Window;
		SDL_Renderer* Renderer;
		SDL_Texture* ScreenTexture;

		void Init(std::string title, bool fullscreen);
		void Dispose();
	};
}
