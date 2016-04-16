using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using belgoquest.CustomControls;
using belgoquest.Controls;
using belgoquest.ViewModel;

namespace belgoquest
{
    public class Pesquisa : ContentPage
    {
        public Pesquisa()
        {
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            PesquisaViewModel pesquisa = (PesquisaViewModel)BindingContext;

            StackLayout layout = new StackLayout
            { 
                Padding = new Thickness(10, 10, 10, 20),
                Children =
                {
                    new Label { Text = pesquisa.Nome }
                }
            };

            //Conteudo do ScrollView
            StackLayout scrollContent = new StackLayout();

            //Objeto Scroll
            ScrollView scroll = new ScrollView();

            for (int i = 0; i < pesquisa.Perguntas.Count; i++)
            {
                var aux = new StackLayout();
                aux.Children.Add(new Label(){ Text = pesquisa.Perguntas[i].Descricao });

                switch (pesquisa.Perguntas[i].TipoPergunta)
                {
                    case "U":
                        BindableRadioGroup radio = new BindableRadioGroup(){ Text = "Descricao", ItemsSource = pesquisa.Perguntas[i].Respostas };
                        radio.BindingContext = pesquisa.Perguntas[i];
                        radio.SetBinding(BindableRadioGroup.SelectedIndexProperty, new Binding("SelectedIndex", BindingMode.TwoWay));
                        radio.SetBinding(BindableRadioGroup.SelectedItemProperty, new Binding("SelectedItem", BindingMode.TwoWay));
                        aux.Children.Add(radio);

                        break;
                    case "M":
                        for (int j = 0; j < pesquisa.Perguntas[i].Respostas.Count; j++)
                        {
                            CheckBox check = new CheckBox();
                            check.BindingContext = pesquisa.Perguntas[i].Respostas[j];
                            check.SetBinding(CheckBox.DefaultTextProperty, new Binding("Descricao", BindingMode.Default));
                            check.SetBinding(CheckBox.CheckedProperty, new Binding("IsChecked", BindingMode.TwoWay));
                            aux.Children.Add(check);
                        }
                        break;

                    default:
                        Entry text = new Entry();
                        text.BindingContext = pesquisa.Perguntas[i];
                        text.SetBinding(Entry.TextProperty, new Binding("Texto", BindingMode.TwoWay));
                        aux.Children.Add(text);
                        break;
                }

                //Adiciona objetos conteudo do scroll
                scrollContent.Children.Add(aux);
            }


            //Adiciona a lista de objetos dentro do scroll
            scroll.Content = scrollContent;

            layout.Children.Add(scroll);

            Button finalizar = new Button()
            { 
                    Text = "Finalizar",
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.FillAndExpand
            };

            finalizar.SetBinding(Button.CommandProperty, new Binding("FinalizarCommand", BindingMode.Default));

            layout.Children.Add(finalizar);

            Content = layout;


        }


    }
}


