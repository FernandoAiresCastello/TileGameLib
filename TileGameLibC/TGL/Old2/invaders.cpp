#include <TGL.h>

// Tiles
tile t_star;
tile t_ufo;
tile t_player;
tile t_missile;
tile t_square_white;
tile t_square_red;
// Tilemaps
tilemap tm_stars;
// Sprites
sprite s_player;
sprite s_player_missile;
spritelist sl_enemies;
// Vars
bool player_shooting = false;
// Functions
void init_tiles();
void init_background();
void scroll_background();
void init_player();
void init_enemies();
void render_frame();
void handle_input();
void handle_player_missile();

// Main
void run_invaders()
{
	tgl.init();
	tgl.title("Invaders");
	tgl.screen(256, 192, 4, 4, 0x000040);
	tgl.bgcolor(0x000000);
	tgl.mouse_hide();

	init_tiles();
	init_background();
	init_enemies();
	init_player();

	while (tgl.sysproc()) {

		render_frame();
		handle_input();
		handle_player_missile();
		scroll_background();
	}
}
void handle_player_missile()
{
	if (!player_shooting) return;

	s_player_missile.move(0, -1);
	if (s_player_missile.get_y() < -8) {
		player_shooting = false;
		s_player_missile.hide();
	}
	
	auto& enemy_collisions = s_player_missile.get_collisions(&sl_enemies);

	for (auto* enemy : enemy_collisions) {
		enemy->destroy();
		if (player_shooting) {
			player_shooting = false;
			s_player_missile.hide();
		}
	}
}
void handle_input()
{
	if (tgl.kb_esc()) tgl.exit();
	/*
	if (tgl.kb_right()) s_player.move(1, 0);
	if (tgl.kb_left()) s_player.move(-1, 0);
	if (tgl.kb_down()) s_player.move(0, 1);
	if (tgl.kb_up()) s_player.move(0, -1);
	*/
	int mx = tgl.mouse_x_clip();
	int my = tgl.mouse_y_clip();
	s_player.pos(mx, my);

	if ((tgl.kb_space() || tgl.mouse_left()) && !player_shooting) {
		player_shooting = true;
		s_player_missile.pos(s_player.get_x(), s_player.get_y());
		s_player_missile.show();
	}
}
void render_frame()
{
	tgl.unclip();
	tgl.print("Hello World!", 0, 0);

	tgl.clip(10, 10, 246, 182);
	tgl.cls();
	tgl.draw_tilemap(&tm_stars);
	tgl.draw_spritelist(&sl_enemies);
	tgl.draw_sprite(&s_player_missile);
	tgl.draw_sprite(&s_player);
}
void init_enemies()
{
	for (int i = 0; i < 30; i++) {
		sprite* s_ufo = sl_enemies.add_new();
		s_ufo->set_tile(&t_ufo);
		int x = tgl.rnd(1, 26) * tile::width;
		int y = tgl.rnd(1, 15) * tile::height;
		s_ufo->pos(x, y);
	}
}
void init_player()
{
	s_player.set_tile(&t_player);
	s_player.pos(120, 160);

	s_player_missile.set_tile(&t_missile);
	s_player_missile.pos(0, 0);
	s_player_missile.hide();
}
void scroll_background()
{
	tm_stars.move(0, 1);
	if (tm_stars.get_y() > 190)
		tm_stars.set_y(-500);
}
void init_background()
{
	tm_stars.size(25, 50);
	tm_stars.pos(0, -500);
	for (int i = 0; i < 50; i++) {
		int x = tgl.rnd(0, 24);
		int y = tgl.rnd(0, 49);
		tm_stars.set(&t_star, x, y);
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

	t_square_white.add(
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"11111111",
		0x000000, 0xffffff, 0x000000, 0x000000);

	t_square_red.add(
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"11111111",
		0x000000, 0xff0000, 0x000000, 0x000000);
}
