//=============================================================================
//		PUBLIC API
//=============================================================================
const TGL_TILESIZE = 8;

class TGL {
	log = new TGL_Log();
	private = new TGL_Private();
	palette = ["#111", "#f00", "#0f0", "#00f", "#ff0", "#0ff", "#f0f", "#888", "#eee"];

	constructor() {
		this.log.info("TGL singleton created");
	}
	init(w, h, backColor) {
		if (backColor) {
			this.private.backColor = backColor;
		}
		this.private.display.init(w, h);
		this.cls();
	}
	log(str) {
		this.private.log(str);
	}
	testDrawPixels() {
		this.colorNormal();
		let i = 0;
		for (let y = 0; y < this.private.display.height; y++) {
			for (let x = 0; x < this.private.display.width; x++) {
				this.private.display.pixels[i++] = 
					this.palette[this.rnd(0, this.palette.length - 1)];
			}
		}
	}
	testDrawTiles() {
		this.colorBinary();
		for (let y = 0; y < this.rows(); y++) {
			for (let x = 0; x < this.cols(); x++) {
				this.colorBinary(
					this.palette[this.rnd(0, this.palette.length - 1)],
					this.palette[this.rnd(0, this.palette.length - 1)]);
				this.drawTiled(tile, x, y);
			}
		}
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
	cls() {
		this.private.display.clear();
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
		if (bgc) {
			this.private.display.binaryBgc = bgc;
		}
	}
	transparency(state) {
		this.private.display.transparency = state;
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
}
//=============================================================================
//		PRIVATE API
//=============================================================================
class TGL_Private {
	log = new TGL_Log();
	display = new TGL_Display(this);
}
class TGL_Log {
	info(str) {
		console.info("TGL >>> " + str);
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
	transparency = false;

	init(w, h) {
		this.width = w;
		this.height = h;
		this.pixels = [];
		for (let i = 0; i < w * h; i++) {
			this.pixels.push(0);
		}
		const page = document.querySelector("body");
		page.style.margin = 0;
		page.style.padding = 0;
		page.innerHTML = "<canvas></canvas>";
		this.element = document.querySelector("canvas");
		this.element.display = "block";
		this.element.style.margin = "0 auto";
		this.element.style.padding = 0;
		this.element.width = w;
		this.element.height = h;
		this.element.style.width = "100%";
		this.element.style.height = "100%";
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
		requestAnimationFrame(() => this.update());
	}
	clear() {
		let i = 0;
		for (let y = 0; y < this.height; y++) {
			for (let x = 0; x < this.width; x++) {
				this.putPixel(x, y, this.backColor);
			}
		}
	}
	renderPixel(x, y, color) {
		this.canvas.fillStyle = color;
		this.canvas.fillRect(x, y, 1, 1);
	}
	putPixel(x, y, color) {
		this.pixels[y * this.width + x] = color;
	}
	putPixelBlock(block, x, y, colorMode) {
		let initX = x;
		for (let i = 0; i < block.length; i++) {
			let color = null;
			if (colorMode == "normal") {
				color = block[i];
			} else if (colorMode == "binary") {
				if (block[i] == '0') {
					if (!this.transparency) {
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
				this.putPixel(x, y, color);
			}
			x++;
			if (x - initX >= 8) {
				x = initX;
				y++;
			}
		}
	}
}
