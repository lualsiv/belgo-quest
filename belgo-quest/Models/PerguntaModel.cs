using System;
using SQLite.Net.Attributes;

namespace belgoquest
{
    public class PerguntaModel
    {
        public PerguntaModel()
        {
        }

        [PrimaryKey]
        public int COD_PERGUNTA
        {
            get;
            set;
        }
        public int COD_PESQUISA
        {
            get;
            set;
        }

        public string DSC_PERGUNTA
        {
            get;
            set;
        }

        public int IND_TPO_PERGUNTA
        {
            get;
            set;
        }

        public int NUM_ORDEM_PEGUNTA
        {
            get;
            set;
        }


    }
}

