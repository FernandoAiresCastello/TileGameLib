/**
 * @author       Fernando Aires Castello <fernandoairescastello@gmail.com>
 * @copyright    2023 Fernando Aires Castello
 * @license      {@link https://opensource.org/licenses/MIT|MIT License}
 */

/** Class for a singleton to serve as the entry point for the entire library */
class TGL
{
    constructor() {
        this.info("Singleton constructed")
    }

    /** Print an informational message to the console */
    info(msg) {
        console.info("[TGL] " + msg);
    }

    /** Initialize the display */
    init(canvas_id, buffer_w, buffer_h, pixel_w, pixel_h, backcolor) {
    }

    _screen = {
        width: 0,
        height: 0,
        canvas: null,
        element: null,
        pixels: null,
        backColor: "#101010",
        colorMode: "normal",
        binaryFgc: "#fff",
        binaryBgc: this.backColor,
        clip: null,
        frameCounter: 0,
        pixel_w: 1,
        pixel_h: 1
    };
};
