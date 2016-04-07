using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace belgoquest
{
    public class PesquisaViewModel : BaseViewModel
    {
        ICommand finalizarCommand;

        ObservableCollection<PerguntaViewModel> perguntas;

        public ObservableCollection<PerguntaViewModel> Perguntas
        { 
            get
            { 
                if (perguntas == null)
                {
                    var all = App.Database.GetPerguntas(item.COD_PESQUISA);
                    perguntas = new ObservableCollection<PerguntaViewModel>();
                    foreach (var pergunta in all)
                    {
                        perguntas.Add(new PerguntaViewModel(pergunta));
                    }

                }
                return perguntas;
            } 
            set
            {
                if (perguntas == value)
                    return;
                perguntas = value;
                OnPropertyChanged();
            }
        }


        PesquisaModel item;

        public PesquisaViewModel(PesquisaModel pesquisaItem)
        {
            item = pesquisaItem;
        }

        public int Codigo
        {
            get{ return item.COD_PESQUISA; }
            set
            {
                item.COD_PESQUISA = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get{ return item.NOM_PESQUISA; }
            set
            {
                item.NOM_PESQUISA = value;
                OnPropertyChanged();
            }
        }

        public ICommand FinalizarCommand
        {
            get { return finalizarCommand ?? (finalizarCommand = new Command(async () => await Finalizar())); }

        }

        public async Task Finalizar()
        {

            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                UserDialogs.Instance.ShowLoading("Finalizando Questionário...");
                await Task.Delay(2000);
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowSuccess("Questionário Finalizado com sucesso!");
                this.Navigation.New<PesquisaListViewModel>();

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

