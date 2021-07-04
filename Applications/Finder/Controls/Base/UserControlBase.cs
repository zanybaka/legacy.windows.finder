using System;
using System.ComponentModel;
using System.Windows.Forms;
using Samples.Finder.Components.Common.PresentationLogic.Interfaces;
using Samples.Finder.Components.Common.PresentationLogic.Presenters.Base;

namespace Samples.Finder.Application.Controls.Base
{
    [TypeDescriptionProvider(typeof(ConcreteClassProvider))]
    public 
#if !DEBUG
    abstract
#endif
    class UserControlBase : UserControl, IView, INotifyPropertyChanged
    {
        protected IPresenter BasePresenter { get; set; }

        private ITask task;

        public virtual bool HasErrors() { return false; }

        protected UserControlBase()
        {
        }

        #region IView Members

        public bool IsSilent { get; set; }

        public string UniqueName
        {
            get { return new Guid().ToString(); }
        }

        #endregion

        #region Virtual methods

        public void Initialize(ITask task)
        {
            this.task = task;
            SetBindings();
            DataBind();
            InitializePresenter(task);
            SetDefaultValues();
        }

        public virtual void InvalidateControls()
        {
        }

        protected virtual void SetBindings()
        {
        }

        protected virtual void DataBind()
        {
        }

        /// <summary>
        /// Overrides default (presenter's) control values
        /// </summary>
        protected virtual void SetDefaultValues()
        {
        }

#if DEBUG
        protected virtual void InitializePresenter(ITask task) { }
#else
        protected abstract void InitializePresenter(ITask task);
#endif

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (!DesignMode)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
                if (!ReferenceEquals(BasePresenter, null))
                {
                    BasePresenter.PropertyChanged(propertyName);
                }
            }
        }
    }
}