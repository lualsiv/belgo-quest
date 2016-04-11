using System;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Definition.Dto
{
    [Table("CAD_PERGUNTA")]
    public class CAD_PERGUNTA
    {
        public CAD_PERGUNTA()
        {
        }

        [PrimaryKey]
        [JsonProperty("ID")]
        public int COD_PERGUNTA
        {
            get;
            set;
        }

        [JsonProperty("IdPesquisa")]
        public int COD_PESQUISA
        {
            get;
            set;
        }

        [JsonProperty("Descricao")]
        public string DSC_PERGUNTA
        {
            get;
            set;
        }

        [JsonProperty("Tipo")]
        public string IND_TPO_PERGUNTA
        {
            get;
            set;
        }

        [JsonProperty("Ordem")]
        public int NUM_ORDEM_PEGUNTA
        {
            get;
            set;
        }

        [ForeignKey(typeof(CAD_PESQUISA))]
        [Indexed]
        public int PesquisaId
        {
            get;
            set;
        }

        [ManyToOne]
        public CAD_PESQUISA Pesquisa
        {
            get;
            set;
        }

        [OneToMany("PerguntaId", CascadeOperations = CascadeOperation.All)]
        [JsonProperty("Respostas")]
        public List<CAD_RESPOSTA> Respostas
        {
            get;
            set;
        }
    }
}

