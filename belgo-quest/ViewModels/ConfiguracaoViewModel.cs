using System;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Windows.Input;

namespace belgoquest
{
    public class ConfiguracaoViewModel : BaseViewModel
    {
        private string valor = string.Empty;

        public ConfiguracaoViewModel()
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

        private ICommand updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new Command(async () => await UpdateSettings())); 
            }
            
        }

        protected   async Task UpdateSettings()
        {
            if (IsLoading)
                return;

            IsLoading = true;
            try
            {
                UserDialogs.Instance.ShowLoading("Atualizando configuração...");
                Settings.UriWebServices = Valor.ToString();
                await Task.Delay(2000);
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowSuccess("Configuração atualizada com sucesso!");
            }catch(Exception ex)
            {
                UserDialogs.Instance.ShowError(ex.Message);
            }finally
            {
                IsLoading = false;
            }

        }


    }
}

