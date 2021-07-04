#region usings

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Samples.Finder.Application.Controls.Base;
using Samples.Finder.Application.Properties;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters;
using System.Linq;
using Timer = System.Timers.Timer;

#endregion

namespace Samples.Finder.Application.Controls
{
    public partial class ResultList : UserControlBase, IResultListView
    {
        #region Private members

        private static readonly object syncObj = new object();
        private readonly List<string[]> cache;

        private readonly Timer timer;

        private IResultListPresenter Presenter
        {
            get
            {
                return (IResultListPresenter) BasePresenter;
            }
        }

        #endregion

        #region .ctor

        public ResultList()
        {
            InitializeComponent();
            cache = new List<string[]>();
            timer = new Timer(Settings.Default.ResultUpdateIntervalMsec);
            timer.AutoReset = false;
            timer.Elapsed += OnTimerTick;
        }

        #endregion

        #region Events

        private void OnResultsDoubleClick(object sender, EventArgs e)
        {
            Presenter.OpenSelectedItem();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            List<string[]> clone;
            lock (cache)
            {
                if (cache.Count > 0)
                {
                    clone = new List<string[]>(cache);
                    cache.Clear();
                } else
                {
                    return;
                }
            }
            lock (syncObj)
            {
                for (int i = 0; i < clone.Count; i++)
                {
                    if (InvokeRequired)
                    {
                        var index = i;
                        Invoke(new MethodInvoker(() => lbResults.Items.AddRange(clone[index])));
                    }
                    else
                    {
                        lbResults.Items.AddRange(clone[i]);
                    }
                }
            }
        }

        #endregion

        #region Overrides

        protected override void InitializePresenter(ITask task)
        {
            BasePresenter = new ResultListPresenter();
            BasePresenter.Initialize(this, task);
        }


        #endregion

        #region IResultListView members

        public void Clear()
        {
            lbResults.Items.Clear();
        }

        public void Add(IEnumerable<string> resultToAdd)
        {
            if (resultToAdd == null)
            {
                return;
            }
            System.Windows.Forms.Application.DoEvents();
            lock (cache)
            {
                cache.Add(resultToAdd.ToArray());
            }
            timer.Start();
        }

        public string SelectedItem
        {
            get
            {
                if (lbResults.SelectedItem != null)
                {
                    return (string)lbResults.SelectedItem;
                }
                return null;
            }
        }

        #endregion

    }
}