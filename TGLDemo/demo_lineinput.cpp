#include <TGL.h>

void demo_lineinput()
{
	TGL tgl;
	tgl.window_gbc();

	tgl.color_single(0x0000ff);
	tgl.font_shadow(true, 0xe0e0e0);

	tgl.print_tiled("Type something:", 1, 1);
	tgl.input_color(0xffff00, 0xff0000);
	string text = tgl.input_tiled(15, 1, 3);

	tgl.clear();

	if (tgl.input_confirmed()) {
		tgl.color_single(0x0000ff);
		tgl.print_tiled("Thx! You typed:", 1, 1);
		tgl.color_single(0x000000);
		tgl.print_tiled(text, 1, 3);
	} else {
		tgl.color_single(0xff0000);
		tgl.print_tiled("You cancelled.", 1, 1);
	}
	
	tgl.halt();
}
