import { ColorString } from "./ColorTypes";

export class Palette {
    
    colors: ColorString[];

    constructor() {
        this.colors = [];
    }

    init(numberOfColors: number, defaultColor: ColorString): ColorString[] {
        this.colors = [];
        for (let i = 0; i < numberOfColors; i++) {
            this.colors.push(defaultColor);
        }
        return this.colors;
    }

    set(ix: number, color: ColorString) {
        this.colors[ix] = color;
    }

    get(ix: number): ColorString {
        return this.colors[ix];
    }

    size(): number {
        return this.colors.length;
    }
}
