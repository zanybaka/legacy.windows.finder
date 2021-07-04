using System.Windows.Forms;

namespace Samples.Finder.Application.Controls
{
    partial class GeneralFilter
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
            this.components = new System.ComponentModel.Container();
            this.lblSearchPath = new System.Windows.Forms.Label();
            this.lblSearchPattern = new System.Windows.Forms.Label();
            this.txtSearchPattern = new Samples.Finder.Application.Controls.RegExTextBox();
            this.fbdSearchPath = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchPath = new Samples.Finder.Application.Controls.RegExTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchPath
            // 
            this.lblSearchPath.AutoSize = true;
            this.lblSearchPath.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchPath.Location = new System.Drawing.Point(4, 30);
            this.lblSearchPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchPath.Name = "lblSearchPath";
            this.lblSearchPath.Size = new System.Drawing.Size(72, 17);
            this.lblSearchPath.TabIndex = 3;
            this.lblSearchPath.Text = "Search in:";
            // 
            // lblSearchPattern
            // 
            this.lblSearchPattern.AutoSize = true;
            this.lblSearchPattern.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchPattern.Location = new System.Drawing.Point(4, 0);
            this.lblSearchPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchPattern.Name = "lblSearchPattern";
            this.lblSearchPattern.Size = new System.Drawing.Size(78, 17);
            this.lblSearchPattern.TabIndex = 5;
            this.lblSearchPattern.Text = "Search for:";
            // 
            // txtSearchPattern
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtSearchPattern, 2);
            this.txtSearchPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPattern.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSearchPattern.Location = new System.Drawing.Point(90, 4);
            this.txtSearchPattern.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchPattern.MaxLength = 100;
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.RegularExpression = "^[^\\/\\\\:?\"<>|]*$";
            this.txtSearchPattern.Size = new System.Drawing.Size(337, 22);
            this.txtSearchPattern.TabIndex = 0;
            this.txtSearchPattern.TextChanged += new System.EventHandler(this.OnSearchPatternChanged);
            // 
            // fbdSearchPath
            // 
            this.fbdSearchPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdSearchPath.ShowNewFolderButton = false;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(395, 34);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(32, 23);
            this.btnBrowseFolder.TabIndex = 2;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.OnBrowseFolderClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.txtSearchPath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSearchPattern, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowseFolder, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchPattern, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSearchPath, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 71);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txtSearchPath
            // 
            this.txtSearchPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSearchPath.Location = new System.Drawing.Point(90, 34);
            this.txtSearchPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchPath.MaxLength = 1000;
            this.txtSearchPath.Name = "txtSearchPath";
            this.txtSearchPath.RegularExpression = "^([a-zA-Z]:)(\\\\([^\\/\\\\:*?\"<>|]*))+(\\\\)?$";
            this.txtSearchPath.Size = new System.Drawing.Size(277, 22);
            this.txtSearchPath.TabIndex = 1;
            this.txtSearchPath.TextChanged += new System.EventHandler(this.OnSearchPathChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // GeneralFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GeneralFilter";
            this.Size = new System.Drawing.Size(447, 71);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSearchPath;
        private System.Windows.Forms.Label lblSearchPattern;
        private RegExTextBox txtSearchPattern;
        private System.Windows.Forms.FolderBrowserDialog fbdSearchPath;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RegExTextBox txtSearchPath;
        private ErrorProvider errorProvider;
    }
}
