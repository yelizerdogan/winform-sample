using BeamDeflection.Datacore.Data;
using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin
{
    public partial class ucGetUsers : UserControl
    {
      
        public ucGetUsers()
        {
            InitializeComponent();
        }

        private void ucGetUsers_Load(object sender, EventArgs e)
        {
            using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
            {
                var result = userRepo.GetList("Roles");

                dgvUsers.DataSource = result.Result;
            }
         

            EditDataGridViewUsers();

        }

        private void EditDataGridViewUsers()
        {
            dgvUsers.Columns["ID"].Visible = false;
            dgvUsers.Columns["Password"].Visible = false;
            dgvUsers.Columns["Calculations"].Visible = false;
            dgvUsers.Columns["Roles"].Visible = false;


            dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
            dgvUsers.Columns["Title"].HeaderText = "Ünvan";
            dgvUsers.Columns["Name"].HeaderText = "Ad";
            dgvUsers.Columns["Surname"].HeaderText = "Soyad";
            dgvUsers.Columns["LastLogin"].HeaderText = "Son Giriş";
            dgvUsers.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
            dgvUsers.Columns["IsDeleted"].HeaderText = "Silinme";
            dgvUsers.Columns["IsActive"].HeaderText = "Aktiflik";
            dgvUsers.Columns["Roles"].HeaderText = "Roller";
            dgvUsers.Columns["UpdatedAt"].HeaderText = "Güncellenme Tarihi";





        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtRoles.Text = String.Empty;
            (dgvUsers.Rows[e.RowIndex].DataBoundItem as ApplicationUser).Roles.ToList().ForEach(x=> {
                txtRoles.Text += x.Name;
                txtRoles.Text += "\n";
            });

        }


    }
}
