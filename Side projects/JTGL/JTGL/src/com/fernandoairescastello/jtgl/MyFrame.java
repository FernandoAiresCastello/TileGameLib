package com.fernandoairescastello.jtgl;

import java.awt.Graphics;
import java.awt.image.*;
import javax.swing.*;
import java.util.Random;

public class MyFrame extends JFrame
{
	long framesDrawn;
	int w, h;
	int[] raster;
	ColorModel cm;
	DataBuffer buffer;
	SampleModel sm;
	WritableRaster wrRaster;
	BufferedImage backBuffer;
	Random random = new Random();

	public void draw(Graphics g)
	{
		// reinitialize all if resized
		if (w != getWidth() || h != getHeight()) {
			w = getWidth();
			h = getHeight();
			raster = new int[w*h];
			cm = new DirectColorModel(24, 255 << 16, 255 << 8, 255);
			buffer = new DataBufferInt(raster, raster.length);
			sm = cm.createCompatibleSampleModel(w,h);
			wrRaster = Raster.createWritableRaster(sm, buffer, null);
			backBuffer = new BufferedImage(cm, wrRaster, false, null);
		}

		// produce raster
		for (int ptr = 0, x = 0; x < w; x++) {
			for (int y = 0; y < h; y++) {
				raster[ptr++] = random.ints(0x000000, 0xffffff)
						.findFirst().getAsInt();
			}
		}

		// draw raster
		g.drawImage(backBuffer, 0, 0, null);
		framesDrawn++;
	}
}
