#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Integrador.Models;

namespace Integrador.Data

{
    public class WebMongoDBContext : DbContext
    {
        public WebMongoDBContext (DbContextOptions<WebMongoDBContext> options)
            : base(options)
        {
        }

        
       public DbSet<Integrador.Models.Service> services { get; set; }
    }
}
