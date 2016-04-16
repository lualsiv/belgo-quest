using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Definition.Dto;

namespace belgoquest
{
    public class BelgoDatabase
    {
        

        static object locker = new object ();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public BelgoDatabase(SQLiteConnection conn)
        {
            database = conn;

            // create the tables
            database.CreateTable<CAD_PESQUISA>();
            database.CreateTable<CAD_PERGUNTA>();
            database.CreateTable<CAD_RESPOSTA>();
            database.CreateTable<CAD_PARTICIPACAO>();
        }

        public  int SaveListPesquisa(IEnumerable<CAD_PESQUISA> listaPesq)
        {
            int retorno = database.InsertAll(listaPesq, true);

            return retorno;
        }

        public  int SaveListPergunta(IEnumerable<CAD_PERGUNTA> listaPerg)
        {
            int retorno = database.InsertAll(listaPerg, true);
            return retorno;
        }

        public  int SaveListResposta(IEnumerable<CAD_RESPOSTA> listaResp)
        {
            int retorno = database.InsertAll(listaResp, true);
            return retorno;
        }

        public IEnumerable<CAD_PARTICIPACAO> GetParticipacoes()
        {
            lock (locker)
            {
                return (from part in database.Table<CAD_PARTICIPACAO>() select part).ToList();
            }
        }

        public IEnumerable<CAD_PESQUISA> GetPesquisas()
        {
            lock (locker) {
                return (from i in database.Table<CAD_PESQUISA>() select i);
            }
        }

        public IEnumerable<CAD_PERGUNTA> GetPerguntas(int codPesquisa)
        {
            lock (locker) {
                return (from i in database.Table<CAD_PERGUNTA>() where i.COD_PESQUISA == codPesquisa  orderby i.NUM_ORDEM_PEGUNTA select i).ToList();
            }
        }

        public IEnumerable<CAD_RESPOSTA> GetRespostas(int codPergunta)
        {
            lock (locker) {
                return (from i in database.Table<CAD_RESPOSTA>() where i.COD_PERGUNTA == codPergunta select i).ToList();
            }
        }

        public CAD_PESQUISA GetPesquisa (int id) 
        {
            lock (locker) {
                return database.Table<CAD_PESQUISA>().FirstOrDefault(x => x.COD_PESQUISA == id);
            }
        }

        public int SaveParticipacao (CAD_PARTICIPACAO item) 
        {
            lock (locker) {
                
                return database.Insert(item);
            }
        }

        public int DeleteParticipacao(int id)
        {
            lock (locker) {
                return database.Delete<CAD_PARTICIPACAO>(id);
            }
        }
    }
}

