/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <Windows.h>
#include "Sound.h"

namespace TBRLGPT
{
	void Sound::Play(byte* wav)
	{
		PlaySound((LPCSTR)wav, NULL, SND_MEMORY);
	}
}
