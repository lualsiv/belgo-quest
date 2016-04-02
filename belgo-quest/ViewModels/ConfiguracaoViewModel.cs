using System;

namespace belgoquest
{
    public class ConfiguracaoViewModel : BaseViewModel
    {
        public string Valor {
            get;
            set;
        }

        public ConfiguracaoViewModel()
        {
            Valor = "https://servicos.belgo.com/";
        }
    }
}

