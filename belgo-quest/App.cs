using System;
using ApiRepository.Repository;
//using Common;
//using DataService;
//using Definition.Enums;
using Definition.Interfaces;
//using Definition.Interfaces.Messenger;
using Definition.Interfaces.Repository;
//using Definition.Interfaces.Service;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
//using Mobile.Helper;
//using Mobile.Messenger;
//using Mobile.Model;
//using Mobile.Stack;
//using Mobile.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using DataService;
using belgoquest.ViewModel;
using Definition.Dto;

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
            ViewFactory.Register<PesquisasList, PesquisaListViewModel> ();
            ViewFactory.Register<Pesquisa, PesquisaViewModel>();
            ViewFactory.Register<SincronizarPesquisa, SincronizarPesquisaViewModel> ();
            ViewFactory.Register<SincronizarResposta, SincronizarRespostaViewModel> ();
            ViewFactory.Register<Configuracao, ConfiguracaoViewModel> ();
            ViewFactory.Register<Ajuda, AjudaViewModel> ();
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
            
            // Set default ServiceLocatorProvider 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterTypes();


            // Load Repositories
            InitializeRepositories();

            // Load Data Services
            InitializeDataServices();

            // Load Models
            InitializeModels();

            InitializeViewModels();

            var mainPage = new belgoquest.MainPage(){
                BackgroundColor = Color.Default,
                BackgroundImage = "Belgo01.png"
            };

            MainPage = mainPage;

        }

        /// <summary>
        /// Helper function to check if already registered before trying again
        /// </summary>
        private void RegisterOnce<TInterface, TClass>() where TClass : class
            where TInterface : class
        {
            if (!SimpleIoc.Default.IsRegistered<TInterface>())
                SimpleIoc.Default.Register<TInterface, TClass>();
        }

        private void RegisterOnce<TClass>() where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TClass>())
                SimpleIoc.Default.Register<TClass>();
        }

        private void RegisterOnce<T>(Func<T> func) where T : class
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
                SimpleIoc.Default.Register<T>(func);
        }

        private void InitializeRepositories()
        {
            RegisterOnce<IPesquisaRepository>(() => new PesquisaRepository(Settings.UriWebServices, "pesquisa/fechado/sim"));
            RegisterOnce<IParticipacaoRepository>(() => new ParticipacaoRepository(Settings.UriWebServices, "participacao"));
        }

        private void InitializeDataServices()
        {
            
            RegisterOnce<IPesquisaService, PesquisaService>();
            RegisterOnce<IParticipacaoService, ParticipacaoService>();

        }

        private void InitializeModels()
        {
            RegisterOnce<CAD_PESQUISA>();
            RegisterOnce<CAD_PERGUNTA>();
            RegisterOnce<CAD_RESPOSTA>();
            RegisterOnce<CAD_PARTICIPACAO>();

        }

        /// <summary>
        /// Automatically create an instance of and register any ViewModel found in the namespace
        /// Mobile.ViewModel
        /// </summary>
        public void InitializeViewModels()
        {
            string @namespace = "belgoquest.ViewModel";

            var query = from t in typeof(App).GetTypeInfo().Assembly.DefinedTypes
                    where t.IsClass && !t.IsSealed && t.Namespace == @namespace && t.Name != "BaseViewModel"
                select t;

            foreach (var t in query.ToList())
            {
                var defaultConstructor = t.DeclaredConstructors.First();

                object instance = null;

                if (defaultConstructor.GetParameters().Count() == 0)
                    instance = (BaseViewModel)Activator.CreateInstance(t.AsType());
                else
                {
                    List<object> parameters = new List<object>();
                    foreach (var p in defaultConstructor.GetParameters())
                    {
                        parameters.Add(ServiceLocator.Current.GetInstance(p.ParameterType));
                    }

                    instance = (BaseViewModel)Activator.CreateInstance(t.AsType(), parameters.ToArray());
                }

                // Subscribe to all messenger events
//                ((BaseViewModel)instance).Subscribe();

                SimpleIoc.Default.Register(() => instance, t.ToString());
            }

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

