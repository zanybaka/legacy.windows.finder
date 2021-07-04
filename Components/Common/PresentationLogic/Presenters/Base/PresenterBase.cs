using System;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;

namespace Samples.Finder.Components.Common.PresentationLogic.Presenters.Base
{
    public abstract class PresenterBase<TView, TTask> : IPresenter
        where TView : IView
        where TTask : ITask
    {
        public virtual void PropertyChanged(string propertyName)
        {
            if (!View.IsSilent)
            {
                View.InvalidateControls();
            }
        }

        protected PresenterBase()
        {
        }

        public void Initialize(IView view, ITask task)
        {
            if (ReferenceEquals(task, null))
            {
                throw new ArgumentNullException("task");
            }
            Task = (TTask)task;
            if (ReferenceEquals(view, null))
            {
                throw new ArgumentNullException("view");
            }
            View = (TView)view;
        }

        protected abstract void InitView();
        protected abstract void InitTask();

        private TView view;
        protected TView View
        {
            get { return view; }
            private set
            {
                view = value;
                InitView();
            }
        }

        private TTask task;
        protected TTask Task
        {
            get { return task; }
            private set
            {
                task = value;
                InitTask();
            }
        }
    }
}