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
        [JsonIgnore]
        public int COD_PARTICIPACAO
        {
            get;
            set;
        }

        [JsonProperty("idPergunta")]
        public int COD_PERGUNTA
        {
            get;
            set;
        }

        [JsonProperty("idResposta")]
        public int? COD_RESPOSTA
        {
            get;
            set;
        }

        [JsonProperty("Descricao")]
        public string DSC_RESP_DISSERTATIVA
        {
            get;
            set;
        }

        [JsonProperty("RespostaNula")]
        public string IND_RESPOSTA_NULA
        {
            get;
            set;
        }

        [JsonProperty("DataParticipacao")]
        public DateTime DTA_PARTICIPACAO
        {
            get;
            set;
        }

        [JsonProperty("DataSincronizacao")]
        public DateTime DTA_SINCRONIZACAO
        {
            get;
            set;
        }
    }
}

