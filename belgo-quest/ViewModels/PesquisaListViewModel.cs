using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using belgoquest.ViewModel;

namespace belgoquest
{
    public class PesquisaListViewModel : BaseViewModel
    {
        ICommand continueCommand;

        ObservableCollection<PesquisaViewModel> contents;

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

            continueCommand = new Command(Continue);
        }

//        PesquisaModel item;
//
        public ICommand ContinueCommand
        {
            get { return continueCommand; }
            set
            {
                if (continueCommand == value)
                    return;
                continueCommand = value;
                OnPropertyChanged ();
            }
        }

        public void Continue()
        {
            this.Navigation.Push(ViewFactory.CreatePage(contents[selectedIndex]));
        }

    }
}

