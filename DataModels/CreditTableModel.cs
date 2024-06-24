using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class CreditTableModel : BaseModel
    {
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public DateOnly ReturnExpected { get; set; }
        public string comments { get; set; }
    }
}
