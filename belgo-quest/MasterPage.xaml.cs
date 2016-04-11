using System;
using System.Collections.Generic;

using Xamarin.Forms;
using belgoquest.ViewModel;

namespace belgoquest
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var contents = new List<MasterPageItemModel>();
            contents.Add(new MasterPageItemModel
                {
                    Title = "Realizar Pesquisa",
                    IconSource = "ic_content_paste_black_48dp.png",
                    TargetType = typeof(PesquisaListViewModel)
                });
            contents.Add(new MasterPageItemModel
                {
                    Title = "Sincronizar Pesquisas",
                    IconSource = "ic_autorenew_black_48dp.png",
                    TargetType = typeof(SincronizarPesquisaViewModel)
                });
            contents.Add(new MasterPageItemModel
                {
                    Title = "Sincronizar Respostas",
                    IconSource = "ic_backup_black_48dp.png",
                    TargetType = typeof(SincronizarRespostaViewModel)
                });
            
            contents.Add(new MasterPageItemModel
                {
                    Title = "Configurar Sincronização",
                    IconSource = "ic_settings_black_48dp.png",
                    TargetType = typeof(ConfiguracaoViewModel)
                });

            listView.ItemsSource = contents;
        }
    }
}

