#include "TGL_GameBase.h"
#include "TGL_Application.h"
#include "TGL_Graphics.h"

namespace TGL
{
	void GameBase::Run(Application* app)
	{
		if (running)
			return;

		running = true;

		Window* wnd = app->GetWindow();
		Keyboard* kb = app->GetKeyboard();
		gr = wnd->GetGraphics();

		OnInit();

		while (running && wnd->IsOpen()) {

			gr->Clear();

			OnUpdate(kb);
			OnDraw(gr);

			Keycode key = kb->GetKey();
			if (key != 0)
				OnKeyPress(key);

			app->Update();
		}

		OnExit();
	}

	void GameBase::Quit()
	{
		running = false;
	}

	void GameBase::SetBackColor(const Color& color)
	{
		gr->SetBackColor(color);
	}

	void GameBase::TextGrid(bool align)
	{
		textAlignToGrid = align;
	}

	void GameBase::Print(const String& text, int x, int y, const Color& color)
	{
		gr->DrawString(&font, text, Point(x, y), color, color, textAlignToGrid, true);
	}

	void GameBase::Print(const String& text, int x, int y, const Color& foreColor, const Color& backColor)
	{
		gr->DrawString(&font, text, Point(x, y), foreColor, backColor, textAlignToGrid, false);
	}
}
