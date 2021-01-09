
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

namespace BeamDeflection.UI.WinForm.Forms
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
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
            else if (txtName.Text == String.Empty)
            {
                lblMessage.Text = "İsim boş geçilemez.";
                txtName.Focus();
                return;
            }
            else if (txtSurname.Text == String.Empty)
            {
                lblMessage.Text = "Soyisim boş geçilemez.";
                txtSurname.Focus();
                return;
            }
            else if (txtTitle.Text == String.Empty)
            {
                lblMessage.Text = "Ünvan boş geçilemez.";
                txtTitle.Focus();
                return;
            }
            using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
            {
                var result = userRepo.Register(txtUsername.Text, txtPassword.Text, txtTitle.Text, txtName.Text, txtSurname.Text);
                switch (result.State)
                {
                    case Basecore.Model.Enums.BusinessResultType.NotSet:
                        lblMessage.Text = result.Message;
                        break;
                    case Basecore.Model.Enums.BusinessResultType.Success:
                        lblMessage.Text = "Kayıt başarılı.";
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
