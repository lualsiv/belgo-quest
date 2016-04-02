using System;
using Xamarin.Forms;

namespace belgoquest
{
    public class ViewModelNavigation
    {
        readonly Page implementor;

        public ViewModelNavigation (Page implementor)
        {
            this.implementor = implementor;
        }

        public void Push (Page page)
        {
            Application.Current.MainPage.Navigation.PushAsync (page);
        }

        public void Push<TViewModel> ()
            where TViewModel : BaseViewModel
        {
            Push (ViewFactory.CreatePage<TViewModel> ());
        }

        public void Pop ()
        {
            Application.Current.MainPage.Navigation.PopAsync ();
        }

        public void PopToRoot ()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync ();
        }

        public void PushModal (Page page)
        {
            Application.Current.MainPage.Navigation.PushModalAsync (page);
        }

        public void PushModal<TViewModel> ()
            where TViewModel : BaseViewModel
        {
            PushModal (ViewFactory.CreatePage<TViewModel> ());
        }

        public void PopModal ()
        {
            var modalParent = implementor;
            while (modalParent.Parent as Page != null)
                modalParent = (Page) modalParent.Parent;
            Application.Current.MainPage.Navigation.PopModalAsync ();
        }
    }
}

