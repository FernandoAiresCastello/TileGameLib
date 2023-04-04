//================================================================================
//		TGL
//================================================================================
class TGL {
	display = {
		width: 0,
		height: 0,
		canvas: null,
		canvas_e: null,
		pixels: null,
		pal: ['#111', '#f00', '#0f0', '#00f', '#ff0', '#0ff', '#f0f', '#888', '#eee']
	};
	init_screen(w, h) {
		this.display.width = w;
		this.display.height = h;
		this.display.pixels = [];
		for (let i = 0; i < w * h; i++) {
			this.display.pixels.push(0);
		}
		const page = document.querySelector("body");
		page.style.margin = 0;
		page.style.padding = 0;
		page.innerHTML = "<canvas></canvas>";
		this.display.canvas_e = document.querySelector("canvas");
		this.display.canvas_e.display = "block";
		this.display.canvas_e.style.margin = "0 auto";
		this.display.canvas_e.style.padding = 0;
		this.display.canvas_e.width = w;
		this.display.canvas_e.height = h;
		this.display.canvas_e.style.width = "100%";
		this.display.canvas_e.style.height = "100%";
		this.display.canvas_e.style.imageRendering = "pixelated";
		this.display.canvas = this.display.canvas_e.getContext("2d");
		requestAnimationFrame(() => this.update());
	}
	update() {
		let i = 0;
		for (let y = 0; y < this.display.height; y++) {
			for (let x = 0; x < this.display.width; x++) {
				this.pset(x, y, this.display.pixels[i++]);
			}
		}
		requestAnimationFrame(() => this.update());
	}
	draw_test_frame() {
		let i = 0;
		for (let y = 0; y < this.display.height; y++) {
			for (let x = 0; x < this.display.width; x++) {
				this.display.pixels[i++] = this.display.pal[this.rnd(0, this.display.pal.length - 1)];
			}
		}
	}
	rnd(min, max) {
		min = Math.ceil(min);
		max = Math.floor(max);
		return Math.floor(Math.random() * (max - min + 1)) + min;
	}
	clear(color) {
		this.display.canvas.fillStyle = color;
		this.display.canvas.fillRect(0, 0, this.display.canvas_e.width, this.display.canvas_e.height);
	}
	pset(x, y, color) {
		this.display.canvas.fillStyle = color;
		this.display.canvas.fillRect(x, y, 1, 1);
	}
}

//================================================================================
//		TEST
//================================================================================
const tgl = new TGL();
tgl.init_screen(256, 192);
tgl.draw_test_frame();
