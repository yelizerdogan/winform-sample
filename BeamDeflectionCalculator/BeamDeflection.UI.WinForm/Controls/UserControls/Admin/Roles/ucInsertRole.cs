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
    public partial class ucInsertRole : UserControl
    {
        public ucInsertRole()
        {
            InitializeComponent();
        }

        private void ucInsertRole_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked==true)
            {
                chkIsActive.Text = "Evet";
            }
            else
            {
                chkIsActive.Text = "Hayır";
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (IRoleRepository roleRepo = new RoleRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Role role = new Role
                    {
                        Name = txtName.Text
                    };
                    var result = roleRepo.Insert(role);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Kayıt başarılı. Kaydedilen rol adı : " + result.Result.Name;
                            txtName.Text = String.Empty;
                            chkIsActive.Checked = true;
                            txtName.Focus();
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
