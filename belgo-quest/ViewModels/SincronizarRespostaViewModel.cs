using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Collections.Generic;
using Definition.Dto;
using Definition.Interfaces;
using Definition.Model;
using System.Linq;

namespace belgoquest.ViewModel
{
    public class SincronizarRespostaViewModel : BaseViewModel
    {
        IParticipacaoService _participacao;
        public ObservableCollection<PesquisaListViewModel> pesquisas { get; set; }

        public PesquisaListViewModel SelectedPesquisa
        {
            get;
            set;
        }

        public SincronizarRespostaViewModel(IParticipacaoService participacao)
        {
            _participacao = participacao;

        }

        private ICommand UpLoadRespostas;

        public ICommand UpLoadRespostasCommand
        {
            get
            {
                return UpLoadRespostas ?? (UpLoadRespostas = new Command(async () => await ExecuteUpLoadRespostasCommand()));
            }
        }


        protected async Task ExecuteUpLoadRespostasCommand()
        {
            if (IsLoading)
                return;

            IsLoading = true;
            List<CAD_PARTICIPACAO> lista;
            Result<string> retorno;
            DateTime dataSinc = DateTime.Now;
            try
            {
                UserDialogs.Instance.ShowLoading("Realizando upload...");

                lista = App.Database.GetParticipacoes().ToList();

                foreach (var part in lista) {

                    part.DTA_SINCRONIZACAO = dataSinc;
                    retorno = await _participacao.Inserir(part);

                    if(retorno.Success)
                    {
                        App.Database.DeleteParticipacao(part.COD_PARTICIPACAO);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.ShowError(retorno.Message);
                        return;
                    }
                }

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowSuccess("Upload realizado com sucesso!");
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowError(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

