/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "SceneEditorBase.h"
#include "Scene.h"
#include "SceneObject.h"
#include "Graphics.h"
#include "Charset.h"
#include "Palette.h"
#include "SceneView.h"
#include "Keyboard.h"
#include "StringUtils.h"
#include "Util.h"

#define DEFAULT_CURSOR_CHAR 0
#define OBJ_ANIMATION_DELAY 200
#define INFO_AREA_HEIGHT 5

namespace TBRLGPT
{
	SceneEditorBase::SceneEditorBase(class Scene* scene, Graphics* gr,
		Charset* editorChars, Palette* editorPal,
		Charset* sceneChars, Palette* scenePal)
	{
		Gr = gr;
		EditorCharset = editorChars;
		EditorPalette = editorPal;
		SceneViewCharset = sceneChars;
		SceneViewPalette = scenePal;
		Scene = scene;
		Running = false;
		ForeColor = 2;
		BackColor = 1;
		InfoSeparatorColor = 0;
		InfoPage = 0;
		InfoArea = Rect(0, Gr->Rows - INFO_AREA_HEIGHT, Gr->Cols, INFO_AREA_HEIGHT);
		InfoEnabled = true;
		View = new SceneView(Gr, SceneViewCharset, SceneViewPalette, OBJ_ANIMATION_DELAY);
		View->SetScene(scene);
		View->SetPosition(0, 0);
		View->SetScroll(0, 0);
		View->SetSize(Gr->Cols, Gr->Rows);
		InitCursor();
		Util::Randomize();

		EditorCharset->SetChar(INFO_AREA_SEPARATOR_CHAR, 0, 0, 255, 255, 255, 255, 255, 255);
	}

	SceneEditorBase::~SceneEditorBase()
	{
		delete View;
	}

	void SceneEditorBase::Run()
	{
		ClearScreen();

		Running = true;

		while (Running) {
			Draw();
			Gr->Update();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_QUIT) {
				Running = false;
			}
			else if (e.type == SDL_KEYDOWN) {
				if (e.key.keysym.sym == SDLK_F1) {
					ShowHelp();
				}
				else {
					OnKeyPress(e.key.keysym.sym);
				}
			}
		}
	}

	void SceneEditorBase::ClearScreen()
	{
		Gr->Clear(GetEditorColor(BackColor));
	}

	int SceneEditorBase::GetEditorColor(int paletteIndex)
	{
		return EditorPalette->Get(paletteIndex)->ToInteger();
	}

	void SceneEditorBase::InitCursor()
	{
		Cursor = new SceneObject();
		Cursor->SetLayer(2);
		Cursor->SetScene(Scene);

		ObjectAnim& anim = Cursor->GetObj()->GetAnimation();
		anim.Clear();
		anim.AddFrame(ObjectChar(DEFAULT_CURSOR_CHAR, ForeColor, BackColor));
		anim.AddFrame(ObjectChar(DEFAULT_CURSOR_CHAR, BackColor, ForeColor));

		Scene->AddObject(Cursor);
	}

	void SceneEditorBase::PutChar(int ch, int x, int y)
	{
		PutChar(ch, x, y, ForeColor, BackColor);
	}

	void SceneEditorBase::PutChar(int ch, int x, int y, int fgc, int bgc)
	{
		Gr->PutChar(EditorCharset, ch, x, y, GetEditorColor(fgc), GetEditorColor(bgc));
	}

	void SceneEditorBase::Print(std::string text, int x, int y)
	{
		Print(text, x, y, ForeColor, BackColor);
	}

	void SceneEditorBase::Print(std::string text, int x, int y, int fgc, int bgc)
	{
		Gr->Print(EditorCharset, x, y, GetEditorColor(fgc), GetEditorColor(bgc), text);
	}

	void SceneEditorBase::Draw()
	{
		View->Draw();
		if (InfoEnabled)
			DrawInfo();
	}

	void SceneEditorBase::ClearInfoArea()
	{
		Gr->ClearRows(InfoArea.Y, InfoArea.Y + InfoArea.Height, GetEditorColor(BackColor));
	}

	void SceneEditorBase::OnKeyPress(SDL_Keycode key)
	{
		const bool alt = Key::Alt();
		const bool ctrl = Key::Ctrl();
		const bool shift = Key::Shift();

		switch (key) {
			case SDLK_ESCAPE:
				Running = false;
				break;
			case SDLK_RETURN:
				if (alt) {
					Gr->ToggleFullscreen();
				}
				break;
			case SDLK_i:
				InfoPage++;
				if (InfoPage >= INFO_AREA_MAX_PAGES) {
					InfoPage = 0;
				}
				break;
			case SDLK_RIGHT:
				if (ctrl)
					View->Scroll(1, 0);
				else
					Cursor->Move(1, 0);
				break;
			case SDLK_LEFT:
				if (ctrl)
					View->Scroll(-1, 0);
				else
					Cursor->Move(-1, 0);
				break;
			case SDLK_UP:
				if (ctrl)
					View->Scroll(0, -1);
				else
					Cursor->Move(0, -1);
				break;
			case SDLK_DOWN:
				if (ctrl)
					View->Scroll(0, 1);
				else
					Cursor->Move(0, 1);
				break;

			default:
				break;
		}
	}
}
