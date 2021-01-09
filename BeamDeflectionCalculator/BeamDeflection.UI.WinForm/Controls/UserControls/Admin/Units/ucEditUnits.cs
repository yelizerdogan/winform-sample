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
    public partial class ucEditUnits : UserControl
    {
        public Unit _Unit { get; set; }
        public ucEditUnits()
        {
            InitializeComponent();
        }

        private void ucEditUnits_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Text = "Hayır";
            chkIsDeleted.Checked = false;
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = unitRepo.GetList();
                    if (result.Result == null)
                    {
                        return;
                    }
                    dgvUnits.DataSource = result.Result;
                    dgvUnits.Columns["ID"].Visible = false;
                    dgvUnits.Columns["Variables"].Visible = false;
                    dgvUnits.Columns["Calculations"].Visible = false;
                    dgvUnits.Columns["Name"].HeaderText = "Birim Adı";
                    dgvUnits.Columns["Display"].HeaderText = "Sembol";
                    dgvUnits.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvUnits.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvUnits.Columns["IsActive"].HeaderText = "Aktiflik";
                    dgvUnits.Columns["IsDeleted"].HeaderText = "Silinme";
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == String.Empty || txtName.Text == String.Empty)
            {
                MessageBox.Show("Alanları boş geçemezsiniz.");
                return;
            }
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    if (_Unit == null)
                    {
                        lblMessage.Text = "Birim seçiniz.";
                        return;
                    }
                    Unit unit = _Unit;
                    unit.Name = txtName.Text;
                    unit.Display = txtDisplay.Text;
                    unit.IsActive = chkIsActive.Checked;
                    unit.IsDeleted = chkIsDeleted.Checked;
                    unit.UpdatedAt = DateTime.UtcNow;
                    var result = unitRepo.Update(unit);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Güncelleme başarılı. Son güncellenen birimin adı : " + result.Result.Name;
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
                ucEditUnits_Load(sender, e);
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
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

        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            _Unit = (Unit)dgvUnits.Rows[e.RowIndex].DataBoundItem;
            txtName.Text = dgvUnits.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtDisplay.Text= dgvUnits.Rows[e.RowIndex].Cells["Display"].Value.ToString();
            chkIsActive.Checked= (bool)dgvUnits.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked = (bool)dgvUnits.Rows[e.RowIndex].Cells["IsDeleted"].Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Unit==null)
            {
                return;
            }
            if (txtDisplay.Text == String.Empty || txtName.Text == String.Empty)
            {
                MessageBox.Show("Silinecek birimi seçiniz.");
                return;
            }
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Unit unit = unitRepo.Get(x=>x.ID==_Unit.ID).Result;
                    var result = unitRepo.Delete(unit);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Birim silindi.";
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
                ucEditUnits_Load(sender, e);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }
    }
}
