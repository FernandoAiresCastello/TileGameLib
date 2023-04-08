const tgl = new TGL();

main();

function main() {
    tgl.init(256, 192);
    tgl.horizontalStretch(70);

    const tile = 
        "11111111" +
        "10000001" +
        "10000001" +
        "10000001" +
        "10000001" +
        "10000001" +
        "10000001" +
        "11111111";

    const tile2 = [
        '#f00','#0ff','#f00','#0ff','#f0f','#0ff','#f0f','#0ff',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0f0','#0f0','#0f0','#0f0','#0f0','#0f0','#f00',
        '#f00','#0ff','#f00','#0ff','#f0f','#0ff','#f0f','#0ff'
    ];

    tgl.backColor("#008");
    tgl.cls();
    tgl.colorNormal();
    tgl.drawFree(tile2, 0, 0);
    tgl.colorBinary("#ff0", "#f0f");
    tgl.drawTiled(tile, 1, 1);
    tgl.transparency(true);
    tgl.drawFree(tile, 12, 12);
    tgl.colorBinary("#0f0")
    tgl.printTiled("~Hello World!~", 4, 10);

    /*
    requestAnimationFrame(onFrame);
    function onFrame() {
        tgl.testDrawTiles();
        requestAnimationFrame(onFrame);
    }
    */
}
