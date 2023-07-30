namespace TileGameMaker.Windows
{
    partial class StringInputWindow
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
            this.LbLabel = new System.Windows.Forms.Label();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbLabel
            // 
            this.LbLabel.AutoSize = true;
            this.LbLabel.Location = new System.Drawing.Point(13, 13);
            this.LbLabel.Name = "LbLabel";
            this.LbLabel.Size = new System.Drawing.Size(33, 13);
            this.LbLabel.TabIndex = 0;
            this.LbLabel.Text = "Label";
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(15, 36);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(397, 20);
            this.TxtValue.TabIndex = 1;
            this.TxtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValue_KeyDown);
            // 
            // StringInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 71);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.LbLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StringInputWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbLabel;
        private System.Windows.Forms.TextBox TxtValue;
    }
}