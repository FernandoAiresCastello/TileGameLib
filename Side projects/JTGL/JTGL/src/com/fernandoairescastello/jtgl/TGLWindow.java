package com.fernandoairescastello.jtgl;

import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.image.*;
import javax.swing.*;
import java.util.Random;

public class TGLWindow extends JFrame
{
	long framesDrawn;
	final int bufferWidth = 352;
	final int bufferHeight = 200;
	final int windowSize = 3;
	int[] raster;
	ColorModel cm;
	DataBuffer buffer;
	SampleModel sm;
	WritableRaster wrRaster;
	BufferedImage backBuffer;
	Random random = new Random();
	Graphics gr;

	public TGLWindow() {
		setSize(windowSize * bufferWidth, windowSize * bufferHeight);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setVisible(true);
		setResizable(false);

		raster = new int[bufferWidth * bufferHeight];
		cm = new DirectColorModel(24, 255 << 16, 255 << 8, 255);
		buffer = new DataBufferInt(raster, raster.length);
		sm = cm.createCompatibleSampleModel(bufferWidth, bufferHeight);
		wrRaster = Raster.createWritableRaster(sm, buffer, null);
		backBuffer = new BufferedImage(cm, wrRaster, false, null);

		createBufferStrategy(1);
		BufferStrategy bs = getBufferStrategy();
		gr = bs.getDrawGraphics();

		addComponentListener(new ComponentAdapter() {
			public void componentResized(ComponentEvent evt) {
				Component c = (Component) evt.getSource();
				draw();
			}
		});
	}

	public void draw()
	{
		// produce raster
		for (int ptr = 0, x = 0; x < bufferWidth; x++) {
			for (int y = 0; y < bufferHeight; y++) {
				raster[ptr++] = random.ints(0x000000, 0xffffff)
						.findFirst().getAsInt();
			}
		}

		// draw raster
		gr.drawImage(backBuffer, 0, 0, getWidth(), getHeight(), null);
		framesDrawn++;
	}
}
