using System;
using System.Collections.ObjectModel;

namespace belgoquest
{
    public class PerguntaViewModel : BaseViewModel
    {

        ObservableCollection<RespostaViewModel> respostas;

        public ObservableCollection<RespostaViewModel> Respostas
        { 
            get
            { 
                if (respostas == null)
                {
                    var all = App.Database.GetRespostas(item.COD_PERGUNTA);
                    respostas = new ObservableCollection<RespostaViewModel>();
                    foreach (var resposta in all)
                    {
                        respostas.Add(new RespostaViewModel(resposta));
                    }

                }
                return respostas;
            } 
            set
            {
                if (respostas == value)
                    return;
                respostas = value;
                OnPropertyChanged();
            }
        }

        PerguntaModel item;

        public string Descricao
        {
            get { return item.DSC_PERGUNTA;}
        }

        public int TipoPergunta
        {
            get{ return item.IND_TPO_PERGUNTA; }

        }

        private string texto;
        public string Texto
        {
            get{return texto; }
            set
            {
                if (texto == value)
                    return;
                texto = value;
                OnPropertyChanged();
            }
        }

        public PerguntaViewModel(PerguntaModel item)
        {
            this.item = item;
        }
    }
}

