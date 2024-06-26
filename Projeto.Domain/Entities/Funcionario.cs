﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal? Salario { get; set; }

        public List<Dependente>? Dependentes { get; set; }
    }
}
