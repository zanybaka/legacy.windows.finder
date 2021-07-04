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
    class FormBase : Form, IView, INotifyPropertyChanged
    {
        protected IPresenter BasePresenter { get; set; }

        public virtual bool HasErrors() { return false; }

        private readonly ITask task;

        protected FormBase()
        {
        }

        protected FormBase(ITask task) : this()
        {
            this.task = task;
        }

        #region IView Members

        public bool IsSilent { get; set; }

        public string UniqueName
        {
            get { return new Guid().ToString(); }
        }

        public virtual void InvalidateControls()
        {
        }

        #endregion

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!DesignMode)
            {
                InitializeLogic();
            }
        }

        protected virtual void SetBindings()
        {
        }
        
        private void InitializeLogic()
        {
            SetBindings();
            InitializePresenter(task);
        }

#if DEBUG
        protected virtual void InitializePresenter(ITask task) { }
#else
        protected abstract void InitializePresenter(ITask task);
#endif

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