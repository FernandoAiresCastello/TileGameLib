package com.fernandoairescastello.jtgl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferStrategy;

public class Main
{
    public static void main(String[] args) {
        MyFrame frame = new MyFrame();

        frame.setSize(800, 600);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);

        // draw FPS in title
        new Timer(1000, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                frame.setTitle(Long.toString(frame.framesDrawn));
                frame.framesDrawn = 0;
            }
        }).start();

        frame.createBufferStrategy(1);
        BufferStrategy bs = frame.getBufferStrategy();
        Graphics g = bs.getDrawGraphics();

        while (true) {
            frame.draw(g);
        }
    }
}
