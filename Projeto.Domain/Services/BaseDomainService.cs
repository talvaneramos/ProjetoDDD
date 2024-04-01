using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainService<T> 
        where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseDomainService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
