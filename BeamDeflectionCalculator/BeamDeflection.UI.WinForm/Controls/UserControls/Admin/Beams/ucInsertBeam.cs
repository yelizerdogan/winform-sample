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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Beams
{
    public partial class ucInsertBeam : UserControl
    {
      
        public ucInsertBeam()
        {
            InitializeComponent();
        }

        private void ucInsertBeam_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
          
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtBeamName.Text==String.Empty)
            {
                MessageBox.Show("Kiriş tipi adı boş geçilemez.");
                txtBeamName.Focus();
                return;
            }
            using (IBeamRepository beamRepo = new BeamRepository(new BeamDeflectionDbContext()))
            {
                var result = beamRepo.Insert(new Beam
                {
                    IsActive = chkIsActive.Checked,
                    Name = txtBeamName.Text
                });
                switch (result.State)
                {
                    case Basecore.Model.Enums.BusinessResultType.NotSet:
                        lblMessage.Text = result.Message;
                        break;
                    case Basecore.Model.Enums.BusinessResultType.Success:
                        lblMessage.Text ="Kayıt başarılı.";
                        txtBeamName.Text = String.Empty;
                        chkIsActive.Checked = true;
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
