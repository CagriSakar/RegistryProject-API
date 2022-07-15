using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApp.Data
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : 
            base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
