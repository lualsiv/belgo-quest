using System;
using Definition.Interfaces;
using Definition;
using Definition.Interfaces.Repository;

namespace DataService
{
    public class ParticipacaoService : IParticipacaoService
    {

        IParticipacaoRepository _participacaoRepository;
        public ParticipacaoService(IParticipacaoRepository participacaoRepository)
        {
            _participacaoRepository = participacaoRepository;
        }

        #region IParticipacaoService implementation

        public System.Threading.Tasks.Task<Definition.Model.Result<string>> Inserir(Definition.Dto.CAD_PARTICIPACAO part)
        {
            return _participacaoRepository.Inserir(part);
        }

        #endregion


    }
}

