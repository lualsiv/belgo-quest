using System;
using SQLite.Net.Attributes;
using System.Collections;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Definition.Dto
{
    [Table("CAD_PESQUISA")]
    public class CAD_PESQUISA
    {
        [PrimaryKey]
        [JsonProperty("ID")]
        public int COD_PESQUISA {
            get;
            set;
        }

        [JsonProperty("Nome")]
        public string NOM_PESQUISA
        {
            get;
            set;
        }

        [JsonProperty("Fechado")]
        public bool? IND_FECHADO
        {
            get;
            set;
        }


        public CAD_PESQUISA()
        {
            Perguntas = new List<CAD_PERGUNTA>();
        }


        [OneToMany("PesquisaId", CascadeOperations = CascadeOperation.All)]
        [JsonProperty("Perguntas")]
        public List<CAD_PERGUNTA> Perguntas
        {
            get;
            set;
        }
    }
}

