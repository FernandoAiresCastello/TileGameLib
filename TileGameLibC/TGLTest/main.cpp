#include <TGL.h>

int main(int argc, char* args[]) 
{
	tgl.init();
	tgl.screen(32, 24, 2, 4, 4);
	tgl.title("Hello World!");

	tgl.pal.add("red", 0xff0000);
	tgl.pal.add("green", 0x00ff00);
	tgl.pal.add("blue", 0x0000ff);
	tgl.pal.add("yellow", 0xffff00);

	tgl.chr.add("square",
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"11111111"
	);
	tgl.chr.add("smiley",
		"00111100"
		"01000010"
		"10100101"
		"10000001"
		"10100101"
		"10011001"
		"01000010"
		"00111100"
	);

	int x = 0;
	int y = 0;
	int incr = 0;

	tgl.tile.newf("smiley", "yellow", "blue");
	tgl.tile.addf("square", "red", "green");

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
