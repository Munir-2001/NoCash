using DataModels;
using Microsoft.Extensions.Logging;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoryRepo : GenericRepo<CategoryModel>, ICategoryRepo
    {

        public CategoryRepo(DatabaseContext dbcontext) : base(dbcontext)
        {           
            
        }

        /*public async Task<int> Upsert(CategoryModel model)
        {
            if (model != null)
            {
                if (model.CategoryId != null)
                {
                    var dbres = _dbset.AddAsync(model);

                }
                else
                {
                    var dbupdate = await _dbset.FindAsync(model.CategoryId);
                    if (dbupdate != null)
                    {
                        dbupdate.CategoryName = model.CategoryName;
                        dbupdate.CategoryComments = model.CategoryComments;
                        dbupdate.Active = true;
                    }


                }
            }
            return model.CategoryId;*/




        }
        


    }

