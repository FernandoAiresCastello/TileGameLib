#include <TGL.h>

void title(TGL& tgl, string str);
void print(TGL& tgl, string str, int x, int y);
void header(TGL& tgl, string str, int x, int y);

void demo_font()
{
	TGL tgl;
	tgl.title("TGL Font Demo");
	tgl.window_160x144(0x201080, 5);
	
	tgl.view_new("background", 10, 10, 150, 134, 0x408040, true);

	while (tgl.window()) {

		tgl.update();

		tgl.view("default");
		tgl.font_shadow(true, 0x000020);
		title(tgl, "Font Demo");

		tgl.view("background");
		tgl.font_shadow(true, 0x004000);

		header(tgl, "Digits", 0, 0);
		print(tgl, "0123456789", 0, 1);
		
		header(tgl, "Letters", 0, 2);
		print(tgl, "abcdefghijklm", 0, 3);
		print(tgl, "nopqrstuvwxyz", 0, 4);
		print(tgl, "ABCDEFGHIJKLM", 0, 5);
		print(tgl, "NOPQRSTUVWXYZ", 0, 6);

		header(tgl, "Symbols", 0, 7);
		print(tgl, "'\"@#$%&-_?!.,:;\\", 0, 8);
		print(tgl, "+=-/*|()[]<>{}^~", 0, 9);

		header(tgl, "Format", 0, 10);
		print(tgl, "\"Hello, World!~\"", 0, 11);
		print(tgl, "Apostrophe's`s", 0, 12);
		print(tgl, "(Parens)[Bracket]", 0, 13);
		print(tgl, "{Braces}<Lt_&_Gt>", 0, 14);

		if (tgl.kb_esc()) tgl.exit();
		if (tgl.kb_right()) tgl.scroll("background", 1, 0);
		if (tgl.kb_left()) tgl.scroll("background", -1, 0);
		if (tgl.kb_down()) tgl.scroll("background", 0, 1);
		if (tgl.kb_up()) tgl.scroll("background", 0, -1);
	}
}
void print(TGL& tgl, string str, int x, int y)
{
	x *= tgl.tilesize;
	y *= tgl.tilesize;

	tgl.font_color(0xffffff);
	tgl.print_free(str, x, y);
}
void header(TGL& tgl, string str, int x, int y)
{
	x *= tgl.tilesize;
	y *= tgl.tilesize;

	tgl.font_color(0xffff00, 0x0000ff);
	tgl.print_free(str, x, y);
}
void title(TGL& tgl, string str)
{
	tgl.font_color(0x00ffff);
	tgl.print_free(str, 43, 1);
}
