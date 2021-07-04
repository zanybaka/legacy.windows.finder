namespace Samples.Finder.Components.Common.Plugins.Mp3Plugin
{
    partial class Mp3Filter
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
            this.txtTitlePart = new System.Windows.Forms.TextBox();
            this.lblTitleContains = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTitlePart
            // 
            this.txtTitlePart.Location = new System.Drawing.Point(133, 0);
            this.txtTitlePart.Name = "txtTitlePart";
            this.txtTitlePart.Size = new System.Drawing.Size(277, 20);
            this.txtTitlePart.TabIndex = 0;
            // 
            // lblTitleContains
            // 
            this.lblTitleContains.AutoSize = true;
            this.lblTitleContains.Location = new System.Drawing.Point(-3, 3);
            this.lblTitleContains.Name = "lblTitleContains";
            this.lblTitleContains.Size = new System.Drawing.Size(129, 13);
            this.lblTitleContains.TabIndex = 1;
            this.lblTitleContains.Text = "Title (id1) contains:";
            // 
            // Mp3Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblTitleContains);
            this.Controls.Add(this.txtTitlePart);
            this.Name = "Mp3Filter";
            this.Size = new System.Drawing.Size(415, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitlePart;
        private System.Windows.Forms.Label lblTitleContains;
    }
}
