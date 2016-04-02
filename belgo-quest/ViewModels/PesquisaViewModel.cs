using System;

namespace belgoquest
{
    public class PesquisaViewModel : BaseViewModel
    {
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

