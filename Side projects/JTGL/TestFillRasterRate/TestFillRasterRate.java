import java.awt.Graphics;
import java.awt.event.*;
import java.awt.image.*;
import javax.swing.*;
import java.util.Random;

public class TestFillRasterRate
{
    static class MyFrame extends JFrame
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
			if (w != getWidth() || h != getHeight())
			{
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
					raster[ptr++] = random.ints(0x000000, 0xffffff).findFirst().getAsInt();
				}
			}

			// draw raster
			g.drawImage(backBuffer, 0, 0, null);
			framesDrawn++;
		}
	}

    public static void main(String[] args)
    {
		final MyFrame frame = new MyFrame();

        frame.setSize(800, 600);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);

		frame.addMouseListener(new MouseListener() {

			@Override
			public void mouseClicked(MouseEvent e) {
				frame.setTitle(e.getX() + "," + e.getY());
			}

			@Override
			public void mousePressed(MouseEvent e) {
			}

			@Override
			public void mouseReleased(MouseEvent e) {
			}

			@Override
			public void mouseEntered(MouseEvent e) {
			}

			@Override
			public void mouseExited(MouseEvent e) {
			}
			
		});

        // draw FPS in title
        new Timer(1000, new ActionListener()
        {
			@Override
			public void actionPerformed(ActionEvent e)
            {   //frame.setTitle(Long.toString(frame.framesDrawn));
                frame.framesDrawn = 0;
            }
			
        }).start();

		frame.createBufferStrategy(1);
		BufferStrategy bs = frame.getBufferStrategy();
		Graphics g = bs.getDrawGraphics();
		
		while (true)
		{
			frame.draw(g);
		}
    }
}