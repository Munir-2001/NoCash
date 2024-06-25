using AutoMapper;
using Repositories.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DTO.Category;
using DataModels;
namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        //public CategoryService() { }

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }

        public async Task<int> CreateCategory(CreateCategoryModel category)
        {

            var categoryobject=_mapper.Map<CreateCategoryModel, CategoryModel>(category);
            if (category != null)
            {
                _unitOfWork.CategoryRepo.Add(categoryobject);

                var result = _unitOfWork.CompleteAsync();

                if (result.Id > 0)
                    return 1;
                else
                    return -1;
            }
            return -1;
        }

        public async Task<bool> DeleteProduct(int categoryId)
        {
            if (categoryId > 0)
            {
                var categoryDetails = await _unitOfWork.CategoryRepo.GetById(categoryId);
                if (categoryDetails.CategoryId != null)
                {
                    _unitOfWork.CategoryRepo.Delete(categoryDetails);
                    var result = _unitOfWork.CompleteAsync();

                    if (result !=null)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllProducts()
        {
            var categoryDetailsList = await _unitOfWork.CategoryRepo.GetAll();
            return categoryDetailsList;
        }

        public async Task<CategoryModel> GetProductById(int categoryId)
        {
            if (categoryId > 0)
            {
                var categoryDetails = await _unitOfWork.CategoryRepo.GetById(categoryId);
                if (categoryDetails != null)
                {
                    return categoryDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(UpdateCategoryModel categoryDetails)
        {
            var categoryobject = _mapper.Map<UpdateCategoryModel, CategoryModel>(categoryDetails);

            if (categoryDetails != null)
            {
                var results =  _unitOfWork.CategoryRepo.GetById(categoryDetails.CategoryId);

                if (results != null)
                {
                   /* categoryobject.CategoryName = categoryDetails.CategoryName;
                    results.CategoryComments = categoryDetails.CategoryComments*/;

                    _unitOfWork.CategoryRepo.Update(categoryobject);

                    

                    if (_unitOfWork.CompleteAsync() !=null)
                        return true;
                    else
                        return false;
                }

            }
            return false;
        }
    }


}

