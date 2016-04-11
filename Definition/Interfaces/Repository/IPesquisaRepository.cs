using System;
using Definition.Dto;
using System.Collections.Generic;
using Definition.Model;
using System.Threading.Tasks;


namespace Definition.Interfaces.Repository
{
    public interface IPesquisaRepository
    {
        Task<Result<IList<CAD_PESQUISA>>> GetData();
    }
}

