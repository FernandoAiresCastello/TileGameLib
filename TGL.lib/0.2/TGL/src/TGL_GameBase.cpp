#include "TGL_GameBase.h"
#include "TGL_Application.h"
#include "TGL_Graphics.h"
#include "TGL_Window.h"

namespace TGL
{
	void GameBase::Run(Application* app)
	{
		if (running)
			return;

		running = true;

		wnd = app->GetWindow();
		kb = app->GetKeyboard();
		gr = wnd->GetGraphics();

		OnInit();

		while (running && wnd->IsOpen()) {

			gr->Clear();
			
			Keycode key = kb->GetKey();
			if (key != 0)
				OnKeyPress(key);

			OnUpdate();
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

	void GameBase::ClearScreen()
	{
		gr->Clear();
	}

	void GameBase::Clip(const Rect& rect)
	{
		gr->SetClip(rect);
	}

	void GameBase::Unclip()
	{
		gr->ResetClip();
	}

	void GameBase::TextGrid(bool align)
	{
		textAlignToGrid = align;
	}

	void GameBase::Print(const String& text, const Point& pos, const Color& color)
	{
		gr->DrawString(&font, text, pos, color, color, textAlignToGrid, true);
	}

	void GameBase::Print(const String& text, const Point& pos, const Color& foreColor, const Color& backColor)
	{
		gr->DrawString(&font, text, pos, foreColor, backColor, textAlignToGrid, false);
	}

	void GameBase::PutChar(char ch, const Point& pos, const Color& color)
	{
		gr->DrawChar(&font, ch, pos, color, color, textAlignToGrid, true);
	}

	void GameBase::PutChar(char ch, const Point& pos, const Color& foreColor, const Color& backColor)
	{
		gr->DrawChar(&font, ch, pos, foreColor, backColor, textAlignToGrid, false);
	}

	void GameBase::DrawImage(Image* img, const Point& pos)
	{
		gr->DrawImage(img, pos);
	}

	void GameBase::DrawImageTile(Image* img, const Rect& tileRect, const Point& pos)
	{
		gr->DrawImageTile(img, tileRect, pos);
	}

	void GameBase::DrawTileMap(TileMap* tilemap)
	{
		tilemap->Draw(gr);
	}

	void GameBase::DrawSprite(Sprite* sprite)
	{
		sprite->Draw(gr);
	}

	void GameBase::DrawRect(const Rect& rect, const Color& color)
	{
		gr->FillRect(rect, color);
	}

	bool GameBase::Key(Scancode key)
	{
		return kb->IsPressed(key);
	}

	bool GameBase::Ctrl()
	{
		return kb->Ctrl();
	}

	bool GameBase::Shift()
	{
		return kb->Shift();
	}

	bool GameBase::Alt()
	{
		return kb->Alt();
	}

	bool GameBase::CapsLock()
	{
		return kb->CapsLock();
	}

	void GameBase::FlushKeyboard()
	{
		kb->Flush();
	}
}
