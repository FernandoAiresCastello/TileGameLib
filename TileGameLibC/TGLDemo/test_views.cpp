#include <TGL.h>

void test_views()
{
	tgl.init();
	tgl.window(0x000000);

	tgl.tile_pat("tp_square_1f", "11111111"
								 "10000001"
								 "10222201"
								 "10233201"
								 "10233201"
								 "10222201"
								 "10000001"
								 "11111111");

	tgl.tile_pat("tp_square_2f", "33333333"
								 "30000003"
								 "30111103"
								 "30122103"
								 "30122103"
								 "30111103"
								 "30000003"
								 "33333333");

	tgl.tile_add("t_square", "tp_square_1f");
	tgl.tile_add("t_square", "tp_square_2f");

	int x = 0;
	int y = 0;

	tgl.view_new("view_bg", 0, 0, tgl.width(), tgl.height(), 0x800000, true);
	tgl.view_new("view_1", 1, 10, 159, 30, 0x404040, true);
	tgl.view_new("view_2", 1, 40, 159, 134, 0x404040, true);
	tgl.view_new("view_3", 50, 20, 100, 100, 0x808080, true);

	while (true) {

		tgl.system();

		tgl.view("view_bg");

		tgl.view("view_1");
		tgl.color(0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_free("t_square", 0, 0);

		tgl.view("view_2");
		tgl.color(0x000000, 0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_tiled("t_square", 1, 1);

		tgl.view("view_3");
		tgl.color(0x000000, 0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw_tiled("t_square", 1, 1);
		tgl.draw_tiled("t_square", 2, 2);
		tgl.draw_tiled("t_square", 4, 4);

		tgl.color(0xffff00, 0xff00ff, 0x00ffff);
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
