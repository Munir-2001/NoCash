using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        //private readonly ILoggerFactory _loggerFactory;
        public ICategoryRepo CategoryRepo { get; set; }

        public UnitOfWork(DatabaseContext context,/*ILoggerFactory loggerFactory*/ICategoryRepo categoryrepo)
        {
            _context = context;
            CategoryRepo = categoryrepo;
            //_loggerFactory = loggerFactory;
            //var categoryLogger = _loggerFactory.CreateLogger<CategoryRepo>();
            //CategoryObj = new CategoryRepo(_context, categoryLogger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();

        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Remove<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
