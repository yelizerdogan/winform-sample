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
    public partial class ucEditBeams : UserControl
    {
        public Beam _Beam { get; set; }
        public ucEditBeams()
        {
            InitializeComponent();
        }

        private void ucEditBeams_Load(object sender, EventArgs e)
        {
            txtBeamName.Text = String.Empty;
            txtBeamName.Tag = null;
            if (chkIsDeleted.Checked == true)
            {
                chkIsDeleted.Text = "Evet";

            }
            else
            {
                chkIsDeleted.Text = "Hayır";
            }
            if (chkIsActive.Checked==true)
            {
                chkIsActive.Text = "Evet";
            }
            else
            {
                chkIsActive.Text = "Hayır";
            }
            chkIsActive.Checked = true;
            chkIsDeleted.Checked = false;
            try
            {
                using (IBeamRepository beamRepo = new BeamRepository(new BeamDeflectionDbContext()))
                {
                    var result = beamRepo.GetList();
                    if (result != null)
                    {
                        dgvBeams.DataSource = result.Result;
                        dgvBeams.Columns["ID"].Visible = false;
                        dgvBeams.Columns["Name"].HeaderText = "Kiriş Tipi";
                        dgvBeams.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                        dgvBeams.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                        dgvBeams.Columns["IsDeleted"].HeaderText = "Silinme";
                        dgvBeams.Columns["IsActive"].HeaderText = "Aktiflik";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_Beam==null)
            {
                lblMessage.Text = "Düzenlenecek kirişi seçiniz.";
                return;
            }
            using (IBeamRepository beamRepo = new BeamRepository(new BeamDeflectionDbContext()))
            {
                Beam beam = _Beam;
                beam.IsActive = chkIsActive.Checked;
                beam.IsDeleted = chkIsDeleted.Checked;
                beam.Name = txtBeamName.Text;
                beam.UpdatedAt = DateTime.UtcNow;

                var result = beamRepo.Update(beam);
                switch (result.State)
                {
                    case Basecore.Model.Enums.BusinessResultType.NotSet:
                        lblMessage.Text = result.Message;
                        break;
                    case Basecore.Model.Enums.BusinessResultType.Success:
                        lblMessage.Text = "Güncelleme başarılı. Son güncellenen kirişin adı : " + result.Result.Name;
                       
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
                ucEditBeams_Load(sender, e);
            }

        }



        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDeleted.Checked==true)
            {
                chkIsDeleted.Text = "Evet";

            }
            else
            {
                chkIsDeleted.Text = "Hayır";
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

        private void dgvBeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtBeamName.Text = dgvBeams.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            _Beam = (Beam)dgvBeams.Rows[e.RowIndex].DataBoundItem;
            chkIsActive.Checked = (bool)dgvBeams.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked= (bool)dgvBeams.Rows[e.RowIndex].Cells["IsDeleted"].Value;
 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Beam == null)
            {
                lblMessage.Text = "Silinecek kirişi seçiniz.";
                return;
            }
            try
            {
                using (IBeamRepository beamRepo= new BeamRepository(new BeamDeflectionDbContext()))
                {
                    Beam oldBeam = beamRepo.Get(x => x.ID == _Beam.ID).Result;
                    var result = beamRepo.Delete(oldBeam);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Başarıyla silindi. Son silinen kiriş tipi adı : " +oldBeam.Name;
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
                    ucEditBeams_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
           
        }
    }
}
