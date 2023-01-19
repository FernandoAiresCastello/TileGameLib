#include <TGL.h>

int main(int argc, char* args[]) 
{
	tgl.init();
	tgl.screen(32, 24, 2, 4, 4);
	tgl.title("Hello World!");

	tgl.pal(0, 0x000000);
	tgl.pal(1, 0xffffff);
	tgl.pal(2, 0xff0000);
	tgl.pal(3, 0x00ff00);
	tgl.pal(4, 0x0000ff);

	tgl.chr(1,
		"11111111"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"10000001"
		"11111111"
	);

	tgl.wcol(1);

	tgl.cls();
	tgl.tron();
	
	tgl.tile_parse("1,2,3; 1,3,2");
	tgl.locate(1, 1);
	tgl.put();
	tgl.locate(1, 3);
	tgl.color(2, 3);
	tgl.troff();
	tgl.print("Hello World!");

	tgl.halt();

	return 0;
}
