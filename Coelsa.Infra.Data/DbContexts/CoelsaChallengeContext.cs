using System;
using Coelsa.Domain.Entities;
using Coelsa.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Coelsa.Infra.Data.DbContexts
{
    public partial class CoelsaChallengeContext : DbContext
    {
        public CoelsaChallengeContext()
        {
        }

        public CoelsaChallengeContext(DbContextOptions<CoelsaChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();           
        }
    }
}
