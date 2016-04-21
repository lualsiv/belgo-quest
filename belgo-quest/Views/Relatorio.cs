using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using belgoquest.CustomControls;
using belgoquest.Controls;
using belgoquest.ViewModel;
using Definition.Dto;

namespace belgoquest
{
    public class Relatorio : ContentPage
    {
        public Relatorio()
        {
            
        }


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RelatorioViewModel pesquisas = (RelatorioViewModel)BindingContext;

            StackLayout layout = new StackLayout
            { 
                Padding = new Thickness(10, 10, 10, 20),
                Children =
                {
                            new Label { Text = "Participações", HorizontalOptions = LayoutOptions.Center, FontSize = 18}
                }
            };

            //Conteudo do ScrollView
            StackLayout scrollContent = new StackLayout();

            //Objeto Scroll
            ScrollView scroll = new ScrollView();

            for (int i = 0; i < pesquisas.Contents.Count; i++)
            {
                int totalParticipacao = 0;
                var aux = new StackLayout();
                aux.Children.Add(new Label(){ Text = string.Format("{0}-({1})", pesquisas.Contents[i].NOM_PESQUISA, TotalParticipacao(pesquisas.Contents[i])) });

                //Adiciona objetos conteudo do scroll
                scrollContent.Children.Add(aux);
            }

            //Adiciona a lista de objetos dentro do scroll
            scroll.Content = scrollContent;

            layout.Children.Add(scroll);

            Content = layout;
        }

        private int TotalParticipacao(CAD_PESQUISA pesquisa)
        {
            int total = 0;
            var participacoes = App.Database.GetParticipacoes();
            total = (from part in participacoes
                              where part.COD_PESQUISA == pesquisa.COD_PESQUISA
                              group part by part.Token).Count();
            return total;

        }

    }
}


