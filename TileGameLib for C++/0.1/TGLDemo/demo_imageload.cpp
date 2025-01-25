#include <TGL.h>

void demo_imageload()
{
	TGL_APP tgl;
	tgl.window_160x144(0xffffff, 5);

	TGL_TILE_RGB smiley = tgl.tile_load_rgb("Tiles/smiley.bmp");

	while (tgl.window()) {
		tgl.clear();
		tgl.draw_tiled(smiley, tgl.cols() / 2 - 1, tgl.rows() / 2 - 1);
		tgl.draw_tiled(smiley, tgl.cols() / 2, tgl.rows() / 2 - 1);
		tgl.draw_tiled(smiley, tgl.cols() / 2 - 1, tgl.rows() / 2);
		tgl.draw_tiled(smiley, tgl.cols() / 2, tgl.rows() / 2);

		tgl.update();
		if (tgl.kb_esc()) {
			tgl.exit();
		}
	}
}
