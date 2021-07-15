/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include <SDL.h>
#include "Global.h"
#include "Rect.h"

namespace TBRLGPT
{
	class Scene;
	class Graphics;
	class Charset;
	class Palette;
	class SceneView;
	class SceneObject;

	class TBRLGPT_API SceneEditor
	{
	public:
		int ForeColor;
		int BackColor;
		int InfoSeparatorColor;

		SceneEditor(class Scene* scene, Graphics* gr, 
			Charset* editorChars, Palette* editorPal,
			Charset* sceneChars, Palette* scenePal);

		~SceneEditor();

		void Run();

	private:
		Graphics* Gr;
		Charset* EditorCharset;
		Palette* EditorPalette;
		Charset* SceneViewCharset;
		Palette* SceneViewPalette;
		SceneView* View;
		class Scene* Scene;
		bool Running;
		SceneObject* Cursor;
		Rect InfoArea;
		int InfoPage;
		std::vector<SceneObject*> ObjTemplates;
		SceneObject* SelectedTemplate;

		void ClearScreen();
		int GetEditorColor(int paletteIndex);
		void InitCursor();
		void PutChar(int ch, int x, int y);
		void PutChar(int ch, int x, int y, int fgc, int bgc);
		void Print(std::string text, int x, int y);
		void Print(std::string text, int x, int y, int fgc, int bgc);
		void ClearInfoArea();
		void DrawInfo();
		void Draw();
		void OnKeyPress(SDL_Keycode key);
		void AddObjTemplate(SceneObject* o, std::string templateId);
		SceneObject* GetObjTemplate(std::string templateId);
		void SelectTemplate(std::string templateId);
		void PutSelectedTemplate(int x, int y, int layer);
	};
}
