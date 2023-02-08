#include <TGL.h>

int main(int argc, char* args[])
{
	tgl.init();
	tgl.window();

	tgl.pattern("tp_square_1f",
		"11111111"
		"10000001"
		"10222201"
		"10233201"
		"10233201"
		"10222201"
		"10000001"
		"11111111");
	tgl.pattern("tp_square_2f",
		"33333333"
		"30000003"
		"30111103"
		"30122103"
		"30122103"
		"30111103"
		"30000003"
		"33333333");

	tgl.tile("t_square", "tp_square_1f", "tp_square_2f");

	int x = 0;
	int y = 0;
	int scroll_x = 0;
	int scroll_y = 0;

	while (tgl.sysproc()) {

		tgl.clip(10, 10, 150, 30);
		tgl.bgcolor(0x404040);
		tgl.clear();
		tgl.pos_free(0, 0);
		tgl.color(0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw("t_square");

		tgl.clip(10, 40, 150, 134);
		tgl.bgcolor(0x404040);
		tgl.clear();
		tgl.pos_tiled(1, 1);
		tgl.color(0x000000, 0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw("t_square");

		tgl.clip(50, 20, 100, 100);
		tgl.bgcolor(0x808080);
		tgl.clear();
		tgl.pos_free(x, y);
		tgl.scroll(scroll_x, scroll_y);
		tgl.color(0xff0000, 0x00ff00, 0x0000ff);
		tgl.draw("t_square");

		tgl.pos_tiled(1, 1);
		tgl.draw("t_square");
		tgl.pos_tiled(2, 2);
		tgl.draw("t_square");
		tgl.pos_tiled(4, 4);
		tgl.draw("t_square");

		if (tgl.kb_ctrl()) {
			if (tgl.kb_right()) scroll_x++;
			if (tgl.kb_left()) scroll_x--;
			if (tgl.kb_down()) scroll_y++;
			if (tgl.kb_up()) scroll_y--;
		} else {
			if (tgl.kb_right()) x++;
			if (tgl.kb_left()) x--;
			if (tgl.kb_down()) y++;
			if (tgl.kb_up()) y--;
		}
	}

	return tgl.halt();
}
