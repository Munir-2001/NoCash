using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class TransactionModel : BaseModel
    {
        [Key]
        public int TransacitonId { get; set; }
        [Required]
        public int Amount { get; set; } = 0;
        [Required]
        public string TransactionType { get; set; } = string.Empty;
        public string Comments { get; set; } =string.Empty;
        public DateTime timestamp { get; set; } = DateTime.Now;
        [Required]
        public int EntityId { get; set; }
        [Required]
        public int CategoryId { get; set; }




    }
}
