#include <TGL.h>

int main(int argc, char* args[])
{
	tgl.init();
	tgl.screen(43, 24, 2, 4, 4);
	
	tile simple_tile;
	simple_tile.add(
		"00011000"
		"00111100"
		"01111110"
		"12222221"
		"12222221"
		"13333331"
		"13333331"
		"11111111",
		0x000000, 0xffffff, 0xff0000, 0x00ff00);

	tile animated_tile;
	animated_tile.tron();
	animated_tile.add(
		"11111111"
		"10022331"
		"10022331"
		"10022331"
		"10022331"
		"10022331"
		"10022331"
		"11111111",
		0x000000, 0xffffff, 0xff0000, 0x00ff00);
	animated_tile.add(
		"11111111"
		"10000001"
		"10000001"
		"12222221"
		"12222221"
		"13333331"
		"13333331"
		"11111111",
		0x000000, 0xff00ff, 0x00ffff, 0xffff00);

	int x = 0;
	int y = 0;
	int speed = 0;
	bool clip = true;

	tgl.bgcol(0x000080);
	tgl.vol(2);
	tgl.music("L100O4CEFD");

	view main_view(10, 10, 150, 150, 0x004000);
	view sub_view(10, 150, 150, 180, 0x800040);

loop:
	tgl.cls();

	tgl.view(main_view);
	tgl.cell(1, 1);
	tgl.draw(simple_tile);
	tgl.coord(x, y);
	tgl.draw(animated_tile);
	tgl.cell(2, 2);
	tgl.draw(simple_tile);

	tgl.view(sub_view);
	tgl.cell(0, 0);
	tgl.draw(simple_tile);
	tgl.cell(1, 1);
	tgl.draw(simple_tile);
	tgl.cell(2, 2);
	tgl.draw(simple_tile);

	tgl.sysproc();

	if (tgl.kb.shift()) speed = 2;
	else if (tgl.kb.ctrl()) speed = 5;
	else if (tgl.kb.alt()) speed = 10;
	else speed = 1;

	if (tgl.kb.last_kname("SPACE")) {
		tgl.kb.clear_last();
		tgl.sfx("L20O6EF");
	}

	if (tgl.kb.caps()) {
		if (tgl.kb.last_kname("RIGHT")) x += speed;
		if (tgl.kb.last_kname("LEFT")) x -= speed;
		if (tgl.kb.last_kname("UP")) y -= speed;
		if (tgl.kb.last_kname("DOWN")) y += speed;
		tgl.kb.clear_last();
	}
	else {
		if (tgl.kb.right()) x += speed;
		if (tgl.kb.left()) x -= speed;
		if (tgl.kb.up()) y -= speed;
		if (tgl.kb.down()) y += speed;
	}

	goto loop;

	return tgl.halt();
}
