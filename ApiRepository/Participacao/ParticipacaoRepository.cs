using System;
using Definition.Model;
using Definition.Dto;

namespace ApiRepository.Repository
{
    public partial class ParticipacaoRepository
    {
        #region IParticipacaoRepository implementation

        public async System.Threading.Tasks.Task<Definition.Model.Result<string>> Inserir(Definition.Dto.CAD_PARTICIPACAO part)
        {
            Result<string> retorno;
            retorno = await base.Post<CAD_PARTICIPACAO, string>(part, string.Empty);

            return retorno;
        }

        #endregion
    }
}

