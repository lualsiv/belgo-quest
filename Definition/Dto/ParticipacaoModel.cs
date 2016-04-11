using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace Definition.Dto
{
    public class CAD_PARTICIPACAO
    {
        public CAD_PARTICIPACAO()
        {
        }

        [PrimaryKey, AutoIncrement]
        [JsonProperty]
        public int COD_PARTICIPACAO
        {
            get;
            set;
        }

        [JsonProperty]
        public int COD_PERGUNTA
        {
            get;
            set;
        }

        [JsonProperty]
        public int COD_RESPOSTA
        {
            get;
            set;
        }

        [JsonProperty]
        public string DSC_RESP_DISSERTATIVA
        {
            get;
            set;
        }

        [JsonProperty]
        public string IND_RESPOSTA_NULA
        {
            get;
            set;
        }

        [JsonProperty]
        public DateTime DTA_PARTICIPACAO
        {
            get;
            set;
        }
    }
}

