using BeamDeflection.Datacore.Data;
using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.UI.WinForm.Forms.MainForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
            DefaultConfigurations.Starter();


        }

        private void FrmLogin_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister frm = new FrmRegister();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == String.Empty)
            {
                lblMessage.Text = "Kullanıcı adı boş geçilemez.";
                txtUsername.Focus();
                return;
            }
            else if (txtPassword.Text == String.Empty)
            {
                lblMessage.Text = "Şifre boş geçilemez.";
                txtPassword.Focus();
                return;
            }
            using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
            {
                var result = userRepo.Login(txtUsername.Text, txtPassword.Text);
                switch (result.State)
                {
                    case Basecore.Model.Enums.BusinessResultType.NotSet:
                        lblMessage.Text = result.Message;
                        break;
                    case Basecore.Model.Enums.BusinessResultType.Success:
                        if (result.Result.Username == "admin" && result.Result.IsActive == true)
                        {
                            result.Result.LastLogin = DateTime.UtcNow;
                            FrmAdmin frm = new FrmAdmin(result.Result);
                            frm.ShowDialog();
                            this.Hide();
                        }
                        else
                        {
                            result.Result.LastLogin = DateTime.UtcNow;
                            FrmCalculation frm = new FrmCalculation(result.Result);
                            frm.Show();
                            this.Hide();
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
