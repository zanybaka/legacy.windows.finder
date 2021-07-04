namespace Samples.Finder.Application.Controls
{
    partial class ResultList
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
            this.lbResults = new System.Windows.Forms.ListBox();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbResults
            // 
            this.lbResults.CausesValidation = false;
            this.lbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResults.HorizontalScrollbar = true;
            this.lbResults.IntegralHeight = false;
            this.lbResults.ItemHeight = 16;
            this.lbResults.Location = new System.Drawing.Point(4, 19);
            this.lbResults.Margin = new System.Windows.Forms.Padding(14);
            this.lbResults.Name = "lbResults";
            this.lbResults.ScrollAlwaysVisible = true;
            this.lbResults.Size = new System.Drawing.Size(771, 375);
            this.lbResults.TabIndex = 0;
            this.lbResults.DoubleClick += new System.EventHandler(this.OnResultsDoubleClick);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.lbResults);
            this.gbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResults.Location = new System.Drawing.Point(0, 0);
            this.gbResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbResults.Name = "gbResults";
            this.gbResults.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbResults.Size = new System.Drawing.Size(779, 398);
            this.gbResults.TabIndex = 1;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Search &results:";
            // 
            // ResultList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gbResults);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ResultList";
            this.Size = new System.Drawing.Size(779, 398);
            this.gbResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.ListBox lbResults;
    }
}
