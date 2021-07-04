namespace Samples.Finder.Application.Controls
{
    partial class AdvancedFilter
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
            this.chkSearchInSubdirectories = new System.Windows.Forms.CheckBox();
            this.chkDateBetween = new System.Windows.Forms.CheckBox();
            this.chkAttributes = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateBeetwenAnd = new System.Windows.Forms.Label();
            this.chkFileSize = new System.Windows.Forms.CheckBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.clbAttributes = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSearchInSubdirectories
            // 
            this.chkSearchInSubdirectories.AutoSize = true;
            this.chkSearchInSubdirectories.Location = new System.Drawing.Point(4, 4);
            this.chkSearchInSubdirectories.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchInSubdirectories.Name = "chkSearchInSubdirectories";
            this.chkSearchInSubdirectories.Size = new System.Drawing.Size(180, 21);
            this.chkSearchInSubdirectories.TabIndex = 0;
            this.chkSearchInSubdirectories.Text = "Search in &subdirectories";
            this.chkSearchInSubdirectories.UseVisualStyleBackColor = true;
            this.chkSearchInSubdirectories.CheckedChanged += new System.EventHandler(this.OnSearchInSubdirectoriesChanged);
            // 
            // chkDateBetween
            // 
            this.chkDateBetween.AutoSize = true;
            this.chkDateBetween.Location = new System.Drawing.Point(4, 38);
            this.chkDateBetween.Margin = new System.Windows.Forms.Padding(4);
            this.chkDateBetween.Name = "chkDateBetween";
            this.chkDateBetween.Size = new System.Drawing.Size(126, 21);
            this.chkDateBetween.TabIndex = 1;
            this.chkDateBetween.Text = "&Date beetween:";
            this.chkDateBetween.UseVisualStyleBackColor = true;
            this.chkDateBetween.CheckedChanged += new System.EventHandler(this.OnSearchByDateChanged);
            // 
            // chkAttributes
            // 
            this.chkAttributes.AutoSize = true;
            this.chkAttributes.Location = new System.Drawing.Point(4, 111);
            this.chkAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.chkAttributes.Name = "chkAttributes";
            this.chkAttributes.Size = new System.Drawing.Size(139, 21);
            this.chkAttributes.TabIndex = 8;
            this.chkAttributes.Text = "&Include attributes:";
            this.chkAttributes.UseVisualStyleBackColor = true;
            this.chkAttributes.CheckedChanged += new System.EventHandler(this.OnSearchWithAttributesChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(191, 38);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(169, 22);
            this.dtpStartDate.TabIndex = 2;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.OnStartDateChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(411, 38);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(169, 22);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.OnEndDateChanged);
            // 
            // lblDateBeetwenAnd
            // 
            this.lblDateBeetwenAnd.AutoSize = true;
            this.lblDateBeetwenAnd.Location = new System.Drawing.Point(369, 43);
            this.lblDateBeetwenAnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateBeetwenAnd.Name = "lblDateBeetwenAnd";
            this.lblDateBeetwenAnd.Size = new System.Drawing.Size(32, 17);
            this.lblDateBeetwenAnd.TabIndex = 6;
            this.lblDateBeetwenAnd.Text = "and";
            // 
            // chkFileSize
            // 
            this.chkFileSize.AutoSize = true;
            this.chkFileSize.Location = new System.Drawing.Point(4, 74);
            this.chkFileSize.Margin = new System.Windows.Forms.Padding(4);
            this.chkFileSize.Name = "chkFileSize";
            this.chkFileSize.Size = new System.Drawing.Size(82, 21);
            this.chkFileSize.TabIndex = 4;
            this.chkFileSize.Text = "&File size:";
            this.chkFileSize.UseVisualStyleBackColor = true;
            this.chkFileSize.CheckedChanged += new System.EventHandler(this.OnSearchBySizeChanged);
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(249, 74);
            this.nudSize.Margin = new System.Windows.Forms.Padding(4);
            this.nudSize.Maximum = new decimal(new int[] {
            0,
            256,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(137, 22);
            this.nudSize.TabIndex = 6;
            this.nudSize.ValueChanged += new System.EventHandler(this.OnFileSizeChanged);
            this.nudSize.Leave += new System.EventHandler(this.OnSearchBySizeChanged);
            // 
            // cbOperation
            // 
            this.cbOperation.DisplayMember = "Value";
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Location = new System.Drawing.Point(191, 73);
            this.cbOperation.Margin = new System.Windows.Forms.Padding(4);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(49, 24);
            this.cbOperation.TabIndex = 5;
            this.cbOperation.ValueMember = "Key";
            this.cbOperation.SelectedIndexChanged += new System.EventHandler(this.OnComparisonOperationChanged);
            // 
            // cbUnit
            // 
            this.cbUnit.DisplayMember = "Value";
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(395, 73);
            this.cbUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(127, 24);
            this.cbUnit.TabIndex = 7;
            this.cbUnit.ValueMember = "Key";
            this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.OnFileUnitChanged);
            // 
            // clbAttributes
            // 
            this.clbAttributes.CheckOnClick = true;
            this.clbAttributes.FormattingEnabled = true;
            this.clbAttributes.Location = new System.Drawing.Point(191, 111);
            this.clbAttributes.Margin = new System.Windows.Forms.Padding(4);
            this.clbAttributes.MultiColumn = true;
            this.clbAttributes.Name = "clbAttributes";
            this.clbAttributes.Size = new System.Drawing.Size(389, 123);
            this.clbAttributes.TabIndex = 9;
            this.clbAttributes.SelectedIndexChanged += new System.EventHandler(this.OnFileAttributesChanged);
            // 
            // AdvancedFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.clbAttributes);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.cbOperation);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.chkFileSize);
            this.Controls.Add(this.lblDateBeetwenAnd);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.chkAttributes);
            this.Controls.Add(this.chkDateBetween);
            this.Controls.Add(this.chkSearchInSubdirectories);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdvancedFilter";
            this.Size = new System.Drawing.Size(600, 265);
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSearchInSubdirectories;
        private System.Windows.Forms.CheckBox chkDateBetween;
        private System.Windows.Forms.CheckBox chkAttributes;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblDateBeetwenAnd;
        private System.Windows.Forms.CheckBox chkFileSize;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.ComboBox cbOperation;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.CheckedListBox clbAttributes;
    }
}
