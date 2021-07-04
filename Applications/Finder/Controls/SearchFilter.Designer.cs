namespace Samples.Finder.Application.Controls
{
    partial class SearchFilter
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
            this.tcFilter = new System.Windows.Forms.TabControl();
            this.tpGeneralFilter = new System.Windows.Forms.TabPage();
            this.ucGeneralFilter = new Samples.Finder.Application.Controls.GeneralFilter();
            this.tpAdvancedFilter = new System.Windows.Forms.TabPage();
            this.ucAdvancedFilter = new Samples.Finder.Application.Controls.AdvancedFilter();
            this.tpPlugins = new System.Windows.Forms.TabPage();
            this.ucPlugins = new Samples.Finder.Application.Controls.Plugins();
            this.panel1.SuspendLayout();
            this.tcFilter.SuspendLayout();
            this.tpGeneralFilter.SuspendLayout();
            this.tpAdvancedFilter.SuspendLayout();
            this.tpPlugins.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 228);
            this.panel1.TabIndex = 0;
            // 
            // tcFilter
            // 
            this.tcFilter.Controls.Add(this.tpGeneralFilter);
            this.tcFilter.Controls.Add(this.tpAdvancedFilter);
            this.tcFilter.Controls.Add(this.tpPlugins);
            this.tcFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFilter.Location = new System.Drawing.Point(0, 0);
            this.tcFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tcFilter.Name = "tcFilter";
            this.tcFilter.SelectedIndex = 0;
            this.tcFilter.Size = new System.Drawing.Size(1048, 228);
            this.tcFilter.TabIndex = 1;
            // 
            // tpGeneralFilter
            // 
            this.tpGeneralFilter.Controls.Add(this.ucGeneralFilter);
            this.tpGeneralFilter.Location = new System.Drawing.Point(4, 25);
            this.tpGeneralFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tpGeneralFilter.Name = "tpGeneralFilter";
            this.tpGeneralFilter.Padding = new System.Windows.Forms.Padding(4);
            this.tpGeneralFilter.Size = new System.Drawing.Size(1040, 187);
            this.tpGeneralFilter.TabIndex = 0;
            this.tpGeneralFilter.Text = "General";
            this.tpGeneralFilter.UseVisualStyleBackColor = true;
            // 
            // ucGeneralFilter
            // 
            this.ucGeneralFilter.AutoSize = true;
            this.ucGeneralFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGeneralFilter.IsSilent = false;
            this.ucGeneralFilter.Location = new System.Drawing.Point(4, 4);
            this.ucGeneralFilter.Margin = new System.Windows.Forms.Padding(5);
            this.ucGeneralFilter.Name = "ucGeneralFilter";
            this.ucGeneralFilter.SearchPath = "";
            this.ucGeneralFilter.SearchPattern = "";
            this.ucGeneralFilter.Size = new System.Drawing.Size(1032, 179);
            this.ucGeneralFilter.TabIndex = 4;
            // 
            // tpAdvancedFilter
            // 
            this.tpAdvancedFilter.Controls.Add(this.ucAdvancedFilter);
            this.tpAdvancedFilter.Location = new System.Drawing.Point(4, 25);
            this.tpAdvancedFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tpAdvancedFilter.Name = "tpAdvancedFilter";
            this.tpAdvancedFilter.Padding = new System.Windows.Forms.Padding(4);
            this.tpAdvancedFilter.Size = new System.Drawing.Size(1040, 199);
            this.tpAdvancedFilter.TabIndex = 1;
            this.tpAdvancedFilter.Text = "Advanced";
            this.tpAdvancedFilter.UseVisualStyleBackColor = true;
            // 
            // ucAdvancedFilter
            // 
            this.ucAdvancedFilter.AutoSize = true;
            this.ucAdvancedFilter.EndDate = new System.DateTime(2008, 3, 11, 16, 7, 24, 248);
            this.ucAdvancedFilter.IsSilent = false;
            this.ucAdvancedFilter.Location = new System.Drawing.Point(8, 7);
            this.ucAdvancedFilter.Margin = new System.Windows.Forms.Padding(5);
            this.ucAdvancedFilter.Name = "ucAdvancedFilter";
            this.ucAdvancedFilter.SearchByDate = false;
            this.ucAdvancedFilter.SearchBySize = false;
            this.ucAdvancedFilter.SearchInSubdirectories = false;
            this.ucAdvancedFilter.SearchWithAttributes = false;
            this.ucAdvancedFilter.Size = new System.Drawing.Size(779, 322);
            this.ucAdvancedFilter.StartDate = new System.DateTime(2008, 3, 11, 16, 7, 24, 248);
            this.ucAdvancedFilter.TabIndex = 4;
            // 
            // tpPlugins
            // 
            this.tpPlugins.Controls.Add(this.ucPlugins);
            this.tpPlugins.Location = new System.Drawing.Point(4, 25);
            this.tpPlugins.Margin = new System.Windows.Forms.Padding(4);
            this.tpPlugins.Name = "tpPlugins";
            this.tpPlugins.Padding = new System.Windows.Forms.Padding(4);
            this.tpPlugins.Size = new System.Drawing.Size(1040, 199);
            this.tpPlugins.TabIndex = 2;
            this.tpPlugins.Text = "Plugins";
            this.tpPlugins.UseVisualStyleBackColor = true;
            // 
            // ucPlugins
            // 
            this.ucPlugins.AutoSize = true;
            this.ucPlugins.IsEditablePlugin = false;
            this.ucPlugins.IsSilent = false;
            this.ucPlugins.Location = new System.Drawing.Point(4, 4);
            this.ucPlugins.Margin = new System.Windows.Forms.Padding(5);
            this.ucPlugins.Name = "ucPlugins";
            this.ucPlugins.SearchInPlugins = false;
            this.ucPlugins.Size = new System.Drawing.Size(844, 277);
            this.ucPlugins.TabIndex = 4;
            // 
            // SearchFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchFilter";
            this.Size = new System.Drawing.Size(1048, 228);
            this.panel1.ResumeLayout(false);
            this.tcFilter.ResumeLayout(false);
            this.tpGeneralFilter.ResumeLayout(false);
            this.tpGeneralFilter.PerformLayout();
            this.tpAdvancedFilter.ResumeLayout(false);
            this.tpAdvancedFilter.PerformLayout();
            this.tpPlugins.ResumeLayout(false);
            this.tpPlugins.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tcFilter;
        private System.Windows.Forms.TabPage tpGeneralFilter;
        private GeneralFilter ucGeneralFilter;
        private System.Windows.Forms.TabPage tpAdvancedFilter;
        private AdvancedFilter ucAdvancedFilter;
        private System.Windows.Forms.TabPage tpPlugins;
        private Plugins ucPlugins;

    }
}
