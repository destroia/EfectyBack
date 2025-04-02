using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfectyContext : DbContext
    {
        public EfectyContext(DbContextOptions<EfectyContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.AddModelBuilder();
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
