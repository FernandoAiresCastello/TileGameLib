(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CanvasPoint = void 0;
class CanvasPoint {
    constructor(x, y, index) {
        this.x = x;
        this.y = y;
        this.index = index;
    }
}
exports.CanvasPoint = CanvasPoint;

},{}],2:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Cursor = void 0;
class Cursor {
    constructor(buffer) {
        this.buffer = buffer;
        this.layer = 0;
        this.x = 0;
        this.y = 0;
    }
    set(buffer, layer, x, y) {
        this.buffer = buffer;
        this.layer = layer;
        this.x = x;
        this.y = y;
    }
    setPos(x, y) {
        this.x = x;
        this.y = y;
    }
    reset(buffer) {
        this.buffer = buffer;
        this.layer = 0;
        this.x = 0;
        this.y = 0;
    }
}
exports.Cursor = Cursor;

},{}],3:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DefaultPalette = void 0;
class DefaultPalette {
    static init(pal) {
        pal.init(256, "#000000");
        pal.set(0, "#000000");
        pal.set(1, "#ffffff");
    }
}
exports.DefaultPalette = DefaultPalette;

},{}],4:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DefaultTileset = void 0;
class DefaultTileset {
    static init(chr) {
        chr.initBlank(256);
        chr.set(0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x21, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00, 0x30, 0x00);
        chr.set(0x22, 0x6c, 0x6c, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x23, 0x00, 0x00, 0x28, 0x7c, 0x28, 0x7c, 0x28, 0x00);
        chr.set(0x24, 0x10, 0xfe, 0xd0, 0xfe, 0x16, 0xd6, 0xfe, 0x10);
        chr.set(0x25, 0x00, 0xc6, 0xcc, 0x18, 0x30, 0x66, 0xc6, 0x00);
        chr.set(0x26, 0x10, 0x7c, 0xe0, 0x7c, 0xe0, 0x7c, 0x10, 0x00);
        chr.set(0x27, 0x70, 0x30, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x28, 0x0c, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x0c);
        chr.set(0x29, 0x30, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x30);
        chr.set(0x2a, 0x00, 0x6c, 0x38, 0xfe, 0x38, 0x6c, 0x00, 0x00);
        chr.set(0x2b, 0x00, 0x18, 0x18, 0x7e, 0x18, 0x18, 0x00, 0x00);
        chr.set(0x2c, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x30, 0x60);
        chr.set(0x2d, 0x00, 0x00, 0x00, 0x7e, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x2e, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x30, 0x00);
        chr.set(0x2f, 0x00, 0x06, 0x0c, 0x18, 0x30, 0x60, 0xc0, 0x00);
        chr.set(0x30, 0x00, 0xfe, 0xc6, 0xd6, 0xd6, 0xc6, 0xfe, 0x00);
        chr.set(0x31, 0x00, 0x38, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x32, 0x00, 0x7e, 0x66, 0x06, 0x7e, 0x60, 0x7e, 0x00);
        chr.set(0x33, 0x00, 0x7e, 0x06, 0x3c, 0x06, 0x06, 0x7e, 0x00);
        chr.set(0x34, 0x00, 0x66, 0x66, 0x66, 0x7e, 0x06, 0x06, 0x00);
        chr.set(0x35, 0x00, 0x7e, 0x60, 0x7e, 0x06, 0x66, 0x7e, 0x00);
        chr.set(0x36, 0x00, 0x7e, 0x60, 0x7e, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x37, 0x00, 0x7e, 0x06, 0x0c, 0x18, 0x30, 0x30, 0x00);
        chr.set(0x38, 0x00, 0x7e, 0x66, 0x3c, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x39, 0x00, 0x7e, 0x66, 0x66, 0x7e, 0x06, 0x7e, 0x00);
        chr.set(0x3a, 0x00, 0x00, 0x18, 0x18, 0x00, 0x18, 0x18, 0x00);
        chr.set(0x3b, 0x00, 0x00, 0x30, 0x30, 0x00, 0x70, 0x30, 0x60);
        chr.set(0x3c, 0x0c, 0x18, 0x30, 0x60, 0x30, 0x18, 0x0c, 0x00);
        chr.set(0x3d, 0x00, 0x00, 0x7e, 0x00, 0x7e, 0x00, 0x00, 0x00);
        chr.set(0x3e, 0x60, 0x30, 0x18, 0x0c, 0x18, 0x30, 0x60, 0x00);
        chr.set(0x3f, 0x7e, 0x66, 0x06, 0x1e, 0x18, 0x00, 0x18, 0x00);
        chr.set(0x40, 0xfe, 0x82, 0xba, 0xaa, 0xbe, 0x80, 0xfe, 0x00);
        chr.set(0x41, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x00);
        chr.set(0x42, 0x7e, 0x66, 0x66, 0x7c, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x43, 0x7e, 0x66, 0x60, 0x60, 0x60, 0x66, 0x7e, 0x00);
        chr.set(0x44, 0x7c, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7c, 0x00);
        chr.set(0x45, 0x7e, 0x60, 0x60, 0x7c, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x46, 0x7e, 0x60, 0x60, 0x7c, 0x60, 0x60, 0x60, 0x00);
        chr.set(0x47, 0x7e, 0x66, 0x60, 0x6e, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x48, 0x66, 0x66, 0x66, 0x7e, 0x66, 0x66, 0x66, 0x00);
        chr.set(0x49, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x4a, 0x06, 0x06, 0x06, 0x06, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x4b, 0x66, 0x66, 0x6c, 0x78, 0x66, 0x66, 0x66, 0x00);
        chr.set(0x4c, 0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x4d, 0x82, 0xc6, 0xee, 0xfe, 0xd6, 0xd6, 0xc6, 0x00);
        chr.set(0x4e, 0x46, 0x66, 0x76, 0x7e, 0x6e, 0x66, 0x62, 0x00);
        chr.set(0x4f, 0x7e, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x50, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x60, 0x60, 0x00);
        chr.set(0x51, 0x7e, 0x66, 0x66, 0x66, 0x66, 0x6e, 0x7e, 0x03);
        chr.set(0x52, 0x7e, 0x66, 0x66, 0x66, 0x7c, 0x66, 0x66, 0x00);
        chr.set(0x53, 0x7e, 0x66, 0x60, 0x7e, 0x06, 0x66, 0x7e, 0x00);
        chr.set(0x54, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00);
        chr.set(0x55, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x56, 0x66, 0x66, 0x66, 0x24, 0x3c, 0x18, 0x18, 0x00);
        chr.set(0x57, 0xc6, 0xc6, 0xd6, 0xd6, 0xfe, 0x6c, 0x6c, 0x00);
        chr.set(0x58, 0x66, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0x66, 0x00);
        chr.set(0x59, 0x66, 0x66, 0x66, 0x66, 0x7e, 0x18, 0x18, 0x00);
        chr.set(0x5a, 0x7e, 0x06, 0x0c, 0x18, 0x30, 0x60, 0x7e, 0x00);
        chr.set(0x5b, 0x1e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x1e);
        chr.set(0x5c, 0x00, 0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x00);
        chr.set(0x5d, 0x78, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78);
        chr.set(0x5e, 0x10, 0x38, 0x6c, 0xc6, 0x00, 0x00, 0x00, 0x00);
        chr.set(0x5f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7e, 0x00);
        chr.set(0x60, 0x38, 0x44, 0xba, 0xa2, 0xba, 0x44, 0x38, 0x00);
        chr.set(0x61, 0x00, 0x00, 0x7c, 0x0c, 0x7c, 0x6c, 0x7e, 0x00);
        chr.set(0x62, 0x70, 0x30, 0x3e, 0x36, 0x36, 0x36, 0x3e, 0x00);
        chr.set(0x63, 0x00, 0x00, 0x7e, 0x66, 0x60, 0x60, 0x7e, 0x00);
        chr.set(0x64, 0x0e, 0x0c, 0x7c, 0x6c, 0x6c, 0x6c, 0x7c, 0x00);
        chr.set(0x65, 0x00, 0x00, 0x7e, 0x66, 0x7e, 0x60, 0x7e, 0x00);
        chr.set(0x66, 0x00, 0x3e, 0x30, 0x7c, 0x30, 0x30, 0x30, 0x00);
        chr.set(0x67, 0x00, 0x00, 0x7e, 0x6c, 0x6c, 0x7c, 0x0c, 0x7c);
        chr.set(0x68, 0x60, 0x60, 0x7c, 0x6c, 0x6c, 0x6c, 0x6e, 0x00);
        chr.set(0x69, 0x18, 0x00, 0x38, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x6a, 0x06, 0x00, 0x06, 0x06, 0x06, 0x36, 0x36, 0x3e);
        chr.set(0x6b, 0x60, 0x60, 0x66, 0x6c, 0x78, 0x66, 0x66, 0x00);
        chr.set(0x6c, 0x38, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00);
        chr.set(0x6d, 0x00, 0x00, 0xfe, 0xd6, 0xd6, 0xd6, 0xd6, 0x00);
        chr.set(0x6e, 0x00, 0x00, 0x7e, 0x36, 0x36, 0x36, 0x36, 0x00);
        chr.set(0x6f, 0x00, 0x00, 0x7e, 0x66, 0x66, 0x66, 0x7e, 0x00);
        chr.set(0x70, 0x00, 0x00, 0x7e, 0x36, 0x36, 0x3e, 0x30, 0x30);
        chr.set(0x71, 0x00, 0x00, 0x7c, 0x6c, 0x6c, 0x7c, 0x0c, 0x0e);
        chr.set(0x72, 0x00, 0x00, 0x7e, 0x36, 0x30, 0x30, 0x30, 0x00);
        chr.set(0x73, 0x00, 0x00, 0x7e, 0x60, 0x7e, 0x06, 0x7e, 0x00);
        chr.set(0x74, 0x00, 0x30, 0x7e, 0x30, 0x30, 0x30, 0x3e, 0x00);
        chr.set(0x75, 0x00, 0x00, 0x6c, 0x6c, 0x6c, 0x6c, 0x7e, 0x00);
        chr.set(0x76, 0x00, 0x00, 0x66, 0x66, 0x66, 0x3c, 0x18, 0x00);
        chr.set(0x77, 0x00, 0x00, 0xd6, 0xd6, 0xd6, 0xfe, 0x6c, 0x00);
        chr.set(0x78, 0x00, 0x00, 0x66, 0x3c, 0x18, 0x3c, 0x66, 0x00);
        chr.set(0x79, 0x00, 0x00, 0x76, 0x36, 0x36, 0x3e, 0x06, 0x3e);
        chr.set(0x7a, 0x00, 0x00, 0x7e, 0x06, 0x18, 0x60, 0x7e, 0x00);
        chr.set(0x7b, 0x0c, 0x18, 0x18, 0x70, 0x18, 0x18, 0x0c, 0x00);
        chr.set(0x7c, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00);
        chr.set(0x7d, 0x60, 0x30, 0x30, 0x1c, 0x30, 0x30, 0x60, 0x00);
        chr.set(0x7e, 0x00, 0x00, 0x60, 0xf2, 0x9e, 0x0c, 0x00, 0x00);
        chr.set(0x7f, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
    }
}
exports.DefaultTileset = DefaultTileset;

},{}],5:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Display = void 0;
const DisplayRenderer_1 = require("./DisplayRenderer");
const TileBuffer_1 = require("./TileBuffer");
class Display {
    constructor(displayElement, width, height, hStretch, vStretch, defaultBufLayers, palette, tileset, animationInterval) {
        this.animationFrameIndex = 0;
        this.renderer = new DisplayRenderer_1.DisplayRenderer(displayElement, width, height, hStretch, vStretch, palette, tileset);
        this.buffers = [];
        this.createDefaultBuffer(defaultBufLayers);
        window.setInterval(this.advanceTileAnimation, animationInterval, this);
    }
    createDefaultBuffer(defaultBufLayers) {
        this.createNewBuffer("default", defaultBufLayers, this.renderer.cols, this.renderer.rows, 0, 0);
    }
    getDefaultBuffer() {
        return this.getBuffer("default");
    }
    createNewBuffer(id, layers, w, h, dispX, dispY) {
        const buf = new TileBuffer_1.TileBuffer(id, layers, w, h);
        buf.view.displayX = dispX;
        buf.view.displayY = dispY;
        this.buffers.push(buf);
        return buf;
    }
    deleteAllBuffers() {
        this.buffers = [];
    }
    reset() {
        const defaultBufLayers = this.getDefaultBuffer().layerCount;
        this.renderer.reset();
        this.deleteAllBuffers();
        this.createDefaultBuffer(defaultBufLayers);
    }
    setBackColorIx(ix) {
        this.renderer.backColorIx = ix;
    }
    clearAllBuffers() {
        for (let i = 0; i < this.buffers.length; i++) {
            this.buffers[i].clearAllLayers();
        }
    }
    update() {
        this.renderer.clearToBackColor();
        this.drawVisibleBuffers();
        this.renderer.update();
    }
    getBuffer(id) {
        for (let i = 0; i < this.buffers.length; i++) {
            const buf = this.buffers[i];
            if (buf.id === id) {
                return buf;
            }
        }
        return null;
    }
    advanceTileAnimation(display) {
        if (!display) {
            display = this;
        }
        display.animationFrameIndex++;
        if (display.animationFrameIndex >= Number.MAX_SAFE_INTEGER) {
            display.animationFrameIndex = 0;
        }
    }
    drawTileFrame(tile, x, y, transparent) {
        this.renderer.drawTileFrame(tile, x, y, transparent);
    }
    drawVisibleBuffers() {
        for (let i = 0; i < this.buffers.length; i++) {
            const buf = this.buffers[i];
            if (buf.visible) {
                this.drawBuffer(buf);
            }
        }
    }
    drawBuffer(buf) {
        for (let i = 0; i < buf.layerCount; i++) {
            const layer = buf.layers[i];
            this.drawBufferLayer(layer, buf.view);
        }
    }
    drawBufferLayer(layer, view) {
        const w = view.width;
        const h = view.height;
        let dispX = view.displayX;
        let dispY = view.displayY;
        let bufX = view.scrollX;
        let bufY = view.scrollY;
        for (let tileY = bufY; tileY < bufY + h; tileY++) {
            for (let tileX = bufX; tileX < bufX + w; tileX++) {
                if (tileX >= 0 && tileY >= 0 && tileX < layer.width && tileY < layer.height &&
                    dispX >= 0 && dispY >= 0 && dispX < this.renderer.cols && dispY < this.renderer.rows) {
                    const tileSeq = layer.getTileRef(tileX, tileY);
                    if (!tileSeq.isEmpty()) {
                        const tile = tileSeq.frames[this.animationFrameIndex % tileSeq.frames.length];
                        this.drawTileFrame(tile, dispX, dispY, tileSeq.transparent);
                    }
                }
                dispX++;
            }
            dispX = view.displayX;
            dispY++;
        }
    }
}
exports.Display = Display;

},{"./DisplayRenderer":6,"./TileBuffer":14}],6:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DisplayRenderer = void 0;
const TGL_InitializationError_1 = require("./TGL_InitializationError");
const CanvasPoint_1 = require("./CanvasPoint");
const PixelBlock_1 = require("./PixelBlock");
class DisplayRenderer {
    constructor(parentElement, bufWidth, bufHeight, pixelWidth, pixelHeight, palette, tileset) {
        this.backColorIx = 0;
        this.pixelBufWidth = bufWidth;
        this.pixelBufHeight = bufHeight;
        this.pixelBufSize = bufWidth * bufHeight;
        this.pixelWidth = pixelWidth;
        this.pixelHeight = pixelHeight;
        this.canvasWidth = bufWidth * pixelWidth;
        this.canvasHeight = bufHeight * pixelHeight;
        this.cols = bufWidth / PixelBlock_1.PixelBlock.Width;
        this.rows = bufHeight / PixelBlock_1.PixelBlock.Height;
        this.palette = palette;
        this.tileset = tileset;
        this.canvasElement = document.createElement("canvas");
        this.canvasElement.width = this.canvasWidth;
        this.canvasElement.height = this.canvasHeight;
        parentElement.append(this.canvasElement);
        let ctx = this.canvasElement.getContext("2d");
        if (ctx === null) {
            throw new TGL_InitializationError_1.TGL_InitializationError("Unable to create CanvasRenderingContext2D");
        }
        this.canvas = ctx;
        this.canvas.imageSmoothingEnabled = false;
        this.canvas.imageSmoothingQuality = 'low';
        this.pixelPositions = this.calculatePixelPositions();
        this.pixels = [];
        this.reset();
    }
    update() {
        for (let i = 0; i < this.pixelPositions.length; i++) {
            const pos = this.pixelPositions[i];
            this.canvas.fillStyle = this.pixels[pos.index];
            this.canvas.fillRect(pos.x, pos.y, this.pixelWidth, this.pixelHeight);
        }
    }
    reset() {
        this.backColorIx = 0;
        this.clearToBackColor();
        this.update();
    }
    clearToBackColor() {
        this.clearToColor(this.backColorIx);
    }
    drawTileFrame(tile, x, y, transparent) {
        x *= PixelBlock_1.PixelBlock.Width;
        y *= PixelBlock_1.PixelBlock.Height;
        const px = x;
        const xmax = x + PixelBlock_1.PixelBlock.Width;
        const pixelBlock = this.tileset.get(tile.ix);
        for (let i = 0; i < pixelBlock.pixels.length; i++) {
            const pixel = pixelBlock.pixels[i];
            const fgc = this.palette.get(tile.fgc);
            const bgc = this.palette.get(tile.bgc);
            if (pixel === PixelBlock_1.PixelBlock.PixelOn) {
                this.setPixelRgb(x, y, fgc);
            }
            else if (pixel === PixelBlock_1.PixelBlock.PixelOff && !transparent) {
                this.setPixelRgb(x, y, bgc);
            }
            x++;
            if (x >= xmax) {
                x = px;
                y++;
            }
        }
    }
    clearToColor(ix) {
        const color = this.palette.get(ix);
        this.clearToColorRgb(color);
    }
    clearToColorRgb(color) {
        for (let pos = 0; pos < this.pixelBufSize; pos++) {
            this.setPixelRgbLinear(pos, color);
        }
    }
    setPixelRgbLinear(pos, color) {
        this.pixels[pos] = color;
    }
    setPixelRgb(x, y, color) {
        this.pixels[y * this.pixelBufWidth + x] = color;
    }
    calculatePixelPositions() {
        const positions = [];
        let canvasX = 0;
        let canvasY = 0;
        for (let pixelBufIndex = 0; pixelBufIndex < this.pixelBufSize; pixelBufIndex++) {
            positions.push(new CanvasPoint_1.CanvasPoint(canvasX, canvasY, pixelBufIndex));
            canvasX += this.pixelWidth;
            if (canvasX >= this.canvasWidth) {
                canvasX = 0;
                canvasY += this.pixelHeight;
            }
        }
        return positions;
    }
}
exports.DisplayRenderer = DisplayRenderer;

},{"./CanvasPoint":1,"./PixelBlock":10,"./TGL_InitializationError":11}],7:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FmtStringPrinter = void 0;
const TGL_RuntimeError_1 = require("./TGL_RuntimeError");
const TileSeq_1 = require("./TileSeq");
class FmtStringPrinter {
    constructor(tgl) {
        this.tgl = tgl;
        this.error = null;
    }
    print(fmt, csr, initFgc, initBgc, transp) {
        const buf = csr.buffer;
        const layer = csr.layer;
        const initX = csr.x;
        let tile = new TileSeq_1.TileSeq();
        tile.transparent = transp;
        tile.setSingle(0, 0, 0);
        let textColor = new TextColor(initFgc, initBgc);
        const chEscapeBegin = "{";
        const chEscapeEnd = "}";
        let escaped = false;
        let escapeSeq = "";
        let isVariable = false;
        let resolvedVariableValue = "";
        for (let i = 0; i < fmt.length; i++) {
            let tileIndex = fmt.charCodeAt(i);
            const ch = fmt.charAt(i);
            if (ch === chEscapeBegin) {
                if (escaped) {
                    this.error = "Escape sequences cannot be nested";
                    return;
                }
                escaped = true;
                continue;
            }
            else if (ch === chEscapeEnd) {
                if (!escaped) {
                    this.error = "Missing opening escape character";
                    return;
                }
                escaped = false;
                const res = this.interpretEscapeSequence(escapeSeq, csr, initX, textColor);
                escapeSeq = "";
                if (res) {
                    if (res.tileIndex) {
                        tileIndex = res.tileIndex;
                    }
                    else if (res.varValue) {
                        isVariable = true;
                        resolvedVariableValue = res.varValue;
                    }
                }
                else {
                    continue;
                }
            }
            else if (escaped) {
                escapeSeq += ch;
                continue;
            }
            if (isVariable) {
                isVariable = false;
                for (let i = 0; i < resolvedVariableValue.length; i++) {
                    tile.set(0, resolvedVariableValue.charCodeAt(i), textColor.fg, textColor.bg);
                    buf.setTile(tile, layer, csr.x, csr.y);
                    csr.x++;
                }
            }
            else {
                tile.set(0, tileIndex, textColor.fg, textColor.bg);
                buf.setTile(tile, layer, csr.x, csr.y);
                csr.x++;
            }
        }
    }
    interpretEscapeSequence(esc, csr, initX, textColor) {
        if (esc.toUpperCase() === "LF") {
            csr.y++;
            csr.x = initX;
            return null;
        }
        else if (esc[0].toUpperCase() === "F") {
            textColor.fgPrev = textColor.fg;
            textColor.fg = Number(esc.substring(1).trim());
            return null;
        }
        else if (esc.toUpperCase() === "/F") {
            textColor.fg = textColor.fgPrev;
            return null;
        }
        else if (esc[0].toUpperCase() === "B") {
            textColor.bgPrev = textColor.bg;
            textColor.bg = Number(esc.substring(1).trim());
            return null;
        }
        else if (esc.toUpperCase() === "/B") {
            textColor.bg = textColor.bgPrev;
            return null;
        }
        else if (esc[0].toUpperCase() === "C") {
            const res = new ResolvedEscapeSeq();
            res.tileIndex = Number(esc.substring(1).trim());
            return res;
        }
        else if (esc[0] === "%") {
            const id = esc.substring(1).trim();
            const value = this.tgl.getGlobals()[id];
            if (value === undefined || value === null) {
                throw new TGL_RuntimeError_1.TGL_RuntimeError(`Unknown variable: ${id}`);
            }
            const res = new ResolvedEscapeSeq();
            res.varValue = value.toString();
            return res;
        }
        else {
            throw new TGL_RuntimeError_1.TGL_RuntimeError(`Unrecognized escape sequence: ${esc}`);
        }
    }
}
exports.FmtStringPrinter = FmtStringPrinter;
class TextColor {
    constructor(fg, bg) {
        this.fg = 0;
        this.bg = 0;
        this.fgPrev = 0;
        this.bgPrev = 0;
        this.fg = fg;
        this.bg = bg;
        this.fgPrev = fg;
        this.bgPrev = bg;
    }
}
class ResolvedEscapeSeq {
    constructor() {
        this.varValue = null;
        this.tileIndex = null;
    }
}

},{"./TGL_RuntimeError":12,"./TileSeq":17}],8:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.KeyboardInput = void 0;
class KeyboardInput {
    constructor() {
        this.keystates = {};
        window.addEventListener("keydown", (e) => {
            this.onKeyDown(e);
        });
        window.addEventListener("keyup", (e) => {
            this.onKeyUp(e);
        });
    }
    onKeyDown(e) {
        const key = this.getKeyName(e);
        this.setKeyState(key, true);
    }
    onKeyUp(e) {
        const key = this.getKeyName(e);
        this.setKeyState(key, false);
    }
    setKeyState(key, state) {
        if (key !== "UNKNOWN") {
            this.keystates[key] = state;
        }
    }
    getKeyState(key) {
        const state = this.keystates[key];
        if (state === undefined) {
            return false;
        }
        else {
            return state;
        }
    }
    getKeyName(e) {
        let key = "";
        if (e.ctrlKey)
            key += "CTRL+";
        if (e.shiftKey)
            key += "SHIFT+";
        if (e.altKey)
            key += "ALT+";
        switch (e.key) {
            case " ":
                key += "SPACE";
                break;
            case "ArrowRight":
                key += "RIGHT";
                break;
            case "ArrowLeft":
                key += "LEFT";
                break;
            case "ArrowUp":
                key += "UP";
                break;
            case "ArrowDown":
                key += "DOWN";
                break;
            case "End":
                key += "END";
                break;
            case "Home":
                key += "HOME";
                break;
            case "PageDown":
                key += "PGDN";
                break;
            case "PageUp":
                key += "PGUP";
                break;
            case "Enter":
                key += "ENTER";
                break;
            case "Insert":
                key += "INS";
                break;
            case "Delete":
                key += "DEL";
                break;
            case "Backspace":
                key += "BS";
                break;
            case "Escape":
                key += "ESC";
                break;
            case "Tab":
                key += "TAB";
                break;
            case "A":
            case "a":
                key += "A";
                break;
            case "B":
            case "b":
                key += "B";
                break;
            case "C":
            case "c":
                key += "C";
                break;
            case "D":
            case "d":
                key += "D";
                break;
            case "E":
            case "e":
                key += "E";
                break;
            case "F":
            case "f":
                key += "F";
                break;
            case "G":
            case "g":
                key += "G";
                break;
            case "H":
            case "h":
                key += "H";
                break;
            case "I":
            case "i":
                key += "I";
                break;
            case "J":
            case "j":
                key += "J";
                break;
            case "K":
            case "k":
                key += "K";
                break;
            case "L":
            case "l":
                key += "L";
                break;
            case "M":
            case "m":
                key += "M";
                break;
            case "N":
            case "n":
                key += "N";
                break;
            case "O":
            case "o":
                key += "O";
                break;
            case "P":
            case "p":
                key += "P";
                break;
            case "Q":
            case "q":
                key += "Q";
                break;
            case "R":
            case "r":
                key += "R";
                break;
            case "S":
            case "s":
                key += "S";
                break;
            case "T":
            case "t":
                key += "T";
                break;
            case "U":
            case "u":
                key += "U";
                break;
            case "V":
            case "v":
                key += "V";
                break;
            case "W":
            case "w":
                key += "W";
                break;
            case "X":
            case "x":
                key += "X";
                break;
            case "Y":
            case "y":
                key += "Y";
                break;
            case "Z":
            case "z":
                key += "Z";
                break;
            case "Ç":
            case "ç":
                key += "Ç";
                break;
            case "0":
                key += "0";
                break;
            case "1":
                key += "1";
                break;
            case "2":
                key += "2";
                break;
            case "3":
                key += "3";
                break;
            case "4":
                key += "4";
                break;
            case "5":
                key += "5";
                break;
            case "6":
                key += "6";
                break;
            case "7":
                key += "7";
                break;
            case "8":
                key += "8";
                break;
            case "9":
                key += "9";
                break;
            case "+":
                key += "+";
                break;
            case "-":
                key += "-";
                break;
            case "*":
                key += "*";
                break;
            case "/":
                key += "/";
                break;
            case "=":
                key += "=";
                break;
            case ".":
                key += ".";
                break;
            case ",":
                key += ",";
                break;
            case ";":
                key += ";";
                break;
            case "'":
                key += "'";
                break;
            case "[":
                key += "[";
                break;
            case "]":
                key += "]";
                break;
            default: return "UNKNOWN";
        }
        return key;
    }
}
exports.KeyboardInput = KeyboardInput;

},{}],9:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Palette = void 0;
class Palette {
    constructor() {
        this.colors = [];
    }
    init(numberOfColors, defaultColor) {
        this.colors = [];
        for (let i = 0; i < numberOfColors; i++) {
            this.colors.push(defaultColor);
        }
        return this.colors;
    }
    set(ix, color) {
        this.colors[ix] = color;
    }
    get(ix) {
        return this.colors[ix];
    }
    size() {
        return this.colors.length;
    }
}
exports.Palette = Palette;

},{}],10:[function(require,module,exports){
"use strict";
var _a;
Object.defineProperty(exports, "__esModule", { value: true });
exports.PixelBlock = void 0;
class PixelBlock {
    constructor() {
        this.pixels = "";
        this.clear();
    }
    clear() {
        this.pixels = "";
        for (let i = 0; i < PixelBlock.Size; i++) {
            this.pixels += PixelBlock.PixelOff;
        }
    }
    toString() {
        return this.pixels;
    }
    setPixelRow(pixelRow, byte) {
        const bitIndex = pixelRow * PixelBlock.Width;
        let currentPixels = this.pixels;
        let newPixels = "";
        const binaryRow = byte.toString(2).padStart(PixelBlock.Width, PixelBlock.PixelOff);
        for (let i = 0; i < currentPixels.length; i++) {
            if (i >= bitIndex && i < bitIndex + PixelBlock.Width) {
                newPixels += binaryRow[i % PixelBlock.Width];
            }
            else {
                newPixels += currentPixels[i];
            }
        }
        this.pixels = newPixels;
    }
    setPixelRows(r0, r1, r2, r3, r4, r5, r6, r7) {
        this.setPixelRow(0, r0);
        this.setPixelRow(1, r1);
        this.setPixelRow(2, r2);
        this.setPixelRow(3, r3);
        this.setPixelRow(4, r4);
        this.setPixelRow(5, r5);
        this.setPixelRow(6, r6);
        this.setPixelRow(7, r7);
    }
    getRowAsByte(pixelRow) {
        const binary = this.getRowAsBinaryString(pixelRow);
        const rowPixels = Number.parseInt(binary, 2);
        return rowPixels;
    }
    getRowAsBinaryString(pixelRow) {
        const bitIndex = pixelRow * PixelBlock.Width;
        let binary = "";
        for (let i = bitIndex; i < bitIndex + PixelBlock.Width; i++) {
            binary += this.pixels[i];
        }
        return binary;
    }
    getRowsAsBytes() {
        let bytes = [];
        for (let row = 0; row < PixelBlock.Height; row++) {
            bytes.push(this.getRowAsByte(row));
        }
        return bytes;
    }
    getRowsAsBinaryStrings() {
        let str = [];
        for (let row = 0; row < PixelBlock.Height; row++) {
            str.push(this.getRowAsBinaryString(row));
        }
        return str;
    }
}
exports.PixelBlock = PixelBlock;
_a = PixelBlock;
PixelBlock.Width = 8;
PixelBlock.Height = 8;
PixelBlock.Size = _a.Width * _a.Height;
PixelBlock.PixelOn = '1';
PixelBlock.PixelOff = '0';

},{}],11:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TGL_InitializationError = void 0;
class TGL_InitializationError extends Error {
    constructor(msg) {
        super();
        Object.setPrototypeOf(this, new.target.prototype);
        this.stack = undefined;
        this.message = msg;
    }
}
exports.TGL_InitializationError = TGL_InitializationError;

},{}],12:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TGL_RuntimeError = void 0;
class TGL_RuntimeError extends Error {
    constructor(msg) {
        super();
        Object.setPrototypeOf(this, new.target.prototype);
        this.stack = undefined;
        this.message = msg;
    }
}
exports.TGL_RuntimeError = TGL_RuntimeError;

},{}],13:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Tile = void 0;
class Tile {
    constructor() {
        this.ix = 0;
        this.fgc = 0;
        this.bgc = 0;
    }
    set(ix, fgc, bgc) {
        this.ix = ix;
        this.fgc = fgc;
        this.bgc = bgc;
    }
    setEqual(other) {
        this.ix = other.ix;
        this.fgc = other.fgc;
        this.bgc = other.bgc;
    }
    setBlank() {
        this.ix = 0;
        this.fgc = 0;
        this.bgc = 0;
    }
}
exports.Tile = Tile;

},{}],14:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TileBuffer = void 0;
const TileBufferLayer_1 = require("./TileBufferLayer");
const TileSeq_1 = require("./TileSeq");
const Viewport_1 = require("./Viewport");
class TileBuffer {
    constructor(id, layerCount, w, h) {
        this.id = id;
        this.layerCount = layerCount;
        this.width = w;
        this.height = h;
        this.size = w * h;
        this.layers = [];
        for (let i = 0; i < layerCount; i++) {
            const emptyLayer = new TileBufferLayer_1.TileBufferLayer(w, h);
            this.layers.push(emptyLayer);
        }
        this.view = new Viewport_1.Viewport(0, 0, w, h);
        this.visible = true;
    }
    clearAllLayers() {
        for (let i = 0; i < this.layerCount; i++) {
            this.clearLayer(i);
        }
    }
    clearLayer(layer) {
        this.layers[layer].clear();
    }
    setTile(tile, layer, x, y) {
        this.layers[layer].setTile(tile, x, y);
    }
    setTileString(str, cursor, fgc, bgc, transp) {
        const px = cursor.x;
        for (let i = 0; i < str.length; i++) {
            const tile = new TileSeq_1.TileSeq();
            const ch = str.charCodeAt(i);
            if (str.charAt(i) === "\n") {
                cursor.y++;
                cursor.x = px;
            }
            else {
                tile.transparent = transp;
                tile.setSingle(ch, fgc, bgc);
                this.setTile(tile, cursor.layer, cursor.x, cursor.y);
                cursor.x++;
            }
        }
    }
    overlapTileString(str, layer, x, y, fgc, bgc, transp) {
        for (let i = 0; i < str.length; i++) {
            const tile = this.getTileRef(layer, x + i, y);
            const ch = str.charCodeAt(i);
            tile.transparent = transp;
            tile.add(ch, fgc, bgc);
        }
    }
    getTileCopy(layer, x, y) {
        return this.layers[layer].getTileCopy(x, y);
    }
    getTileRef(layer, x, y) {
        return this.layers[layer].getTileRef(x, y);
    }
}
exports.TileBuffer = TileBuffer;

},{"./TileBufferLayer":15,"./TileSeq":17,"./Viewport":19}],15:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TileBufferLayer = void 0;
const TileSeq_1 = require("./TileSeq");
class TileBufferLayer {
    constructor(w, h) {
        this.width = w;
        this.height = h;
        this.size = w * h;
        this.tiles = [];
        for (let i = 0; i < this.size; i++) {
            const emptyTile = new TileSeq_1.TileSeq();
            this.tiles.push(emptyTile);
        }
    }
    clear() {
        for (let i = 0; i < this.size; i++) {
            this.tiles[i].deleteAll();
        }
    }
    setTile(tile, x, y) {
        if (x >= 0 && y >= 0 && x < this.width && y < this.height) {
            const pos = y * this.width + x;
            this.tiles[pos].setEqual(tile);
        }
    }
    getTileCopy(x, y) {
        const tile = new TileSeq_1.TileSeq();
        tile.setEqual(this.getTileRef(x, y));
        return tile;
    }
    getTileRef(x, y) {
        return this.tiles[y * this.width + x];
    }
}
exports.TileBufferLayer = TileBufferLayer;

},{"./TileSeq":17}],16:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TGL = void 0;
const TGL_InitializationError_1 = require("./TGL_InitializationError");
const TGL_RuntimeError_1 = require("./TGL_RuntimeError");
const Palette_1 = require("./Palette");
const Tileset_1 = require("./Tileset");
const Display_1 = require("./Display");
const Cursor_1 = require("./Cursor");
const TileSeq_1 = require("./TileSeq");
const DefaultTileset_1 = require("./DefaultTileset");
const DefaultPalette_1 = require("./DefaultPalette");
const FmtStringPrinter_1 = require("./FmtStringPrinter");
const KeyboardInput_1 = require("./KeyboardInput");
document.addEventListener("DOMContentLoaded", () => {
    const global = window;
    global.tgl = new TGL("TGL_Display");
    global.tgl.init();
    global.tgl.runLoop();
});
class TGL {
    constructor(displayElementId) {
        this.log("Initializing...");
        this.initialized = false;
        const displayElement = document.getElementById(displayElementId);
        if (!displayElement) {
            throw new TGL_InitializationError_1.TGL_InitializationError(`Display element not found with id: ${displayElementId}`);
        }
        this.displayElement = displayElement;
        this.display = null;
        this.palette = new Palette_1.Palette();
        this.tileset = new Tileset_1.Tileset();
        this.cursor = null;
        this.currentTile = new TileSeq_1.TileSeq();
        this.currentTextFgc = 1;
        this.currentTextBgc = 0;
        this.keyboard = new KeyboardInput_1.KeyboardInput();
        this.animationInterval = 400;
        this.autoVsyncHandle = 0;
        this.runLoopActive = false;
        this.runLoopHandle = 0;
        this.exited = false;
        DefaultPalette_1.DefaultPalette.init(this.palette);
        DefaultTileset_1.DefaultTileset.init(this.tileset);
        this.runAutoVsync();
    }
    log(msg) {
        console.log(`%c[TileGameLib]%c ${msg}`, "color:#0f0", "color:#fff");
    }
    getGlobals() {
        return window;
    }
    init() {
        if (this.initialized) {
            throw new TGL_InitializationError_1.TGL_InitializationError(`TGL_Init function has already been called once`);
        }
        const global = this.getGlobals();
        if (!global.TGL_Init) {
            throw new TGL_InitializationError_1.TGL_InitializationError(`TGL_Init function not found`);
        }
        this.log("TGL_Init started...");
        global.TGL_Init();
        this.log("TGL_Init finished");
        this.initialized = true;
    }
    runLoop() {
        if (this.exited) {
            return;
        }
        const global = this.getGlobals();
        if (!global.TGL_Loop) {
            throw new TGL_InitializationError_1.TGL_InitializationError(`TGL_Loop function not found`);
        }
        if (!this.runLoopActive) {
            this.runLoopActive = true;
            this.log("TGL_Loop started...");
        }
        global.TGL_Loop();
        this.runLoopHandle = window.requestAnimationFrame(() => this.runLoop());
    }
    runAutoVsync() {
        if (this.display) {
            this.display.update();
        }
        this.autoVsyncHandle = window.requestAnimationFrame(() => this.runAutoVsync());
    }
    stopAutoVsync() {
        window.cancelAnimationFrame(this.autoVsyncHandle);
    }
    // Commands:
    TEST() {
        this.log("TEST executed");
    }
    EXIT() {
        if (!this.exited) {
            this.exited = true;
            window.cancelAnimationFrame(this.runLoopHandle);
            this.log("TGL_Loop finished");
        }
    }
    RESET() {
        if (this.display) {
            this.display.reset();
            if (this.cursor) {
                this.cursor.reset(this.display.getDefaultBuffer());
            }
        }
        this.currentTile = new TileSeq_1.TileSeq();
        this.currentTextFgc = 1;
        this.currentTextBgc = 0;
        DefaultPalette_1.DefaultPalette.init(this.palette);
        DefaultTileset_1.DefaultTileset.init(this.tileset);
    }
    KEY(key) {
        return this.keyboard.getKeyState(key);
    }
    SCREEN(width, height, hStretch, vStretch, defaultBufLayers) {
        if (this.display) {
            this.display.reset();
            if (this.cursor) {
                this.cursor.set(this.display.getDefaultBuffer(), 0, 0, 0);
            }
        }
        else {
            this.display = new Display_1.Display(this.displayElement, width, height, hStretch, vStretch, defaultBufLayers, this.palette, this.tileset, this.animationInterval);
            this.cursor = new Cursor_1.Cursor(this.display.getDefaultBuffer());
        }
    }
    PAL(ix, rgb) {
        this.palette.set(ix, rgb);
    }
    CLS() {
        if (this.display) {
            this.display.clearAllBuffers();
        }
        if (this.cursor) {
            this.cursor.setPos(0, 0);
        }
    }
    WCOL(color) {
        if (this.display) {
            this.display.setBackColorIx(color);
        }
    }
    FCOL(color) {
        this.currentTextFgc = color;
    }
    BCOL(color) {
        this.currentTextBgc = color;
    }
    COLOR(fgc, bgc) {
        this.currentTextFgc = fgc;
        this.currentTextBgc = bgc;
    }
    ROWS() {
        if (this.cursor) {
            return this.cursor.buffer.height;
        }
        else {
            return 0;
        }
    }
    COLS() {
        if (this.cursor) {
            return this.cursor.buffer.width;
        }
        else {
            return 0;
        }
    }
    LOCATE(x, y) {
        if (this.cursor) {
            this.cursor.setPos(x, y);
        }
    }
    PRINT(fmt) {
        if (this.display && this.cursor) {
            const stringFmt = new FmtStringPrinter_1.FmtStringPrinter(this);
            stringFmt.print(fmt, this.cursor, this.currentTextFgc, this.currentTextBgc, this.currentTile.transparent);
            if (stringFmt.error) {
                throw new TGL_RuntimeError_1.TGL_RuntimeError(`${stringFmt.error}: ${fmt}`);
            }
        }
    }
    PRINTL(fmt) {
        this.PRINT(fmt + "{LF}");
    }
}
exports.TGL = TGL;

},{"./Cursor":2,"./DefaultPalette":3,"./DefaultTileset":4,"./Display":5,"./FmtStringPrinter":7,"./KeyboardInput":8,"./Palette":9,"./TGL_InitializationError":11,"./TGL_RuntimeError":12,"./TileSeq":17,"./Tileset":18}],17:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.TileSeq = void 0;
const Tile_1 = require("./Tile");
class TileSeq {
    constructor() {
        this.frames = [];
        this.transparent = false;
    }
    deleteAll() {
        this.frames = [];
    }
    add(ix, fgc, bgc) {
        const frame = new Tile_1.Tile();
        frame.set(ix, fgc, bgc);
        this.frames.push(frame);
    }
    set(frame, ix, fgc, bgc) {
        this.frames[frame].set(ix, fgc, bgc);
    }
    setSingle(ix, fgc, bgc) {
        this.deleteAll();
        this.add(ix, fgc, bgc);
    }
    isEmpty() {
        return this.frames.length === 0;
    }
    setEqual(other) {
        this.transparent = other.transparent;
        this.frames = [];
        for (let i = 0; i < other.frames.length; i++) {
            const tile = new Tile_1.Tile();
            tile.setEqual(other.frames[i]);
            this.frames.push(tile);
        }
    }
}
exports.TileSeq = TileSeq;

},{"./Tile":13}],18:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Tileset = void 0;
const PixelBlock_1 = require("./PixelBlock");
class Tileset {
    constructor() {
        this.tiles = [];
    }
    initBlank(numberOfTiles) {
        this.tiles = [];
        for (let i = 0; i < numberOfTiles; i++) {
            this.tiles.push(new PixelBlock_1.PixelBlock());
        }
        return this.tiles;
    }
    set(ix, r0, r1, r2, r3, r4, r5, r6, r7) {
        this.tiles[ix].setPixelRows(r0, r1, r2, r3, r4, r5, r6, r7);
    }
    setPixelRow(ix, pixelRow, byte) {
        this.tiles[ix].setPixelRow(pixelRow, byte);
    }
    get(ix) {
        return this.tiles[ix];
    }
    size() {
        return this.tiles.length;
    }
}
exports.Tileset = Tileset;

},{"./PixelBlock":10}],19:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Viewport = void 0;
class Viewport {
    constructor(dispX, dispY, w, h) {
        this.displayX = dispX;
        this.displayY = dispY;
        this.width = w;
        this.height = h;
        this.scrollX = 0;
        this.scrollY = 0;
    }
    set(dispX, dispY, w, h) {
        this.displayX = dispX;
        this.displayY = dispY;
        this.width = w;
        this.height = h;
    }
    scroll(dx, dy) {
        this.scrollX += dx;
        this.scrollY += dy;
    }
}
exports.Viewport = Viewport;

},{}]},{},[16]);
