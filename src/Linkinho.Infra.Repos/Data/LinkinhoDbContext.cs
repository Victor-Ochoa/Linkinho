using Linkinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkinho.Infra.Repos.Data
{
    public class LinkinhoDbContext : DbContext
    {
        public LinkinhoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Link> Links { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LinkinhoDbContext).Assembly);
        }
    }

}
