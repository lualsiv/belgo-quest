using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;

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
            database.CreateTable<PesquisaModel>();
            database.CreateTable<PerguntaModel>();
//            database.CreateTable<>();
        }

        public IEnumerable<PesquisaModel> GetPesquisas()
        {
            lock (locker) {
                return (from i in database.Table<PesquisaModel>() select i).ToList();
            }
        }

        public IEnumerable<PerguntaModel> GetPerguntas(int codPesquisa)
        {
            lock (locker) {
                return (from i in database.Table<PerguntaModel>() where i.COD_PESQUISA == codPesquisa  orderby i.NUM_ORDEM_PEGUNTA select i).ToList();
            }
        }

        public IEnumerable<RespostaModel> GetRespostas(int codPergunta)
        {
            lock (locker) {
                return (from i in database.Table<RespostaModel>() where i.COD_PERGUNTA == codPergunta select i).ToList();
            }
        }

        public PesquisaModel GetPesquisa (int id) 
        {
            lock (locker) {
                return database.Table<PesquisaModel>().FirstOrDefault(x => x.COD_PESQUISA == id);
            }
        }

//        public int SaveItem (TodoItem item) 
//        {
//            lock (locker) {
//                if (item.ID != 0) {
//                    database.Update(item);
//                    return item.ID;
//                } else {
//                    return database.Insert(item);
//                }
//            }
//        }
//
//        public int DeleteItem(int id)
//        {
//            lock (locker) {
//                return database.Delete<TodoItem>(id);
//            }
//        }
    }
}

