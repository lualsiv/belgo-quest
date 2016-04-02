using System;
using SQLite.Net.Attributes;

namespace belgoquest
{
    
    public class PesquisaModel
    {
        [PrimaryKey]
        public int COD_PESQUISA {
            get;
            set;
        }

        public string NOM_PESQUISA
        {
            get;
            set;
        }

        public bool IND_FECHADO
        {
            get;
            set;
        }

        public PesquisaModel()
        {
            
        }
    }
}

