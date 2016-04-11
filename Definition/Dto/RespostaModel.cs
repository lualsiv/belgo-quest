using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace Definition.Dto
{
    public class CAD_RESPOSTA
    {
        [PrimaryKey]
        [JsonProperty("ID")]
        public int COD_RESPOSTA
        {
            get;
            set;
        }

        [JsonProperty("IdPergunta")]
        public int COD_PERGUNTA {
            get;
            set;
        }

        [JsonProperty("Descricao")]
        public string DSC_RESPOSTA {
            get;
            set;
        }

        [ForeignKey(typeof(CAD_PERGUNTA))]
        [Indexed]
        public int PerguntaId
        {
            get;
            set;
        }

        [ManyToOne]
        public CAD_PERGUNTA Pergunta
        {
            get;
            set;
        }

        public CAD_RESPOSTA()
        {
        }
    }
}

