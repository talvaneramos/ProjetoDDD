using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Models
{
    public class DepedenteCadastroModel
    {
        [Required(ErrorMessage = " Por favor, informe o nome do dependente. ")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = " Por favor, informe a data de nascimento do dependente. ")]
        public string? DataNascimento { get; set; }

        [Required(ErrorMessage = " Por favor, informe id do Funcionário. ")]
        public string? IdFuncionario { get; set; }
    }
}
