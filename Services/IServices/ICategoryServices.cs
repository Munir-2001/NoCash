using Azure;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DTO.Category;

namespace Services.IServices
{
    public interface ICategoryServices : IBaseService
    {
        Task<List<CategoryModel>> GetAllCategories();
        Task<IEnumerable<CategoryModel>> GetCategoryById(int categoryId);
        Task<int> CreateCategory(CategoryModel category);
        Task<bool> UpdateCategory(UpdateCategoryModel category); 
        Task<bool> DeleteCategory(int categoryId);


    }
}
