using Azure;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICategoryServices : IBaseService
    {
        Task<List<CategoryModel>> GetAllCategories();
        Task<IEnumerable<CategoryModel>> GetCategoryById(int categoryId);
        Task<int> CreateCategory(CategoryModel category);
        Task<bool> UpdateCategory(CategoryModel category); 
        Task<bool> DeleteCategory(int categoryId);


    }
}
