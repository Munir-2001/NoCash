using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<CategoryModel> CategoryModels { get; set; }
        public virtual DbSet<CreditTableModel> CreditTableModels { get; set; }
        public virtual DbSet<DebitTableModel> DebitTableModels { get; set; }
        public virtual DbSet<EntityModel> EntityModels { get; set; }

        public virtual DbSet<TransactionModel> TransactionModels { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }


    }
}
