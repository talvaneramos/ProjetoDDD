using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        private readonly DataContext _dataContext;

        public DependenteRepository(DataContext dataContext)
            : base(dataContext) 
        {
            _dataContext = dataContext;
        }
    }
}
