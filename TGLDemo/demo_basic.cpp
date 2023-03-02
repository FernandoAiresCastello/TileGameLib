#include <TGL.h>

void demo_basic()
{
	TGL tgl;
	tgl.window_gbc();

	while (tgl.running()) {
		tgl.system();

		tgl.color_single(0x000000);
		tgl.font_shadow(true, 0xc0c0c0);
		tgl.print_tiled("Hello World!", 1, 1);

		if (tgl.kb_esc()) tgl.exit();
	}
}
