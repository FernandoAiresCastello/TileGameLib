#include <TGL.h>

void demo_views()
{
	TGL tgl;
	tgl.window_gbc(0x000000, 5);

	tgl.tile_file("tp_square_1f", "Tiles/test_1.bmp");
	tgl.tile_file("tp_square_1f", "Tiles/test_2.bmp");
	tgl.tile_add("t_square", "tp_square_1f");
	tgl.tile_add("t_square", "tp_square_2f");

	int x = 0;
	int y = 0;

	tgl.view_new("view_bg", 0, 0, tgl.width(), tgl.height(), 0x800000, true);
	tgl.view_new("view_1", 1, 10, 159, 30, 0x404040, true);
	tgl.view_new("view_2", 1, 40, 159, 134, 0x404040, true);
	tgl.view_new("view_3", 50, 20, 100, 100, 0x808080, true);

	while (tgl.running()) {

		tgl.system();

		tgl.view("view_bg");

		tgl.view("view_1");
		tgl.color_sprite(0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_free("t_square", 0, 0);

		tgl.view("view_2");
		tgl.color_normal(0x000000, 0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_tiled("t_square", 1, 1);

		tgl.view("view_3");
		tgl.color_normal(0x000000, 0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_tiled("t_square", 1, 1);
		tgl.draw_tiled("t_square", 2, 2);
		tgl.draw_tiled("t_square", 4, 4);

		tgl.color_sprite(0xffff00, 0xff00ff, 0x00ffff);
		tgl.draw_free("t_square", x, y);

		if (tgl.kb_esc()) tgl.exit();

		if (tgl.kb_ctrl()) {
			if (tgl.kb_right()) tgl.scroll(1, 0);
			if (tgl.kb_left()) tgl.scroll(-1, 0);
			if (tgl.kb_down()) tgl.scroll(0, 1);
			if (tgl.kb_up()) tgl.scroll(0, -1);
		} else {
			if (tgl.kb_right()) x++;
			if (tgl.kb_left()) x--;
			if (tgl.kb_down()) y++;
			if (tgl.kb_up()) y--;
		}
	}
}
