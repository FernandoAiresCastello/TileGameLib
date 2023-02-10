#include <TGL.h>

void test_basic()
{
	tgl.init();

	tgl.view_new("view_bg", 0x404040);

	while (tgl.system()) {

		tgl.view("view_bg");
		if (tgl.kb_esc()) tgl.exit();
	}
}
