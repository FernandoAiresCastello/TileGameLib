/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "CharSelectorEditor.h"
#include "Graphics.h"
#include "UIContext.h"
#include "CharSelector2.h"
#include "CharEditor.h"

namespace TBRLGPT
{
	CharSelectorEditor::CharSelectorEditor(UIContext* ctx, Charset* chars, int initialChar, 
		int x, int y, int w, int h) :
		Ctx(ctx), CharsToSelectEdit(chars), CharIndex(initialChar), X(x), Y(y), Width(w), Height(h)
	{
	}

	void CharSelectorEditor::Run()
	{
		while (CharIndex >= 0) {
			CharSelector2* chrsel = new CharSelector2(Ctx, CharsToSelectEdit, X, Y, Width, Height);
			CharIndex = chrsel->Select(CharIndex, false);
			delete chrsel;
			if (CharIndex >= 0) {
				CharEditor* chredit = new CharEditor(Ctx, CharsToSelectEdit, X + 18, Y);
				CharIndex = chredit->Edit(CharIndex);
				delete chredit;
			}
		}
	}
}
