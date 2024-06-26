using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class EntityModel : BaseModel,IActivatable
    {
        [Key]
        public int EntityId { get; set; }
        [Required]
        public string EntityName { get; set; }

        public string EntityAccountNumber { get; set; } = string.Empty;
        [Required]
        public string Relation { get; set; }

    }
}
