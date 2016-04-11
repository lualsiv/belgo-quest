using Definition.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Model;

namespace Definition.Interfaces
{
    public interface IPesquisaService
    {

        Task<Result<IList<CAD_PESQUISA>>> GetData();
    }
}

