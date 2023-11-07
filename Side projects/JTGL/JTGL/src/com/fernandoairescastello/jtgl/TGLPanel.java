package com.fernandoairescastello.jtgl;

import javax.swing.*;
import java.awt.*;

public class TGLPanel extends JPanel
{
    private final int bufferWidth = 352;
    private final int bufferHeight = 200;
    private final int[][] pixels;

    public TGLPanel(TGLWindow parent) {
        pixels = new int[bufferHeight][bufferWidth];
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        update(g);
    }

    public void update(Graphics g) {
        final int pixelWidth = getWidth() / bufferWidth;
        final int pixelHeight = getHeight() / bufferHeight;

        for (int y = 0; y < bufferHeight; y++) {
            for (int x = 0; x < bufferWidth; x++) {
                g.setColor(new Color(pixels[y][x]));
                final int px = x * pixelWidth;
                final int py = y * pixelHeight;
                g.fillRect(px, py, pixelWidth, pixelHeight);
            }
        }
    }
}
