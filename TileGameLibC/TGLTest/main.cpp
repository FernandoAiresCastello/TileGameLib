#include <TGL.h>

int main(int argc, char* args[])
{
	tgl.init();
	tgl.screen(43, 24, 2, 4, 4);

	tgl.pal.add("red", 0xff0000);
	tgl.pal.add("blue", 0x0000ff);

	tgl.chr.add("empty", "0000000000000000000000000000000000000000000000000000000000000000");
	tgl.chr.add("square", "1111111110000001100000011000000110000001100000011000000111111111");

	tgl.spr.create("test");
	tgl.spr.select("test");
	tgl.spr.add_tile("square", "red", "black");
	tgl.spr.add_tile("square", "blue", "black");
	tgl.spr.tron();
	tgl.spr.set_pos(100, 100);
	tgl.spr.show();

	int speed = 1;

loop:
	tgl.cls();
	tgl.locate(1, 1);
	tgl.println("X: %i", tgl.spr.x());
	tgl.println("Y: %i", tgl.spr.y());

	tgl.default_proc();

	if (tgl.key.space()) speed = 3; else speed = 1;

	if (tgl.key.right()) tgl.spr.move(speed, 0);
	if (tgl.key.left()) tgl.spr.move(-speed, 0);
	if (tgl.key.up()) tgl.spr.move(0, -speed);
	if (tgl.key.down()) tgl.spr.move(0, speed);

	goto loop;

	return 0;
}
