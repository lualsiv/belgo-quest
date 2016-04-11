using System;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace belgoquest
{
    public static class Settings
    {
        public static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        const string URIWEBSERVICES = "UriWebServices";
        static readonly string UriWebServicesDefault = "http://api.ftcon.com.br/api/";

        #endregion

        public static string UriWebServices
        {
            get
            { 
                return PCLWebUtility.WebUtility.UrlDecode(AppSettings.GetValueOrDefault<string>(URIWEBSERVICES, UriWebServicesDefault)); 
            }
            set
            { 
                AppSettings.AddOrUpdateValue<string>(URIWEBSERVICES, PCLWebUtility.WebUtility.UrlEncode(value));
                    

            }
        }
    }
}

