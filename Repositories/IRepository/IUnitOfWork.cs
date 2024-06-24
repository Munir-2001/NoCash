using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepo CategoryRepo { get; set; }

        Task CompleteAsync();
        public int Save();
        public void Dispose();
        public void Remove<T>(T entity) where T : class;

       // Task Remove();
    }
}
