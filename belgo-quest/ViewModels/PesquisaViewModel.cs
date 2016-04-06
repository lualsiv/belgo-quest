using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace belgoquest
{
    public class PesquisaViewModel : BaseViewModel
    {

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
    }
}

