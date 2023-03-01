#include <TGL.h>

void demo_imageload()
{
	TGL tgl;
	tgl.window();

	tgl.tile_file("smiley", "Tiles/smiley.bmp");
	tgl.tile_add("smiley", "smiley");

	while (tgl.running()) {
		if (tgl.kb_esc()) tgl.exit();

		tgl.clear();
		tgl.color_normal(0x00ffff, 0x000000, 0xff0000, 0xff00ff);
		tgl.draw_tiled("smiley", tgl.cols / 2 - 1, tgl.rows / 2 - 1);
		tgl.color_normal(0xff80ff, 0x004000, 0x00b000, 0x008000);
		tgl.draw_tiled("smiley", tgl.cols / 2, tgl.rows / 2 - 1);
		tgl.color_normal(0xffffff, 0x000000, 0xff8000, 0xffff00);
		tgl.draw_tiled("smiley", tgl.cols / 2 - 1, tgl.rows / 2);
		tgl.color_normal(0xffff00, 0x000000, 0x0000b0, 0x0000ff);
		tgl.draw_tiled("smiley", tgl.cols / 2, tgl.rows / 2);

		tgl.system();
	}
}
