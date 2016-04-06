using System;

using Xamarin.Forms;

namespace belgoquest
{
    public class Pesquisa : ContentPage
    {
        public Pesquisa()
        {
            Content = new StackLayout
            { 
                Children =
                {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}


