#include <SDL.h>
#include <SDL_audio.h>
#include <CppUtils.h>
#include <cmath>
#include "TSound.h"
using namespace CppUtils;

namespace TileGameLib
{
	bool Running = false;
	bool PlayingAsync = false;
	bool Enabled = false;
	TSoundType WaveType = TSoundType::Sine;
	float WaveTone = 0;
	int Length = 0;

	void FillAudioBuffer(void*, Uint8*, int);
	int PlayThread(void*);

	TSound::TSound()
	{
		Init();
	}

	TSound::~TSound()
	{
		Running = false;
	}

	void TSound::Init()
	{
		SDL_Init(SDL_INIT_AUDIO);

		SDL_AudioSpec desired, returned;
		SDL_AudioDeviceID idDevice;

		SDL_zero(desired);
		desired.freq = SamplingRate;
		desired.format = AUDIO_S16SYS;
		desired.channels = 1;
		desired.samples = BufferSize;
		desired.callback = &FillAudioBuffer;
		desired.userdata = this;

		idDevice = SDL_OpenAudioDevice(nullptr, 0, &desired, &returned, 0);

		if (idDevice > 0) {
			SDL_PauseAudioDevice(idDevice, 0);
			SDL_CreateThread(PlayThread, "PlayThread", nullptr);
		}
		else {
			MsgBox::Error(String::Format("Sound system failed to start:\n\n%s", SDL_GetError()));
		}
	}

	void TSound::GenerateSamples(short *stream, int length)
	{
		int samplesToWrite = length / sizeof(short);
		for (int i = 0; i < samplesToWrite; i++) {
			if (Enabled) {
				if (WaveType == TSoundType::Sine)
					stream[i] = (short)(Amplitude * SampleSine(SamplingIndex));
			}
			else
				stream[i] = 0;

			SamplingIndex += (WaveTone * M_PI * 2) / SamplingRate;
			if (SamplingIndex >= (M_PI * 2))
				SamplingIndex -= M_PI * 2;
		}
	}

	float TSound::SampleSine(float index)
	{
		double result = sin(index);
		return result;
	}

	void FillAudioBuffer(void* userdata, Uint8* _stream, int len)
	{
		short* stream = reinterpret_cast<short*>(_stream);
		int length = len;
		TSound* beeper = (TSound*)userdata;
		beeper->GenerateSamples(stream, length);
	}

	int PlayThread(void* dummy)
	{
		Running = true;

		while (Running) {
			if (PlayingAsync) {
				Enabled = true;
				SDL_Delay(Length);
				Enabled = false;
				PlayingAsync = false;
			}
		}

		return 0;
	}

	void TSound::Play(TSoundType type, int tone, int length, bool wait)
	{
		WaveType = type;
		WaveTone = tone;
		Length = length;

		if (wait) {
			Enabled = true;
			SDL_Delay(Length);
			Enabled = false;
		}
		else {
			PlayingAsync = true;
		}
	}
}
