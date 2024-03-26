using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Added;
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }
    }
}
