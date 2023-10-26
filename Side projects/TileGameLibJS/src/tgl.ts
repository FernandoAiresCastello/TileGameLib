import { Log } from "./log";

export class TGL
{
    constructor() {
        Log.info("TGL singleton created!");
    }

    hello() {
        Log.info("Hello World!");
    }
}

document.addEventListener("DOMContentLoaded", (event) => {
    (window as any).tgl = new TGL();
});
