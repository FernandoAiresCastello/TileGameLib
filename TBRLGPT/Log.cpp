/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include <string>
#include <cstdarg>
#include "Log.h"
#include "Util.h"

namespace TBRLGPT
{
	Log::Log(std::string filename)
	{
		File = fopen(filename.c_str(), "wb");
		Timestamp = true;
	}

	void Log::SetTimestamp(bool timestamp)
	{
		Timestamp = timestamp;
	}

	Log::~Log()
	{
		fflush(File);
		fclose(File);
	}

	void Log::Print(const char* fmt, ...)
	{
		char str[TempStrBufferLength] = { 0 };
		va_list arg;
		va_start(arg, fmt);
		vsprintf(str, fmt, arg);
		va_end(arg);

		if (Timestamp) {
			std::string datetime = Util::DateTime() + " ";
			fprintf(File, datetime.c_str());
		}

		fprintf(File, str);
		fprintf(File, "\r\n");
	}

	void Log::Print(std::string msg)
	{
		if (Timestamp) {
			std::string datetime = Util::DateTime() + " ";
			fprintf(File, datetime.c_str());
		}

		fprintf(File, msg.c_str());
		fprintf(File, "\r\n");
	}

	void Log::Print(std::exception ex)
	{
		if (Timestamp) {
			std::string datetime = Util::DateTime() + " ";
			fprintf(File, datetime.c_str());
		}

		fprintf(File, ex.what());
		fprintf(File, "\r\n");
	}
}
