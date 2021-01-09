/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <map>
#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class UIContext;
	class Window;

	class TBRLGPT_API TextEditor
	{
	public:
		TextEditor(UIContext* ctx, bool border = false);
		TextEditor(UIContext* ctx, int x, int y, int w, int h, bool border);
		~TextEditor();

		void Run();
		void SetReadonly(bool readonly);
		void AddInterruptKey(int key, bool preventDefault = true);
		void EnableEscape(bool enable);
		void SetTabWidth(int width);
		void SetText(std::string text);
		std::string GetText();
		std::string GetText(std::string newline);
		int GetKeyPressed();
		bool KeyPressed(int key);
		void NewLine();
		std::string GetCurrentLine();
		void LoadFromFile(std::string path);
		void Clear();

	private:
		UIContext* Ctx;
		Window* Win;
		std::vector<std::string> Lines;
		bool Readonly;
		bool Running;
		bool Overwrite;
		int Col;
		int Row;
		int Scroll;
		int LastKeyPressed;
		std::map<int, bool> InterruptKeys;
		bool EscEnabled;
		int TabWidth;

		void Draw();
		void ProcessKeyInput();
		bool CheckInterrupt();
		bool PreventDefault();
		void AddChar(int ch);
		void AddTab();
		void AddBlankLine();
		void BackSpace();
		void Delete();
		void ToggleOverwrite();
		void CursorRight();
		void CursorLeft();
		void CursorDown();
		void CursorUp();
		void Home();
		void End();
		void ScrollDown();
		void ScrollUp();
		void SelectLoadFromFile();
	};
}
