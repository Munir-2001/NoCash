using DataModels;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Utilities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionController(ILogger<TransactionModel> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitOfWork = unitofwork;

        }
        [HttpPost]
        public async Task<IActionResult> Transaction(TransactionModel Transactionmodel)
        {
            try
            {
                await _unitOfWork.TransactionRepo.Add(Transactionmodel);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<TransactionModel>
                {
                    Success = true,
                    Message = "Transaction Model Added Successfully",
                    Data = Transactionmodel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<TransactionModel>
                {
                    Success = false,
                    Message = $"Failed adding the Transaction. {ex.Message}",
                    Data = null
                });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Transaction(int id)
        {

            try
            {
                var Transaction = await _unitOfWork.TransactionRepo.GetById(id);
                if (Transaction == null)
                {
                    return NotFound(new Response<CategoryModel>
                    {
                        Success = false,
                        Message = "Transaction not found",
                        Data = null
                    });
                }
                _unitOfWork.TransactionRepo.Delete(Transaction);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<TransactionModel>
                {
                    Success = true,
                    Message = "Transaction Deleted Successfully",
                    Data = Transaction
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<TransactionModel>
                {
                    Success = false,
                    Message = $"Failed deleting the Transaction. {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> TransactionUpdate(TransactionModel Transactionmodel)
        {
            try
            {
                _unitOfWork.TransactionRepo.Update(Transactionmodel);
                await _unitOfWork.CompleteAsync();
                return Ok(new Response<TransactionModel>
                {
                    Success = true,
                    Message = "Transaction Updated Successfully",
                    Data = Transactionmodel
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<TransactionModel>
                {
                    Success = false,
                    Message = $"Failed updating the Transaction. {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> TransactionById(int id)
        {
            try
            {
                var Transaction = await _unitOfWork.TransactionRepo.GetById(id);
                if (Transaction == null)
                {
                    return NotFound(new Response<TransactionModel>
                    {
                        Success = false,
                        Message = "Transaction not found",
                        Data = null
                    });
                }
                return Ok(new Response<TransactionModel>
                {
                    Success = true,
                    Message = "Got Data of Transaction",
                    Data = Transaction
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<TransactionModel>
                {
                    Success = false,
                    Message = $"Failed fetching the Transaction. {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Transaction()
        {
            try
            {
                var s = await _unitOfWork.TransactionRepo.GetAll();
                Response<List<TransactionModel>> response = new Response<List<TransactionModel>>
                {
                    Success = true,
                    Message = "Got Data of All Transaction models",
                    Data = (List<TransactionModel>)s
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<List<TransactionModel>>
                {
                    Success = false,
                    Message = $"Failed fetching the Transaction Models. {ex.Message}",
                    Data = null
                });

            }

        }

        [HttpGet]
        [Route("GetAllEntityLists")]
        public async Task<IActionResult> GetAllEntityLists()
        {
            try
            {
                var s = await _unitOfWork.TransactionRepo.GetAllEntityList();
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
                    Message = $"Failed fetching the Category Models. {ex.Message}",
                    Data = null
                });

            }

        }

        [HttpGet]
        [Route("GetAllCategoryLists")]
        public async Task<IActionResult> GetAllCategoryList()
        {
            try
            {
                var s = await _unitOfWork.TransactionRepo.GetAllCategoryList();
                Response<List<CategoryModel>> response = new Response<List<CategoryModel>>
                {
                    Success = true,
                    Message = "Got Data of All Category models",
                    Data = (List<CategoryModel>)s
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<List<TransactionModel>>
                {
                    Success = false,
                    Message = $"Failed fetching the Transaction Models. {ex.Message}",
                    Data = null
                });

            }

        }
    }
}
