//=============================================================================
//		PUBLIC API
//=============================================================================
class TGL {
	log = new TGL_Log();
	private = new TGL_Private();
	backColor = '#111';

	constructor() {
		this.log.info("TGL singleton created");
	}
	init(w, h, backColor) {
		if (backColor) {
			this.backColor = backColor;
		}
		this.private.display.init(w, h);
		this.cls();
	}
	log(str) {
		this.private.log(str);
	}
	drawTestFrame() {
		let i = 0;
		for (let y = 0; y < this.private.display.height; y++) {
			for (let x = 0; x < this.private.display.width; x++) {
				this.private.display.pixels[i++] = 
					this.private.palette[this.rnd(0, this.private.palette.length - 1)];
			}
		}
	}
	rnd(min, max) {
		min = Math.ceil(min);
		max = Math.floor(max);
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}
	cls() {
		this.private.display.clear(this.backColor);
	}
}
//=============================================================================
//		PRIVATE API
//=============================================================================
class TGL_Private {
	log = new TGL_Log();
	display = new TGL_Display(this);
	palette = ["#111", "#f00", "#0f0", "#00f", "#ff0", "#0ff", "#f0f", "#888", "#eee"];
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
				this.pset(x, y, this.pixels[i++]);
			}
		}
		requestAnimationFrame(() => this.update());
	}
	clear(color) {
		let i = 0;
		for (let y = 0; y < this.height; y++) {
			for (let x = 0; x < this.width; x++) {
				this.pset(x, y, color);
			}
		}
	}
	pset(x, y, color) {
		this.canvas.fillStyle = color;
		this.canvas.fillRect(x, y, 1, 1);
	}
}
