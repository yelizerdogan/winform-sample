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
    public partial class ucEditLoads : UserControl
    {
        public Load _Load { get; set; }
        public Beam _Beam { get; set; }
        public ucEditLoads()
        {
            InitializeComponent();
        }

        private void ucEditLoads_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Text = "Hayır";
            chkIsDeleted.Checked = false;
            try
            {
                using (ILoadRepository loadRepo = new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = loadRepo.GetList("Beam");
                    if (result.Result == null)
                    {
                        return;
                    }
                    dgvLoads.DataSource = result.Result;
                    dgvLoads.Columns["BeamId"].Visible = false;
                    dgvLoads.Columns["Calculations"].Visible = false;
                    dgvLoads.Columns["ID"].Visible = false;

                    dgvLoads.Columns["Name"].HeaderText = "Yük Adı";
                    dgvLoads.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvLoads.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvLoads.Columns["IsDeleted"].HeaderText = "Silinme";
                    dgvLoads.Columns["IsActive"].HeaderText = "Aktiflik";

                }
                using (IBeamRepository beamRepo=new BeamRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = beamRepo.GetList("Loads");
                    if (result==null)
                    {
                        lblMessage.Text = "Kayıtlı kiriş tipi bulunamadı. Önce kiriş tipi ekleyin";
                        return;
                    }
                    cmbBeams.DataSource = result.Result;
                    
                }

            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbBeams.SelectedIndex==-1)
            {
                MessageBox.Show("Kiriş tipi seçiniz.");
            }
            if (txtName.Text == String.Empty)
            {
                MessageBox.Show("Yük tipi adı giriniz.");
            }
            try
            {
                using (ILoadRepository loadRepo= new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Load oldLoad = loadRepo.Get(x=>x.ID==_Load.ID).Result;
                    oldLoad.BeamId = ((Beam)cmbBeams.SelectedItem).ID;
                    oldLoad.Name = txtName.Text;
                    oldLoad.IsActive = chkIsActive.Checked;
                    oldLoad.IsDeleted = chkIsDeleted.Checked;
                    oldLoad.UpdatedAt = DateTime.UtcNow;
                    var result = loadRepo.Update(oldLoad);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Güncelleme başarılı. Son güncellenen yük tipinin adı : "+result.Result.Name;
                            txtName.Text = String.Empty;
                            cmbBeams.SelectedIndex = 0;
                            chkIsActive.Checked = true;
                            chkIsDeleted.Checked = false;
                            
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
                    ucEditLoads_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
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

        private void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            _Beam = ((Beam)dgvLoads.Rows[e.RowIndex].Cells["Beam"].Value);
            foreach (var item in cmbBeams.Items)
            {
                if (((Beam)item).Name==_Beam.Name)
                {
                    cmbBeams.SelectedItem = item;
                    break;
                }
            }
            txtName.Text = dgvLoads.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            chkIsActive.Checked = (bool)dgvLoads.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked = (bool)dgvLoads.Rows[e.RowIndex].Cells["IsDeleted"].Value;
            _Load = (Load)dgvLoads.Rows[e.RowIndex].DataBoundItem;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Load==null)
            {
                lblMessage.Text = "Silinecek yük tipini seçiniz.";
                return;
            }
            try
            {
                using (ILoadRepository loadRepo= new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Load oldLoad = loadRepo.Get(x=>x.ID==_Load.ID).Result;
                    var result = loadRepo.Delete(oldLoad);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Silme işlemi başarılı. Son silinen yük tipi adı : " + oldLoad.Name;
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
                    ucEditLoads_Load(sender, e);
                }
            }
            catch (Exception ex )
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }
    }
}
