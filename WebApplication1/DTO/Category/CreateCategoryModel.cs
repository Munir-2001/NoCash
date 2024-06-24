using DataModels;

namespace WebApplication1.DTO.Category
{
    public class CreateCategoryModel
    {
        //ublic int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime datetimeofentry { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public string CategoryComments { get; set; } = string.Empty;
    }
}
