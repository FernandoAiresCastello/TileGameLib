import { PixelBlock } from "./PixelBlock";

export class Tileset {

    tiles: PixelBlock[];

    constructor() {
        this.tiles = [];
    }

    initBlank(numberOfTiles: number): PixelBlock[] {
        this.tiles = [];
        for (let i = 0; i < numberOfTiles; i++) {
            this.tiles.push(new PixelBlock());
        }
        return this.tiles;
    }

    set(ix: number, r0: number, r1: number, r2: number, r3: number, r4: number, r5: number, r6: number, r7: number) {
        this.tiles[ix].setPixelRows(r0, r1, r2, r3, r4, r5, r6, r7);
    }

    setPixelRow(ix: number, pixelRow: number, byte: number) {
        this.tiles[ix].setPixelRow(pixelRow, byte);
    }

    get(ix: number): PixelBlock {
        return this.tiles[ix];
    }

    size(): number {
        return this.tiles.length;
    }
}
