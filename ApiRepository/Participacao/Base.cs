using System;
using Definition;
using Definition.Interfaces.Repository;

namespace ApiRepository.Repository
{
    public partial class ParticipacaoRepository : BaseRepository, IParticipacaoRepository
    {
        

        public ParticipacaoRepository(string baseUrl, string entity) : base(baseUrl, entity)
        {
        }
    }
}

