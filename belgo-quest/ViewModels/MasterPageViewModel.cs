using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace belgoquest.ViewModel
{
    public class MasterPageViewModel : BaseViewModel
    {
        ObservableCollection<MasterPageItemModel> contents = new ObservableCollection<MasterPageItemModel> ();
        public ObservableCollection<MasterPageItemModel> Contents { 
            get { return contents; } 
            set
            {
                if (contents == value)
                    return;
                contents = value;
                OnPropertyChanged ();
            }
        }

        public MasterPageViewModel()
        {
            
            contents.Add (new MasterPageItemModel {
                Title = "Realizar Pesquisa",
                IconSource = "ic_content_paste_black_48dp.png",
                TargetType = typeof(PesquisaListViewModel)
            });
            contents.Add (new MasterPageItemModel {
                Title = "Sincronizar Pesquisas",
                IconSource = "ic_autorenew_black_48dp.png",
                TargetType = typeof(SincronizarPesquisaViewModel)
            });
//            contents.Add (new MasterPageItemModel {
//                Title = "Sincronizar Respostas",
//                IconSource = "ic_backup_black_48dp.png",
//                TargetType = typeof(SincronizarResposta)
//            });
//
//            contents.Add (new MasterPageItemModel {
//                Title = "Configurar Sincronização",
//                IconSource = "ic_settings_black_48dp.png",
//                TargetType = typeof(Configuracao)
//            });
        }

        object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;
                // something was selected
                selectedItem = value;

                OnPropertyChanged ();

                if (selectedItem != null) {

                    var item = ((MasterPageItemModel)selectedItem);

                    this.Navigation.Push(ViewFactory.CreatePage(item.TargetType));

                    selectedItem = null;
                }
            }
        }
    }
}

