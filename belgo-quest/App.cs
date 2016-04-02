using System;

using Xamarin.Forms;

namespace belgoquest
{
    public class App : Application
    {

        public static INavigation Navigation {
            get;
            set;
        }

        static void RegisterTypes ()
        {
            // This can be replaced by any number of MVVM tools. It is done this way merely because this 
            // is not intended to be a demo of those tools.

            ViewFactory.Register<MasterPage, MasterPageViewModel> ();
            ViewFactory.Register<Pesquisas, PesquisaListViewModel> ();
            ViewFactory.Register<SincronizarPesquisa, SincronizarPesquisaViewModel> ();
            ViewFactory.Register<SincronizarResposta, SincronizarRespostaViewModel> ();
            ViewFactory.Register<Configuracao, ConfiguracaoViewModel> ();
        }


        static SQLite.Net.SQLiteConnection conn;
        static BelgoDatabase database;
        public static void SetDatabaseConnection (SQLite.Net.SQLiteConnection connection)
        {
            conn = connection;
            database = new BelgoDatabase (conn);
        }
        public static BelgoDatabase Database {
            get { return database; }
        }

        public App()
        {
            RegisterTypes();

            var mainPage = new belgoquest.MainPage(){
                BackgroundColor = Color.Transparent,
                BackgroundImage = "Belgo01.png"
            };

            MainPage = mainPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

