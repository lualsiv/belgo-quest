using System;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Definition.Dto;

namespace belgoquest.ViewModel
{
    public class RelatorioViewModel : BaseViewModel
    {
        
        public RelatorioViewModel()
        {
            var all = App.Database.GetPesquisas();
            contents = new ObservableCollection<CAD_PESQUISA>(all);
        }

        ObservableCollection<CAD_PESQUISA> contents;

        public ObservableCollection<CAD_PESQUISA> Contents
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
    }
}

