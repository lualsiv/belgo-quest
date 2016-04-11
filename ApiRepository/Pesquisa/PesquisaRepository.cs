using Definition.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Model;


namespace ApiRepository.Repository
{
    public partial class PesquisaRepository
    {
        #region IPesquisaRepository implementation

        public async Task<Result<IList<CAD_PESQUISA>>> GetData()
        {
            Result<IList<CAD_PESQUISA>> retorno;

            retorno = await base.GetList<CAD_PESQUISA>(string.Empty);

            return retorno;
        }

        #endregion


    }
}

