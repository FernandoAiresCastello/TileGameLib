#include <TGL.h>

void demo_lineinput()
{
	TGL_APP tgl;
	tgl.window_160x144(0xffffff, 5);

	tgl.text_color(0x0000ff);
	tgl.text_shadow(true, 0xe0e0e0);

	tgl.print_tiled("Type something:", 1, 1);
	tgl.input_color(0xffff00, 0xff0000);
	tgl.input_placeholder("Type here");
	std::string text = tgl.input_tiled(15, 1, 3);

	tgl.clear();

	if (tgl.input_ok()) {
		tgl.text_color(0x0000ff);
		tgl.print_tiled("Thx! You typed:", 1, 1);
		tgl.text_color(0x000000);
		tgl.print_tiled(text, 1, 3);
	} else {
		tgl.text_color(0xff0000);
		tgl.print_tiled("You cancelled.", 1, 1);
	}
	
	tgl.halt();
}
