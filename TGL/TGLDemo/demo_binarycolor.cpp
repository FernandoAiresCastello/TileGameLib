#include <TGL.h>

void demo_binarycolor()
{
	TGL tgl;
	tgl.window_gbc(0xffffff, 5);

	tgl.tile_add("test", 
		"11111111"
		"10000001"
		"10100101"
		"10000001"
		"10100101"
		"10011001"
		"10000001"
		"11111111"
	);
	tgl.tile_add("test",
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10011001"
		"10100101"
		"10000001"
		"11111111"
	);

	while (tgl.running()) {
		tgl.color_binary(0xff0000, 0x00ff00);
		tgl.draw_tiled("test", 0, 0);
		tgl.color_binary(0x0000ff, 0xff00ff);
		tgl.draw_tiled("test", 1, 1);
		if (tgl.kb_esc()) tgl.exit();
		tgl.update();
	}
}
