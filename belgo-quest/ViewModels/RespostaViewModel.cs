using System;

namespace belgoquest
{
    public class RespostaViewModel : BaseViewModel
    {




        RespostaModel item;

        public string Descricao
        {
            get{ return item.DSC_RESPOSTA; }
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


        public RespostaViewModel(RespostaModel item)
        {
            this.item = item;
        }
    }
}

