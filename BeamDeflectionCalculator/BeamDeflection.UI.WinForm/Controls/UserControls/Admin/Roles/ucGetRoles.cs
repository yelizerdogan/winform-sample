using BeamDeflection.Datacore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Roles
{
    public partial class ucGetRoles : UserControl
    {
        public ucGetRoles()
        {
            InitializeComponent();
        }

        private void ucGetRoles_Load(object sender, EventArgs e)
        {
            try
            {
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = roleRepo.GetList();
                    if (result.Result==null)
                    {
                        return;
                    }
                    dgvRoles.DataSource = result.Result;

                    dgvRoles.Columns["Users"].Visible = false;
                    dgvRoles.Columns["ID"].Visible = false;

                    dgvRoles.Columns["Name"].HeaderText = "Rol Adı";
                    dgvRoles.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvRoles.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvRoles.Columns["IsDeleted"].HeaderText = "Silinme";
                    dgvRoles.Columns["IsActive"].HeaderText = "Aktiflik";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
