using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Models
{
    public class FuncionarioCadastroModel 
    {
        [Required(ErrorMessage = "Por favor, informe o Nome do Funcionário. ")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Cpf do Funcionário. ")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Data Admissão do Funcionário. ")]
        public string? DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o salário do Funcionário. ")]
        public string? Decimal { get; set; }
    }
}
