/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "SceneEditor.h"
#include "Scene.h"
#include "SceneObject.h"
#include "Graphics.h"
#include "Charset.h"
#include "Palette.h"
#include "SceneView.h"
#include "Keyboard.h"
#include "StringUtils.h"
#include "Util.h"

#define INFO_AREA_SEPARATOR_CHAR 1
#define INFO_AREA_MAX_PAGES 2
#define DEFAULT_CURSOR_CHAR 0

#define TEMPLATE_OBJ_ID_PROP "template_id"

namespace TBRLGPT
{
	SceneEditor::SceneEditor(class Scene* scene, Graphics* gr, 
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
		SelectedTemplate = NULL;
		const int infoAreaHeight = 5;
		InfoArea = Rect(0, Gr->Rows - infoAreaHeight, Gr->Cols, infoAreaHeight);
		View = new SceneView(Gr, SceneViewCharset, SceneViewPalette, 200);
		View->SetScene(scene);
		View->SetPosition(0, 0);
		View->SetScroll(0, 0);
		View->SetSize(Gr->Cols, Gr->Rows);
		InitCursor();
		Util::Randomize();

		EditorCharset->SetChar(INFO_AREA_SEPARATOR_CHAR, 0, 0, 255, 255, 255, 255, 255, 255);
	}

	SceneEditor::~SceneEditor()
	{
		delete View;

		for (int i = 0; i < ObjTemplates.size(); i++) {
			delete ObjTemplates[i];
			ObjTemplates[i] = NULL;
		}
		ObjTemplates.clear();
	}

	void SceneEditor::Run()
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
				OnKeyPress(e.key.keysym.sym);
			}
		}
	}

	void SceneEditor::ClearScreen()
	{
		Gr->Clear(GetEditorColor(BackColor));
	}

	int SceneEditor::GetEditorColor(int paletteIndex)
	{
		return EditorPalette->Get(paletteIndex)->ToInteger();
	}

	void SceneEditor::InitCursor()
	{
		Cursor = new SceneObject(Scene);
		Cursor->SetLayer(2);

		ObjectAnim& anim = Cursor->GetObj()->GetAnimation();
		anim.Clear();
		anim.AddFrame(ObjectChar(DEFAULT_CURSOR_CHAR, ForeColor, BackColor));
		anim.AddFrame(ObjectChar(DEFAULT_CURSOR_CHAR, BackColor, ForeColor));

		Scene->AddObject(Cursor);
	}

	void SceneEditor::PutChar(int ch, int x, int y)
	{
		PutChar(ch, x, y, ForeColor, BackColor);
	}

	void SceneEditor::PutChar(int ch, int x, int y, int fgc, int bgc)
	{
		Gr->PutChar(EditorCharset, ch, x, y, GetEditorColor(fgc), GetEditorColor(bgc));
	}

	void SceneEditor::Print(std::string text, int x, int y)
	{
		Print(text, x, y, ForeColor, BackColor);
	}

	void SceneEditor::Print(std::string text, int x, int y, int fgc, int bgc)
	{
		Gr->Print(EditorCharset, x, y, GetEditorColor(fgc), GetEditorColor(bgc), text);
	}

	void SceneEditor::ClearInfoArea()
	{
		Gr->ClearRows(InfoArea.Y, InfoArea.Y + InfoArea.Height, GetEditorColor(BackColor));
	}

	void SceneEditor::DrawInfo()
	{
		ClearInfoArea();
		for (int x = InfoArea.X; x < InfoArea.Width; x++) {
			PutChar(INFO_AREA_SEPARATOR_CHAR, x, InfoArea.Y - 1, BackColor, InfoSeparatorColor);
		}

		int x = InfoArea.X + 1;
		int y = InfoArea.Y;

		if (InfoPage == 0) {
			Print(String::Format("%s", Scene->GetName().c_str()), x, y++);
		}
		else if (InfoPage == 1) {
			Print(String::Format("Scene ID: %s", Scene->GetId().c_str()), x, y++);
			Print(String::Format("C(%i,%i) V(%i,%i)",
				Cursor->GetX(), Cursor->GetY(), View->GetScrollX(), View->GetScrollY()), x, y++);
		}
	}

	void SceneEditor::Draw()
	{
		View->Draw();
		DrawInfo();
	}

	void SceneEditor::OnKeyPress(SDL_Keycode key)
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

	void SceneEditor::AddObjTemplate(SceneObject* o, std::string templateId)
	{
		o->GetObj()->SetProperty(TEMPLATE_OBJ_ID_PROP, templateId);
		ObjTemplates.push_back(o);
	}

	SceneObject* SceneEditor::GetObjTemplate(std::string templateId)
	{
		for (int i = 0; i < ObjTemplates.size(); i++) {
			SceneObject* o = ObjTemplates[i];
			if (o->GetObj()->GetPropertyAsString(TEMPLATE_OBJ_ID_PROP) == templateId) {
				return o;
			}
		}

		return NULL;
	}

	void SceneEditor::SelectTemplate(std::string templateId)
	{
		SelectedTemplate = GetObjTemplate(templateId);
	}

	void SceneEditor::PutSelectedTemplate(int x, int y, int layer)
	{
		if (SelectedTemplate == NULL)
			return;

		SceneObject* existingObject = Scene->GetObjectAt(x, y, layer);
		if (existingObject != NULL) {
			Scene->RemoveObject(existingObject);
		}

		SceneObject* newObject = new SceneObject();
		newObject->SetEqual(SelectedTemplate);
		Scene->AddObject(newObject);
	}
}
