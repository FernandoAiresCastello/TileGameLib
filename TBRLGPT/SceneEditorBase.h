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

#define INFO_AREA_SEPARATOR_CHAR 1
#define INFO_AREA_MAX_PAGES 2

namespace TBRLGPT
{
	class Scene;
	class Graphics;
	class Charset;
	class Palette;
	class SceneView;
	class SceneObject;

	class TBRLGPT_API SceneEditorBase
	{
	public:
		int ForeColor;
		int BackColor;
		int InfoSeparatorColor;

		SceneEditorBase(class Scene* scene, Graphics* gr,
			Charset* editorChars, Palette* editorPal,
			Charset* sceneChars, Palette* scenePal);

		virtual ~SceneEditorBase();

		void Run();

	protected:
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
		bool InfoEnabled;

		void ClearScreen();
		int GetEditorColor(int paletteIndex);
		void InitCursor();
		void PutChar(int ch, int x, int y);
		void PutChar(int ch, int x, int y, int fgc, int bgc);
		void Print(std::string text, int x, int y);
		void Print(std::string text, int x, int y, int fgc, int bgc);
		void Draw();
		void ClearInfoArea();

		virtual void DrawInfo() = 0;
		virtual void ShowHelp() = 0;
		virtual void OnKeyPress(SDL_Keycode key);
	};
}
