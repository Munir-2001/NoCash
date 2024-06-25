using DataModels;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class TransactionRepo : GenericRepo<TransactionModel>, ITransactionRepo
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IEntityRepo _entityRepo;
        public TransactionRepo(DatabaseContext dbcontext, ICategoryRepo category,IEntityRepo entiity) : base(dbcontext)
        {
            _categoryRepo = category;
            _entityRepo = entiity;

        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoryList()
        {
            return await _categoryRepo.GetAll();
        }
        
        public async Task<IEnumerable<EntityModel>> GetAllEntityList()
        {
            return await _entityRepo.GetAll();
        }


    }
}
