/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <string>
#include <SDL.h>
#include "CharEditor.h"
#include "Char.h"
#include "Palette.h"
#include "ObjectChar.h"
#include "Graphics.h"
#include "Charset.h"
#include "UIContext.h"
#include "Window.h"
#include "StringUtils.h"
#include "Keyboard.h"

namespace TBRLGPT
{
	CharEditor::CharEditor(UIContext* ctx, Charset* chars, int x, int y) :
		Ctx(ctx), CharsToEdit(chars), CharIndex(0), X(x), Y(y), 
		PixelRow(0), PixelBit(0), Running(false)
	{
		Buffer = new char[Char::Size];
		WinInd = new Window(Ctx, x, y, 8, 1);
		Win = new Window(Ctx, x, y + 3, Char::Width, Char::Height);
		WinPreview = new Window(Ctx, x, y + Char::Height + 5, Char::Width, 3);
		RepaintPositions = new std::vector<CharInstance>();
	}

	CharEditor::~CharEditor()
	{
		delete Buffer;
		delete Win;
		delete WinPreview;
		delete WinInd;
		delete RepaintPositions;
	}

	void CharEditor::AddRepaintPosition(CharInstance ci)
	{
		RepaintPositions->push_back(ci);
	}

	int CharEditor::Edit(int charIndex)
	{
		SetCharIndex(charIndex);
		Running = true;

		while (Running)
		{
			Draw();
			Ctx->Update();

			SDL_Event e = { 0 };
			SDL_PollEvent(&e);

			if (e.type == SDL_KEYDOWN) {
				const byte* keys = SDL_GetKeyboardState(NULL);
				bool ctrl = Key::Ctrl();

				switch (e.key.keysym.sym) {
					case SDLK_ESCAPE:
					case SDLK_RETURN:
					case SDLK_e: {
						Running = false;
						break;
					}
					case SDLK_SPACE: {
						TogglePixel();
						break;
					}
					case SDLK_PAGEUP: {
						if (CharIndex > 0) {
							UpdateChar();
							SetCharIndex(CharIndex - 1);
						}
						break;
					}
					case SDLK_PAGEDOWN: {
						if (CharIndex < Charset::Size - 1) {
							UpdateChar();
							SetCharIndex(CharIndex + 1);
						}
						break;
					}
					case SDLK_RIGHT: {
						if (PixelBit < Char::Width - 1) {
							if (ctrl) SetPixelOn();
							PixelBit++;
						}
						break;
					}
					case SDLK_LEFT: {
						if (PixelBit > 0) {
							if (ctrl) SetPixelOn();
							PixelBit--;
						}
						break;
					}
					case SDLK_UP: {
						if (PixelRow > 0) {
							if (ctrl) SetPixelOn();
							PixelRow--;
						}
						break;
					}
					case SDLK_DOWN: {
						if (PixelRow < Char::Height - 1) {
							if (ctrl) SetPixelOn();
							PixelRow++;
						}
						break;
					}
					case SDLK_DELETE: {
						ClearChar();
						break;
					}
				}
			}
		}

		UpdateChar();
		return CharIndex;
	}

	void CharEditor::SetCharIndex(int index)
	{
		CharIndex = index;
		FillBuffer();
	}

	void CharEditor::FillBuffer()
	{
		byte* pixels = CharsToEdit->Get(CharIndex);
		int bufferIx = 0;

		for (int row = 0; row < Char::Height; row++)
		{
			const unsigned int& bits = pixels[row];

			for (int pos = Char::Width - 1; pos >= 0; pos--, bufferIx++)
			{
				int pixelOn = (bits & (1 << pos));
				Buffer[bufferIx] = pixelOn ? '1' : '0';
			}
		}
	}

	void CharEditor::UpdateChar()
	{
		byte* pixels = CharsToEdit->Get(CharIndex);

		for (int row = 0; row < Char::Height; row++)
		{
			std::string rowbits = "";

			for (int col = 0; col < Char::Width; col++)
				rowbits += Buffer[col + (row * Char::Width)];

			pixels[row] = (byte)strtol(rowbits.c_str(), NULL, 2);
		}
	}

	void CharEditor::Draw()
	{
		Win->Draw();
		WinPreview->Draw();
		WinInd->Draw();

		int initX = X + 1;
		int px = initX;
		int py = Y + 4;

		for (int row = 0; row < Char::Height; row++)
		{
			for (int col = 0; col < Char::Width; col++, px++)
			{
				int pixelOn = Buffer[col + (row * Char::Width)] == '1';
				bool atCursor = PixelRow == row && PixelBit == col;

				int chr = 0x00;
				if (pixelOn || atCursor)
					chr = 0xdb;

				int color;
				if (atCursor)
				{
					if (pixelOn)
						color = Ctx->BackColor;
					else
						color = Ctx->ForeColor;
				}
				else
					color = Ctx->ForeColor;

				Ctx->Gr->PutChar(Ctx->Chars, chr, px, py, color, Ctx->BackColor);
			}

			py++;
			px = initX;
		}

		WinInd->Print(1, 0, String::Format("%03Xh", CharIndex));
		WinInd->PutChar(CharIndex, 6, 0, Ctx->ForeColor, Ctx->BackColor, CharsToEdit);

		for (int mx = 0; mx < WinPreview->Width; mx++)
			for (int my = 0; my < WinPreview->Height; my++)
				Ctx->Gr->PutChar(CharsToEdit, CharIndex, WinPreview->X + mx + 1, WinPreview->Y + my + 1, Ctx->ForeColor, Ctx->BackColor);
	}

	char& CharEditor::GetCurrentPixel()
	{
		return Buffer[PixelBit + (PixelRow * Char::Width)];
	}

	void CharEditor::SetPixelOn()
	{
		GetCurrentPixel() = '1';
		UpdateChar();
	}

	void CharEditor::SetPixelOff()
	{
		GetCurrentPixel() = '0';
		UpdateChar();
	}

	void CharEditor::TogglePixel()
	{
		char& c = GetCurrentPixel();

		if (c == '1')
			c = '0';
		else
			c = '1';

		UpdateChar();
		DrawRepaintPositions();
	}

	void CharEditor::DrawRepaintPositions()
	{
		for (unsigned i = 0; i < RepaintPositions->size(); i++)
		{
			Palette* pal = (*RepaintPositions)[i].Pal;
			ObjectChar* ch = (*RepaintPositions)[i].Char;
			int x = (*RepaintPositions)[i].X;
			int y = (*RepaintPositions)[i].Y;
			Ctx->Gr->PutChar(CharsToEdit, ch->Index, x, y,
				pal->Get(ch->ForeColorIx)->ToInteger(), pal->Get(ch->BackColorIx)->ToInteger());
		}
	}

	void CharEditor::ClearChar()
	{
		for (int i = 0; i < Char::Size; i++)
			Buffer[i] = '0';

		UpdateChar();
	}
}
