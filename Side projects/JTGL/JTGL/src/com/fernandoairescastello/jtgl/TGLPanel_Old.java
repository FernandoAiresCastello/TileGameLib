package com.fernandoairescastello.jtgl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.image.*;
import java.util.Random;

public class TGLPanel_Old extends JPanel
{
    long framesDrawn;
    final int bufferWidth = 352;
    final int bufferHeight = 200;
    int[] raster;
    ColorModel cm;
    DataBuffer buffer;
    SampleModel sm;
    WritableRaster wrRaster;
    BufferedImage backBuffer;
    Random random = new Random();
    Graphics gr;

    public TGLPanel_Old(TGLWindow parent) {

        raster = new int[bufferWidth * bufferHeight];
        cm = new DirectColorModel(24, 255 << 16, 255 << 8, 255);
        buffer = new DataBufferInt(raster, raster.length);
        sm = cm.createCompatibleSampleModel(bufferWidth, bufferHeight);
        wrRaster = Raster.createWritableRaster(sm, buffer, null);
        backBuffer = new BufferedImage(cm, wrRaster, false, null);

        parent.createBufferStrategy(1);
        BufferStrategy bs = parent.getBufferStrategy();
        gr = bs.getDrawGraphics();

        addComponentListener(new ComponentAdapter() {
            public void componentResized(ComponentEvent evt) {
                Component c = (Component) evt.getSource();
                draw();
            }
        });

        new Timer(1000, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                parent.setTitle(Long.toString(framesDrawn));
                framesDrawn = 0;
            }
        }).start();
    }

    public void draw()
    {
        for (int ptr = 0, x = 0; x < bufferWidth; x++) {
            for (int y = 0; y < bufferHeight; y++) {
                raster[ptr++] = random.ints(0x000000, 0xffffff)
                        .findFirst().getAsInt();
            }
        }

        int x = 0;
        int y = 0;
        int w = getWidth();
        int h = getHeight();

        gr.drawImage(backBuffer, x, y, w, h, null);
        framesDrawn++;
    }
}
