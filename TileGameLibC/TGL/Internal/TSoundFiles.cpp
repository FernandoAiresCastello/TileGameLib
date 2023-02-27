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
		if (Exists(id)) {
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
		if (!Exists(id)) {
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

	bool TSoundFiles::Exists(std::string id)
	{
		return Files.find(id) != Files.end();
	}

	void TSoundFiles::ShowError(unsigned long error)
	{
		char msg[1024] = { 0 };
		mciGetErrorString(error, msg, 1024);
		MsgBox::Error(msg);
	}

	/*
	void TSoundFiles::PlayFile(std::string file, bool async)
	{
		if (HasFileLoaded(file)) {
			bool closedOk = CloseFile(file, true);
			if (!closedOk)
				return;
		}

		std::string id = String::ToString(AvailableFileNumber);
		bool loadedOk = LoadFile(id, file);
		if (!loadedOk) {
			return;
		}

		std::string playString = "play " + Files[file];
		if (!async) {
			playString += " wait";
		}
		MCIERROR error = mciSendString(playString.c_str(), NULL, 0, NULL);
		if (error) {
			char msg[1024] = { 0 };
			mciGetErrorString(error, msg, 1024);
			MsgBox::Error(msg);
			return;
		}
	}

	bool TSoundFiles::LoadFile(std::string id, std::string file)
	{
		if (HasFileLoaded(file)) {
			
			return false;
		}
		
		Files[file] = id;

		std::string openString = "open \"" + file + "\" type waveaudio alias " + Files[file];
		MCIERROR error = mciSendString(openString.c_str(), NULL, 0, NULL);
		if (error) {
			char msg[1024] = { 0 };
			mciGetErrorString(error, msg, 1024);
			MsgBox::Error(msg);
			return false;
		}

		AvailableFileNumber++;
		return true;
	}

	void TSoundFiles::PlayLoadedFile(std::string id, bool async)
	{
		if (!HasFileLoaded(id)) {
			MsgBox::Error("No loaded sound file found with id: " + id);
			return;
		}
	}

	bool TSoundFiles::HasFileLoaded(std::string file)
	{
		return Files.find(file) != Files.end();
	}

	bool TSoundFiles::CloseFile(std::string file, bool removeEntry)
	{
		std::string closeString = "close " + Files[file];
		MCIERROR error = mciSendString(closeString.c_str(), NULL, 0, NULL);
		if (error) {
			char msg[1024] = { 0 };
			mciGetErrorString(error, msg, 1024);
			MsgBox::Error(msg);
			return false;
		}
		if (removeEntry) {
			Files.erase(file);
		}
		return true;
	}
	*/
}
