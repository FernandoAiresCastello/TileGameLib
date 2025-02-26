#pragma once
#include "TGL_Global.h"

namespace TGL
{
	struct TGLAPI TileAnimation
	{
		bool enabled = true;
		int currentFrame = 0;
		int frameCounter = 0;
		int maxFrameCounter = 70;

		TileAnimation() {}
		TileAnimation(int maxFrameCounter, bool enabled) : 
			maxFrameCounter(maxFrameCounter), enabled(enabled) {}
	};
}
