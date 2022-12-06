using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Integrador.Models;

namespace Integrador.Data
{
    public class IntegradorContext : DbContext
    {
        public IntegradorContext(DbContextOptions<IntegradorContext> options)
           : base(options)
        {
        }

        public DbSet<Integrador.Models.Service> Service { get; set; } = default!;
    }
}
