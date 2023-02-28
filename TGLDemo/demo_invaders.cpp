#include <TGL.h>

static TGL tgl;

struct {
	int x = 75;
	int y = 110;
	struct {
		int x = 0;
		int y = 0;
		bool active = false;
	} missile;
	int score = 0;
} player;

struct t_alien {
	int x = 0;
	int y = 0;
	bool alive = true;
	int blast_counter = 20;
};
vector<t_alien> aliens;

void init_tiles();
void init_aliens();
void init_sounds();
void aliens_cycle();
void alien_destroy(t_alien& alien);
void player_cycle();
void player_shoot();
void handle_input();
void draw_score();

void demo_invaders()
{
	tgl.title("TGL Invaders");
	tgl.window();

	init_tiles();
	init_aliens();
	init_sounds();

	tgl.sound("bgmusic");

	tgl.timer_new("alien_move", 30, true);

	tgl.view_new("main", 0, 0, tgl.width, 120, 0x000000, true);
	tgl.view_new("sub", 0, 120, tgl.width, 144, 0x0000a0, true);

	while (tgl.running()) {

		tgl.system();

		tgl.view("main");
		aliens_cycle();
		player_cycle();
		draw_score();
		handle_input();
	}
}
void draw_score()
{
	tgl.view("sub");
	string score = tgl.fmt("Score: %05i", player.score);
	tgl.color_single(0x000020);
	tgl.print_free(score, 33, 5);
	tgl.color_single(0xffffff);
	tgl.print_free(score, 32, 4);
}
void handle_input()
{
	if (tgl.kb_char('R')) tgl.gpad_redetect();

	if (tgl.kb_esc() || tgl.gpad_start()) tgl.exit();

	if (tgl.kb_right() || tgl.gpad_right() || tgl.gpad_r()) player.x++;
	if (tgl.kb_left() || tgl.gpad_left() || tgl.gpad_l()) player.x--;

	if (player.x < -tgl.tilesize) 
		player.x = tgl.width;
	else if (player.x >= tgl.width) 
		player.x = -tgl.tilesize;

	if (tgl.kb_space() || tgl.gpad_a()) player_shoot();
}
void player_shoot()
{
	if (player.missile.active) return;

	//tgl.play_notes("l30cd");
	tgl.sound("player_missile");

	player.missile.active = true;
	player.missile.x = player.x;
	player.missile.y = player.y;
}
void player_cycle()
{
	if (player.missile.active) {
		tgl.color_sprite(0x00ffff, 0x0080ff, 0x0000a0);
		tgl.draw_free("missile", player.missile.x, player.missile.y);
	}
	tgl.color_sprite(0xffffff, 0x80a0ff, 0xff8000);
	tgl.draw_free("spaceship", player.x, player.y);

	if (player.missile.active) {
		player.missile.y -= 2;
		if (player.missile.y < -tgl.tilesize) {
			player.missile.active = false;
		}
	}
}
void aliens_cycle()
{
	for (auto& alien : aliens) {
		if (alien.alive) {
			if (alien.y >= -tgl.tilesize) {
				tgl.color_sprite(0x00ff00, 0x00c000, 0x007000);
				tgl.draw_free("alien", alien.x, alien.y);
				if (player.missile.active && tgl.collision(alien.x, alien.y, player.missile.x, player.missile.y)) {
					alien_destroy(alien);
				}
			}
		} else if (alien.blast_counter > 0) {
			alien.blast_counter--;
			tgl.color_sprite(0xff0000, 0xff8000, 0xffff00);
			tgl.draw_free("blast", alien.x, alien.y);
		}
		if (tgl.timer("alien_move")) {
			alien.y += 4;
		}
	}
}
void alien_destroy(t_alien& alien)
{
	//tgl.play_notes("l30ba");
	tgl.sound("enemy_dead");

	alien.alive = false;
	player.missile.active = false;
	player.score++;
}
void init_aliens()
{
	int number_of_aliens = tgl.rnd(150, 250);

	for (int i = 0; i < number_of_aliens; i++) {
		t_alien alien;
		alien.x = tgl.rnd(0, tgl.cols - 1) * tgl.tilesize;
		alien.y = tgl.rnd(-200, 0) * tgl.tilesize;
		aliens.push_back(alien);
	}
}
void init_sounds()
{
	// MUSIC
	tgl.sound_file("bgmusic", "Sound/bgmusic.wav");

	// SFX
	tgl.sound_file("player_missile", "Sound/player_missile.wav");
	tgl.sound_file("enemy_dead", "Sound/enemy_dead.wav");
}
void init_tiles()
{
	// SPACESHIP
	tgl.tile_pat("tp_spaceship_1f", "0001100000011000002112000121121011211211100110010033330000033000");
	tgl.tile_pat("tp_spaceship_2f", "0001100000011000002112000121121011211211100110010003300000000000");
	tgl.tile_add("spaceship", "tp_spaceship_1f");
	tgl.tile_add("spaceship", "tp_spaceship_2f");
	
	// MISSILE
	tgl.tile_pat("tp_missile_1f", "0001100000011000000110000001100000022000000220000003300000033000");
	tgl.tile_add("missile", "tp_missile_1f");

	// ALIEN
	tgl.tile_pat("tp_alien_1f", "0011100022222220131313102222222000111000010001000000000000000000");
	tgl.tile_pat("tp_alien_2f", "0011100022222220313131302222222000111000001010000000000000000000");
	tgl.tile_add("alien", "tp_alien_1f");
	tgl.tile_add("alien", "tp_alien_2f");

	// BLAST
	tgl.tile_pat("tp_blast_1f", "0300003033300333032222300021120000211200032222303330033303000030");
	tgl.tile_pat("tp_blast_2f", "0200002022200222021001200000000000000000021001202220022202000020");
	tgl.tile_add("blast", "tp_blast_1f");
	tgl.tile_add("blast", "tp_blast_2f");
}
