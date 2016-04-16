using System;
using Definition.Dto;
using System.Threading.Tasks;
using Definition.Model;

namespace Definition.Interfaces
{
    public interface IParticipacaoService
    {
        Task<Result<string>> Inserir(CAD_PARTICIPACAO part);
    }

}

