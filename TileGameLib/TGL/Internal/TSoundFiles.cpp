#include <Windows.h>
#include "CppUtils.h"
#include "TSoundFiles.h"
using namespace CppUtils;

namespace TGL_Internal
{
	TSoundFiles::TSoundFiles()
	{
	}

	TSoundFiles::~TSoundFiles()
	{
		CloseAll();
	}

	void TSoundFiles::Load(std::string id, std::string file)
	{
		if (Has(id)) {
			MsgBox::Error("Sound file is already loaded\r\n\r\n"
				"Sound ID: " + id + "\r\n"
				"File: " + file);
			return;
		}
		Files[id] = file;
		
		std::string openString = "open \"" + file + "\" type waveaudio alias " + id;

		MCIERROR error = mciSendString(openString.c_str(), NULL, 0, NULL);
		if (error) {
			ShowError(error);
		}
	}

	void TSoundFiles::Play(std::string id, bool async)
	{
		if (!Has(id)) {
			MsgBox::Error("Sound not found with ID: " + id);
			return;
		}

		std::string seekString = "seek " + id + " to start";
		MCIERROR seekError = mciSendString(seekString.c_str(), NULL, 0, NULL);
		if (seekError) {
			ShowError(seekError);
			return;
		}

		std::string playString = "play " + id;
		if (!async) {
			playString += " wait";
		}
		MCIERROR playError = mciSendString(playString.c_str(), NULL, 0, NULL);
		if (playError) {
			ShowError(playError);
			return;
		}
	}

	void TSoundFiles::CloseAll()
	{
		for (auto& file : Files) {
			std::string closeString = "close " + file.first;
			MCIERROR error = mciSendString(closeString.c_str(), NULL, 0, NULL);
			if (error) {
				ShowError(error);
			}
		}
		Files.clear();
	}

	bool TSoundFiles::Has(std::string id)
	{
		return Files.find(id) != Files.end();
	}

	void TSoundFiles::StopAll()
	{
		for (auto& file : Files) {
			std::string playString = "stop " + file.first;
			MCIERROR playError = mciSendString(playString.c_str(), NULL, 0, NULL);
			if (playError) {
				ShowError(playError);
				return;
			}
		}
	}

	void TSoundFiles::ShowError(unsigned long error)
	{
		char msg[1024] = { 0 };
		mciGetErrorString(error, msg, 1024);
		MsgBox::Error(msg);
	}
}
