using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Samples.Finder.Components.Common.Plugins.TxtPlugin;
using Samples.Finder.Components.Common.PluginSDK;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;
using Samples.Finder.Components.Common.PresentationLogic.Tasks;

namespace Samples.Finder.Components.Common.PresentationLogic.Tests
{
    [TestFixture]
    public class PluginsPresenterTests
    {
        private MockRepository repository;

        #region Setup/Teardown

        [SetUp]
        public void Init()
        {
            repository = new MockRepository();

            pluginsMock = repository.Stub<IPluginsView>();

            var task = new SearchTask();

            pluginsPresenter = new PluginsPresenter();
            pluginsPresenter.Initialize(pluginsMock, task);
        }

        [TearDown]
        public void Teardown()
        {
            repository.VerifyAll();
        }

        #endregion

        private IPluginsView pluginsMock;

        private PluginsPresenter pluginsPresenter;

        /// <summary>
        /// Checks loading process
        /// </summary>
        [Test]
        public void RefreshPluginsTest()
        {
            var loader = repository.DynamicMock<IPluginLoader>();
            Expect.On(loader).Call(loader.LoadPlugins(null, null)).IgnoreArguments().Repeat.AtLeastOnce().Return(new List<IPlugin> {new TxtPlugin()});
            pluginsPresenter.PluginLoader = loader;
            pluginsMock.RefreshPluginList(null);
            LastCall.IgnoreArguments().Repeat.AtLeastOnce();
            repository.ReplayAll();
            pluginsPresenter.RefreshPlugins();
        }
    }
}