using Azure;
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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }



}
    /*protected readonly DatabaseContext _dbcontext;
    protected DbSet<T> _dbset;
    protected readonly ILogger _logger;
    public GenericRepo(DatabaseContext dbcontext,ILogger<GenericRepo<T>> logger)
    {
        _dbcontext = dbcontext;
        _logger= logger;
        this._dbset = _dbcontext.Set<T>();

    }
    public virtual Task<Response<T>> Upsert(T model)
    {
        throw new NotImplementedException();


    }

    public async Task<int> DeleteById(int id)
    {
        var dbreponse= await GetById(id);
        if (dbreponse != null) {
            _dbset.Remove(dbreponse);
            return id;
        }
        return -1;

    }

    public async Task<IEnumerable<T>> GetAll()
    {
            return await _dbset.ToListAsync();
    }

    public async Task<T>GetById(int id)
    {
        var dbresponse= await _dbset.FindAsync(id);
        return dbresponse;
        //throw new NotImplementedException();
    }
    *//*public async Task<T> GetbyModel(T model) {
        return await _dbset.FindAsync(model);
    }*//*

    public async Task<T> UpdateById(T model)
    {
        throw new NotImplementedException();


    }

    Task<int> IGenericRepo<T>.Upsert(T model)
    {
        throw new NotImplementedException();
    }
}*/

