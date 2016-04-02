using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace belgoquest
{
    public class SincronizarRespostaViewModel : BaseViewModel
    {
        public ObservableCollection<PesquisaListViewModel> pesquisas { get; set; }

        public PesquisaListViewModel SelectedPesquisa
        {
            get;
            set;
        }

        public SincronizarRespostaViewModel()
        {
        }

        private ICommand UpLoadRespostas;

        public ICommand UpLoadRespostasCommand
        {
            get
            {
                return UpLoadRespostas ?? (UpLoadRespostas = new Command(async () => await ExecuteUpLoadRespostasCommand()));
            }
        }


        protected async Task ExecuteUpLoadRespostasCommand()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                UserDialogs.Instance.ShowLoading("Realizando upload...");
                await Task.Delay(2000);
                //                pesquisas.Clear();
                //                var timesheets = await TimesheetService.GetTimesheetEntries();
                //                foreach (var timesheet in timesheets)
                //                {
                //                    pesquisas.Add(new TimesheetEntryViewModel(timesheet));
                //                }
                UserDialogs.Instance.HideLoading();

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

