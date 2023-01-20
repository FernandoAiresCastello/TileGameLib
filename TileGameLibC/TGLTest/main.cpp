#include <TGL.h>

int main(int argc, char* args[]) 
{
	tgl.init();
	tgl.screen(32, 24, 2, 4, 4);
	tgl.title("Hello World!");

	tgl.pal.set(0, 0x000000);
	tgl.pal.set(1, 0xffffff);
	tgl.pal.set(2, 0xff0000);
	tgl.pal.set(3, 0x00ff00);
	tgl.pal.set(4, 0x0000ff);

	tgl.chr.set(1,
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"11111111"
	);

	int x = 0;
	int y = 0;
	int incr = 0;

	tgl.wcol(4);
	tgl.tile.newf(1, 1, 4);

loop:
	tgl.fill();
	tgl.locate(1, 1);
	tgl.println("X: %i", x);
	tgl.println("Y: %i", y);
	tgl.vsync();
	tgl.global_proc();

	incr = tgl.key.shift() ? 10 : 1;

	if (tgl.key.right()) x += incr;
	if (tgl.key.left()) x -= incr;
	if (tgl.key.down()) y += incr;
	if (tgl.key.up()) y -= incr;

	if (tgl.key.space()) tgl.play("l64cde");

	goto loop;

	tgl.halt();
	return 0;
}
