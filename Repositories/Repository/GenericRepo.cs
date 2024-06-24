using Azure;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public Task<Response<T>> AddToDb(T model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<T>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<T>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<T>> UpdateById(T model)
        {
            throw new NotImplementedException();
        }
    }
}
