using System;
using SQLite.Net.Attributes;

namespace belgoquest
{
    public class RespostaModel
    {
        [PrimaryKey]
        public int COD_RESPOSTA
        {
            get;
            set;
        }

        public int COD_PERGUNTA {
            get;
            set;
        }

        public string DSC_RESPOSTA {
            get;
            set;
        }


        public RespostaModel()
        {
        }
    }
}

