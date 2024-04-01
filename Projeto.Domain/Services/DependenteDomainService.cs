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

        public DependenteDomainService(IDependenteRepository dependenteRepository)
            : base(dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }
    }
}
