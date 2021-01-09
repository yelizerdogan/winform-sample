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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Roles
{
    public partial class ucEditRoles : UserControl
    {
        public Role _Role { get; set; }
        public ucEditRoles()
        {
            InitializeComponent();
        }

        private void ucEditRoles_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Text = "Hayır";
            chkIsDeleted.Checked = false;
            try
            {
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = roleRepo.GetList();
                    if (result.Result == null)
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
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Rol adı boş geçilemez.");
                return;
            }
            else if (dgvRoles.SelectedRows == null)
            {
                MessageBox.Show("Rol seçiniz.");
                return;
            }
            try
            {
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var oldRole = roleRepo.Get(x => x.Name == _Role.Name);
                    if (oldRole.Result != null)
                    {
                        oldRole.Result.Name = txtName.Text;
                        oldRole.Result.IsActive = chkIsActive.Checked;
                        oldRole.Result.IsDeleted = chkIsDeleted.Checked;
                        oldRole.Result.UpdatedAt = DateTime.Now;
                        var newRole = roleRepo.Update(oldRole.Result);
                        switch (newRole.State)
                        {
                            case Basecore.Model.Enums.BusinessResultType.NotSet:
                                lblMessage.Text = newRole.Message;
                                break;
                            case Basecore.Model.Enums.BusinessResultType.Success:
                                lblMessage.Text = "Başarıyla güncellendi.";
                                txtName.Text = String.Empty;
                                chkIsActive.Checked = true;
                                ucEditRoles_Load(sender, e);
                                break;
                            case Basecore.Model.Enums.BusinessResultType.Error:
                                lblMessage.Text = newRole.Message;
                                break;
                            case Basecore.Model.Enums.BusinessResultType.Warning:
                                lblMessage.Text = newRole.Message;
                                break;
                            case Basecore.Model.Enums.BusinessResultType.Info:
                                lblMessage.Text = newRole.Message;
                                break;
                            default:
                                break;
                        }

                    }


                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtName.Text = dgvRoles.Rows[e.RowIndex].Cells["Name"].Value + "";
            chkIsActive.Checked = (bool)dgvRoles.Rows[e.RowIndex].Cells["IsActive"].Value;
            _Role = (Role)dgvRoles.Rows[e.RowIndex].DataBoundItem;
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

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_Role == null)
            {
                lblMessage.Text = "Silmek istediğiniz rolü seçiniz.";
                return;
            }
            try
            {
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Role oldRole = roleRepo.Get(x => x.ID == _Role.ID).Result;
                    var result = roleRepo.Delete(oldRole);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Silme işlemi başarılı. Son silinen rolün adı : " + oldRole.Name;
                            ucEditRoles_Load(sender, e);
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
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }
    }
}
