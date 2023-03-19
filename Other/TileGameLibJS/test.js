document.onreadystatechange = () => { if (document.readyState == "complete") main() }

let tgl;

const tile = [
	[
		'#f00','#f00','#f00','#f00','#f00','#f00','#f00','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#0ef','#0ef','#0ef','#0ef','#0ef','#0ef','#f00',
		'#f00','#f00','#f00','#f00','#f00','#f00','#f00','#f00'
	]
];

const tile_binary = [
	"00111100" +
	"01000010" +
	"10100101" +
	"10000001" +
	"10100101" +
	"10011001" +
	"01000010" +
	"00111100",
	
	"00111100" +
	"01111110" +
	"11011011" +
	"11111111" +
	"11011011" +
	"11100111" +
	"01111110" +
	"00111100"
];

let x = 0;
let y = 0;

function main()
{
	tgl = new TGL();
	tgl.screen(160, 144, 4, 4);
	
	tgl.draw_frame(() => {
		draw_view_1();
		draw_view_2();
		tgl.update();
		x++;
		y++;
	});
}

function draw_view_1()
{
	tgl.unclip();
	tgl.clear('#ffff00');
	
	tgl.color_binary('#00f', '#0f0');
	tgl.draw_tiled(2, 6, tile_binary);
	tgl.color_binary('#f0f', '#804');
	tgl.draw_tiled(3, 6, tile_binary);

	tgl.color_normal();	
	tgl.draw_free(x, y, tile);
	tgl.enable_transparency('#0ef');
	tgl.draw_free(4, 4, tile);
	tgl.disable_transparency();
	tgl.draw_tiled(0, 3, tile);
	tgl.draw_tiled(1, 4, tile);
}

function draw_view_2()
{
	tgl.clip(50,20,120,100);
	tgl.scroll_to(5, 5);
	tgl.clear('#008000');
	
	tgl.color_binary('#00f', '#0f0');
	tgl.draw_tiled(2, 6, tile_binary);
	tgl.color_binary('#f0f', '#804');
	tgl.draw_tiled(3, 6, tile_binary);

	tgl.color_normal();	
	tgl.draw_free(0, 0, tile);
	tgl.enable_transparency('#0ef');
	tgl.draw_free(4, 4, tile);
	tgl.disable_transparency();
	tgl.draw_tiled(0, 3, tile);
	tgl.draw_tiled(1, 4, tile);
}
