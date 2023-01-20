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

	int counter = 12345;

	tgl.wcol(4);
	tgl.locate(1, 1);
	tgl.color(0, 1);
	tgl.println("Hello {f2}red{/f} world!");
	tgl.println("And hello {b3}green{/b} world!");
	tgl.println("This is the counter: %i", counter);
	tgl.println("This is a square : {c1}");

	tgl.locate(3, 10);
	tgl.color(2, 3);
	tgl.print("Text");
	tgl.locate(3, 10);
	tgl.color(3, 2);
	tgl.print_add("Text");

	tgl.halt();

	return 0;
}
