#include "TGL_Window.h"

namespace TGL
{
	struct {
		SDL_Window* Window = nullptr;
		SDL_Renderer* Renderer = nullptr;
		SDL_Texture* Texture = nullptr;
		TGL_Rgb* Buffer = nullptr;
		TGL_Rgb BackColor = 0x000000;
		int BufferLength = 0;
		int Width = 0;
		int Height = 0;
		bool IsCreated = false;
		bool IsVisible = false;
	} impl;

	TGL_Window::TGL_Window()
	{
	}

	TGL_Window::~TGL_Window()
	{
		if (impl.IsCreated) {

			SDL_DestroyTexture(impl.Texture);
			SDL_DestroyRenderer(impl.Renderer);
			SDL_DestroyWindow(impl.Window);
			SDL_VideoQuit();

			delete[] impl.Buffer;

			impl.IsCreated = false;
		}
	}

	void TGL_Window::Create(int width, int height, TGL_Rgb backColor)
	{
		impl.Width = width;
		impl.Height = height;
		impl.BackColor = backColor;
		impl.BufferLength = sizeof(int) * width * height;
		impl.Buffer = new TGL_Rgb[impl.BufferLength];
		impl.IsCreated = true;
		impl.IsVisible = false;

		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		impl.Window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, impl.Width, impl.Height, impl.IsVisible ? SDL_WINDOW_SHOWN : SDL_WINDOW_HIDDEN);
		impl.Renderer = SDL_CreateRenderer(impl.Window, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(impl.Renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(impl.Renderer, impl.Width, impl.Height);

		impl.Texture = SDL_CreateTexture(impl.Renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, impl.Width, impl.Height);

		SDL_SetTextureBlendMode(impl.Texture, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(impl.Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		Update();
	}

	void TGL_Window::Show()
	{
		SDL_ShowWindow(impl.Window);
		Update();
		SDL_RaiseWindow(impl.Window);
	}

	void TGL_Window::ClearBackground()
	{
		ClearToRgb(impl.BackColor);
	}

	void TGL_Window::ClearToRgb(TGL_Rgb rgb)
	{
		for (int y = 0; y < impl.Height; y++)
			for (int x = 0; x < impl.Width; x++)
				impl.Buffer[y * impl.Width + x] = rgb;
	}

	void TGL_Window::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(impl.Texture, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, impl.Buffer, impl.BufferLength);
		SDL_UnlockTexture(impl.Texture);
		SDL_RenderCopy(impl.Renderer, impl.Texture, nullptr, nullptr);
		SDL_RenderPresent(impl.Renderer);
	}

	bool TGL_Window::IsOpen()
	{
		return impl.IsCreated;
	}
}
