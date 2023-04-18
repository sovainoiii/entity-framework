using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Modules
{
    internal class ProductDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        private const string strConn = @"Data Source=MINH\SQLEXPRESS;Initial Catalog=data01;Integrated Security=True;Persist Security Info=True;User ID=sa;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(strConn);
        }
    }
}
