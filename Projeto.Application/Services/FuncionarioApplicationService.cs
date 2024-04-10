using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using Projeto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly IFuncionarioDomainService _funcionarioDomainService;

        public FuncionarioApplicationService(IFuncionarioDomainService funcionarioDomainService)
        {
            _funcionarioDomainService = funcionarioDomainService;
        }

        public void Add(FuncionarioCadastroModel model)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.Salario = decimal.Parse(model.Salario);
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);

            _funcionarioDomainService.Add(funcionario); 
        }

        public void Update(FuncionarioEdicaoModel model)
        {
            var funcionario = new Funcionario();

            funcionario.IdFuncionario = int.Parse(model.IdFuncionario);
            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.Salario = decimal.Parse(model.Salario);
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);

            _funcionarioDomainService.Update(funcionario);
        }

        public void Delete(int id)
        {
            var funcionario = _funcionarioDomainService.GetById(id);

            if (funcionario != null)
            {
                _funcionarioDomainService.Delete(funcionario);
            }
            else
            {
                throw new Exception("Erro! Funcionário não encontrado. ");
            }
        }

        public List<FuncionarioConsultaModel> GetAll()
        {
            var lista = new List<FuncionarioConsultaModel>();

            foreach (var item in _funcionarioDomainService.GetAll())
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = item.IdFuncionario.ToString();
                model.Nome = item.Nome;
                model.Cpf = item.Cpf;
                model.Salario = item.Salario.ToString();
                model.DataAdmissao = item.DataAdmissao.ToString("dd/MM/yyyy");

                model.Dependentes = new List<DependenteConsultaModel>();

                foreach (var dependente in item.Dependentes)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependentes.Add(modelDependente);

                }

                lista.Add(model);
            }
            return lista;
        }

        public FuncionarioConsultaModel GetById(int id)
        {
            var funcionario = _funcionarioDomainService.GetById(id);

            if(funcionario != null)
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = funcionario.IdFuncionario.ToString();
                model.Nome = funcionario.Nome;
                model.Cpf = funcionario.Cpf;
                model.Salario = funcionario.Salario.ToString();
                model.DataAdmissao = funcionario.DataAdmissao.ToString("dd/MM/yyyy");

                foreach (var dependente in funcionario.Dependentes)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependentes.Add(modelDependente);

                }

                return model;
            }
            else
            {
                throw new Exception("Erro! Funcionário não encontrado. ");
            }
        }
    }
}
