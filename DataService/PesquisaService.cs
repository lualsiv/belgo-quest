using Definition.Dto;
using Definition.Interfaces;
using Definition.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Definition.Model;

namespace DataService
{
    public class PesquisaService : IPesquisaService
    {

        IPesquisaRepository _pesquisaRepository;
        public PesquisaService(IPesquisaRepository pesquisaRepository)
        {
            _pesquisaRepository = pesquisaRepository;
        }


        #region IPesquisaService implementation

        public Task<Result<IList<CAD_PESQUISA>>> GetData()
        {
            return _pesquisaRepository.GetData();
        }

        #endregion


    }
}

