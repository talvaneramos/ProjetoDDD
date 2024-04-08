using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class DependenteApplicationService : IDependenteApplicationService
    {
        private readonly IDependenteDomainService _dependenteDomainService;

        public DependenteApplicationService(IDependenteDomainService dependenteDomainService)
        {
            _dependenteDomainService = dependenteDomainService;
        }

        public void Add(DepedenteCadastroModel model)
        {
            var dependente = new Dependente();

            dependente.Nome = model.Nome;
            dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
            dependente.IdFuncionario = int.Parse(model.IdFuncionario);

            _dependenteDomainService.Add(dependente);
            
        }

        public void Update(DependenteEdicaoModel model)
        {
            var dependente = new Dependente();

            dependente.IdDependente = int.Parse(model.IdDependente);
            dependente.Nome = model.Nome;
            dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
            dependente.IdFuncionario = int.Parse(model.IdFuncionario);

            _dependenteDomainService.Update(dependente);
        }

        public void Delete(int id)
        {
            var dependente = _dependenteDomainService.GetById(id);

            if (dependente != null)
            {
                _dependenteDomainService.Delete(dependente);
            }
            else
            {
                throw new Exception("Dependente não encontrado. ");
            }
        }

        public List<DependenteConsultaModel> GetAll()
        {
            var lista = new List<DependenteConsultaModel>();

            foreach (var item in _dependenteDomainService.GetAll())
            {
                var model = new DependenteConsultaModel();

                model.IdDependente = item.IdDependente.ToString();
                model.Nome = item.Nome;
                model.DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy");
                model.IdFuncionario = item.Funcionario.ToString();

                lista.Add(model);
            }
            return lista;
        }

        public DependenteConsultaModel GetById(int id)
        {
            var dependente = _dependenteDomainService.GetById(id);

            if(dependente != null)
            {
                var model = new DependenteConsultaModel();

                model.IdDependente = dependente.IdDependente.ToString();
                model.Nome = dependente.Nome;
                model.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                model.IdFuncionario = dependente.IdFuncionario.ToString();

                return model;
            }
            else
            {
                throw new Exception("Erro! Dependente não foi encontrado. ");
            }
        }
    }
}
