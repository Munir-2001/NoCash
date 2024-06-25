using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ITransactionRepo: IGenericRepo<TransactionModel>
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoryList();
        Task<IEnumerable<EntityModel>> GetAllEntityList();
    }
}
