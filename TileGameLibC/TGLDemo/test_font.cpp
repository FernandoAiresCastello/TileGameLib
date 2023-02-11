#include <TGL.h>

void test_font()
{
	tgl.init();
	tgl.window(0x00ff00);

	tgl.font('a', "00112000"
				  "01201200"
				  "12000120"
				  "12000120"
				  "11111120"
				  "12000120"
				  "12000120"
				  "00000000");

	tgl.font('b', "11111200"
				  "12000120"
				  "12000120"
				  "11111200"
				  "12000120"
				  "12000120"
				  "11111200"
				  "00000000");

	tgl.font('c', "00111200"
				  "01200120"
				  "12000000"
				  "12000000"
				  "12000000"
				  "01200120"
				  "00111200"
				  "00000000");

	tgl.view_new("view_bg", 10, 10, 150, 134, 0xc0c0c0, true);

	while (tgl.system()) {

		tgl.view("view_bg");

		tgl.color(0xffffff, 0x000000, 0);
		tgl.print_free("abc", 0, 0);
		tgl.color(0xffff00, 0x404040, 0);
		tgl.print_tiled("cba", 1, 1);
		tgl.color(0xff0000, 0x00ffff, 0x000080, 0);
		tgl.print_free("bxb", 50, 50);

		if (tgl.kb_esc()) tgl.exit();
		if (tgl.kb_right()) tgl.scroll(1, 0);
		if (tgl.kb_left()) tgl.scroll(-1, 0);
		if (tgl.kb_down()) tgl.scroll(0, 1);
		if (tgl.kb_up()) tgl.scroll(0, -1);
	}
}
