#include <TGL.h>

void test_font()
{
	tgl.init();
	tgl.window(0x201080);

	tgl.view_new("background", 10, 10, 150, 134, 0x408040, true);

	while (true) {

		tgl.system();

		tgl.view("background");
		tgl.color(0xffffff, 0x000000, 0);
		tgl.print_tiled("abcdefgh", 0, 0);
		tgl.print_tiled("ABCDEFGH", 0, 1);
		tgl.print_tiled("0123456789", 0, 2);

		if (tgl.kb_esc()) tgl.exit();
		if (tgl.kb_right()) tgl.scroll(1, 0);
		if (tgl.kb_left()) tgl.scroll(-1, 0);
		if (tgl.kb_down()) tgl.scroll(0, 1);
		if (tgl.kb_up()) tgl.scroll(0, -1);
	}
}
