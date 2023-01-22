#include <TGL.h>

int main(int argc, char* args[]) 
{
	tgl.init();
	tgl.screen(43, 24, 2, 4, 4);

	tgl.pal.add("red", 0xff0000);

	tgl.chr.add("empty", "0000000000000000000000000000000000000000000000000000000000000000");
	tgl.chr.add("square", "1111111110000001100000011000000110000001100000011000000111111111");

	tgl.locate(1, 1);
	tgl.fcolor("red");
	tgl.print("Hello world!");

	tgl.spr.create("test");
	tgl.spr.add_tile("test", "square", "white", "black");
	tgl.spr.add_tile("test", "empty", "white", "black");
	tgl.spr.tron("test");
	tgl.spr.show("test");

loop:
	tgl.vsync();
	tgl.global_proc();
	
	if (tgl.key.right()) tgl.spr.move("test", 1, 0);
	if (tgl.key.left()) tgl.spr.move("test", -1, 0);
	if (tgl.key.up()) tgl.spr.move("test", 0, -1);
	if (tgl.key.down()) tgl.spr.move("test", 0, 1);
	if (tgl.key.space()) tgl.spr.destroy("test");
	
	goto loop;

	return 0;
}
