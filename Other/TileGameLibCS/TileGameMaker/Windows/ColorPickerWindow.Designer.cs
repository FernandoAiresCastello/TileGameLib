namespace TileGameMaker.Windows
{
    partial class ColorPickerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlColorPicker = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PnlColorPicker
            // 
            this.PnlColorPicker.AutoScroll = true;
            this.PnlColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlColorPicker.Location = new System.Drawing.Point(1, 0);
            this.PnlColorPicker.Name = "PnlColorPicker";
            this.PnlColorPicker.Size = new System.Drawing.Size(213, 212);
            this.PnlColorPicker.TabIndex = 0;
            // 
            // ColorPickerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 212);
            this.Controls.Add(this.PnlColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPickerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Color";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorPickerWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlColorPicker;
    }
}