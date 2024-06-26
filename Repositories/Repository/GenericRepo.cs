using Azure;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {


        protected readonly DatabaseContext _dbContext;

        protected GenericRepo(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll(){
             return await _dbContext.Set<T>().ToListAsync();
            // return (IEnumerable<T>)await _dbContext.Set<CategoryModel>().Where(x => x.Active).ToListAsync();
            // return (IEnumerable<T>)await _dbContext.Set<CategoryModel>().Where(x => x.Active).ToListAsync();


        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class, IActivatable
        {

            return (IEnumerable<T>)await _dbContext.Set<CategoryModel>().Where(x => x.Active).ToListAsync();

        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }



}
    