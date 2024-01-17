﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepthSearchApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private SearchFilters _SelectedFile;
        public SearchFilters SelectedFile
        {
            get { return _SelectedFile; }
            set 
            {
                _SelectedFile = value;
            }
        }

        public ReadOnlyObservableCollection<string> AllFiles;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
