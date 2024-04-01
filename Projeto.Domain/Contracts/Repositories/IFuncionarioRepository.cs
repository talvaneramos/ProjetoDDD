﻿using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByCpf(string cpf);

        int CountDependentes(int idFuncionario);

    }
}
