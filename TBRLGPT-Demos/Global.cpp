#include "Global.h"

namespace Global
{
	Project* Proj = NULL;
	Palette* Pal = NULL;
	Charset* Chr = NULL;
	Graphics* Gr = NULL;
	UIContext* Ctx = NULL;

	void Init() {
		Proj = new Project();
		Pal = Proj->GetPalette();
		Chr = Proj->GetCharset();
		Gr = new Graphics(256, 192, 3 * 256, 3 * 192, false);
		Ctx = new UIContext(Gr, 0xffffff, 0x000000);
	}

	void Destroy() {
		delete Proj;
		delete Ctx;
		delete Gr;
	}
}
