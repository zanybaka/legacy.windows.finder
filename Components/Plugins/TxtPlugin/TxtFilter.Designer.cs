namespace Samples.Finder.Components.Common.Plugins.TxtPlugin
{
    partial class TxtFilter
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
            this.txtPart = new System.Windows.Forms.TextBox();
            this.lblContains = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPart
            // 
            this.txtPart.Location = new System.Drawing.Point(54, 0);
            this.txtPart.Name = "txtPart";
            this.txtPart.Size = new System.Drawing.Size(231, 20);
            this.txtPart.TabIndex = 0;
            // 
            // lblContains
            // 
            this.lblContains.AutoSize = true;
            this.lblContains.Location = new System.Drawing.Point(-3, 3);
            this.lblContains.Name = "lblContains";
            this.lblContains.Size = new System.Drawing.Size(51, 13);
            this.lblContains.TabIndex = 1;
            //TODO: get it from resources
            this.lblContains.Text = "Contains:";
            // 
            // TxtFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblContains);
            this.Controls.Add(this.txtPart);
            this.Name = "TxtFilter";
            this.Size = new System.Drawing.Size(288, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPart;
        private System.Windows.Forms.Label lblContains;
    }
}
