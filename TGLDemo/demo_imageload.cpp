#include <TGL.h>

void demo_imageload()
{
	TGL tgl;
	tgl.window();

	tgl.tile_file("soldier_1", "Tiles/soldier.bmp");
	tgl.tile_add("soldier", "soldier_1");

	while (tgl.running()) {
		if (tgl.kb_esc()) tgl.exit();

		tgl.clear();
		tgl.color_sprite(0xffff80, 0xff00ff, 0x00ffff);
		tgl.draw_tiled("soldier", tgl.cols / 2 - 1, tgl.rows / 2 - 1);
		tgl.system();
	}
}
