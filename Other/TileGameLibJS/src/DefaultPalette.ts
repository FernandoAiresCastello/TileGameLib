import { Palette } from "./Palette";

export class DefaultPalette {

    static init(pal: Palette) {

        pal.init(256, "#000000");
        
        pal.set(0, "#000000");
        pal.set(1, "#ffffff");
    }
}
