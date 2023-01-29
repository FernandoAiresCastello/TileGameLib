#include <TGL.h>

// Tiles
tile t_star;
tile t_ufo;
tile t_player;
tile t_missile;
// Tilemaps
tilemap tm_stars;
// Sprites
sprite s_player;
sprite s_player_missile;
// Functions
void init_tiles();

int tm_stars_x = 0;
int tm_stars_y = -500;

// Main
void run_invaders()
{
	tgl.init();
	tgl.title("Invaders");
	tgl.screen(256, 192, 4, 4, 0x000040);
	tgl.clip(10, 10, 246, 182);
	tgl.bgcolor(0x000000);

	init_tiles();
	tm_stars.size(25, 50);
	for (int i = 0; i < 50; i++) {
		int x = tgl.rnd(0, 24);
		int y = tgl.rnd(0, 49);
		tm_stars.set(&t_star, x, y);
	}

	s_player.single(&t_player);
	s_player.pos(100, 100);
	s_player_missile.single(&t_missile);
	s_player_missile.pos(0, 0);
	s_player_missile.hide();

	bool shooting = false;
	
	while (tgl.sysproc()) {

		tgl.cls();
		tgl.drawtilemap(tm_stars, tm_stars_x, tm_stars_y);
		tgl.drawsprite(s_player_missile);
		tgl.drawsprite(s_player);

		if (tgl.kb_esc()) tgl.exit();
		if (tgl.kb_right()) s_player.x++;
		if (tgl.kb_left()) s_player.x--;
		if (tgl.kb_down()) s_player.y++;
		if (tgl.kb_up()) s_player.y--;

		if (tgl.kb_space() && !shooting) {
			shooting = true;
			s_player_missile.pos(s_player.x, s_player.y);
			s_player_missile.show();
		}
		if (shooting) {
			s_player_missile.y--;
			if (s_player_missile.y < -8) {
				shooting = false;
				s_player_missile.hide();
			}
		}

		tm_stars_y++;
		if (tm_stars_y > 190)
			tm_stars_y = -500;
	}
}
void init_tiles()
{
	t_ufo.add(
		"00000000"
		"01111100"
		"11111110"
		"10010010"
		"11111110"
		"00111000"
		"01000100"
		"00000000",
		0x000000, 0x00ff00);
	t_ufo.add(
		"01111100"
		"11111110"
		"10010010"
		"11111110"
		"00111000"
		"00101000"
		"00000000"
		"00000000",
		0x000000, 0x00ff00);

	t_star.add(
		"00000100"
		"00000000"
		"00000000"
		"00200000"
		"00000000"
		"00000000"
		"00000003"
		"00000000",
		0x000000, 0x00ffff, 0xffffff, 0xa0a0a0);
	t_star.add(
		"00000100"
		"00000000"
		"00000000"
		"00200000"
		"00000000"
		"00000000"
		"00000003"
		"00000000",
		0x000000, 0xa0a0a0, 0x00ffff, 0xffffff);

	t_player.add(
		"00011000"
		"00011000"
		"00211200"
		"01211210"
		"21211212"
		"20011002"
		"00033000"
		"00000000",
		0x000000, 0xe0e0e0, 0x00a0ff, 0xff0000);
	t_player.add(
		"00011000"
		"00011000"
		"00211200"
		"01211210"
		"21211212"
		"20011002"
		"00333300"
		"00033000",
		0x000000, 0xe0e0e0, 0x00a0ff, 0xff8000);

	t_missile.add(
		"00011000"
		"00011000"
		"00011000"
		"00011000"
		"00022000"
		"00022000"
		"00033000"
		"00033000",
		0x000000, 0x00ffff, 0x0080ff, 0x0000a0);
}
