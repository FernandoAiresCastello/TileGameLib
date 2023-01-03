export class PixelBlock {

    static readonly Width = 8;
    static readonly Height = 8;
    static readonly Size = this.Width * this.Height;
    static readonly PixelOn: string = '1';
    static readonly PixelOff: string = '0';

    pixels: string;

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

    toString(): string {
        return this.pixels;
    }

    setPixelRow(pixelRow: number, byte: number) {
        const bitIndex = pixelRow * PixelBlock.Width;
        let currentPixels = this.pixels;
        let newPixels = "";
        const binaryRow = byte.toString(2).padStart(PixelBlock.Width, PixelBlock.PixelOff);
        for (let i = 0; i < currentPixels.length; i++) {
            if (i >= bitIndex && i < bitIndex + PixelBlock.Width) {
                newPixels += binaryRow[i % PixelBlock.Width];
            } else {
                newPixels += currentPixels[i];
            }
        }
        this.pixels = newPixels;
    }

    setPixelRows(r0: number, r1: number, r2: number, r3: number, r4: number, r5: number, r6: number, r7: number) {
        this.setPixelRow(0, r0);
        this.setPixelRow(1, r1);
        this.setPixelRow(2, r2);
        this.setPixelRow(3, r3);
        this.setPixelRow(4, r4);
        this.setPixelRow(5, r5);
        this.setPixelRow(6, r6);
        this.setPixelRow(7, r7);
    }

    getRowAsByte(pixelRow: number): number {
        const binary = this.getRowAsBinaryString(pixelRow);
        const rowPixels = Number.parseInt(binary, 2);
        return rowPixels;
    }

    getRowAsBinaryString(pixelRow: number): string {
        const bitIndex = pixelRow * PixelBlock.Width;
        let binary = "";
        for (let i = bitIndex; i < bitIndex + PixelBlock.Width; i++) {
            binary += this.pixels[i];
        }
        return binary;
    }

    getRowsAsBytes(): number[] {
        let bytes = [];
        for (let row = 0; row < PixelBlock.Height; row++) {
            bytes.push(this.getRowAsByte(row));
        }
        return bytes;
    }

    getRowsAsBinaryStrings(): string[] {
        let str = [];
        for (let row = 0; row < PixelBlock.Height; row++) {
            str.push(this.getRowAsBinaryString(row));
        }
        return str;
    }
}
