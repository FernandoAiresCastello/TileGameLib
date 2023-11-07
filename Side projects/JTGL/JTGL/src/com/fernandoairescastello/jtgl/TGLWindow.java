package com.fernandoairescastello.jtgl;

import javax.swing.*;
import java.awt.*;

public class TGLWindow extends JFrame
{
	final private TGLPanel panel;

	public TGLWindow() {
		setSize(800, 600);
		//setUndecorated(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		setVisible(true);
		setResizable(false);

		panel = new TGLPanel(this);

		BorderLayout layout = new BorderLayout();
		setLayout(layout);
		add(panel, BorderLayout.CENTER);
	}
}
