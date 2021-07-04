using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Samples.Finder.Components.Common.BusinessLogic.Exceptions;
using Samples.Finder.Components.Common.BusinessLogic.Properties;

namespace Samples.Finder.Components.Common.BusinessLogic
{
    public abstract class SearchEngine
    {
        #region Private fields

        private bool isInProgress;

        #endregion

        #region Public properties

        public bool IsInProgress
        {
            get { return isInProgress; }
        }

        #endregion

        #region Public and protected methods

        protected abstract T[] FilterByQuery<T>(T[] array) where T : class;

        public void Start()
        {
            try
            {
                isInProgress = true;
                EventHandler handler = Started;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
                Process();
            }
            catch (Exception e)
            {
                var wrapper = new SearchEngineException(e);
                if (ExceptionPolicy.HandleException(wrapper, Settings.Default.BusinessLogicPolicyName))
                {
                    throw wrapper;
                }
            }
            finally
            {
                Finish();
            }
        }

        protected abstract void Process();

        public void Finish()
        {
            isInProgress = false;
            EventHandler handler = Finished;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected void OnProcessing(SearchResult result)
        {
            EventHandler<SearchResultEventArgs> handler = Processing;
            if (handler != null)
            {
                handler(this, new SearchResultEventArgs(result));
            }
        }

        #endregion

        #region Events

        public event EventHandler Started;

        public event EventHandler Finished;

        public event EventHandler<SearchResultEventArgs> Processing;

        #endregion
    }
}