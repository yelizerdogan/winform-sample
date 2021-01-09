using BeamDeflection.Basecore.Helpers.Common;
using BeamDeflection.Datacore.Data;
using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.UI.WinForm
{
    public static class DefaultConfigurations
    {
        public static void Starter()
        {
            using (BeamDeflectionDbContext ctx = new BeamDeflectionDbContext())
            {
                if (ctx.Users.SingleOrDefault(x=>x.Username=="admin")!=null)
                {
                    return;
                }
            }
            using (IUnitRepository unitRepo = new UnitRepository(new BeamDeflectionDbContext()))
            {
                try
                {
                    List<Unit> units = new List<Unit> {
                        new Unit{
                            Name="meters",
                            Display="m"
                        },
                        new Unit{
                            Name="centimeters",
                            Display="cm"
                        },
                        new Unit{
                            Name="milimeters",
                            Display="mm"
                        },
                        new Unit{
                            Name="kilonewtons",
                            Display="kN"
                        },
                        new Unit{
                            Name="newtons",
                            Display="N"
                        },
                        new Unit{
                            Name="megapascals",
                            Display="MPa"
                        },
                        new Unit{
                            Name="pascals",
                            Display="Pa"
                        },
                        new Unit{
                            Name="meters to fourth power",
                            Display="m⁴"
                        },
                        new Unit{
                            Name="centimeters to fourth power",
                            Display="cm⁴"
                        },
                        new Unit{
                            Name="newtons per meter",
                            Display="N/m"
                        },
                        new Unit{
                            Name="kilonewtons per meter",
                            Display="kN/m"
                        },
                        new Unit{
                            Name="newton meters",
                            Display="Nm"
                        },
                        new Unit{
                            Name="kilogram-centimeters",
                            Display="kg-cm"
                        }
                    };
                    unitRepo.InsertList(units);
                }
                catch (Exception )
                {

                    throw;
                }
            }
            using (IBeamRepository beamRepo = new BeamRepository(new BeamDeflectionDbContext()))
            {
                try
                {
                    List<Beam> beams = new List<Beam>
                    {
                        new Beam
                        {
                            Name="Basitçe desteklenen kiriş"
                        },
                        new Beam
                        {
                            Name="Konsol kiriş"
                        }
                    };
                    beamRepo.InsertList(beams);
                }
                catch (Exception )
                {

                    throw;
                }
            }
            using (IRoleRepository roleRepo = new RoleRepository(new BeamDeflectionDbContext()))
            {
                try
                {
                    List<Role> roles = new List<Role>
                {
                    new Role
                    {
                        Name="admin"
                    },
                    new Role
                    {
                        Name="appuser"
                    },
                    new Role
                    {
                        Name="guest"
                    }
                };
                    roleRepo.InsertList(roles);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
            {
                try
                {
                    userRepo.Register("admin", "admin", "admin", "admin", "admin", "admin", true);
                    userRepo.Register("Yeliz", "yeliz", "student", "Yeliz", "ERDOĞAN", "admin", true);
                    userRepo.Register("user", "user", "appuser", "Yeliz", "ERDOĞAN", "appuser", true);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            using (ILoadRepository loadRepo = new LoadRepository(new BeamDeflectionDbContext()))
            {
                try
                {
                    loadRepo.InsertWithBeam(new Load { Name = "Ortadan yük" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Herhangi bir noktadan yük" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Düzgün yük" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Düzgün değişen yük" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Üçgen yük" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Tek destekte moment yükü" }, "Basitçe desteklenen kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Sona yük" }, "Konsol Kiriş");


                    loadRepo.InsertWithBeam(new Load { Name = "Herhangi bir noktaya yük" }, "Konsol kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Düzgün yayılan yük" }, "Konsol kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Düzgün değişen yük (Durum 1)" }, "Konsol kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Düzgün değişen yük (Durum 2)" }, "Konsol kiriş");
                    loadRepo.InsertWithBeam(new Load { Name = "Sonunda moment yükü" }, "Konsol kiriş");
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

    }
}
