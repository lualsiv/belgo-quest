using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Definition.Dto;

namespace belgoquest.ViewModel
{
    public class PesquisaViewModel : BaseViewModel
    {
        ICommand finalizarCommand;

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


        CAD_PESQUISA item;

        public PesquisaViewModel(CAD_PESQUISA pesquisaItem)
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

        public ICommand FinalizarCommand
        {
            get { return finalizarCommand ?? (finalizarCommand = new Command(async () => await Finalizar())); }

        }

        public async Task Finalizar()
        {

            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                UserDialogs.Instance.ShowLoading("Finalizando Questionário...");

                CAD_PARTICIPACAO participacao;
                DateTime dataParticipacao = DateTime.Now;
                string token = Guid.NewGuid().ToString();

                for (int i = 0; i < perguntas.Count; i++)
                {
                    
                    
                    switch (perguntas[i].TipoPergunta)
                    {
                        case "U":


                            participacao = new CAD_PARTICIPACAO()
                            {
                                COD_PESQUISA = this.Codigo,
                                COD_PERGUNTA = perguntas[i].Codigo,
                                COD_RESPOSTA = perguntas[i].SelectedItem == null ? default(int?) : perguntas[i].SelectedItem.Codigo,
                                DTA_PARTICIPACAO = dataParticipacao,
                                IND_RESPOSTA_NULA = perguntas[i].SelectedItem == null ? "S" : "N",
                                Token = token
                            };
                            
                            App.Database.SaveParticipacao(participacao);

                            break;

                        case "M":

                            var respSelecionadas = perguntas[i].Respostas.Where(resp => resp.IsChecked).ToList();
                            for (int j = 0; j < respSelecionadas.Count; j++)
                            {
                                participacao = new CAD_PARTICIPACAO()
                                {
                                    COD_PESQUISA = this.Codigo,
                                    COD_PERGUNTA = perguntas[i].Codigo,
                                    COD_RESPOSTA = respSelecionadas[j].Codigo,
                                    DTA_PARTICIPACAO = dataParticipacao,
                                    IND_RESPOSTA_NULA = "N",
                                    Token = token
                                };
                                App.Database.SaveParticipacao(participacao);
                            }
                            break;
                        case "D":
                            participacao = new CAD_PARTICIPACAO()
                            {
                                COD_PESQUISA = this.Codigo,
                                COD_PERGUNTA = perguntas[i].Codigo,
                                DSC_RESP_DISSERTATIVA = perguntas[i].Texto,
                                DTA_PARTICIPACAO = dataParticipacao,
                                IND_RESPOSTA_NULA = String.IsNullOrWhiteSpace(perguntas[i].Texto) ? "S" : "N",
                                Token = token
                                        
                            };
                            App.Database.SaveParticipacao(participacao);
                            break;
                        default:
                            break;
                    }
                }

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.ShowSuccess("Questionário Finalizado com sucesso!");
                this.Navigation.New<PesquisaListViewModel>();

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

