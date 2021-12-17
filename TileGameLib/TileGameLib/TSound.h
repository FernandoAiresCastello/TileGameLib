/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <SDL.h>
#include "TGlobal.h"

namespace TileGameLib
{
	enum class TSoundType { Sine };

	class TSound
	{
	public:
		TSound();
		~TSound();

		void Play(TSoundType type, int tone, int length, bool wait);

	private:
		float SamplingIndex = 0;

		const Sint16 Amplitude = 32000;
		const int SamplingRate = 44100;
		const int BufferSize = 1024;

		void Init();
		float SampleSine(float index);
		void GenerateSamples(short* stream, int length);
		friend void FillAudioBuffer(void* userdata, Uint8* _stream, int len);
	};
}
