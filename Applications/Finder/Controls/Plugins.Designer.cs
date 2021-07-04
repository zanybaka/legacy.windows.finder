namespace Samples.Finder.Application.Controls
{
    partial class Plugins
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
            this.chkSearchInPlugins = new System.Windows.Forms.CheckBox();
            this.lbPlugins = new System.Windows.Forms.ListBox();
            this.lblSettings = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblPluginInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkSearchInPlugins
            // 
            this.chkSearchInPlugins.AutoSize = true;
            this.chkSearchInPlugins.Location = new System.Drawing.Point(13, 11);
            this.chkSearchInPlugins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSearchInPlugins.Name = "chkSearchInPlugins";
            this.chkSearchInPlugins.Size = new System.Drawing.Size(136, 21);
            this.chkSearchInPlugins.TabIndex = 0;
            this.chkSearchInPlugins.Text = "&Search in plugins";
            this.chkSearchInPlugins.UseVisualStyleBackColor = true;
            this.chkSearchInPlugins.CheckedChanged += new System.EventHandler(this.OnSearchInPluginsChanged);
            // 
            // lbPlugins
            // 
            this.lbPlugins.FormattingEnabled = true;
            this.lbPlugins.ItemHeight = 16;
            this.lbPlugins.Location = new System.Drawing.Point(13, 39);
            this.lbPlugins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbPlugins.Name = "lbPlugins";
            this.lbPlugins.Size = new System.Drawing.Size(155, 148);
            this.lbPlugins.TabIndex = 1;
            this.lbPlugins.SelectedIndexChanged += new System.EventHandler(this.OnSelectedPluginChanged);
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSettings.Location = new System.Drawing.Point(177, 69);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(72, 17);
            this.lblSettings.TabIndex = 9;
            this.lblSettings.Text = "Settings:";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.Location = new System.Drawing.Point(180, 94);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(449, 127);
            this.pnlContent.TabIndex = 3;
            // 
            // lblPluginInfo
            // 
            this.lblPluginInfo.AutoSize = true;
            this.lblPluginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPluginInfo.Location = new System.Drawing.Point(177, 12);
            this.lblPluginInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPluginInfo.Name = "lblPluginInfo";
            this.lblPluginInfo.Size = new System.Drawing.Size(94, 17);
            this.lblPluginInfo.TabIndex = 11;
            this.lblPluginInfo.Text = "Information:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(177, 39);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            this.lblInfo.TabIndex = 12;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(13, 196);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(156, 25);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.OnRefreshPluginsClick);
            // 
            // Plugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblPluginInfo);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.chkSearchInPlugins);
            this.Controls.Add(this.lbPlugins);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Plugins";
            this.Size = new System.Drawing.Size(635, 226);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSearchInPlugins;
        private System.Windows.Forms.ListBox lbPlugins;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblPluginInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnRefresh;


    }
}
