using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Constants
{
    public static class DbConstants
    {
      
        public static readonly TableNameSchema ApplicationUser = new TableNameSchema("Users", Management);
        public static readonly TableNameSchema Role = new TableNameSchema("Roles", Management);
        public static readonly TableNameSchema ApplicationUserRole = new TableNameSchema("UserRoles", Intersections);
        public static readonly TableNameSchema Beam = new TableNameSchema("Beams", Main);
        public static readonly TableNameSchema Calculation = new TableNameSchema("Calculations", Main);
        public static readonly TableNameSchema Load = new TableNameSchema("Loads", Main);
        public static readonly TableNameSchema Unit = new TableNameSchema("Units", Main);
        public static readonly TableNameSchema Variable = new TableNameSchema("Variables", Main);
        public static readonly TableNameSchema LoadVariables = new TableNameSchema("LoadVariables", Intersections);
        
        //Schemas
        private const string Intersections = "Intersections";
        private const string Management = "Management";
        private const string Main = "Main";
        private const string Accounting = "Accounting";
    }

    public class TableNameSchema
    {
        public TableNameSchema(string name, string schema)
        {
            Name = name;
            Schema = schema;

            SchemaWithName = schema + "." + name;
        }

        public string Name { get; set; }

        public string Schema { get; set; }

        public string SchemaWithName { get; set; }
    }

}
