#include <Windows.h>
#include "CppMsgBox.h"

namespace CppUtils
{
	void MsgBox::Info(std::string message)
	{
		Info("", message);
	}

	void MsgBox::Info(std::string title, std::string message)
	{
		MessageBoxA(nullptr, message.c_str(), title.c_str(),
			MB_OK | MB_ICONINFORMATION | MB_TASKMODAL | MB_SETFOREGROUND);
	}

	void MsgBox::Warning(std::string message)
	{
		Warning("", message);
	}

	void MsgBox::Warning(std::string title, std::string message)
	{
		MessageBoxA(nullptr, message.c_str(), title.c_str(),
			MB_OK | MB_ICONWARNING | MB_TASKMODAL | MB_SETFOREGROUND);
	}

	void MsgBox::Error(std::string message)
	{
		Error("", message);
	}

	void MsgBox::Error(std::string title, std::string message)
	{
		MessageBoxA(nullptr, message.c_str(), title.c_str(),
			MB_OK | MB_ICONERROR | MB_TASKMODAL | MB_SETFOREGROUND);
	}
}
