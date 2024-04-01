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
    /// <summary>
    /// Construtor com passagem de parâmetros/argumentos.
    /// base(funcionarioRepository) significa que chama o construtor da classe Pai. 
    /// </summary>
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository)
            : base(funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
    }
}
