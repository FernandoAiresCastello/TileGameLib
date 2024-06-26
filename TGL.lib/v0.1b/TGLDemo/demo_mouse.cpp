#include <TGL.h>

void demo_mouse()
{
	TGL_APP tgl;
	tgl.window_352x200(0xffffff, 4);

	while (tgl.window()) {

		tgl.clear();
		tgl.text_color(0x000000);
		tgl.text_shadow(true, 0xd0d0d0);
		tgl.print_tiled(tgl.fmt("X: %i", tgl.mouse_x()), 1, 1);
		tgl.print_tiled(tgl.fmt("Y: %i", tgl.mouse_y()), 1, 2);
		tgl.print_tiled(tgl.fmt("L: %i", tgl.mouse_left()), 1, 4);
		tgl.print_tiled(tgl.fmt("R: %i", tgl.mouse_right()), 1, 5);
		tgl.print_tiled(tgl.fmt("M: %i", tgl.mouse_middle()), 1, 6);

		if (tgl.kb_esc()) tgl.exit();

		tgl.update();
	}
}
