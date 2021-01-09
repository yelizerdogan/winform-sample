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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Users
{
    public partial class ucEditUsers : UserControl
    {
        public ApplicationUser _User { get; set; }
        public Role _Role { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ucEditUsers()
        {
            InitializeComponent();
        }
        private void ucEditUsers_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Text = "Hayır";
            chkIsDeleted.Checked = false;

            try
            {
                using (IUserRepository userRepo = new UserRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = userRepo.GetList("Roles", "Calculations");
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Kullanıcı bulunamadı.";
                        return;
                    }
                    dgvUsers.DataSource = result.Result;
                    dgvUsers.Columns["ID"].Visible = false;
                    dgvUsers.Columns["Password"].Visible = false;
                    dgvUsers.Columns["Roles"].Visible = false;
                    dgvUsers.Columns["Calculations"].Visible = false;

                    dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
                    dgvUsers.Columns["Title"].HeaderText = "Ünvan";
                    dgvUsers.Columns["Name"].HeaderText = "Adı";
                    dgvUsers.Columns["Surname"].HeaderText = "Soyadı";
                    dgvUsers.Columns["LastLogin"].HeaderText = "Son Giriş Tarihi";
                    dgvUsers.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvUsers.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvUsers.Columns["IsActive"].HeaderText = "Aktiflik";
                    dgvUsers.Columns["IsDeleted"].HeaderText = "Silinme";

                }
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = roleRepo.GetList();
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Rol bulunamadı.";
                        return;
                    }
                    cmbRoles.DataSource = result.Result;
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked == true)
            {
                chkIsActive.Text = "Evet";
            }
            else
            {
                chkIsActive.Text = "Hayır";
            }
        }

        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDeleted.Checked == true)
            {
                chkIsDeleted.Text = "Evet";
            }
            else
            {
                chkIsDeleted.Text = "Hayır";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser oldUser=null;
                Role newRole = null;
                _Role = (Role)cmbRoles.SelectedItem;
                using (IRoleRepository roleRepo= new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    newRole = roleRepo.Get(x=>x.ID==_Role.ID).Result;
                }
                using (IUserRepository userRepo = new UserRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    oldUser = _User;
                    oldUser.IsActive = chkIsActive.Checked;
                    oldUser.IsDeleted = chkIsDeleted.Checked;
                    oldUser.Name = txtName.Text;
                    oldUser.Surname = txtSurname.Text;
                    oldUser.Title = txtTitle.Text;
                    oldUser.UpdatedAt = DateTime.UtcNow;
                    oldUser.Username = txtUsername.Text;
                    
                    var result = userRepo.Update(oldUser);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Düzenleme işlemi başarılı. Düzenlenen son kullanıcı : " + result.Result.Username;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Error:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Warning:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Info:
                            lblMessage.Text = result.Message;
                            break;
                        default:
                            break;
                    }
                    userRepo.InsertUserRoles(oldUser, newRole);

                    ucEditUsers_Load(sender,e);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_User == null)
                {
                    lblMessage.Text = "Silinecek kullanıcıyı seçiniz.";
                    return;
                }
                using (IUserRepository userRepo= new UserRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    ApplicationUser oldUser = userRepo.Get(x=>x.ID==_User.ID).Result;
                    var result = userRepo.Delete(oldUser);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Silme işlemi başarılı. Silinen son kullanıcı : " + oldUser.Name;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Error:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Warning:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Info:
                            lblMessage.Text = result.Message;
                            break;
                        default:
                            break;
                    }
                    ucEditUsers_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

     

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            _User = ((ApplicationUser)dgvUsers.Rows[e.RowIndex].DataBoundItem);

            dgvUserRoles.DataSource = _User.Roles.ToList();
            dgvUserRoles.Columns["ID"].Visible = false;
            dgvUserRoles.Columns["CreatedAt"].Visible = false;
            dgvUserRoles.Columns["UpdatedAt"].Visible = false;
            dgvUserRoles.Columns["IsActive"].Visible = false;
            dgvUserRoles.Columns["IsDeleted"].Visible = false;
            dgvUserRoles.Columns["Users"].Visible = false;


            dgvUserRoles.Columns["Name"].HeaderText = "Seçilen Kullanıcının Rolleri";

            txtName.Text = _User.Name;
            txtSurname.Text = _User.Surname;
            txtTitle.Text = _User.Title;
            txtUsername.Text = _User.Username;
            chkIsActive.Checked = (bool)dgvUsers.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked = (bool)dgvUsers.Rows[e.RowIndex].Cells["IsDeleted"].Value;

        }
    }
}
