namespace TileGameLib.Controls
{
    partial class ColorPickerWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			RootPanel = new Panel();
			SuspendLayout();
			// 
			// RootPanel
			// 
			RootPanel.AutoSize = true;
			RootPanel.Location = new Point(0, 0);
			RootPanel.Name = "RootPanel";
			RootPanel.Size = new Size(209, 205);
			RootPanel.TabIndex = 0;
			// 
			// ColorPaletteWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Control;
			ClientSize = new Size(209, 205);
			Controls.Add(RootPanel);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			Name = "ColorPaletteWindow";
			StartPosition = FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel RootPanel;
	}
}
