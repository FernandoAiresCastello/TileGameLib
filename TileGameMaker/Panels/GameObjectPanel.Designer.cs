﻿namespace TileGameMaker.Panels
{
    partial class GameObjectPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtObject = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtObject);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 206);
            this.panel1.TabIndex = 0;
            // 
            // TxtObject
            // 
            this.TxtObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObject.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObject.Location = new System.Drawing.Point(0, 0);
            this.TxtObject.Margin = new System.Windows.Forms.Padding(0);
            this.TxtObject.Multiline = true;
            this.TxtObject.Name = "TxtObject";
            this.TxtObject.ReadOnly = true;
            this.TxtObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtObject.Size = new System.Drawing.Size(150, 206);
            this.TxtObject.TabIndex = 1;
            this.TxtObject.WordWrap = false;
            // 
            // GameObjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "GameObjectPanel";
            this.Size = new System.Drawing.Size(150, 206);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtObject;
    }
}
