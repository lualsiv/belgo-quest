using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using belgoquest.CustomControls;
using belgoquest.Controls;

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

            for (int i = 0; i < pesquisa.Perguntas.Count; i++)
            {
                var aux = new StackLayout();
                aux.Children.Add(new Label(){ Text = pesquisa.Perguntas[i].Descricao });

                switch (pesquisa.Perguntas[i].TipoPergunta)
                {
                    case 1:
                        for (int j = 0; j < pesquisa.Perguntas[i].Respostas.Count; j++)
                        {
                            CustomRadioButton radio = new CustomRadioButton();
                            radio.BindingContext = pesquisa.Perguntas[i].Respostas[j];
                            radio.SetBinding(CustomRadioButton.TextProperty, new Binding("Descricao", BindingMode.Default));
                            radio.SetBinding(CustomRadioButton.CheckedProperty, new Binding("IsChecked", BindingMode.TwoWay));
                            aux.Children.Add(radio);
                        }
                        break;
                    case 2:
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
                layout.Children.Add(aux);
            }

            Content = layout;


        }


    }
}


