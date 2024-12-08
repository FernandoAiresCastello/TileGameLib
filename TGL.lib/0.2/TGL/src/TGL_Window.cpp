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
		if (isCreated)
			return;
		
		isCreated = true;

		gr = new Graphics(size);

		this->size = size;
		this->backColor = backColor;

		widthMult++;
		heightMult++;

		const int multipliedWidth = size.GetWidth() * widthMult;
		const int multipliedHeight = size.GetHeight() * heightMult;

		ClearBackground();

		SDL_CreateWindowAndRenderer("", size.GetWidth() * widthMult, size.GetHeight() * heightMult, SDL_WINDOW_HIDDEN, &window, &renderer);
		SDL_SetWindowPosition(window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);

		texture = SDL_CreateTexture(renderer, SDL_PIXELFORMAT_ARGB8888, SDL_TEXTUREACCESS_STREAMING, size.GetWidth(), size.GetHeight());

		SDL_SetTextureScaleMode(texture, SDL_SCALEMODE_NEAREST);
		SDL_SetRenderLogicalPresentation(renderer, size.GetWidth(), size.GetHeight(), SDL_LOGICAL_PRESENTATION_STRETCH);
		SDL_SetRenderDrawBlendMode(renderer, SDL_BLENDMODE_NONE);
		SDL_SetTextureBlendMode(texture, SDL_BLENDMODE_NONE);
		SDL_SetRenderTarget(renderer, texture);
		SDL_RenderClear(renderer);
		SDL_RenderPresent(renderer);

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

			delete gr;
			gr = nullptr;

			isCreated = false;
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
		static void* pixels;
		static int pitch;
		SDL_LockTexture(texture, nullptr, &pixels, &pitch);
		SDL_memcpy(pixels, gr->GetBuffer(), gr->GetBufferLength());
		SDL_UnlockTexture(texture);
		SDL_RenderTexture(renderer, texture, nullptr, nullptr);
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
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN;
		Uint32 isFullscreen = SDL_GetWindowFlags(window) & fullscreenFlag;

		if ((full && isFullscreen) || (!full && !isFullscreen))
			return;

		SDL_SetWindowFullscreen(window, full ? fullscreenFlag : 0);
		Update();
	}

	void Window::ToggleFullscreen()
	{
		Uint32 fullscreenFlag = SDL_WINDOW_FULLSCREEN;
		Uint32 isFullscreen = SDL_GetWindowFlags(window) & fullscreenFlag;
		SDL_SetWindowFullscreen(window, isFullscreen ? 0 : fullscreenFlag);
		Update();
	}

	bool Window::IsFullscreen() const
	{
		return (SDL_GetWindowFlags(window) & SDL_WINDOW_FULLSCREEN) == SDL_WINDOW_FULLSCREEN;
	}

	void Window::SetBordered(bool bordered)
	{
		SDL_SetWindowBordered(window, bordered ? true : false);
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
		SDL_DestroySurface(&icon);
	}

	Graphics* Window::GetGraphics()
	{
		return gr;
	}
}
