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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Units
{
    public partial class ucInsertUnit : UserControl
    {
        public ucInsertUnit()
        {
            InitializeComponent();
        }

        private void ucInsertUnit_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
            chkIsActive.Text = "Evet";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text==String.Empty || txtName.Text==String.Empty )
            {
                MessageBox.Show("Alanları boş geçemezsiniz.");
                return;
            }
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Unit unit = new Unit
                    {
                        Name=txtName.Text,
                        Display=txtDisplay.Text,
                        IsActive=chkIsActive.Checked
                    };
                    var result = unitRepo.Insert(unit);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Kayıt başarılı. Son eklenen birim adı : " + result.Result.Name;
                            txtDisplay.Text = String.Empty;
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
    }
}
