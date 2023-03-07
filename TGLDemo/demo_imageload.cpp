#include <TGL.h>

void demo_imageload()
{
	TGL tgl;
	tgl.window_gbc(0xffffff, 5);

	tgl.tile_load("smiley", "Tiles/smiley.bmp");
	tgl.tile_add("smiley", "smiley");

	while (tgl.running()) {
		if (tgl.kb_esc()) tgl.exit();

		tgl.clear();
		tgl.draw_tiled("smiley", tgl.cols() / 2 - 1, tgl.rows() / 2 - 1);
		tgl.draw_tiled("smiley", tgl.cols() / 2, tgl.rows() / 2 - 1);
		tgl.draw_tiled("smiley", tgl.cols() / 2 - 1, tgl.rows() / 2);
		tgl.draw_tiled("smiley", tgl.cols() / 2, tgl.rows() / 2);

		tgl.system();
	}
}
