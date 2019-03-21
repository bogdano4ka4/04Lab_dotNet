﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Practice7UserList.Tools
{

    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
      
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


            // [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
