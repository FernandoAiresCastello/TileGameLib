#include "TGL_Window.h"
#include "TGL_Image.h"

namespace TGL
{
	Window::Window()
	{
	}

	Window::~Window()
	{
		Close();
	}

	void Window::Open(int width, int height, const Color& backColor, bool show)
	{
		Open(width, height, 0, 0, backColor, show);
	}

	void Window::Open(int width, int height, int sizeMult, const Color& backColor, bool show)
	{
		Open(width, height, sizeMult, sizeMult, backColor, show);
	}

	void Window::Open(int width, int height, int widthMult, int heightMult, const Color& backColor, bool show)
	{
		this->width = width;
		this->height = height;
		this->backColor = backColor;
		bufferLength = sizeof(int) * width * height;
		buffer = new RGB[bufferLength];
		isCreated = true;

		widthMult++;
		heightMult++;

		const int multipliedWidth = width * widthMult;
		const int multipliedHeight = height * heightMult;

		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, multipliedWidth, multipliedHeight, SDL_WINDOW_HIDDEN);
		renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(renderer, multipliedWidth, multipliedHeight);

		texture = SDL_CreateTexture(renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, width, height);

		SDL_SetTextureBlendMode(texture, SDL_BLENDMODE_NONE);
		SDL_SetWindowPosition(window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		if (show)
			Show();
		else
			Hide();
		
		SetTitle(title);
		Update();
	}

	void Window::Close()
	{
		if (isCreated) {

			SDL_DestroyTexture(texture);
			SDL_DestroyRenderer(renderer);
			SDL_DestroyWindow(window);
			SDL_VideoQuit();

			delete[] buffer;

			isCreated = false;
		}
	}

	void Window::WaitClose()
	{
		while (IsOpen()) {
			Update();
			SDL_Event e;
			while (SDL_PollEvent(&e)) {
				if (e.type == SDL_QUIT) {
					Close();
				}
				else if (e.type == SDL_KEYDOWN) {
					if (e.key.keysym.sym == SDLK_RETURN && SDL_GetModState() & KMOD_ALT)
						ToggleFullscreen();
					else if (e.key.keysym.sym == SDLK_ESCAPE)
						Close();
				}
			}
		}
	}

	void Window::Show()
	{
		SDL_ShowWindow(window);
		Update();
		SDL_RaiseWindow(window);
		isVisible = true;
	}

	void Window::Hide()
	{
		SDL_HideWindow(window);
		isVisible = false;
	}

	void Window::ClearBackground()
	{
		ClearToColor(backColor);
	}

	void Window::ClearToColor(const Color& color)
	{
		for (int y = 0; y < height; y++)
			for (int x = 0; x < width; x++)
				buffer[y * width + x] = color.ToRGB();
	}

	void Window::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(texture, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, buffer, bufferLength);
		SDL_UnlockTexture(texture);
		SDL_RenderCopy(renderer, texture, nullptr, nullptr);
		SDL_RenderPresent(renderer);
	}

	bool Window::IsOpen() const
	{
		return isCreated;
	}

	void Window::SetFullscreen(bool full)
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(window, full ? fullscreenFlag : 0);
		Update();
	}

	void Window::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
		Uint32 isFullscreen = SDL_GetWindowFlags(window) & fullscreenFlag;
		SDL_SetWindowFullscreen(window, isFullscreen ? 0 : fullscreenFlag);
		Update();
	}

	bool Window::IsFullscreen() const
	{
		return (SDL_GetWindowFlags(window) & SDL_WINDOW_FULLSCREEN_DESKTOP) == SDL_WINDOW_FULLSCREEN_DESKTOP;
	}

	void Window::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(window, bordered ? SDL_TRUE : SDL_FALSE);
	}

	void Window::SetTitle(const String& title)
	{
		SDL_SetWindowTitle(window, title.Cstr());
		this->title = title;
	}

	void Window::SetIcon(const String& iconfile)
	{
		SDL_Surface icon;
		SDL_LoadBMP(iconfile.Cstr());
		SDL_SetWindowIcon(window, &icon);
		SDL_FreeSurface(&icon);
	}

	void Window::SaveScreenshot(const String& file) const
	{
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, width, height, 32, SDL_PIXELFORMAT_ARGB8888);
		SDL_memcpy(surface->pixels, buffer, bufferLength);
		SDL_SaveBMP(surface, file.Cstr());
		SDL_FreeSurface(surface);
	}

	void Window::SetBackColor(const Color& color)
	{
		backColor = color;
	}

	Color Window::GetBackColor() const
	{
		return backColor;
	}

	void Window::SetPixelRGB(int x, int y, RGB rgb)
	{
		if (x >= 0 && y >= 0 && x < width && y < height)
			buffer[y * width + x] = rgb;
	}

	void Window::SetPixel(int x, int y, const Color& color)
	{
		if (x >= 0 && y >= 0 && x < width && y < height)
			buffer[y * width + x] = color.ToRGB();
	}

	void Window::FillRect(int x, int y, int w, int h, const Color& color)
	{
		int px = x * w;
		int py = y * h;
		const int prevX = px;
		for (int iy = 0; iy < w; iy++) {
			for (int ix = 0; ix < h; ix++) {
				if (px >= 0 && py >= 0 && px < width && py < height) {
					buffer[py * width + px] = color.ToRGB();
				}
				px++;
			}
			px = prevX;
			py++;
		}
	}

	RGB Window::GetPixelRGB(int x, int y)
	{
		return buffer[y * width + x];
	}

	Color Window::GetPixel(int x, int y)
	{
		return Color(buffer[y * width + x]);
	}

	void Window::DrawImage(Image* img, int x, int y)
	{
		for (int py = 0; py < img->GetHeight(); py++) {
			for (int px = 0; px < img->GetWidth(); px++) {
				SetPixel(x + px, y + py, img->GetPixel(px, py));
			}
		}
	}
}
