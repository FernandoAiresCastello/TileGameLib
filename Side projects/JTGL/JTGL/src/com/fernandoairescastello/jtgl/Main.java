package com.fernandoairescastello.jtgl;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferStrategy;

public class Main
{
    public static void main(String[] args) {
        TGLWindow wnd = new TGLWindow();

        // draw FPS in title
        new Timer(1000, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                wnd.setTitle(Long.toString(wnd.framesDrawn));
                wnd.framesDrawn = 0;
            }
        }).start();

        while (true) {
            wnd.draw();
        }
    }
}
