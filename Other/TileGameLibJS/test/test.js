function TGL_Init() {
    tgl.SCREEN(256, 192, 4, 4, 2);
    tgl.PAL(0, "#000000");
    tgl.PAL(1, "#ffffff");
    tgl.PAL(2, "#ff0000");
    tgl.PAL(3, "#00ff00");
    tgl.PAL(4, "#0000ff");
    tgl.PAL(5, "#ffff00");
    tgl.PAL(6, "#ff00ff");
    tgl.PAL(7, "#00ffff");
}

var x = 0;
var y = 0;

function TGL_Loop() {
    tgl.CLS();
    tgl.LOCATE(1,1);
    tgl.PRINTL(`{f3}X: {/f}${x}`);
    tgl.PRINTL(`{f3}Y: {/f}${y}`);

    if (tgl.KEY("RIGHT")) x++;
    if (tgl.KEY("LEFT")) x--;
    if (tgl.KEY("DOWN")) y++;
    if (tgl.KEY("UP")) y--;
    if (tgl.KEY("ESC")) tgl.EXIT();
}
