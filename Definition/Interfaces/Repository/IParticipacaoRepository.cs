using System;
using Definition.Dto;
using System.Threading.Tasks;
using Definition.Model;

namespace Definition.Interfaces.Repository
{
    public interface IParticipacaoRepository
    {
        Task<Result<string>> Inserir(CAD_PARTICIPACAO part);
    }
}

