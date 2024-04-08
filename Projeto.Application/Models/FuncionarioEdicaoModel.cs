using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do Funcionário. ")]
        public string? IdFuncionario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do Funcionário. ")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do Funcionário. ")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data Admissão do Funcionário. ")]
        public string? DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o salário do Funcionário. ")]
        public string? Decimal { get; set; }
    }
}
