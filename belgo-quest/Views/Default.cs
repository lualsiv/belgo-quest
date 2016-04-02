using System;

using Xamarin.Forms;

namespace belgoquest
{
    public class Default : ContentPage
    {
        public Default()
        {
            Content = new StackLayout
            { 
                Children =
                {
                            new Label { Text = "BEM VINDO AO BELGO QUEST", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand}
                }
            };
        }
    }
}


