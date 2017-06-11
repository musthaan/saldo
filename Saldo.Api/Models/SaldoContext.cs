using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Saldo.Api.Models
{
    public class SaldoContext : DbContext
    {
        public SaldoContext()
              : base("name=SaldoAPIContext")
        {

        }
        
        public DbSet<User> Users { get; set; }

        
    }
}