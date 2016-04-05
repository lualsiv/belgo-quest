using System;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace belgoquest
{
    public class ConfiguracaoViewModel : BaseViewModel
    {
        private string valor= string.Empty;

        public ConfiguracaoViewModel ()
        {
            valor = Settings.UriWebServices;
        }

        public string Valor
        {
            get { return valor; }
            set 
            {
                valor = value;
                OnPropertyChanged();
            }
        }

        private Command updateCommand;
        public Command UpdateCommand{
            get 
            { return updateCommand ?? (updateCommand = new Command(() =>
                    {
                        UserDialogs.Instance.ShowLoading("Atualizando configuração...");
                        Settings.UriWebServices = Valor;
                        UserDialogs.Instance.Alert("Configuração atualizada com sucesso!", "Configuração");

                    })); 
            }
            
        }
    }
}

