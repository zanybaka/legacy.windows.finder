#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Application.Extensions;
using Samples.Finder.Application.Properties;
using Samples.Finder.Components.Common.CommonLibrary.Enums;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;
using Samples.Finder.Components.Common.PresentationLogic;
using Samples.Finder.Components.Common.PresentationLogic.Adapters;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;

#endregion

namespace Samples.Finder.Application.Controls
{
    public partial class AdvancedFilter : UserControlBase, IAdvancedFilterView
    {
        #region .ctor

        public AdvancedFilter()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        protected override void SetBindings()
        {
            dtpStartDate.AddBinding(control=>control.Enabled, this, source=>source.SearchByDate);
            dtpEndDate.AddBinding(control => control.Enabled, this, source => source.SearchByDate);
            cbOperation.AddBinding(control => control.Enabled, this, source => source.SearchBySize);
            nudSize.AddBinding(control => control.Enabled, this, source => source.SearchBySize);
            cbUnit.AddBinding(control => control.Enabled, this, source => source.SearchBySize);
            clbAttributes.AddBinding(control => control.Enabled, this, source => source.SearchWithAttributes);
        }

        protected override void DataBind()
        {
            using (new SilentViewMode(this))
            {
                cbUnit.Fill(DataAdapter.GetFileUnitList());
                cbOperation.Fill(DataAdapter.GetComparisonOperationList());
                Dictionary<FileAttributes, string> fileAttributeList = DataAdapter.GetFileAttributeList();
                clbAttributes.Fill(fileAttributeList);
            }
        }

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new AdvancedFilterPresenter();
            BasePresenter.Initialize(this, task);
        }

        protected override void SetDefaultValues()
        {
            using (new SilentViewMode(this))
            {
                SetFileUnit(Settings.Default.DefaultFileUnit);
                SetComparisonOperation(Settings.Default.DefaultComparisonOperation);
                //SetFileAttributes(Settings.Default.DefaultFileAttributes);
            }
        }

        #endregion

        #region IAdvancedFilterView members

        public bool SearchInSubdirectories
        {
            get { return chkSearchInSubdirectories.Checked; }
            set { chkSearchInSubdirectories.Checked = value; }
        }

        public bool SearchWithAttributes
        {
            get { return chkAttributes.Checked; }
            set { chkAttributes.Checked = value; }
        }

        public bool SearchByDate
        {
            get { return chkDateBetween.Checked; }
            set { chkDateBetween.Checked = value; }
        }

        public bool SearchBySize
        {
            get { return chkFileSize.Checked; }
            set { chkFileSize.Checked = value; }
        }

        public DateTime StartDate
        {
            get { return dtpStartDate.Value; }
            set
            {
                if (value.Year < 1900)
                {
                    dtpStartDate.Value = new DateTime(1900, 1, 1);
                }
                else if (value.Year > 2100)
                {
                    dtpStartDate.Value = new DateTime(2100, 1, 1);
                }
                else
                {
                    dtpStartDate.Value = value;
                }
            }
        }

        public DateTime EndDate
        {
            get { return dtpEndDate.Value; }
            set
            {
                if (value.Year < 1900)
                {
                    dtpEndDate.Value = new DateTime(1900, 1, 1);
                }
                else if (value.Year > 2100)
                {
                    dtpEndDate.Value = new DateTime(2100, 1, 1);
                } else
                {
                    dtpEndDate.Value = value;
                }
            }
        }

        public void SetFileAttributes(FileAttributes value)
        {
            for (int i = 0; i < clbAttributes.Items.Count; i++)
            {
                FileAttributes attribute = ((KeyValuePair<FileAttributes, string>) clbAttributes.Items[i]).Key;
                clbAttributes.SetItemChecked(i, (attribute & value) == attribute);
            }
        }

        public FileAttributes GetFileAttributes()
        {
            return clbAttributes.CheckedItems
                .Cast<KeyValuePair<FileAttributes, string>>()
                .Aggregate<KeyValuePair<FileAttributes, string>, FileAttributes>(
                    0,
                    (current, pair) => current | pair.Key
                );
        }

        public void SetFileSizeInBytes(long value)
        {
            FileUnit selectedFileUnit = GetSelectedFileUnit();
            decimal length = selectedFileUnit.GetByteCount();
            nudSize.Value = value/length;
        }

        public long GetFileSizeInBytes()
        {
            FileUnit selectedFileUnit = GetSelectedFileUnit();
            decimal length = selectedFileUnit.GetByteCount();
            decimal val = nudSize.Value*length;
            return (long) val;
        }

        public void SetComparisonOperation(ComparisonOperation value)
        {
            cbOperation.SafeSetValue(value);
        }

        public ComparisonOperation GetComparisonOperation()
        {
            return (ComparisonOperation) cbOperation.SelectedValue;
        }

        private FileUnit GetSelectedFileUnit()
        {
            if (cbUnit.SelectedItem == null)
            {
                return Settings.Default.DefaultFileUnit;
            }
            FileUnit unit = ((KeyValuePair<FileUnit, string>) cbUnit.SelectedItem).Key;
            return unit;
        }

        private void SetFileUnit(FileUnit unit)
        {
            cbUnit.SafeSetValue(unit);
        }

        #endregion

        #region Events

        private void OnSearchInSubdirectoriesChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SearchInSubdirectories");
        }

        private void OnSearchByDateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SearchByDate");
        }

        private void OnSearchBySizeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SearchBySize");
        }

        private void OnSearchWithAttributesChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SearchWithAttributes");
        }

        private void OnFileUnitChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("FileUnit");
        }

        private void OnStartDateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("StartDate");
        }

        private void OnEndDateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("EndDate");
        }

        private void OnComparisonOperationChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("ComparisonOperation");
        }

        private void OnFileSizeChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("FileSize");
        }

        private void OnFileAttributesChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("FileAttributes");
        }

        #endregion
    }
}