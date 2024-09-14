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

	void Window::Open(const Size& size, const Color& backColor, bool show)
	{
		Open(size, 0, 0, backColor, show);
	}

	void Window::Open(const Size& size, int sizeMult, const Color& backColor, bool show)
	{
		Open(size, sizeMult, sizeMult, backColor, show);
	}

	void Window::Open(const Size& size, int widthMult, int heightMult, const Color& backColor, bool show)
	{
		this->size = size;
		this->backColor = backColor;
		bufferLength = sizeof(int) * size.GetWidth() * size.GetHeight();
		buffer = new RGB[bufferLength];
		isCreated = true;

		widthMult++;
		heightMult++;

		const int multipliedWidth = size.GetWidth() * widthMult;
		const int multipliedHeight = size.GetHeight() * heightMult;

		ClearBackground();

		SDL_Init(SDL_INIT_VIDEO);
		SDL_SetHint(SDL_HINT_RENDER_DRIVER, "direct3d");
		SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "nearest");

		window = SDL_CreateWindow("", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, multipliedWidth, multipliedHeight, SDL_WINDOW_HIDDEN);
		renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_PRESENTVSYNC | SDL_RENDERER_ACCELERATED | SDL_RENDERER_TARGETTEXTURE);

		SDL_SetRenderDrawBlendMode(renderer, SDL_BLENDMODE_NONE);
		SDL_RenderSetLogicalSize(renderer, multipliedWidth, multipliedHeight);

		texture = SDL_CreateTexture(renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, size.GetWidth(), size.GetHeight());

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
		for (int y = 0; y < size.GetHeight(); y++)
			for (int x = 0; x < size.GetWidth(); x++)
				buffer[y * size.GetWidth() + x] = color.ToRGB();
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

	Size Window::GetSize() const
	{
		return size;
	}

	Rect Window::GetRect() const
	{
		return Rect(0, 0, size.GetWidth() - 1, size.GetHeight() - 1);
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
		SDL_Surface* surface = SDL_CreateRGBSurfaceWithFormat(0, size.GetWidth(), size.GetHeight(), 32, SDL_PIXELFORMAT_ARGB8888);
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

	void Window::SetPixel(const Point& pos, const Color& color)
	{
		if (pos.GetX() >= 0 && pos.GetY() >= 0 && pos.GetX() < size.GetWidth() && pos.GetY() < size.GetHeight())
			buffer[pos.GetY() * size.GetWidth() + pos.GetX()] = color.ToRGB();
	}

	void Window::FillRect(const Rect& rect, const Color& color)
	{
		for (int iy = rect.GetY1(); iy <= rect.GetY2(); iy++) {
			for (int ix = rect.GetX1(); ix <= rect.GetX2(); ix++) {
				if (ix >= 0 && iy >= 0 && ix < size.GetWidth() && iy < size.GetHeight()) {
					buffer[iy * size.GetWidth() + ix] = color.ToRGB();
				}
			}
		}
	}

	Color Window::GetPixel(int x, int y)
	{
		return Color(buffer[y * size.GetWidth() + x]);
	}

	void Window::DrawImage(Image* img, const Point& pos)
	{
		for (int py = 0; py < img->GetSize().GetHeight(); py++) {
			for (int px = 0; px < img->GetSize().GetWidth(); px++) {
				SetPixel(Point(pos.GetX() + px, pos.GetY() + py), img->GetPixel(Point(px, py)));
			}
		}
	}

	void Window::DrawImageTile(Image* img, const Rect& imgRect, const Point& dest)
	{
		int destX = dest.GetX();
		int destY = dest.GetY();

		const int initialX = destX;
		for (int py = imgRect.GetY1(); py <= imgRect.GetY2(); py++) {
			for (int px = imgRect.GetX1(); px <= imgRect.GetX2(); px++) {
				SetPixel(Point(destX, destY), img->GetPixel(Point(px, py)));
				destX++;
			}
			destX = initialX;
			destY++;
		}
	}
}
