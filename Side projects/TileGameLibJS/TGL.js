//=============================================================================
//		PUBLIC API
//=============================================================================
const TGL_TILESIZE = 8;

class TGL {
	log = new TGL_Log();
	private = new TGL_Private(this);

	constructor() {
		this.log.info("TGL singleton created");
	}
	init(target_canvas_id, buffer_w, buffer_h, pixel_w, pixel_h, backColor) {
		if (backColor) {
			this.private.backColor = backColor;
		}
		this.private.display.init(buffer_w, buffer_h, pixel_w, pixel_h, target_canvas_id);
		this.cls();
	}
	rnd(min, max) {
		min = Math.ceil(min);
		max = Math.floor(max);
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}
	tilesize() {
		return TGL_TILESIZE;
	}
	cols() {
		return this.private.display.width / TGL_TILESIZE;
	}
	rows() {
		return this.private.display.height / TGL_TILESIZE;
	}
	width() {
		return this.private.display.width;
	}
	height() {
		return this.private.display.height;
	}
	frameNumber() {
		return this.private.display.frameCounter;
	}
	cls() {
		this.private.display.clear();
	}
	clearClip() {
		this.private.display.clearClip();
	}
	backColor(color) {
		this.private.display.backColor = color;
	}
	colorNormal() {
		this.private.display.colorMode = "normal";
	}
	colorBinary(fgc, bgc) {
		this.private.display.colorMode = "binary";
		this.private.display.binaryFgc = fgc;
		this.private.display.binaryBgc = bgc;
	}
	drawFree(tile, x, y) {
		this.private.display.putPixelBlock(tile, x, y, 
			this.private.display.colorMode);
	}
	drawTiled(tile, x, y) {
		this.private.display.putPixelBlock(tile, 
			x * TGL_TILESIZE, y * TGL_TILESIZE, 
			this.private.display.colorMode);
	}
	printFree(str, x, y) {
		for (let i = 0; i < str.length; i++) {
			this.private.display.putPixelBlock(
				this.private.font[str.charCodeAt(i)], x, y, "binary");
		}
	}
	printTiled(str, x, y) {
		for (let i = 0; i < str.length; i++) {
			this.private.display.putPixelBlock(
				this.private.font[str.charCodeAt(i)], 
				x * TGL_TILESIZE, y * TGL_TILESIZE, "binary");
			x++;
		}
	}
	font(chr, binaryTile) {
		this.private.setFont(chr, binaryTile);
	}
	clip(x1, y1, x2, y2, backColor) {
		this.private.display.setClip(x1, y1, x2, y2, backColor);
	}
	unclip() {
		this.private.display.removeClip();
	}
}
//=============================================================================
//		PRIVATE API
//=============================================================================
class TGL_Private {
	log = new TGL_Log();
	public_api = null;
	display = new TGL_Display(this);
	palette = ["#111", "#f00", "#0f0", "#00f", "#ff0", "#0ff", "#f0f", "#888", "#eee"];
	font = [];
	constructor(public_api) {
		this.public_api = public_api;
		this.initDefaultFont();
	}
	setFont(chr, binaryTile) {
		this.font[chr] = binaryTile;
	}
	clearFont() {
		this.font = [];
		for (let i = 0; i < 256; i++) {
			this.setFont(i, 
				"01111100" +
				"01000100" +
				"01000100" +
				"01000100" +
				"01000100" +
				"01000100" +
				"01111100" +
				"00000000"
			);
		}
	}
	initDefaultFont() {
		this.clearFont();
		this.setFont(32, "0000000000000000000000000000000000000000000000000000000000000000"); // 32 Space
		this.setFont(33, "0011000000110000001100000011000000110000000000000011000000000000"); // 33 !
		this.setFont(34, "0110110001101100011011000000000000000000000000000000000000000000"); // 34 "
		this.setFont(35, "0000000000010100001111100001010000111110000101000000000000000000"); // 35 #
		this.setFont(36, "0001000011111110110100001111111000010110110101101111111000010000"); // 36 $
		this.setFont(37, "0000000001100010011001000000100000010000001001100100011000000000"); // 37 %
		this.setFont(38, "0001000001111100011000000011100001100000011111000001000000000000"); // 38 &
		this.setFont(39, "0000000000011000000110000011000000000000000000000000000000000000"); // 39 '
		this.setFont(40, "0000110000011000001100000011000000110000000110000000110000000000"); // 40 (
		this.setFont(41, "0011000000011000000011000000110000001100000110000011000000000000"); // 41 )
		this.setFont(42, "0000000001101100001110001111111000111000011011000000000000000000"); // 42 *
		this.setFont(43, "0000000000011000000110000111111000011000000110000000000000000000"); // 43 +
		this.setFont(44, "0000000000000000000000000000000000011000000110000011000000000000"); // 44 ,
		this.setFont(45, "0000000000000000000000000111111000000000000000000000000000000000"); // 45 -
		this.setFont(46, "0000000000000000000000000000000000000000000110000001100000000000"); // 46 .
		this.setFont(47, "0000000100000010000001000000100000010000001000000100000010000000"); // 47 /
		this.setFont(48, "0000000011111110110001101101011011010110110001101111111000000000"); // 48 Digit 0
		this.setFont(49, "0000000000111000000110000001100000011000000110000111111000000000"); // 49 Digit 1
		this.setFont(50, "0000000001111110011001100000011001111110011000000111111000000000"); // 50 Digit 2
		this.setFont(51, "0000000001111110000001100011110000000110000001100111111000000000"); // 51 Digit 3
		this.setFont(52, "0000000001100110011001100110011001111110000001100000011000000000"); // 52 Digit 4
		this.setFont(53, "0000000001111110011000000111111000000110011001100111111000000000"); // 53 Digit 5
		this.setFont(54, "0000000001111110011000000111111001100110011001100111111000000000"); // 54 Digit 6
		this.setFont(55, "0000000001111110000001100000110000011000001100000011000000000000"); // 55 Digit 7
		this.setFont(56, "0000000001111110011001100011110001100110011001100111111000000000"); // 56 Digit 8
		this.setFont(57, "0000000001111110011001100110011001111110000001100111111000000000"); // 57 Digit 9
		this.setFont(58, "0000000000000000000110000001100000000000000110000001100000000000"); // 58 :
		this.setFont(59, "0000000000000000000110000001100000000000000110000001100000001000"); // 59 ;
		this.setFont(60, "0000000000000110000110000110000000011000000001100000000000000000"); // 60 <
		this.setFont(61, "0000000000000000011111100000000001111110000000000000000000000000"); // 61 =
		this.setFont(62, "0000000001100000000110000000011000011000011000000000000000000000"); // 62 >
		this.setFont(63, "0111111001100110000001100001111000011000000000000001100000000000"); // 63 ?
		this.setFont(64, "1111111010000010101110101010101010111110100000001111111000000000"); // 64 @
		this.setFont(65, "0111111001100110011001100110011001111110011001100110011000000000"); // 65 Letter A
		this.setFont(66, "0111111001100110011001100111110001100110011001100111111000000000"); // 66 Letter B
		this.setFont(67, "0111111001100110011000000110000001100000011001100111111000000000"); // 67 Letter C
		this.setFont(68, "0111110001100110011001100110011001100110011001100111110000000000"); // 68 Letter D
		this.setFont(69, "0111111001100000011000000111110001100000011000000111111000000000"); // 69 Letter E
		this.setFont(70, "0111111001100000011000000111110001100000011000000110000000000000"); // 70 Letter F
		this.setFont(71, "0111111001100110011000000110111001100110011001100111111000000000"); // 71 Letter G
		this.setFont(72, "0110011001100110011001100111111001100110011001100110011000000000"); // 72 Letter H
		this.setFont(73, "0111111000011000000110000001100000011000000110000111111000000000"); // 73 Letter I
		this.setFont(74, "0000011000000110000001100000011001100110011001100111111000000000"); // 74 Letter J
		this.setFont(75, "0110011001100110011011000111100001100110011001100110011000000000"); // 75 Letter K
		this.setFont(76, "0110000001100000011000000110000001100000011000000111111000000000"); // 76 Letter L
		this.setFont(77, "1000001011000110111011101111111011010110110101101100011000000000"); // 77 Letter M
		this.setFont(78, "0100011001100110011101100111111001101110011001100110001000000000"); // 78 Letter N
		this.setFont(79, "0111111001100110011001100110011001100110011001100111111000000000"); // 79 Letter O
		this.setFont(80, "0111111001100110011001100110011001111110011000000110000000000000"); // 80 Letter P
		this.setFont(81, "0111111001100110011001100110011001100110011011100111111000000011"); // 81 Letter Q
		this.setFont(82, "0111111001100110011001100110011001111100011001100110011000000000"); // 82 Letter R
		this.setFont(83, "0111111001100110011000000111111000000110011001100111111000000000"); // 83 Letter S
		this.setFont(84, "0111111000011000000110000001100000011000000110000001100000000000"); // 84 Letter T
		this.setFont(85, "0110011001100110011001100110011001100110011001100111111000000000"); // 85 Letter U
		this.setFont(86, "0110011001100110011001100010010000111100000110000001100000000000"); // 86 Letter V
		this.setFont(87, "1100011011000110110101101101011011111110011011000110110000000000"); // 87 Letter W
		this.setFont(88, "0110011001100110001111000001100000111100011001100110011000000000"); // 88 Letter X
		this.setFont(89, "0110011001100110011001100110011001111110000110000001100000000000"); // 89 Letter Y
		this.setFont(90, "0111111000000110000011000001100000110000011000000111111000000000"); // 90 Letter Z
		this.setFont(91, "0001111000011000000110000001100000011000000110000001100000011110"); // 91 [
		this.setFont(92, "1000000001000000001000000001000000001000000001000000001000000001"); // 92 Backslash (\)
		this.setFont(93, "0111100000011000000110000001100000011000000110000001100001111000"); // 93 ]
		this.setFont(94, "1111111111111111111111111111111111111111111111111111111111111111"); // 94 Solid box (^)
		this.setFont(95, "0000000000000000000000000000000000000000000000000111111000000000"); // 95 _
		this.setFont(96, "0000000000011000000110000011000000000000000000000000000000000000"); // 96 Backtick (`)
		this.setFont(97, "0000000000000000011111000000110001111100011011000111111000000000"); // 97 Letter a
		this.setFont(98, "0111000000110000001111100011011000110110001101100011111000000000"); // 98 Letter b
		this.setFont(99, "0000000000000000011111100110011001100000011000000111111000000000"); // 99 Letter c
		this.setFont(100, "0000111000001100011111000110110001101100011011000111110000000000"); // 100 Letter d
		this.setFont(101, "0000000000000000011111100110011001111110011000000111111000000000"); // 101 Letter e
		this.setFont(102, "0000000000111110001100000111110000110000001100000011000000000000"); // 102 Letter f
		this.setFont(103, "0000000000000000011111100110110001101100011111000000110001111100"); // 103 Letter g
		this.setFont(104, "0110000001100000011111000110110001101100011011000110111000000000"); // 104 Letter h
		this.setFont(105, "0001100000000000001110000001100000011000000110000111111000000000"); // 105 Letter i
		this.setFont(106, "0000011000000000000001100000011000000110001101100011011000111110"); // 106 Letter j
		this.setFont(107, "0110000001100000011001100110110001111000011001100110011000000000"); // 107 Letter k
		this.setFont(108, "0011100000011000000110000001100000011000000110000111111000000000"); // 108 Letter l
		this.setFont(109, "0000000000000000111111101101011011010110110101101101011000000000"); // 109 Letter m
		this.setFont(110, "0000000000000000011111100011011000110110001101100011011000000000"); // 110 Letter n
		this.setFont(111, "0000000000000000011111100110011001100110011001100111111000000000"); // 111 Letter o
		this.setFont(112, "0000000000000000011111100011011000110110001111100011000000110000"); // 112 Letter p
		this.setFont(113, "0000000000000000011111000110110001101100011111000000110000001110"); // 113 Letter q
		this.setFont(114, "0000000000000000011111100011011000110000001100000011000000000000"); // 114 Letter r
		this.setFont(115, "0000000000000000011111100110000001111110000001100111111000000000"); // 115 Letter s
		this.setFont(116, "0000000000110000011111100011000000110000001100000011111000000000"); // 116 Letter t
		this.setFont(117, "0000000000000000011011000110110001101100011011000111111000000000"); // 117 Letter u
		this.setFont(118, "0000000000000000011001100110011001100110001111000001100000000000"); // 118 Letter v
		this.setFont(119, "0000000000000000110101101101011011010110111111100110110000000000"); // 119 Letter w
		this.setFont(120, "0000000000000000011001100011110000011000001111000110011000000000"); // 120 Letter x
		this.setFont(121, "0000000000000000011101100011011000110110001111100000011000111110"); // 121 Letter y
		this.setFont(122, "0000000000000000011111100000011000011000011000000111111000000000"); // 122 Letter z
		this.setFont(123, "0000111000001000000010000011000000001000000010000000111000000000"); // 123 {
		this.setFont(124, "0001100000011000000110000001100000011000000110000001100000011000"); // 124 |
		this.setFont(125, "0111000000010000000100000000110000010000000100000111000000000000"); // 125 }
		this.setFont(126, "0000000001101100111111101111111001111100001110000001000000000000"); // 126 Heart (~)
	}

	testDrawTiles() {
		const tile = 
		"11111111" +
		"10000001" +
		"10000001" +
		"10011001" +
		"10011001" +
		"10000001" +
		"10000001" +
		"11111111";
		this.public_api.colorBinary();
		for (let y = 0; y < this.public_api.rows(); y++) {
			for (let x = 0; x < this.public_api.cols(); x++) {
				this.public_api.colorBinary(
					this.palette[this.public_api.rnd(0, this.palette.length - 1)],
					this.palette[this.public_api.rnd(0, this.palette.length - 1)]);
				this.public_api.drawTiled(tile, x, y);
			}
		}
	}
}
class TGL_Log {
	info(str) {
		console.info("[TGL] " + str);
	}
	error(str) {
		console.error("[TGL] " + str);
		alert("TGL error:\n\n" + str);
	}
}
class TGL_Display {
	log = new TGL_Log();
	width = 0;
	height = 0;
	canvas = null;
	element = null;
	pixels = null;
	backColor = "#111";
	colorMode = "normal";
	binaryFgc = "#fff";
	binaryBgc = this.backColor;
	clip = null;
	frameCounter = 0;
	pixel_w = 1;
	pixel_h = 1;

	init(buffer_w, buffer_h, pixel_w, pixel_h, target_canvas_id) {
		this.width = buffer_w;
		this.height = buffer_h;
		this.pixel_w = pixel_w;
		this.pixel_h = pixel_h;
		this.pixels = [];
		for (let i = 0; i < buffer_w * buffer_h; i++) {
			this.pixels.push(0);
		}
		if (!target_canvas_id) {
			const page = document.querySelector("body");
			page.innerHTML = "<canvas id='tgl'></canvas>";
			this.element = document.querySelector("canvas");
		} else {
			this.element = document.querySelector("canvas#" + target_canvas_id);
			if (!this.element) {
				this.log.error("Canvas not found with id: " + target_canvas_id);
				return;
			}
		}
		this.element.display = "block";
		this.element.width = buffer_w * pixel_w;
		this.element.height = buffer_h * pixel_h;
		this.element.style.imageRendering = "pixelated";
		this.canvas = this.element.getContext("2d");
		requestAnimationFrame(() => this.update());
		this.log.info("Display created");
	}
	update() {
		let i = 0;
		for (let y = 0; y < this.height; y++) {
			for (let x = 0; x < this.width; x++) {
				this.renderPixel(x, y, this.pixels[i++]);
			}
		}
		this.frameCounter++;
		requestAnimationFrame(() => this.update());
	}
	setClip(x1, y1, x2, y2, backColor) {
		if (!backColor) {
			backColor = '#111';
		}
		this.clip = { x1: x1, y1: y1, x2: x2, y2: y2, backColor: backColor };
	}
	removeClip() {
		this.clip = null;
	}
	clear() {
		let i = 0;
		for (let y = 0; y < this.height; y++) {
			for (let x = 0; x < this.width; x++) {
				this.putPixel(x, y, this.backColor);
			}
		}
	}
	clearClip() {
		if (this.clip) {
			let i = 0;
			for (let y = this.clip.y1; y <= this.clip.y2; y++) {
				for (let x = this.clip.x1; x <= this.clip.x2; x++) {
					this.putPixel(x, y, this.clip.backColor);
				}
			}
		}
	}
	renderPixel(x, y, color) {
		x *= this.pixel_w;
		y *= this.pixel_h;
		this.canvas.fillStyle = color;
		this.canvas.fillRect(x, y, this.pixel_w, this.pixel_h);
	}
	putPixel(x, y, color) {
		if (x >= 0 && y >= 0 && x < this.width && y < this.height) {
			this.pixels[y * this.width + x] = color;
		}
	}
	putPixelBlock(block, x, y, colorMode) {
		if (this.clip) {
			x += this.clip.x1;
			y += this.clip.y1;
		}
		let initX = x;
		for (let i = 0; i < block.length; i++) {
			let color = null;
			if (colorMode == "normal") {
				color = block[i];
			} else if (colorMode == "binary") {
				if (block[i] == '0') {
					if (this.binaryBgc) {
						color = this.binaryBgc;
					}
				} else if (block[i] == '1') {
					color = this.binaryFgc;
				} else {
					throw new Error("Invalid binary bit: " + block[i]);
				}
			} else {
				throw new Error("Invalid color mode: " + colorMode);
			}
			if (color) {
				if (this.clip) {
					if (x <= this.clip.x2 && y <= this.clip.y2) {
						this.putPixel(x, y, color);
					}
				} else {
					this.putPixel(x, y, color);
				}
			}
			x++;
			if (x - initX >= TGL_TILESIZE) {
				x = initX;
				y++;
			}
		}
	}
}
