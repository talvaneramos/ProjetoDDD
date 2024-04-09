using Microsoft.EntityFrameworkCore;
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
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly DataContext _dataContext;

        public FuncionarioRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override List<Funcionario> GetAll()
        {
            return _dataContext
                            .Funcionario
                            .Include(f => f.Dependentes)
                            .ToList();
        }

        public override Funcionario GetById(int id)
        {
            return _dataContext
                        .Funcionario
                        .Include(f => f.Dependentes)
                        .FirstOrDefault(f => f.IdFuncionario == id);

        }

        public Funcionario GetByCpf(string cpf)
        {
            return _dataContext
                        .Funcionario
                        .FirstOrDefault(f => f.Cpf.Equals(cpf));
        }

        public int CountDependentes(int idFuncionario)
        {
            return _dataContext
                        .Dependente
                        .Count(f => f.IdFuncionario == idFuncionario);
        }
    }
}
