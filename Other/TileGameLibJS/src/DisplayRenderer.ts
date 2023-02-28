import { TGL_InitializationError } from "./TGL_InitializationError";
import { CanvasPoint } from "./CanvasPoint";
import { ColorString, PaletteIndex } from "./ColorTypes";
import { Palette } from "./Palette";
import { PixelBlock } from "./PixelBlock";
import { Tile } from "./Tile";
import { Tileset } from "./Tileset";

export class DisplayRenderer {

    backColorIx: PaletteIndex = 0;
    readonly cols: number;
    readonly rows: number;
    private readonly palette: Palette;
    private readonly tileset: Tileset;

    private canvasElement: HTMLCanvasElement;
    private canvas: CanvasRenderingContext2D;
    private canvasWidth: number;
    private canvasHeight: number;
    private pixelBufWidth: number;
    private pixelBufHeight: number;
    private pixelBufSize: number;
    private pixels: ColorString[];
    private pixelWidth: number;
    private pixelHeight: number;
    private pixelPositions: CanvasPoint[];

    constructor(parentElement: HTMLElement, 
        bufWidth: number, bufHeight: number, 
        pixelWidth: number, pixelHeight: number, 
        palette: Palette, tileset: Tileset) {
        
        this.pixelBufWidth = bufWidth;
        this.pixelBufHeight = bufHeight;
        this.pixelBufSize = bufWidth * bufHeight;
        this.pixelWidth = pixelWidth;
        this.pixelHeight = pixelHeight;
        this.canvasWidth = bufWidth * pixelWidth;
        this.canvasHeight = bufHeight * pixelHeight;
        this.cols = bufWidth / PixelBlock.Width;
        this.rows = bufHeight / PixelBlock.Height;
        this.palette = palette;
        this.tileset = tileset;

        this.canvasElement = document.createElement("canvas");
        this.canvasElement.width = this.canvasWidth;
        this.canvasElement.height = this.canvasHeight;
        parentElement.append(this.canvasElement);

        let ctx = this.canvasElement.getContext("2d");
        if (ctx === null) {
            throw new TGL_InitializationError("Unable to create CanvasRenderingContext2D");
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

    drawTileFrame(tile: Tile, x: number, y: number, transparent: boolean) {
        x *= PixelBlock.Width;
        y *= PixelBlock.Height;
        const px = x;
        const xmax = x + PixelBlock.Width;
        const pixelBlock = this.tileset.get(tile.ix);
        for (let i = 0; i < pixelBlock.pixels.length; i++) {
            const pixel = pixelBlock.pixels[i];
            const fgc = this.palette.get(tile.fgc);
            const bgc = this.palette.get(tile.bgc);
            if (pixel === PixelBlock.PixelOn) {
                this.setPixelRgb(x, y, fgc);
            } else if (pixel === PixelBlock.PixelOff && !transparent) {
                this.setPixelRgb(x, y, bgc);
            }
            x++;
            if (x >= xmax) {
                x = px;
                y++;
            }
        }
    }

    private clearToColor(ix: PaletteIndex) {
        const color = this.palette.get(ix);
        this.clearToColorRgb(color);
    }

    private clearToColorRgb(color: ColorString) {
        for (let pos = 0; pos < this.pixelBufSize; pos++) {
            this.setPixelRgbLinear(pos, color);
        }
    }

    private setPixelRgbLinear(pos: number, color: ColorString) {
        this.pixels[pos] = color;
    }

    private setPixelRgb(x: number, y: number, color: ColorString) {
        this.pixels[y * this.pixelBufWidth + x] = color;
    }

    private calculatePixelPositions() : CanvasPoint[] {
        const positions = [];
        let canvasX = 0;
        let canvasY = 0;
        for (let pixelBufIndex = 0; pixelBufIndex < this.pixelBufSize; pixelBufIndex++) {
            positions.push(new CanvasPoint(canvasX, canvasY, pixelBufIndex));
            canvasX += this.pixelWidth;
            if (canvasX >= this.canvasWidth) {
                canvasX = 0;
                canvasY += this.pixelHeight;
            }
        }
        return positions;
    }
}
