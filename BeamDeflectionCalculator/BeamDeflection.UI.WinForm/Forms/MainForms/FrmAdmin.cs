using BeamDeflection.Datacore.Data;
using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Beams;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Calculations;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Loads;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Roles;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Units;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Users;
using BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Forms.MainForms
{
    public partial class FrmAdmin : Form
    {
        public ApplicationUser CurrentUser { get; set; }
        public FrmAdmin(ApplicationUser currentUser)
        {
            CurrentUser = currentUser;

            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // trvAdmin.ExpandAll();
            lblHeader.Text = String.Empty;

        }

        private void trvAdmin_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text!="Kullanıcı" && e.Node.Text != "Rol" && e.Node.Text != "Kiriş" && e.Node.Text != "Yük" && e.Node.Text != "Değişken" && e.Node.Text != "Birim" && e.Node.Text != "Hesaplama")
            {
                lblHeader.Text = e.Node.Text;
                pnlMain.Controls.Clear();
                switch (e.Node.Text)
                {
                    case "Listele":
                        ucGetUsers getUsers = new ucGetUsers();
                        getUsers.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getUsers);
                        break;
                    case "Yeni Kullanıcı":
                        ucInsertUser insertUsers = new ucInsertUser();
                        insertUsers.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(insertUsers);
                        break;
                    case "Düzenle":
                        ucEditUsers editUsers = new ucEditUsers();
                        editUsers.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editUsers);
                        break;
                    case "Roller":
                        ucGetRoles getRoles = new ucGetRoles();
                        getRoles.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getRoles);
                        break;
                    case "Rol Ekle":
                        ucInsertRole insertRole = new ucInsertRole();
                        insertRole.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(insertRole);
                        break;
                    case "Rol Düzenle":
                        ucEditRoles editRoles = new ucEditRoles();
                        editRoles.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editRoles);
                        break;
                    case "Kiriş Tipleri":
                        ucGetBeams getBeams = new ucGetBeams();
                        getBeams.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getBeams);
                        break;
                    case "Kiriş Tipi Ekle":
                        ucInsertBeam insertBeam = new ucInsertBeam();
                        insertBeam.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(insertBeam);
                        break;
                    case "Kiriş Tiplerini Düzenle":
                        ucEditBeams editBeams = new ucEditBeams();
                        editBeams.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editBeams);
                        break;
                    case "Yük Tipleri":
                        ucGetLoads getLoads = new ucGetLoads();
                        getLoads.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getLoads);
                        break;
                    case "Yük Tipi Ekle":
                        ucInsertLoad insertLoad = new ucInsertLoad();
                        insertLoad.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(insertLoad);
                        break;
                    case "Yük Tiplerini Düzenle":
                        ucEditLoads editLoads = new ucEditLoads();
                        editLoads.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editLoads);
                        break;
                    case "Değişkenler":
                        ucGetVariables getVariables = new ucGetVariables();
                        getVariables.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getVariables);
                        break;
                    case "Değişken Düzenle":
                        ucEditVariables editVariables = new ucEditVariables();
                        editVariables.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editVariables);
                        break;
                    case "Birimler":
                        ucGetUnits getUnits = new ucGetUnits();
                        getUnits.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getUnits);
                        break;
                    case "Birim Ekle":
                        ucInsertUnit insertUnit = new ucInsertUnit();
                        insertUnit.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(insertUnit);
                        break;
                    case "Birim Düzenle":
                        ucEditUnits editUnits = new ucEditUnits();
                        editUnits.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editUnits);
                        break;
                    case "Hesaplamalar":
                        ucGetCalculations getCalculations = new ucGetCalculations();
                        getCalculations.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(getCalculations);
                        break;
                    case "Hesaplama Düzenle":
                        ucEditCalculations editCalculations = new ucEditCalculations();
                        editCalculations.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(editCalculations);
                        break;
                    default:
                        break;
                }
            }
           
           

        }

        private void btnCalculation_Click(object sender, EventArgs e)
        {
            FrmCalculation frm = new FrmCalculation(CurrentUser);
            frm.Show();
        }
    }
}
