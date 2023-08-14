using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public class DatabaseContext : IdentityDbContext<Employee>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        
        public DbSet<StockItem> STOCKMGT { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }


    }
}
