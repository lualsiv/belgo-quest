using System;
using Definition.Interfaces.Repository;

namespace ApiRepository.Repository
{
    public partial class PesquisaRepository : BaseRepository, IPesquisaRepository
    {
        public PesquisaRepository(string baseUrl, string entity): base(baseUrl, entity)
        {
        }
    }
}

