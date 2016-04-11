using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using belgoquest.Helpers;

namespace belgoquest.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
//        protected AsyncLock _lock = new AsyncLock();
        private bool _isLoading = false;

        public bool IsLoading
        {
            get{ return _isLoading;}
            set{ _isLoading = value;}
        }

        public ViewModelNavigation Navigation
        {
            get;
            set;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public BaseViewModel()
        {
        }

        protected virtual void  OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}

