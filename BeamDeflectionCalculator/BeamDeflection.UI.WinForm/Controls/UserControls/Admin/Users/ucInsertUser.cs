using BeamDeflection.Datacore.Data;
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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin
{
    public partial class ucInsertUser : UserControl
    {
        public ucInsertUser()
        {
            InitializeComponent();
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

        private void ucInsertUser_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
            using (IRoleRepository roleRepo=new RoleRepository(new BeamDeflectionDbContext()))
            {
                var result = roleRepo.GetList();
                cmbRoles.DataSource = result.Result;
                cmbRoles.DisplayMember = "Name";
                cmbRoles.ValueMember = "ID";

            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text==String.Empty)
            {
                MessageBox.Show("Kullanıcı adı boş geçilemez.");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Şifre boş geçilemez.");
                txtPassword.Focus();
            }
            else if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Ad boş geçilemez.");
                txtName.Focus();
            }
            else if (txtSurname.Text == String.Empty)
            {
                MessageBox.Show("Soyad boş geçilemez.");
                txtSurname.Focus();
            }
            else if (txtTitle.Text == String.Empty)
            {
                MessageBox.Show("Ünvan boş geçilemez.");
                txtTitle.Focus();
            }

            using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
            {
                var result = userRepo.Register(txtUsername.Text, txtPassword.Text, txtTitle.Text, txtName.Text, txtSurname.Text, cmbRoles.Text, chkIsActive.Checked);
                switch (result.State)
                {
                    case Basecore.Model.Enums.BusinessResultType.NotSet:
                        lblMessage.Text = result.Message;
                        break;
                    case Basecore.Model.Enums.BusinessResultType.Success:
                        lblMessage.Text = "Kayıt başarılı. Son kaydedilen kullanıcı : " + result.Result.Username;
                        foreach (var item in pnlMain.Controls)
                        {
                            if (item is TextBox)
                            {
                                ((TextBox)item).Text = String.Empty;
                            }
                            if (item is MaskedTextBox)
                            {
                                ((MaskedTextBox)item).Text = String.Empty;
                            }

                        }
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
    }
}
