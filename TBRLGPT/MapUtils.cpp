/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "MapUtils.h"
#include "Map.h"
#include "ObjectLayer.h"
#include "UIContext.h"
#include "Graphics.h"
#include "Charset.h"
#include "Palette.h"
#include "Project.h"

namespace TBRLGPT
{
	void MapUtils::DrawFlatMap(UIContext* ctx, Map* map, int offsetX, int offsetY)
	{
		Charset* chars = map->GetProject()->GetCharset();
		Palette* pal = map->GetProject()->GetPalette();

		for (int layerIx = 0; layerIx < map->GetLayerCount(); layerIx++) {
			ObjectLayer* layer = map->GetLayer(layerIx);
			for (int y = 0; y < layer->GetHeight(); y++) {
				for (int x = 0; x < layer->GetWidth(); x++) {
					ObjectChar& ch = layer->GetObject(x + offsetX, y + offsetY)->GetAnimation().GetFrame(0);
					int fgc = pal->Get(ch.ForeColorIx)->ToInteger();
					int bgc = pal->Get(ch.BackColorIx)->ToInteger();
					ctx->Gr->PutChar(chars, ch.Index, x, y, fgc, bgc);
				}
			}
		}
	}
}
