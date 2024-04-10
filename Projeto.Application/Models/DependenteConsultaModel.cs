﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Models
{
    public class DependenteConsultaModel
    {
        public string? IdDependente { get; set; }
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? IdFuncionario { get; set; }

        public FuncionarioConsultaModel? Funcionario { get; set; }
    }
}
