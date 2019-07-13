﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameSamples
{
    public partial class MainMenuWindow : Form
    {
        private readonly List<DisplayWindow> Samples = new List<DisplayWindow>();

        public MainMenuWindow()
        {
            InitializeComponent();

            Samples.Add(new GraphicsSampleWindow());

            SampleListBox.DataSource = Samples;
            SampleListBox.DisplayMember = "Text";
            SampleListBox.DoubleClick += SampleListBox_DoubleClick;
        }

        private void SampleListBox_DoubleClick(object sender, EventArgs e)
        {
            DisplayWindow sample = (DisplayWindow)SampleListBox.SelectedValue;
            if (sample != null)
                sample.ShowDialog();
        }
    }
}
