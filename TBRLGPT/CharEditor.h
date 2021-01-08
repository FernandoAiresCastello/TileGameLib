/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include "Char.h"
#include "CharInstance.h"

namespace TBRLGPT
{
	class UIContext;
	class Charset;
	class Window;

	class TBRLGPT_API CharEditor
	{
	public:
		CharEditor(UIContext* ctx, Charset* chars, int x, int y);
		~CharEditor();

		void AddRepaintPosition(CharInstance ci);
		int Edit(int charIndex);

	private:
		UIContext* Ctx;
		Charset* CharsToEdit;
		Window* Win;
		Window* WinPreview;
		Window* WinInd;
		int CharIndex;
		bool Running;
		int X;
		int Y;
		int PixelRow;
		int PixelBit;
		char* Buffer;
		std::vector<CharInstance>* RepaintPositions;

		CharEditor(CharEditor& other) {}

		void SetCharIndex(int index);
		void FillBuffer();
		void UpdateChar();
		void Draw();
		char& GetCurrentPixel();
		void SetPixelOn();
		void SetPixelOff();
		void TogglePixel();
		void DrawRepaintPositions();
		void ClearChar();
	};
}
