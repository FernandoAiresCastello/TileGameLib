#include "TGL_Window.h"
#include "TGL_Graphics.h"

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
		gr = std::make_shared<Graphics>(size);

		this->size = size;
		this->backColor = backColor;
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
		gr->ClearToColor(backColor);
	}

	void Window::Update()
	{
		static int pitch;
		static void* pixels;

		SDL_LockTexture(texture, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, gr->GetBuffer(), gr->GetBufferLength());
		SDL_UnlockTexture(texture);
		SDL_RenderCopy(renderer, texture, nullptr, nullptr);
		SDL_RenderPresent(renderer);
	}

	bool Window::IsOpen() const
	{
		return isCreated;
	}

	void Window::SetBackColor(const Color& color)
	{
		backColor = color;
	}

	Color Window::GetBackColor() const
	{
		return backColor;
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

	Graphics* Window::GetGraphics()
	{
		return gr.get();
	}
}
