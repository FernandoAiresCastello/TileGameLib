/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#include "FilePath.h"
#include "File.h"
#include "StringUtils.h"

namespace TBRLGPT
{
	FilePath::FilePath()
	{
	}

	FilePath::~FilePath()
	{
	}

	bool FilePath::IsEmpty()
	{
		return Path.empty();
	}

	std::string FilePath::GetPath()
	{
		return GetFullPath("");
	}

	std::string FilePath::GetFullPath(std::string file)
	{
		std::string fullPath = "";
		for (unsigned i = 0; i < Path.size(); i++)
			fullPath += Path[i];
		if (!String::EndsWith(fullPath, "/"))
			fullPath += "/";
		if (!file.empty())
			fullPath += file;

		return fullPath;
	}

	std::string FilePath::GetCurrentDirectory()
	{
		return Path.back();
	}

	void FilePath::SetPath(std::string path)
	{
		Path.clear();

		if (path.empty()) {
			Path.push_back(File::CurrentDirectory);
		}
		else {
			std::vector<std::string> dirs = String::Split(path, '/');
			for (unsigned i = 0; i < dirs.size(); i++)
				Path.push_back(dirs[i] + "/");
		}
	}

	void FilePath::EnterDirectory(std::string dir)
	{
		if (!String::EndsWith(dir, "/"))
			dir += "/";
		
		if (File::IsCurrentDirectory(dir)) {
			return;
		}
		if (File::IsParentDirectory(dir)) {
			std::string currentDir = GetCurrentDirectory();
			if (File::IsCurrentDirectory(currentDir)) {
				Path.pop_back();
				Path.push_back(dir);
			}
			else if (File::IsParentDirectory(currentDir)) {
				Path.push_back(dir);
			}
			else {
				Path.pop_back();
				if (Path.empty()) {
					Path.push_back("../");
				}
			}
		}
		else {
			Path.push_back(dir);
		}
	}

	void FilePath::ExitDirectory()
	{
		std::string currentDir = GetCurrentDirectory();
		
		if (File::IsCurrentDirectory(currentDir)) {
			Path.pop_back();
			Path.push_back(File::ParentDirectory);
		}
		else if (File::IsParentDirectory(currentDir)) {
			Path.push_back(File::ParentDirectory);
		}
		else if (!Path.empty()) {
			Path.pop_back();
		}
	}
}
