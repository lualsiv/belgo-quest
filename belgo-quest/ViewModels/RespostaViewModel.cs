using System;
using Definition.Dto;

namespace belgoquest.ViewModel
{
    public class RespostaViewModel : BaseViewModel
    {




        CAD_RESPOSTA item;

        public string Descricao
        {
            get{ return item.DSC_RESPOSTA; }
        }

        public int Codigo
        {
            get { return item.COD_RESPOSTA; }

        }

        private bool isChecked = false;

        public bool IsChecked
        {
            get{ return isChecked;}
            set
            { 
                if (isChecked == value)
                    return;
                isChecked = value;
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


        public RespostaViewModel(CAD_RESPOSTA item)
        {
            this.item = item;
        }
    }
}

