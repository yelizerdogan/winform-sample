namespace BeamDeflection.Datacore.Migrations
{
    using BeamDeflection.Basecore.Helpers.Common;
    using BeamDeflection.Domain.Model.BeamDeflectionDb;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeamDeflection.Datacore.Data.BeamDeflectionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeamDeflection.Datacore.Data.BeamDeflectionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Users.AddOrUpdate(x => x.Username, new ApplicationUser
            //{
            //    Password = "admin".GetMD5Hash(),
            //    Username = "admin",
            //    Name = "admin",
            //    IsActive = true,
            //    Surname = "admin",
            //    Title = "admin"
            //});
            //context.Roles.AddOrUpdate(x => x.Name, new Role
            //{
            //    Name = "admin"
            //});
            //context.Roles.AddOrUpdate(x => x.Name, new Role
            //{
            //    Name = "guest"
            //});


            //context.SaveChanges();
            //context.Users.Include("Roles").SingleOrDefault(x => x.Username == "admin").Roles.Add(context.Roles.Include("Users").SingleOrDefault(x => x.Name == "admin"));
            //context.SaveChanges();




        }
    }
}
