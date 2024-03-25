using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByCpf(string cpf);
    }
}
