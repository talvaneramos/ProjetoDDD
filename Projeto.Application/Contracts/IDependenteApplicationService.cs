using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    public interface IDependenteApplicationService
    {
        void Add(DepedenteCadastroModel model);
        void Update(DependenteEdicaoModel model);
        void Delete(int id);
        List<DependenteConsultaModel> GetAll();
        DependenteConsultaModel GetById(int id);
    }
}
