#region usings

using System;
using System.Collections.Generic;
using System.IO;
using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Application.Properties;
using Samples.Finder.Application.Resources;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;

#endregion

namespace Samples.Finder.Application.Controls
{
    public partial class Plugins : UserControlBase, IPluginsView
    {
        #region Private members

        private IPluginsPresenter Presenter
        {
            get
            {
                return (IPluginsPresenter) BasePresenter;
            }
        }

        private PluginDictionary pluginDictionary;

        #endregion

        #region .ctor

        public Plugins()
        {
            pluginDictionary = new PluginDictionary();
            InitializeComponent();
        }

        #endregion

        #region IPluginsView members

        private bool isEditablePlugin;
        public bool IsEditablePlugin
        {
            get { return isEditablePlugin; }
            set
            {
                isEditablePlugin = value;
                OnPropertyChanged("IsEditablePlugin");
            }
        }

        public bool SearchInPlugins
        {
            get { return chkSearchInPlugins.Checked; }
            set { chkSearchInPlugins.Checked = value; }
        }

        public string PluginPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Default.PluginDirectory); }
        }

        public string PluginExtension
        {
            get { return Settings.Default.PluginExtension; }
        }

        public IPlugin GetSelectedPlugin()
        {
            if (lbPlugins.SelectedItem == null)
            {
                return null;
            }
            Guid id = ((KeyValuePair<Guid, string>) lbPlugins.SelectedItem).Key;
            return pluginDictionary[id];
        }

        public void RefreshPluginList(IEnumerable<IPlugin> collection)
        {
            pluginDictionary = new PluginDictionary();
            foreach (IPlugin plugin in collection)
            {
                pluginDictionary.Add(plugin.Id, plugin);
            }
            DataBind();
        }

        #endregion

        #region Overrides

        protected override void SetBindings()
        {
            lbPlugins.AddBinding(control=>control.Enabled, this, source=>source.SearchInPlugins);
            btnRefresh.AddBinding(control => control.Enabled, this, source => source.SearchInPlugins);
            pnlContent.AddBinding(control => control.Enabled, this, source => source.IsEditablePlugin);
            lblSettings.AddBinding(control => control.Enabled, this, source => source.IsEditablePlugin);
            lblInfo.AddBinding(control => control.Enabled, this, source => source.IsEditablePlugin);
            lblPluginInfo.AddBinding(control => control.Enabled, this, source => source.IsEditablePlugin);
        }

        public override void InvalidateControls()
        {
            pnlContent.Controls.Clear();
            var selectedPlugin = GetSelectedPlugin();
            if (selectedPlugin != null)
            {
                pnlContent.Controls.Add(selectedPlugin.MainInterface);
                lblInfo.Text = string.Format(Strings.PluginPatternFormat, selectedPlugin.FilePattern);
            }
            else
            {
                lblInfo.Text = string.Empty;
            }
        }

        protected override void DataBind()
        {
            var list = pluginDictionary.ToList();
            lbPlugins.Fill(list);
        }

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new PluginsPresenter();
            BasePresenter.Initialize(this, task);
        }

        #endregion

        #region Events

        private void OnSearchInPluginsChanged(object sender, EventArgs e)
        {
            if (!IsSilent)
            {
                Presenter.SearchInPluginsChanged();
                OnPropertyChanged("SearchInPlugins");
            }
        }

        private void OnSelectedPluginChanged(object sender, EventArgs e)
        {
            if (!IsSilent)
            {
                Presenter.PluginSelected();
                OnPropertyChanged("SelectedPlugin");
            }
        }

        private void OnRefreshPluginsClick(object sender, EventArgs e)
        {
            Presenter.RefreshPlugins();
        }

        #endregion
    }
}