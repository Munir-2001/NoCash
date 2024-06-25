using Microsoft.AspNetCore.Mvc;
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
        public class EntityController : ControllerBase
        {
            private readonly ILogger<EntityModel> _logger;
            private readonly IUnitOfWork _unitOfWork;

            public EntityController(ILogger<EntityModel> logger, IUnitOfWork unitofwork)
            {
                _logger = logger;
                _unitOfWork = unitofwork;

            }
            [HttpPost]
            public async Task<IActionResult> Entity(EntityModel entitymodel)
            {
                try
                {
                    await _unitOfWork.EntityRepo.Add(entitymodel);
                    await _unitOfWork.CompleteAsync();
                    return Ok(new Response<EntityModel>
                    {
                        Success = true,
                        Message = "Entity Model Added Successfully",
                        Data = entitymodel
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new Response<EntityModel>
                    {
                        Success = false,
                        Message = $"Failed adding the Entity. {ex.Message}",
                        Data = null
                    });
                }
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> Entity(int id)
            {

                try
                {
                    var entity = await _unitOfWork.EntityRepo.GetById(id);
                    if (entity == null)
                    {
                        return NotFound(new Response<CategoryModel>
                        {
                            Success = false,
                            Message = "Entity not found",
                            Data = null
                        });
                    }
                    _unitOfWork.EntityRepo.Delete(entity);
                    await _unitOfWork.CompleteAsync();
                    return Ok(new Response<EntityModel>
                    {
                        Success = true,
                        Message = "Entity Deleted Successfully",
                        Data = entity
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new Response<EntityModel>
                    {
                        Success = false,
                        Message = $"Failed deleting the Entity. {ex.Message}",
                        Data = null
                    });
                }
            }

            [HttpPut]
            public async Task<IActionResult> EntityUpdate(EntityModel entitymodel)
            {
                try
                {
                    _unitOfWork.EntityRepo.Update(entitymodel);
                    await _unitOfWork.CompleteAsync();
                    return Ok(new Response<EntityModel>
                    {
                        Success = true,
                        Message = "Entity Updated Successfully",
                        Data = entitymodel
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new Response<EntityModel>
                    {
                        Success = false,
                        Message = $"Failed updating the Entity. {ex.Message}",
                        Data = null
                    });
                }
            }

            [HttpGet]
            [Route("{id}")]
            public async Task<IActionResult> EntityById(int id)
            {
                try
                {
                    var entity = await _unitOfWork.EntityRepo.GetById(id);
                    if (entity == null)
                    {
                        return NotFound(new Response<EntityModel>
                        {
                            Success = false,
                            Message = "Entity not found",
                            Data = null
                        });
                    }
                    return Ok(new Response<EntityModel>
                    {
                        Success = true,
                        Message = "Got Data of Entity",
                        Data = entity
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new Response<EntityModel>
                    {
                        Success = false,
                        Message = $"Failed fetching the Entity. {ex.Message}",
                        Data = null
                    });
                }
            }

            [HttpGet]

            public async Task<IActionResult> Entity()
            {
                try
                {
                    var s = await _unitOfWork.EntityRepo.GetAll();
                    Response<List<EntityModel>> response = new Response<List<EntityModel>>
                    {
                        Success = true,
                        Message = "Got Data of All Entity models",
                        Data = (List<EntityModel>)s
                    };
                    return Ok(response);

                }
                catch (Exception ex)
                {
                    return BadRequest(new Response<List<EntityModel>>
                    {
                        Success = false,
                        Message = $"Failed fetching the Entity Models. {ex.Message}",
                        Data = null
                    });

                }

            }
        }

    }

