/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "FileSelector.h"
#include "UIContext.h"
#include "Graphics.h"
#include "ScrollingMenu.h"
#include "MenuItem.h"
#include "SimpleDialog.h"
#include "File.h"
#include "ConfirmDialog.h"
#include "StringUtils.h"
#include "Keyboard.h"

namespace TBRLGPT
{
	FileSelector::FileSelector(UIContext* ctx) : Ctx(ctx)
	{
	}

	FileSelector::~FileSelector()
	{
	}

	std::string FileSelector::Select(std::string title, std::string initialPath, std::string extension)
	{
		Title = title;
		Path.SetPath(initialPath);
		std::string file = "";

		while (true) {
			Ctx->Clear();
			PrintInfo();
			file = ShowFileMenu(extension);
			if (file.empty())
				break;

			if (KeyPressed == SDLK_n) {
				CreateNewFile();
			}
			else if (KeyPressed == SDLK_d) {
				if (!File::IsDirectory(file))
					DuplicateFile(Path.GetFullPath(file));
			}
			else if (KeyPressed == SDLK_DELETE) {
				if (!File::IsDirectory(file))
					DeleteFile(Path.GetFullPath(file));
			}
			else if (KeyPressed == SDLK_LEFT || KeyPressed == SDLK_BACKSPACE) {
				Path.ExitDirectory();
			}
			else if (KeyPressed == SDLK_RETURN || KeyPressed == SDLK_RIGHT) {
				if (File::IsDirectory(file))
					Path.EnterDirectory(file);
				else
					return Path.GetFullPath(file);
			}
			if (File::IsRoot(Path.GetPath()))
				Path.SetPath(File::GetRoot());
		}

		return file;
	}

	std::string FileSelector::ShowFileMenu(std::string extension)
	{
		std::vector<std::string> files = File::List(Path.GetPath(), extension, true);

		ScrollingMenu menu(Ctx, 0, 1, Ctx->Gr->Cols - 3, Ctx->Gr->Rows - 7, true, false);
		for (unsigned i = 0; i < files.size(); i++)
			menu.AddItem(files[i]);

		KeyPressed = 0;
		MenuItem* item = menu.Show();
		KeyPressed = menu.GetKeyPressed();
		if (item != NULL)
			return item->GetText();

		return "";
	}

	void FileSelector::PrintInfo()
	{
		Ctx->Print(1, 0, Title);
		int y = Ctx->Gr->Rows - 4;
		Ctx->Print(1, y, String::Last(Path.GetPath(), Ctx->Gr->Cols - 2));

		Ctx->InvertColors();
		Ctx->Print( 1, y + 1, " ENTER ");
		Ctx->Print( 1, y + 2, "  DEL  ");
		Ctx->Print(16, y + 1, "   N   ");
		Ctx->Print(16, y + 2, "  ESC  ");
		Ctx->Print(31, y + 1, "   D   ");
		Ctx->InvertColors();
		Ctx->Print( 9, y + 1, "Select");
		Ctx->Print( 9, y + 2, "Delete");
		Ctx->Print(24, y + 1, "Create");
		Ctx->Print(24, y + 2, "Cancel");
		Ctx->Print(39, y + 1, "Dup.");
	}

	void FileSelector::CreateNewFile()
	{
		SimpleDialog dialog(Ctx);
		std::string file = dialog.ReadString("New file:");
		if (!file.empty()) {
			std::string filePath = Path.GetFullPath(file);
			bool overwrite = true;
			if (File::Exists(filePath)) {
				ConfirmDialog conf(Ctx);
				overwrite = conf.Confirm("Overwrite");
			}
			if (overwrite)
				File::Create(filePath);
		}
	}
	
	void FileSelector::DeleteFile(std::string file)
	{
		ConfirmDialog conf(Ctx);
		if (conf.Confirm("Delete")) {
			File::Delete(file);
		}
	}

	void FileSelector::DuplicateFile(std::string file)
	{
		SimpleDialog dialog(Ctx);
		std::string dupFile = dialog.ReadString("Duplicate file as:");
		if (!dupFile.empty()) {
			std::string filePath = Path.GetFullPath(dupFile);
			if (File::Exists(filePath)) {
				SimpleDialog alert(Ctx);
				alert.ShowMessage("Filename already in use");
			}
			else {
				File::Duplicate(file, filePath);
			}
		}
	}
}
