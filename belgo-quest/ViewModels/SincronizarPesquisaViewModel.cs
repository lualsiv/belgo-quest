using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace belgoquest
{
    public class SincronizarPesquisaViewModel : BaseViewModel
    {
        public ObservableCollection<PesquisaListViewModel> pesquisas { get; set; }

        public PesquisaListViewModel SelectedPesquisa
        {
            get;
            set;
        }

        public SincronizarPesquisaViewModel()
        {
            pesquisas = new ObservableCollection<PesquisaListViewModel>();
        }


        private ICommand LoadPesquisas;

        public ICommand LoadPesquisasCommand
        {
            get
            {
                return LoadPesquisas ?? (LoadPesquisas = new Command(async () => await ExecuteLoadPesquisasCommand()));
            }
        }


        protected async Task ExecuteLoadPesquisasCommand()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                UserDialogs.Instance.ShowLoading("Realizando download...");
                await Task.Delay(2000);

                UserDialogs.Instance.HideLoading();

            }
            finally
            {
                IsLoading = false;
            }
        }

    }
}

