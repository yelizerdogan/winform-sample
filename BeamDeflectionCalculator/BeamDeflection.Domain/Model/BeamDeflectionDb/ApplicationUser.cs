using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class ApplicationUser :BaseEntity
    {
        public ApplicationUser()
        {
            LastLogin = DateTime.UtcNow;
            base.IsActive = false;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Calculation> Calculations { get; set; }
        public override string ToString()
        {
            return Username;
        }

    }
}
