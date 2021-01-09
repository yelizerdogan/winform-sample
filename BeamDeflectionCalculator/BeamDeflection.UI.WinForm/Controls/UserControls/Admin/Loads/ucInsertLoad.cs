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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Loads
{
    public partial class ucInsertLoad : UserControl
    {
        public ucInsertLoad()
        {
            InitializeComponent();
        }

        private void ucInsertLoad_Load(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            try
            {
                using (IBeamRepository beamRepo = new BeamRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = beamRepo.GetList();
                    if (result.Result==null)
                    {
                        lblMessage.Text = "Kayıtlı kiriş tipi bulunamadı. Önce kiriş tipi ekleyin.";
                        btnInsert.Enabled = false;
                        return;
                    }
                    cmbBeam.DataSource = result.Result;

                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cmbBeam.SelectedIndex==-1)
            {
                MessageBox.Show("Kiriş tipi seçiniz.");
                return;
            }
            if (txtName.Text==String.Empty)
            {
                MessageBox.Show("Yük tipi adını boş geçemezsiniz.");
                return;
            }
            try
            {
                using (ILoadRepository loadRepo = new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Load load = new Load
                    {
                        BeamId = ((Beam)cmbBeam.SelectedItem).ID,
                        Name = txtName.Text
                    };
                    var result = loadRepo.Insert(load);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Kayıt başarılı. Son kaydedilen yük tipinin adı : " + result.Result.Name;
                            txtName.Text = String.Empty;
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
