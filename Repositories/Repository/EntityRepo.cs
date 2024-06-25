using DataModels;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class EntityRepo : GenericRepo<EntityModel>, IEntityRepo
    {
        public EntityRepo(DatabaseContext dbcontext) : base(dbcontext)
        {
        }
    }
}
