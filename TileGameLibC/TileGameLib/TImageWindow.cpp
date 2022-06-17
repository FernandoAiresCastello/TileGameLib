#include "TImageWindow.h"
#include "TTiledImage.h"
#include "TImage.h"

namespace TileGameLib
{
	TImageWindow::TImageWindow(int width, int height) :
		PixelFormat(SDL_PIXELFORMAT_ARGB8888),
		Width(width), Height(height),
		BufferLength(sizeof(int) * width * height)
	{
		Buffer = new RGB[BufferLength];
		BackColor = 0;
		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("",
			SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED,
			Width, Height, SDL_WINDOW_HIDDEN);

		Renderer = SDL_CreateRenderer(Window, -1,
			SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(Renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(Renderer, Width, Height);

		Scrtx = SDL_CreateTexture(Renderer,
			PixelFormat, SDL_TEXTUREACCESS_STREAMING, Width, Height);

		SDL_SetTextureBlendMode(Scrtx, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
	}

	TImageWindow::~TImageWindow()
	{
	}

	void TImageWindow::Update()
	{
		ClearBackground();

		static int pitch;
		static void* pixels;

		SDL_LockTexture(Scrtx, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Scrtx);
		SDL_RenderCopy(Renderer, Scrtx, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	void TImageWindow::Hide()
	{
		SDL_HideWindow(Window);
	}

	void TImageWindow::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
	}

	void TImageWindow::ClearBackground()
	{
		ClearToRGB(BackColor);
	}

	void TImageWindow::ClearToRGB(RGB rgb)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = rgb;
	}
	
	void TImageWindow::SetPixel(int x, int y, RGB rgb)
	{
		if (x >= 0 && y >= 0 && x < Width && y < Height) {
			Buffer[y * Width + x] = rgb;
		}
	}
	
	RGB TImageWindow::GetPixel(int x, int y)
	{
		return Buffer[y * Width + x];
	}

	void TImageWindow::DrawImageTile(TTiledImage* timg, int tix, int x, int y)
	{
		TImage* img = timg->GetTile(tix);
		int ix = x;
		int iy = y;

		for (int px = 0; px < timg->TileWidth; px++) {
			for (int py = 0; py < timg->TileHeight; py++) {
				TColor& color = img->GetPixel(px, py);
				if (!(img->IsTransparent() && img->GetTransparency().Equals(color))) {
					SetPixel(ix, iy, color.ToColorRGB());
				}
				ix++;
			}
			iy++;
		}
	}
}
