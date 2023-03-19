class TGL
{
	static singleton_created = false;
	width = 0;
	height = 0;
	scrbuf = [];
	scrbuf_len = 0;
	default_bgcolor = "#f0f0f0";
	default_border = "#000000";
	canvas = null;
	pixel_w = 0;
	pixel_h = 0;
	clip_area = { enabled: false, x1: 0, y1: 0, x2: 0, y2: 0 };
	tilesize = 8;
	transparency = { enabled: false, key: '#000' };
	scroll_pos = { x: 0, y: 0 };
	COLOR_MODE_NORMAL = 0;
	COLOR_MODE_BINARY = 1;
	color_mode = this.COLOR_MODE_NORMAL;
	binary_fgc = '#ffffff';
	binary_bgc = '#000000';
	anim = {
		index: 0,
		delay: 300,
		interval_id: null
	};
	frame = {
		counter: 0,
		delay: 1,
		interval_id: null
	};
	draw_frame_callback = null;
	
	constructor()
	{
		if (TGL.singleton_created === false) {
			TGL.singleton_created = true;
			
			this.anim.interval_id = window.setInterval(() => {
				this.anim.index++;
			}, this.anim.delay);
			
			this.frame.interval_id = window.requestAnimationFrame(() => {
				this.internal_draw_frame();
			});
			
			console.log("TGL singleton created!");
		} else {
			console.error("Illegal attempt to create more than one TGL instance");
		}
	}
	
	internal_draw_frame()
	{
		if (this.draw_frame_callback) {
			this.draw_frame_callback();
		}
		window.requestAnimationFrame(() => { this.internal_draw_frame() });
	}
	
	draw_frame(fn)
	{
		this.draw_frame_callback = fn;
	}

	screen(width, height, pixel_w, pixel_h)
	{
		this.width = width;
		this.height = height;
		this.pixel_w = pixel_w;
		this.pixel_h = pixel_h;
		this.scrbuf_len = width * height;
		
		for (let i = 0; i < this.scrbuf_len; i++) {
			this.scrbuf.push(this.default_bgcolor);
		}
		
		const canvas_element = document.createElement("canvas");
		canvas_element.width = width * pixel_w;
		canvas_element.height = height * pixel_h;
		canvas_element.style = "border: 1px solid " + this.default_border;
		document.body.appendChild(canvas_element);
		
		this.canvas = canvas_element.getContext("2d");
		
		this.update();
	}
	
	update()
	{
		let x = 0;
		let y = 0;
		
		for (let i = 0; i < this.scrbuf_len; i++) {
			this.canvas.fillStyle = this.scrbuf[i];
			this.canvas.fillRect(x * this.pixel_w, y * this.pixel_h, this.pixel_w, this.pixel_h);
			x++;
			if (x >= this.width) {
				x = 0;
				y++;
			}
		}
		
		this.frame.counter++;
	}
	
	clear(color)
	{
		for (let y = 0; y < this.height; y++) {
			for (let x = 0; x < this.width; x++) {
				this.pset(x, y, color, true);
			}			
		}
	}
	
	clip(x1, y1, x2, y2)
	{
		this.clip_area.enabled = true;
		this.clip_area.x1 = x1;
		this.clip_area.y1 = y1;
		this.clip_area.x2 = x2;
		this.clip_area.y2 = y2;
		this.scroll_to(0, 0);
	}
	
	unclip()
	{
		this.clip_area.enabled = false;
		this.scroll_to(0, 0);
	}
	
	pset(x, y, color, ignore_scroll)
	{
		if (!ignore_scroll) {
			x -= this.scroll_pos.x;
			y -= this.scroll_pos.y;
		}
		if (this.clip_area.enabled) {
			x += this.clip_area.x1;
			y += this.clip_area.y1;
			if (x >= 0 && y >= 0 && x < this.width && y < this.height &&
				x >= this.clip_area.x1 && y >= this.clip_area.y1 && x <= this.clip_area.x2 && y <= this.clip_area.y2) {
				this.scrbuf[y * this.width + x] = color;
			}
		} else {
			this.scrbuf[y * this.width + x] = color;
		}
	}
	
	enable_transparency(color)
	{
		this.transparency.enabled = true;
		if (color !== undefined) {
			this.transparency.key = color;
		}
	}
	
	disable_transparency()
	{
		this.transparency.enabled = false;
	}
	
	color_normal()
	{
		this.color_mode = 0;
	}

	color_binary(fgc, bgc)
	{
		this.color_mode = 1;
		this.binary_fgc = fgc;
		this.binary_bgc = bgc;
	}
	
	scroll_to(x, y)
	{
		this.scroll_pos.x = x;
		this.scroll_pos.y = y;
	}

	scroll(dx, dy)
	{
		this.scroll_pos.x += dx;
		this.scroll_pos.y += dy;
	}
	
	draw_free(x, y, pixels)
	{
		let px = x;
		let py = y;
		
		for (let i = 0; i < this.tilesize * this.tilesize; i++) {
			let color = null;
			if (this.color_mode == this.COLOR_MODE_NORMAL) {
				color = pixels[this.anim.index % pixels.length][i];
			} else if (this.color_mode == this.COLOR_MODE_BINARY) {
				color = pixels[this.anim.index % pixels.length][i] == '1' ? this.binary_fgc : this.binary_bgc;
			}
			if (!this.transparency.enabled || color != this.transparency.key) {
				this.pset(px, py, color);
			}
			px++;
			if (px >= x + this.tilesize) {
				px = x;
				py++;
			}
		}
	}
	
	draw_tiled(col, row, pixels)
	{
		this.draw_free(col * this.tilesize, row * this.tilesize, pixels);
	}
}
