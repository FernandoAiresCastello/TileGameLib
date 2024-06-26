#include <TGL.h>

void demo_views()
{
	TGL_APP tgl;
	tgl.window_160x144(0x000000, 5);

	TGL_TILE_RGB square_1 = tgl.tile_load_rgb("Tiles/test_1.bmp");
	TGL_TILE_RGB square_2 = tgl.tile_load_rgb("Tiles/test_2.bmp");

	int x = 0;
	int y = 0;

	TGL_VIEW view_bg(0, 0, tgl.width(), tgl.height(), 0x800000);
	TGL_VIEW view_1(1, 10, 159, 30, 0x404040);
	TGL_VIEW view_2(1, 40, 159, 134, 0x404040);
	TGL_VIEW view_3(50, 20, 100, 100, 0x808080);

	while (tgl.window()) {

		tgl.update();

		tgl.view(view_bg);

		tgl.view(view_1);
		tgl.draw_free(square_1, 0, 0);

		tgl.view(view_2);
		tgl.draw_tiled(square_1, 1, 1);

		tgl.view(view_3);
		tgl.draw_tiled(square_1, 1, 1);
		tgl.draw_tiled(square_1, 2, 2);
		tgl.draw_tiled(square_1, 4, 4);

		tgl.draw_free(square_2, x, y);

		if (tgl.kb_esc()) tgl.exit();

		if (tgl.kb_ctrl()) {
			if (tgl.kb_right()) view_3.scroll(1, 0);
			if (tgl.kb_left()) view_3.scroll(-1, 0);
			if (tgl.kb_down()) view_3.scroll(0, 1);
			if (tgl.kb_up()) view_3.scroll(0, -1);
		} else {
			if (tgl.kb_right()) x++;
			if (tgl.kb_left()) x--;
			if (tgl.kb_down()) y++;
			if (tgl.kb_up()) y--;
		}
	}
}
