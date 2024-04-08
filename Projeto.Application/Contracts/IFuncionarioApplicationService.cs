using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioApplicationService
    {
        void Add(FuncionarioCadastroModel model);
        void Update(FuncionarioEdicaoModel model);
        void Delete(int id);
        List<FuncionarioConsultaModel> GetAll();
        FuncionarioConsultaModel GetById(int id);
    }
}
