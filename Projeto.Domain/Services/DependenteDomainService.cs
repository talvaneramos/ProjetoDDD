using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService : BaseDomainService<Dependente>, IDependenteDomainService
    {
        private readonly IDependenteRepository _dependenteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public DependenteDomainService(IDependenteRepository dependenteRepository, IFuncionarioRepository funcionarioRepository)
            : base(dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public override void Add(Dependente obj)
        {
            var quantidade = _funcionarioRepository.CountDependentes(obj.IdFuncionario);

            if (quantidade >= 3)
            {
                throw new Exception("Funcionário atingiu o limite de 3 Dependentes. ");
            }
            else
            {
                _dependenteRepository.Add(obj);
            }
        }

        public override void Update(Dependente obj)
        {
            var quantidade = _funcionarioRepository.CountDependentes(obj.IdFuncionario);

            if (quantidade >= 3)
            {
                throw new Exception("Funcionário atingiu o limite de 3 Dependentes. ");
            }
            else
            {
                _dependenteRepository.Update(obj);
            }
        }
    }
}
