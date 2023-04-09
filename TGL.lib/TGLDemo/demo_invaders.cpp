#include <TGL.h>

static TGL_APP tgl;

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
	TGL_TIMER tmr_blast = TGL_TIMER(50, false);
};
vector<t_alien> aliens;

struct {
	TGL_TILE_RGB missile;
	TGL_TILE_RGB spaceship;
	TGL_TILE_RGB spaceship_2;
	TGL_TILE_RGB alien;
	TGL_TILE_RGB alien_2;
	TGL_TILE_RGB blast;
	TGL_TILE_RGB blast_2;
} tiles;

struct {
	TGL_VIEW scene;
	TGL_VIEW score;
} views;

struct {
	TGL_SOUND bgmusic;
	TGL_SOUND player_missile;
	TGL_SOUND enemy_dead;
} sounds;

TGL_TIMER tmr_alien_move(30, true);
TGL_TIMER tmr_animation(30, true);

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
	tgl.window_160x144(0xffffff, 5);

	init_tiles();
	init_aliens();
	init_sounds();

	//tgl.sound("bgmusic");

	views.scene = TGL_VIEW(0, 0, tgl.width(), 120, 0x000000);
	views.score = TGL_VIEW(0, 120, tgl.width(), 144, 0x0000a0);

	while (tgl.window()) {
		tgl.view_in(views.scene);
		aliens_cycle();
		player_cycle();
		draw_score();
		handle_input();
		tgl.update();
		tmr_animation.tick();
	}
}
void draw_score()
{
	tgl.view_in(views.score);
	string score = tgl.fmt("Score: %05i", player.score);
	tgl.text_color(0x000020);
	tgl.print_free(score, 33, 5);
	tgl.text_color(0xffffff);
	tgl.print_free(score, 32, 4);
}
void handle_input()
{
	if (tgl.kb_char('R')) tgl.gpad_redetect();
	if (tgl.kb_esc() || tgl.gpad_start()) tgl.exit();

	if (tgl.kb_right() || tgl.gpad_right() || tgl.gpad_r()) player.x++;
	if (tgl.kb_left() || tgl.gpad_left() || tgl.gpad_l()) player.x--;

	if (player.x < -TGL_TILESIZE) 
		player.x = tgl.width();
	else if (player.x >= tgl.width()) 
		player.x = -TGL_TILESIZE;

	if (tgl.kb_space() || tgl.gpad_a()) player_shoot();
}
void player_shoot()
{
	if (player.missile.active) return;

	tgl.sound_play(sounds.player_missile);

	player.missile.active = true;
	player.missile.x = player.x;
	player.missile.y = player.y;
}
void player_cycle()
{
	if (player.missile.active) {
		tgl.draw_free(tiles.missile, player.missile.x, player.missile.y);
	}
	if (tmr_animation.elapsed < tmr_animation.length / 2) {
		tgl.draw_free(tiles.spaceship, player.x, player.y);
	}
	else {
		tgl.draw_free(tiles.spaceship_2, player.x, player.y);
	}

	if (player.missile.active) {
		player.missile.y -= 2;
		if (player.missile.y < -TGL_TILESIZE) {
			player.missile.active = false;
		}
	}
}
void aliens_cycle()
{
	for (auto& alien : aliens) {
		if (alien.alive) {
			if (alien.y >= -TGL_TILESIZE) {
				if (tmr_animation.elapsed < tmr_animation.length / 2) {
					tgl.draw_free(tiles.alien, alien.x, alien.y);
				}
				else {
					tgl.draw_free(tiles.alien_2, alien.x, alien.y);
				}
				if (player.missile.active && tgl.collision(alien.x, alien.y, player.missile.x, player.missile.y)) {
					alien_destroy(alien);
				}
			}
		} else if (!alien.tmr_blast.done()) {
			alien.tmr_blast.tick();
			if (tmr_animation.elapsed < tmr_animation.length / 2) {
				tgl.draw_free(tiles.blast, alien.x, alien.y);
			}
			else {
				tgl.draw_free(tiles.blast_2, alien.x, alien.y);
			}
		}
		if (tmr_alien_move.done()) {
			alien.y += 4;
		}
	}
	tmr_alien_move.tick();
}
void alien_destroy(t_alien& alien)
{
	tgl.sound_play(sounds.enemy_dead);

	alien.alive = false;
	player.missile.active = false;
	player.score++;
}
void init_aliens()
{
	int number_of_aliens = tgl.rnd(150, 250);

	for (int i = 0; i < number_of_aliens; i++) {
		t_alien alien;
		alien.x = tgl.rnd(0, tgl.cols() - 1) * TGL_TILESIZE;
		alien.y = tgl.rnd(-200, 0) * TGL_TILESIZE;
		aliens.push_back(alien);
	}
}
void init_sounds()
{
	sounds.bgmusic = tgl.sound_load("Sound/bgmusic.wav");
	sounds.player_missile = tgl.sound_load("Sound/player_missile.wav");
	sounds.enemy_dead = tgl.sound_load("Sound/enemy_dead.wav");
}
void init_tiles()
{
	tiles.spaceship = tgl.tile_load_rgb("Tiles/spaceship_1.bmp", 0xffffff);
	tiles.spaceship_2 = tgl.tile_load_rgb("Tiles/spaceship_2.bmp", 0xffffff);
	tiles.missile = tgl.tile_load_rgb("Tiles/player_missile.bmp", 0xffffff);
	tiles.alien = tgl.tile_load_rgb("Tiles/alien_1.bmp", 0xffffff);
	tiles.alien_2 = tgl.tile_load_rgb("Tiles/alien_2.bmp", 0xffffff);
	tiles.blast = tgl.tile_load_rgb("Tiles/blast_1.bmp", 0xffffff);
	tiles.blast_2 = tgl.tile_load_rgb("Tiles/blast_2.bmp", 0xffffff);
}
