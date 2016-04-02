using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace belgoquest
{
    public class PesquisaListViewModel : BaseViewModel
    {
        ObservableCollection<PesquisaViewModel> contents;
// = new ObservableCollection<PesquisaViewModel> ();
        public ObservableCollection<PesquisaViewModel> Contents
        { 
            get { return contents; } 
            set
            {
                if (contents == value)
                    return;
                contents = value;
                OnPropertyChanged();
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value == selectedIndex) return;
                selectedIndex = value;
                OnPropertyChanged();
            }
        }

        public PesquisaListViewModel()
        {
            var all = App.Database.GetPesquisas();
            contents = new ObservableCollection<PesquisaViewModel>((from pesq in all
                                                                                 select new PesquisaViewModel(pesq)));
        }

//        PesquisaModel item;
//
//        ICommand saveCommand, deleteCommand, cancelCommand, speakCommand;

    }
}

