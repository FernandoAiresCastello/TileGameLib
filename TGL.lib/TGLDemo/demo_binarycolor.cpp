#include <TGL.h>

void demo_binarycolor()
{
	TGL tgl;
	tgl.window_160x144(0xffffff, 5);

	tile_bin test_1(
		"11111111"
		"10000001"
		"10100101"
		"10000001"
		"10100101"
		"10011001"
		"10000001"
		"11111111"
	);

	while (tgl.window()) {
		tgl.draw_tiled(test_1, 0, 0, 0xff0000, 0x00ff00);
		tgl.draw_free(
			"11111111"
			"10000001"
			"11100111"
			"10000001"
			"10011001"
			"10100101"
			"10000001"
			"11111111", 4, 4, 0x0000ff);

		tgl.update();
		if (tgl.kb_esc()) {
			tgl.exit();
		}
	}
}
