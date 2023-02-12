#include <TGL.h>

struct {
	int x = 75;
	int y = 110;
	struct {
		int x = 0;
		int y = 0;
		bool active = false;
	} missile;
} player;

struct t_alien {
	int x = 0;
	int y = 0;
	bool alive = true;
};
vector<t_alien> aliens;

void init_tiles();
void init_aliens();

// MAIN
void test_invaders()
{
	tgl.init();
	tgl.window();
	tgl.mouse_off();

	init_tiles();
	init_aliens();

	tgl.timer_new("tm_alien_move", 3, true);

	tgl.view_new("vw_main", 0, 0, 160, 120, 0x000000, true);
	tgl.view_new("vw_sub", 0, 120, 160, 144, 0x202020, true);

	while (true) {

		tgl.system();

		// RENDER MAIN VIEW
		tgl.view("vw_main");

		for (auto& alien : aliens) {
			if (alien.alive && alien.y >= -tgl.tilesize()) {
				tgl.color(0x00ff00, 0x00c000, 0x007000);
				tgl.draw_free("t_alien", alien.x, alien.y);

				if (player.missile.active && tgl.collision(alien.x, alien.y, player.missile.x, player.missile.y)) {
					alien.alive = false;
					player.missile.active = false;
				}
			}
			if (tgl.timer("tm_alien_move")) {
				alien.y++;
			}
		}

		if (player.missile.active) {
			tgl.color(0x00ffff, 0x0080ff, 0x0000a0);
			tgl.draw_free("t_missile", player.missile.x, player.missile.y);
		}
		tgl.color(0xffffff, 0x80a0ff, 0xff8000);
		tgl.draw_free("t_spaceship", player.x, player.y);

		// RENDER SUB VIEW
		tgl.view("vw_sub");

		// INPUT
		if (tgl.kb_esc()) tgl.exit();
		if (tgl.kb_right()) player.x++;
		if (tgl.kb_left()) player.x--;
		if (tgl.kb_space() && !player.missile.active) {
			player.missile.active = true;
			player.missile.x = player.x;
			player.missile.y = player.y;
		}

		// PLAYER MISSILE CYCLE
		if (player.missile.active) {
			player.missile.y--;
			if (player.missile.y < -tgl.tilesize()) {
				player.missile.active = false;
			}
		}
	}
}
void init_aliens()
{
	for (int i = 0; i < 200; i++) {
		t_alien alien;
		alien.x = tgl.rnd(0, tgl.cols() - 1) * tgl.tilesize();
		alien.y = tgl.rnd(-200, 0) * tgl.tilesize();
		aliens.push_back(alien);
	}
}
void init_tiles()
{
	// SPACESHIP
	tgl.tile_pat("tp_spaceship_1f",
		"00011000"
		"00011000"
		"00211200"
		"01211210"
		"11211211"
		"10011001"
		"00333300"
		"00033000");
	tgl.tile_pat("tp_spaceship_2f",
		"00011000"
		"00011000"
		"00211200"
		"01211210"
		"11211211"
		"10011001"
		"00033000"
		"00000000");

	tgl.tile_add("t_spaceship", "tp_spaceship_1f");
	tgl.tile_add("t_spaceship", "tp_spaceship_2f");

	// MISSILE
	tgl.tile_pat("tp_missile_1f",
		"00011000"
		"00011000"
		"00011000"
		"00011000"
		"00022000"
		"00022000"
		"00033000"
		"00033000");

	tgl.tile_add("t_missile", "tp_missile_1f");

	// ALIEN
	tgl.tile_pat("tp_alien_1f",
		"00111000"
		"22222220"
		"13131310"
		"22222220"
		"00111000"
		"01000100"
		"00000000"
		"00000000");
	tgl.tile_pat("tp_alien_2f",
		"00111000"
		"22222220"
		"31313130"
		"22222220"
		"00111000"
		"00101000"
		"00000000"
		"00000000");

	tgl.tile_add("t_alien", "tp_alien_1f");
	tgl.tile_add("t_alien", "tp_alien_2f");
}
