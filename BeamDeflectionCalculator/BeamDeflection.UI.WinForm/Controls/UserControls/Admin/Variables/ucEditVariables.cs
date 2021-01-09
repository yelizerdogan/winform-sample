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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Variables
{
    public partial class ucEditVariables : UserControl
    {
        public Unit _Unit { get; set; }
        public Variable _Variable { get; set; }
        public ucEditVariables()
        {
            InitializeComponent();
        }

        private void ucEditVariables_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Checked = false;
            chkIsDeleted.Text = "Hayır";
            try
            {
                using (IVariableRepository variableRepo = new VariableRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = variableRepo.GetList("Calculation", "Unit");
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Düzenlenecek kayıt bulunamadı.";
                        return;

                    }
                    dgvVariables.DataSource = result.Result;
                    dgvVariables.Columns["ID"].Visible = false;
                    dgvVariables.Columns["CalculationId"].Visible = false;
                    dgvVariables.Columns["UnitId"].Visible = false;

                    dgvVariables.Columns["Name"].HeaderText = "Değişken Adı";
                    dgvVariables.Columns["Display"].HeaderText = "Sembol";
                    dgvVariables.Columns["Value"].HeaderText = "Değeri";
                    dgvVariables.Columns["Calculation"].HeaderText = "Kullanılan Hesaplamanın Sonucu";
                    dgvVariables.Columns["Unit"].HeaderText = "Birimi";
                    dgvVariables.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvVariables.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvVariables.Columns["IsActive"].HeaderText = "Aktiflik";
                    dgvVariables.Columns["IsDeleted"].HeaderText = "Silinme";

                }
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = unitRepo.GetList();
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Birim bulunamadı.";
                        return;
                    }
                    cmbUnits.DataSource = result.Result;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_Variable == null)
            {
                lblMessage.Text = "Düzenlenecek değişkeni seçiniz.";
                return;
            }
            if (_Unit == null)
            {
                lblMessage.Text = "Birimi seçiniz.";
                return;
            }
            try
            {
                using (IVariableRepository variableRepo = new VariableRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Variable variable = variableRepo.Get(x => x.ID == _Variable.ID).Result;
                    variable.Name = txtName.Text;
                    variable.Display = txtDisplay.Text;
                    variable.IsActive = chkIsActive.Checked;
                    variable.IsDeleted = chkIsDeleted.Checked;
                    variable.UnitId = ((Unit)cmbUnits.SelectedItem).ID;
                    variable.Value = Convert.ToDouble(txtValue.Text);
                    variable.UpdatedAt = DateTime.UtcNow;

                    var result = variableRepo.Update(variable);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Düzenleme başarılı. Son düzenlenen değişkenin adı : " + result.Result.Name;
                            
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
                    ucEditVariables_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Variable == null)
                {
                    lblMessage.Text = "Silinecek değişkeni seçiniz.";
                    return;
                }
                using (IVariableRepository varRepo = new VariableRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    Variable oldVar = varRepo.Get(x => x.ID == _Variable.ID).Result;
                    var result = varRepo.Delete(oldVar);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Başarıyla silindi. Son silinen değişkenin adı : "+oldVar.Name;
                           
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
                    ucEditVariables_Load(sender, e);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void dgvVariables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            _Variable = ((Variable)dgvVariables.Rows[e.RowIndex].DataBoundItem);
            _Unit = ((Unit)dgvVariables.Rows[e.RowIndex].Cells["Unit"].Value);
            txtCalculationResult.Text = ((BeamDeflection.Domain.Model.BeamDeflectionDb.Calculation)dgvVariables.Rows[e.RowIndex].Cells["Calculation"].Value).ToString();
            txtDisplay.Text = dgvVariables.Rows[e.RowIndex].Cells["Display"].Value.ToString();
            txtName.Text = dgvVariables.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtValue.Text = dgvVariables.Rows[e.RowIndex].Cells["Value"].Value.ToString();
            chkIsActive.Checked = (bool)dgvVariables.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked = (bool)dgvVariables.Rows[e.RowIndex].Cells["IsDeleted"].Value;
            foreach (Unit item in cmbUnits.Items)
            {
                if (item.ID == _Unit.ID)
                {
                    cmbUnits.SelectedItem = item;
                    break;
                }
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
    }
}
