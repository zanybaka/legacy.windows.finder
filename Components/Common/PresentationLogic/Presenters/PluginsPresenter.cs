#region usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PresentationLogic.Exceptions;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;
using Samples.Finder.Components.Common.PresentationLogic.Properties;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

#endregion

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters
{
    public class PluginsPresenter : PresenterBase<IPluginsView, SearchTask>, IPluginsPresenter
    {
        public IPluginLoader PluginLoader { get; set; }

        public PluginsPresenter()
        {
            PluginLoader = new FileSystemPluginLoader();
        }

        public void RefreshPlugins()
        {
            var list = new List<IPlugin>();
            try
            {
                list = PluginLoader.LoadPlugins(View.PluginPath, View.PluginExtension);
            } catch (Exception e)
            {
                var wrapper = new RuntimeException("Can't load at least one plugin.", e);
                if (ExceptionPolicy.HandleException(wrapper, Settings.Default.PresentationLogicPolicyName))
                {
                    throw wrapper;
                }
                View.SearchInPlugins = false;
            }
            View.RefreshPluginList(list);
            View.InvalidateControls();
        }

        public void SearchInPluginsChanged()
        {
            if (View.SearchInPlugins)
            {
                RefreshPlugins();
            }
            Task.Query.Plugin = View.SearchInPlugins ? View.GetSelectedPlugin() : null;
        }

        public void PluginSelected()
        {
            Task.Query.Plugin = View.GetSelectedPlugin();
        }

        protected override void InitView()
        {
            View.InvalidateControls();
        }

        protected override void InitTask()
        {
            Task.Query.PropertyChanged += OnQueryChanged;
        }

        private void OnQueryChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Task.Query.GetPropertyName(x=>x.Plugin))
            {
                View.IsEditablePlugin = Task.Query.Plugin != null;
            }
        }
    }
}