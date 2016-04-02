using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace belgoquest
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MasterPageItemModel);

            if (Device.OS == TargetPlatform.WinPhone) {
                Master.Icon = "swap.png";
            }

//            Master = new MasterPage();
//            Detail = new NavigationPage(new Pesquisas());
        }

        void NavigateTo (MasterPageItemModel menu)
        {
            Page displayPage = ViewFactory.CreatePage(menu.TargetType);

            Detail = new NavigationPage (displayPage);

            IsPresented = false;
        }
    }
}

