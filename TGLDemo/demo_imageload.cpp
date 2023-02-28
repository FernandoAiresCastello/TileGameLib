#include <TGL.h>

void demo_imageload()
{
	TGL tgl;
	tgl.window();

	tgl.tile_file("tile_1", "Images/tile_1.bmp");
	tgl.tile_file("tile_2", "Images/tile_2.bmp");

	tgl.tile_add("tile", "tile_1");
	tgl.tile_add("tile", "tile_2");

	while (tgl.running()) {
		if (tgl.kb_esc()) tgl.exit();

		tgl.clear();
		tgl.color_normal(0xff0000, 0x00ff00, 0x0000ff, 0xffff00);
		tgl.draw_tiled("tile", tgl.cols / 2 - 1, tgl.rows / 2 - 1);
		tgl.color_normal(0xff00ff, 0x00ffff, 0xffc000, 0x808080);
		tgl.draw_tiled("tile", tgl.cols / 2, tgl.rows / 2);
		tgl.system();
	}
}
