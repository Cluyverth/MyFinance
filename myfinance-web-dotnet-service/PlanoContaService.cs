using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private IPlanoContaRepository _planoContaRepository;
        public PlanoContaService(IPlanoContaRepository planoContaRepository) 
        {
            _planoContaRepository = planoContaRepository;
        }
        public void Cadastrar(PlanoConta Entidade)
        {
            _planoContaRepository.Cadastrar(Entidade);
        }

        public PlanoConta Consultar(int id)
        {
           return _planoContaRepository.Consultar(id);
        }

        public void Excluir(int id)
        {
            _planoContaRepository.Excluir(id);
        }

        public List<PlanoConta> ListarRegistros()
        {
           return _planoContaRepository.ListarRegistros();
        }
    }
}
