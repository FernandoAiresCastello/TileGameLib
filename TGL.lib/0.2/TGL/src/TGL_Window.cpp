#include "TGL_Window.h"
#include "TGL_Image.h"

namespace TGL
{
	TGL_Window::TGL_Window()
	{
	}

	TGL_Window::~TGL_Window()
	{
		Close();
	}

	void TGL_Window::Open(int width, int height, const TGL_Color& backColor, bool show)
	{
		Open(width, height, 0, 0, backColor, show);
	}

	void TGL_Window::Open(int width, int height, int sizeMult, const TGL_Color& backColor, bool show)
	{
		Open(width, height, sizeMult, sizeMult, backColor, show);
	}

	void TGL_Window::Open(int width, int height, int widthMult, int heightMult, const TGL_Color& backColor, bool show)
	{
		Width = width;
		Height = height;
		BackColor = backColor;
		BufferLength = sizeof(int) * width * height;
		Buffer = new TGL_Rgb[BufferLength];
		IsCreated = true;

		widthMult++;
		heightMult++;

		const int multipliedWidth = Width * widthMult;
		const int multipliedHeight = height * heightMult;

		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		Window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, multipliedWidth, multipliedHeight, SDL_WINDOW_HIDDEN);
		Renderer = SDL_CreateRenderer(Window, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(Renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(Renderer, multipliedWidth, multipliedHeight);

		Texture = SDL_CreateTexture(Renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, Width, Height);

		SDL_SetTextureBlendMode(Texture, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(Window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		if (show)
			Show();
		else
			Hide();
		
		SetTitle(Title);
		Update();
	}

	void TGL_Window::Close()
	{
		if (IsCreated) {

			SDL_DestroyTexture(Texture);
			SDL_DestroyRenderer(Renderer);
			SDL_DestroyWindow(Window);
			SDL_VideoQuit();

			delete[] Buffer;

			IsCreated = false;
		}
	}

	void TGL_Window::Show()
	{
		SDL_ShowWindow(Window);
		Update();
		SDL_RaiseWindow(Window);
		IsVisible = true;
	}

	void TGL_Window::Hide()
	{
		SDL_HideWindow(Window);
		IsVisible = false;
	}

	void TGL_Window::ClearBackground()
	{
		ClearToColor(BackColor);
	}

	void TGL_Window::ClearToColor(const TGL_Color& color)
	{
		for (int y = 0; y < Height; y++)
			for (int x = 0; x < Width; x++)
				Buffer[y * Width + x] = color.ToRgb();
	}

	void TGL_Window::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(Texture, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, Buffer, BufferLength);
		SDL_UnlockTexture(Texture);
		SDL_RenderCopy(Renderer, Texture, nullptr, nullptr);
		SDL_RenderPresent(Renderer);
	}

	bool TGL_Window::IsOpen() const
	{
		return IsCreated;
	}

	void TGL_Window::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(Window, full ? fullscreenFlag : 0);
		Update();
	}

	void TGL_Window::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(Window) & fullscreenFlag;
		SDL_SetWindowFullscreen(Window, isFullscreen ? 0 : fullscreenFlag);
		Update();
	}

	bool TGL_Window::IsFullscreen() const
	{
		return (SDL_GetWindowFlags(Window) & SDL_WINDOW_FULLSCREEN_DESKTOP) == SDL_WINDOW_FULLSCREEN_DESKTOP;
	}

	void TGL_Window::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(Window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void TGL_Window::SetTitle(const TGL_String& title)
	{
		SDL_SetWindowTitle(Window, title.Cstr());
		Title = title;
	}

	void TGL_Window::SetIcon(const TGL_String& iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.Cstr());
		SDL_SetWindowIcon(Window, &icon);
		SDL_FreeSurface(&icon);
	}

	void TGL_Window::SaveScreenshot(const TGL_String& file) const
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, Width, Height, 32, SDL_PIXELFORMAT_ARGB8888);
		SDL_memcpy(surface->pixels, Buffer, BufferLength);
		SDL_SaveBMP(surface, file.Cstr());
		SDL_FreeSurface(surface);
	}

	void TGL_Window::SetBackColor(const TGL_Color& color)
	{
		BackColor = color;
	}

	TGL_Color TGL_Window::GetBackColor() const
	{
		return BackColor;
	}

	void TGL_Window::SetPixelRgb(int x, int y, TGL_Rgb rgb)
	{
		if (x >= 0 && y >= 0 && x < Width && y < Height)
			Buffer[y * Width + x] = rgb;
	}

	void TGL_Window::SetPixel(int x, int y, const TGL_Color& color)
	{
		if (x >= 0 && y >= 0 && x < Width && y < Height)
			Buffer[y * Width + x] = color.ToRgb();
	}

	void TGL_Window::FillRect(int x, int y, int w, int h, const TGL_Color& color)
	{
		int px = x * w;
		int py = y * h;
		const int prevX = px;
		for (int iy = 0; iy < w; iy++) {
			for (int ix = 0; ix < h; ix++) {
				if (px >= 0 && py >= 0 && px < Width && py < Height) {
					Buffer[py * Width + px] = color.ToRgb();
				}
				px++;
			}
			px = prevX;
			py++;
		}
	}

	TGL_Rgb TGL_Window::GetPixelRgb(int x, int y)
	{
		return Buffer[y * Width + x];
	}

	TGL_Color TGL_Window::GetPixel(int x, int y)
	{
		return TGL_Color(Buffer[y * Width + x]);
	}

	void TGL_Window::DrawImage(TGL_Image* img, int x, int y)
	{
		for (int py = 0; py < img->GetHeight(); py++) {
			for (int px = 0; px < img->GetWidth(); px++) {
				SetPixel(x + px, y + py, img->GetPixel(px, py));
			}
		}
	}
}
