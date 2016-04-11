﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Definition.Dto;
using Definition.Interfaces;
using Definition.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PropertyChanged;
using Xamarin.Forms;

namespace belgoquest.ViewModel
{
    public class SincronizarPesquisaViewModel : BaseViewModel
    {

        IPesquisaService _pesquisaService;


        public SincronizarPesquisaViewModel(IPesquisaService pesquisaService)
        {
            _pesquisaService = pesquisaService;
        }


        private RelayCommand _sincronizarCommand;
        public RelayCommand SincronizarCommand
        {
            get
            {
                return _sincronizarCommand
                    ?? (_sincronizarCommand = new RelayCommand(
                        async () =>
                        {
                            await _sincronizarCommand.SingleRun(async () =>
                                {
                                    Result<IList<CAD_PESQUISA>> pesquisas;

                                    try
                                    {
                                        IsLoading = true;
                                        UserDialogs.Instance.ShowLoading("Realizando download...");

                                        pesquisas = await _pesquisaService.GetData();

                                        if(pesquisas.Success)
                                        {
                                            //var listaExistente = App.Database.GetPesquisas();
                                            var listaFiltrada = pesquisas.Value.Where(item=> (item.IND_FECHADO.HasValue)); //&& !listaExistente.Any(pesq=> pesq.COD_PESQUISA == item.COD_PESQUISA));

                                            App.Database.SaveListPesquisa(listaFiltrada);

                                            foreach (var pesq in listaFiltrada) {
                                                App.Database.SaveListPergunta(pesq.Perguntas);

                                                foreach (var perg in pesq.Perguntas) {
                                                    App.Database.SaveListResposta(perg.Respostas);
                                                }
                                            }
                                            UserDialogs.Instance.ShowSuccess("Sincronizacão realizada com sucesso!");
                                        }else
                                        {
                                            UserDialogs.Instance.ShowError(string.Format("{0}-{1}",pesquisas.Error, pesquisas.Message));
                                        }
                                        UserDialogs.Instance.HideLoading();
                                    }
                                    catch(Exception ex)
                                    {
                                        UserDialogs.Instance.ShowError(string.Format("Erro: {1}",ex.Message));
                                    }
                                    finally
                                    {
                                        IsLoading = false;
                                    }

                                });

                        }));
            }
        }

    }
}

