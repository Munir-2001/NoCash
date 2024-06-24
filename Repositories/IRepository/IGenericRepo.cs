using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<Response<T>> GetById(int id);
        Task<Response<List<T>>> GetAll();
        Task<Response<T>> AddToDb(T model);
        Task<Response<int>> DeleteById(int id);
        Task<Response<T>> UpdateById(T model);


    }
}
