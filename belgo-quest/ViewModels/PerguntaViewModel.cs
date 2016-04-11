using System;
using System.Collections.ObjectModel;
using Definition.Dto;

namespace belgoquest.ViewModel
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

        CAD_PERGUNTA item;

        public string Descricao
        {
            get { return item.DSC_PERGUNTA;}
        }

        public int Codigo
        {
            get { return item.COD_PERGUNTA; }

        }
        public string TipoPergunta
        {
            get{ return item.IND_TPO_PERGUNTA.ToUpper(); }

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

        private RespostaViewModel selectedItem;
        public RespostaViewModel SelectedItem
        {
            get{ return selectedItem;}
            set
            { 
                if (selectedItem == value)
                    return;
                selectedItem = value;
                OnPropertyChanged();
            }
        }


        public PerguntaViewModel(CAD_PERGUNTA item)
        {
            this.item = item;
        }
    }
}

