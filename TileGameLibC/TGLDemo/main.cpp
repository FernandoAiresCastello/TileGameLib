#include <TGL.h>

int main(int argc, char* args[])
{
	tgl.init();
	tgl.screen(256, 192, 4, 4, 0xffffff);
	
	tile t_water;
	t_water.add(
		"00000000"
		"00100000"
		"01010000"
		"00000000"
		"00000000"
		"00000100"
		"00001010"
		"00000000",
		0x000080, 0x2080a0);
	t_water.add(
		"00000000"
		"00100000"
		"01010000"
		"00000000"
		"00000000"
		"00000100"
		"00001010"
		"00000000",
		0x2080a0, 0x000080);

	tile t_player;
	t_player.sprite();
	t_player.add(
		"00000000"
		"00011000"
		"00011000"
		"02222220"
		"00022000"
		"00300300"
		"03300330"
		"00000000",
		0x000000, 0xffffff, 0x00ff00, 0x0000ff);

	tilemap tm_ocean;
	tm_ocean.size(12, 10);
	tm_ocean.fill(&t_water);

	int tmx = -200;
	int tmy = 0;

draw_frame:

	tgl.clip(50, 30, 200, 150);
	tgl.bgcolor(0x0080ff);
	tgl.cls();

	tgl.drawtilemap(tm_ocean, tmx, tmy);
	tgl.drawtile(t_player, 10, 10);

	tgl.sysproc();
	tmx++;
	if (tmx > 200) {
		tmx = -200;
	}

	goto draw_frame;

	return tgl.halt();
}
