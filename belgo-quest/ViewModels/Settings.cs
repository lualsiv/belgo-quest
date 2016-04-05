using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace belgoquest
{
    public class Settings : BaseViewModel
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        static Settings settings;
        public static Settings Current
        {
            get { return settings ?? (settings = new Settings()); }
        }

        #region Setting Constants

        const string URIWEBSERVICES = "UriWebServices";
        static readonly string UriWebServicesDefault = "http://belgo-quest.com";

        #endregion

        public string UriWebServices
        {
            get
            { 
                return AppSettings.GetValueOrDefault<string>(URIWEBSERVICES, UriWebServicesDefault); 
            }
            set
            { 
                if (AppSettings.AddOrUpdateValue<string>(URIWEBSERVICES, value))
                    OnPropertyChanged();

            }
        }
    }
}

