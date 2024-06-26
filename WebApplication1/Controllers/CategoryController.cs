using DataModels;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Utilities;
using WebApplication1.Data;
using WebApplication1.DTO.Category;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitOfWork = unitofwork;


        }
        [HttpPost]
        public async Task<IActionResult> Category(CategoryModel category)
        {
            try
            {
                await _unitOfWork.CategoryRepo.Add(category);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<CategoryModel>
                {
                    Success = true,
                    Message = "Category Added Successfully",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryModel>
                {
                    Success = false,
                    Message = $"Failed adding the Category. {ex.Message}",
                    Data = null
                });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Category(int id)
        {

            try
            {
                var category = await _unitOfWork.CategoryRepo.GetById(id);
                if (category == null)
                {
                    return NotFound(new Response<CategoryModel>
                    {
                        Success = false,
                        Message = "Category not found",
                        Data = null
                    });
                }
                category.Active = false;
                _unitOfWork.CategoryRepo.Delete(category);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<CategoryModel>
                {
                    Success = true,
                    Message = "Category Deleted Successfully",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryModel>
                {
                    Success = false,
                    Message = $"Failed deleting the Category. {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> CategoryUpdate(CategoryModel category)
        {
            try
            {
                _unitOfWork.CategoryRepo.Update(category);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<CategoryModel>
                {
                    Success = true,
                    Message = "Category Updated Successfully",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryModel>
                {
                    Success = false,
                    Message = $"Failed updating the Category. {ex.Message}",
                    Data = null
                });
            }
        }

       [HttpGet]
       [Route("{id}")]
        public async Task<IActionResult> CategoryItem(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepo.GetById(id);
                if (category == null)
                {
                    return NotFound(new Response<CategoryModel>
                    {
                        Success = false,
                        Message = "Category not found",
                        Data = null
                    });
                }
                return Ok(new Response<CategoryModel>
                {
                    Success = true,
                    Message = "Got Data of Category",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryModel>
                {
                    Success = false,
                    Message = $"Failed fetching the Category. {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpGet]

        public async Task<IActionResult> Category()
        {
            try
            {
                var s = await _unitOfWork.CategoryRepo.GetAll();
                Response<List<CategoryModel>> response = new Response<List<CategoryModel>>
                {
                    Success = true,
                    Message = "Got Data of All category models",
                    Data = (List<CategoryModel>)s
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<List<CategoryModel>>
                {
                    Success = false,
                    Message = $"Failed fetching the Models. {ex.Message}",
                    Data = null
                });
                
            }

        }
    }
}