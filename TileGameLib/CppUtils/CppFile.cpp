/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <Windows.h>
#include <iostream>
#include <fstream>
#include <algorithm>
#include "CppFile.h"
#include "CppString.h"
#include "CppUtil.h"
#include "CppMsgBox.h"

namespace CppUtils
{
	const std::string File::CurrentDirectory = "./";
	const std::string File::ParentDirectory = "../";

	File::File(std::string path, Mode mode)
	{
		if (mode == Mode::ReadBinary && !File::Exists(path)) {
			MsgBox::Error("File not found: " + path);
			return;
		}

		Fp = fopen(path.c_str(), mode == Mode::ReadBinary ? "rb" : "wb");

		if (mode == Mode::ReadBinary) {
			DataRead = File::ReadBytes(path);
			LengthRead = DataRead.size();
		}
	}

	File::~File()
	{
		if (Fp) {
			fflush(Fp);
			fclose(Fp);
		}
	}

	std::vector<std::string> File::List(std::string directory, std::string pattern, bool showFolders, bool showHidden)
	{
		if (pattern.empty())
			pattern = "*";

		std::vector<std::string> files;
		std::string path = directory + "\\" + pattern;
		WIN32_FIND_DATA data;
		HANDLE hFind = FindFirstFile(path.c_str(), &data);

		if (hFind != INVALID_HANDLE_VALUE) {
			do {
				if ((data.dwFileAttributes & FILE_ATTRIBUTE_HIDDEN) && !showHidden)
					continue;
				
				std::string file = data.cFileName;
				if (file == "." || file == "..")
					continue;

				if (data.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) {

					if (showFolders) {
						files.push_back(file + "/");
					}
				}
				else {
					files.push_back(file);
				}
			} 
			while (FindNextFile(hFind, &data));

			FindClose(hFind);
		}

		std::sort(files.begin(), files.end());

		return files;
	}

	std::vector<std::string> File::ListFolders(std::string directory, bool showHidden)
	{
		std::vector<std::string> folders;

		for (auto& entry : List(directory, "*", true, showHidden)) {
			if (IsDirectory(entry)) {
				folders.push_back(entry);
			}
		}

		return folders;
	}

	bool File::IsDirectory(std::string file)
	{
		return String::EndsWith(file, "/");
	}

	bool File::IsCurrentDirectory(std::string file)
	{
		return file == "./";
	}

	bool File::IsParentDirectory(std::string file)
	{
		return file == "../";
	}

	bool File::IsRoot(std::string directory)
	{
		std::vector<std::string> files = File::List(directory, "*", true, true);
		for (unsigned i = 0; i < files.size(); i++) {
			if (files[i] == "../")
				return false;
		}
		return true;
	}

	std::string File::GetRoot()
	{
		return "C:/";
	}

	bool File::Exists(std::string path)
	{
		struct stat buffer;
		return (stat(path.c_str(), &buffer) == 0);
	}

	bool File::ExistsFolder(std::string path)
	{
		struct stat buffer;
		stat(path.c_str(), &buffer);
		return (buffer.st_mode & S_IFDIR);
	}

	void File::Create(std::string path)
	{
		unsigned pos = 0;
		do {
			pos = path.find_first_of("\\/", pos + 1);
			if (pos == std::string::npos)
				break;

			CreateDirectory(path.substr(0, pos).c_str(), NULL);
		} while (pos != std::string::npos);

		std::fstream fs;
		fs.open(path, std::ios::out);
		fs.close();
	}

	void File::CreateFolder(std::string path)
	{ 
		CreateDirectory(path.c_str(), NULL);
	}

	void File::Delete(std::string path)
	{
		if (File::Exists(path))
			DeleteFile(path.c_str());
	}

	std::string File::ReadText(std::string filename)
	{
		auto chars = ReadChars(filename);
		return std::string(chars.begin(), chars.end());
	}

	std::vector<std::string> File::ReadLines(std::string filename, std::string lineDelimiter)
	{
		auto text = ReadText(filename);
		return String::Split(text, lineDelimiter, true);
	}

	std::vector<byte> File::ReadBytes(std::string filename)
	{
		auto chars = ReadChars(filename);
		std::vector<byte> bytes;
		for (auto& ch : chars)
			bytes.push_back((byte)ch);

		return bytes;
	}

	std::vector<char> File::ReadChars(std::string filename)
	{
		if (!File::Exists(filename)) {
			MsgBox::Error("File not found: " + filename);
			return std::vector<char>{};
		}

		std::ifstream ifs(filename, std::ios::binary | std::ios::ate);
		std::ifstream::pos_type pos = ifs.tellg();

		if (pos == 0)
			return std::vector<char>{};

		std::vector<char> result(pos);

		ifs.seekg(0, std::ios::beg);
		ifs.read(&result[0], pos);

		return result;
	}

	void File::WriteText(std::string filename, std::string text)
	{
		if (!File::Exists(filename))
			File::Create(filename);

		std::ofstream ofs(filename);

		if (ofs.good())
			ofs.write(text.c_str(), text.length());

		ofs.flush();
		ofs.close();
	}

	void File::WriteLines(std::string filename, std::vector<std::string> lines, std::string lineDelimiter)
	{
		std::ofstream ofs(filename);

		if (ofs.good()) {
			for (int i = 0; i < lines.size(); i++) {
				std::string line = lines[i];
				if (i < lines.size() - 1) {
					line.append(lineDelimiter);
				}
				ofs.write(line.c_str(), line.length());
			}
		}

		ofs.flush();
		ofs.close();
	}

	void File::WriteBytes(std::string filename, std::vector<byte>& bytes)
	{
		File file(filename, Mode::WriteBinary);
		for (auto& byte : bytes)
			file.WriteByte(byte);
	}

	void File::Duplicate(std::string orig, std::string dupl)
	{
		CopyFile(orig.c_str(), dupl.c_str(), true);
	}

	std::string File::GetParentDirectory(std::string file)
	{
		size_t pathDelimiterIndex = String::FindLast(file, '/');
		if (pathDelimiterIndex == std::string::npos)
			pathDelimiterIndex = String::FindLast(file, '\\');
		if (pathDelimiterIndex != std::string::npos)
			return String::GetFirstChars(file, pathDelimiterIndex);
		
		return "";
	}

	std::string File::GetName(std::string fullPath)
	{
		std::string filename;
		int ix_last_slash = String::FindLast(fullPath, '\\');
		
		if (ix_last_slash > 0)
			filename = String::Skip(fullPath, ix_last_slash + 1);
		else
			filename = fullPath;

		return filename;
	}

	std::string File::GetCurrentExecutableFilePath()
	{
		return __argv[0];
	}

	std::string File::GetCurrentExecutableFileName(bool removeExtension)
	{
		std::string exe_file = File::GetName(File::GetCurrentExecutableFilePath());
		std::string exe_name;

		if (removeExtension)
			return File::RemoveExtension(exe_file);
		else
			return exe_file;
	}

	std::string File::RemoveExtension(std::string file)
	{
		size_t ixLastDot = file.find_last_of(".");
		if (ixLastDot != std::string::npos)
			return file.substr(0, ixLastDot);
		else
			return file;
	}

	std::string File::GetTempDirectory()
	{
		char path[MAX_PATH + 20];
		GetTempPath(sizeof(path), path);
		return std::string(path);
	}

	std::string File::GetTempFilePath()
	{
		auto tempDir = File::GetTempDirectory();
		auto tempFile = Util::RandomHex(8);
		return tempDir + tempFile;
	}

	void File::WriteString(std::string str)
	{
		fprintf(Fp, "%s", str.c_str());
		fputc(0, Fp);
	}

	void File::WriteByte(byte b)
	{
		fputc(b, Fp);
	}

	void File::WriteShort(ushort s)
	{
		byte bytes[2];
		Util::ShortToBytes(s, bytes);
		fwrite(bytes, sizeof(byte), 2, Fp);
	}

	void File::WriteInt(uint i)
	{
		byte bytes[4];
		Util::IntToBytes(i, bytes);
		fwrite(bytes, sizeof(byte), 4, Fp);
	}

	std::string File::ReadString()
	{
		std::string str = "";
		while (true) {
			if (ValidRead()) {
				char ch = DataRead[ReadPtr++];
				if (ch > 0)
					str += ch;
				else
					break;
			}
			else
				break;
		}
		return str;
	}

	byte File::ReadByte()
	{
		if (ValidRead()) {
			byte ch = DataRead[ReadPtr++];
			return ch;
		}
		return 0;
	}

	uint File::ReadInt()
	{
		byte bytes[4] = { 0 };

		if (ValidRead())
			bytes[0] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[1] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[2] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[3] = DataRead[ReadPtr++];

		return Util::BytesToInt(bytes);
	}

	ushort File::ReadShort()
	{
		byte bytes[2] = { 0 };

		if (ValidRead())
			bytes[0] = DataRead[ReadPtr++];
		if (ValidRead())
			bytes[1] = DataRead[ReadPtr++];

		return Util::BytesToShort(bytes);
	}

	bool File::ValidRead()
	{
		return ReadPtr < LengthRead;
	}
}
