using DataModels;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CategoryModel> CategoryModels { get; set; }    
        public virtual DbSet<CreditTableModel> CreditTableModels { get; set; }
        public virtual DbSet<DebitTableModel> DebitTableModels { get; set; }
        public virtual DbSet<EntityModel> EntityModels { get; set; }

        public virtual DbSet<TransactionModel> TransactionModels { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {  }


    }
}
