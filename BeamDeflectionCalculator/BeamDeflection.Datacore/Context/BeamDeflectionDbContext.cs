
using BeamDeflection.Datacore.Context.Mapping;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.Domain.Model.Intersections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Data
{
    public class BeamDeflectionDbContext : DbContext
    {
        public BeamDeflectionDbContext() : base("name=BeamDeflectionDbCstr")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new CalculationMap());
            modelBuilder.Configurations.Add(new BeamMap());
            modelBuilder.Configurations.Add(new LoadMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new VariableMap());
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Beam> Beams { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Variable> Variables { get; set; }
        

    }
}
