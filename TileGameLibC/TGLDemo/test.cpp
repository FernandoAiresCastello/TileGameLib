#include <TGL.h>

void run_test()
{
	tgl.init();
	tgl.title("TGL Demo");
	tgl.screen(256, 192, 4, 4, 0xf0e0a0);

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

	tilemap tm_ocean;
	tm_ocean.size(12, 10);
	tm_ocean.fill(&t_water);

	tile t_player;
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

	tile t_enemy;
	t_enemy.add(
		"00000000"
		"00011000"
		"00011000"
		"02222220"
		"00022000"
		"00300300"
		"03300330"
		"00000000",
		0x000000, 0x800000, 0xff0000, 0xa00000);

	int bg_x = 0;
	int bg_y = 0;
	int player_x = 100;
	int player_y = 50;
	int enemy_x = 100;
	int enemy_y = 100;

	while (tgl.sysproc()) {

		tgl.clip(50, 30, 200, 150);
		tgl.bgcolor(0x0080ff);
		tgl.cls();
		tgl.drawtilemap(tm_ocean, bg_x, bg_y);
		tgl.drawtile(t_player, player_x, player_y);
		tgl.drawtile(t_enemy, enemy_x, enemy_y);

		if (tgl.kb_esc()) tgl.exit();

		if (tgl.kb_shift()) {
			if (tgl.kb_right()) bg_x++;
			if (tgl.kb_left()) bg_x--;
			if (tgl.kb_down()) bg_y++;
			if (tgl.kb_up()) bg_y--;
		} else {
			if (tgl.kb_right()) player_x++;
			if (tgl.kb_left()) player_x--;
			if (tgl.kb_down()) player_y++;
			if (tgl.kb_up()) player_y--;
		}
	}
}
