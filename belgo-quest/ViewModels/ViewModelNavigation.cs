using System;
using Xamarin.Forms;
using belgoquest.ViewModel;
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
            ((MainPage)Application.Current.MainPage).Detail.Navigation.PushAsync (page);
        }

        public void Push<TViewModel> ()
            where TViewModel : BaseViewModel
        {
            Push (ViewFactory.CreatePage<TViewModel> ());
        }

        public void Pop ()
        {
            ((MainPage)Application.Current.MainPage).Detail.Navigation.PopAsync ();
        }

        public void PopToRoot ()
        {
            ((MainPage)Application.Current.MainPage).Detail.Navigation.PopToRootAsync ();
        }

        public void PushModal (Page page)
        {
            ((MainPage)Application.Current.MainPage).Detail.Navigation.PushModalAsync (page);
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
            ((MainPage)Application.Current.MainPage).Detail.Navigation.PopModalAsync ();
        }

        public void New<TViewModel> ()
            where TViewModel : BaseViewModel
        {
            ((MainPage)Application.Current.MainPage).Detail = new NavigationPage(ViewFactory.CreatePage<TViewModel> ());
        }
    }
}

