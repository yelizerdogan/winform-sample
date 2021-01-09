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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Calculations
{
    public partial class ucEditCalculations : UserControl
    {
        public BeamDeflection.Domain.Model.BeamDeflectionDb.Calculation _Calculation { get; set; }
        public Unit _Unit { get; set; }
        public ApplicationUser _User { get; set; }
        public Load _Load { get; set; }
        public ucEditCalculations()
        {
            InitializeComponent();
        }

        private void ucEditCalculations_Load(object sender, EventArgs e)
        {
            chkIsActive.Text = "Evet";
            chkIsActive.Checked = true;
            chkIsDeleted.Text = "Hayır";
            chkIsDeleted.Checked = false;

            try
            {
                using (ICalculationRepository calRepo = new CalculationRepository(new BeamDeflectionDbContext()))
                {
                    var result = calRepo.GetList("Load", "Unit", "AppUser");
                    if (result.Result == null)
                    {
                        return;
                    }
                    dgvCalculations.DataSource = result.Result;
                    dgvCalculations.Columns["ID"].Visible = false;
                    dgvCalculations.Columns["LoadId"].Visible = false;
                    dgvCalculations.Columns["UserId"].Visible = false;
                    dgvCalculations.Columns["UnitId"].Visible = false;
                    dgvCalculations.Columns["Variables"].Visible = false;

                    dgvCalculations.Columns["Result"].HeaderText = "Sonuç";
                    dgvCalculations.Columns["Load"].HeaderText = "Yük Tipi";
                    dgvCalculations.Columns["Unit"].HeaderText = "Birimi";
                    dgvCalculations.Columns["AppUser"].HeaderText = "Hesaplamayı Yapan Kullanıcı";
                    dgvCalculations.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvCalculations.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvCalculations.Columns["IsDeleted"].HeaderText = "Silinme";
                    dgvCalculations.Columns["IsActive"].HeaderText = "Aktiflik";
                }
                using (IUserRepository userRepo = new UserRepository(new BeamDeflectionDbContext()))
                {
                    var result = userRepo.GetList();
                    if (result.Result==null)
                    {
                        lblMessage.Text = "Eklenecek kullanıcı bulunamadı.";
                        return;
                    }
                    cmbUsers.DataSource = result.Result;

                }
                using (IUnitRepository unitRepo = new UnitRepository(new BeamDeflectionDbContext()))
                {
                    var result = unitRepo.GetList();
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Eklenecek birim bulunamadı.";
                        return;
                    }
                    cmbUnits.DataSource = result.Result;

                }
                using (ILoadRepository loadRepo = new LoadRepository(new BeamDeflectionDbContext()))
                {
                    var result = loadRepo.GetList();
                    if (result.Result == null)
                    {
                        lblMessage.Text = "Eklenecek yük tipi bulunamadı.";
                        return;
                    }
                    cmbLoads.DataSource = result.Result;

                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = "Hata : " + ex.GetBaseException();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_User==null)
            {
                lblMessage.Text = "Kullanıcı seçin";
                return;
            }
            if (_Load==null)
            {
                lblMessage.Text = "Yük tipi seçin";
                return;
            }
            if (_Unit == null)
            {
                lblMessage.Text = "Birim seçin";
                return;
            }
            if (_Calculation==null)
            {
                lblMessage.Text = "Hesaplama seçin";
                return;
            }
            try
            {
                using (ICalculationRepository calRepo= new CalculationRepository(new BeamDeflectionDbContext()))
                {
                    BeamDeflection.Domain.Model.BeamDeflectionDb.Calculation newCal = calRepo.Get(x=>x.ID==_Calculation.ID,"Load","AppUser","Unit").Result;
                    newCal.IsActive = chkIsActive.Checked;
                    newCal.IsDeleted = chkIsDeleted.Checked;
                    newCal.LoadId =((Load)cmbLoads.SelectedItem).ID;
                    newCal.UnitId = ((Unit)cmbUnits.SelectedItem).ID;
                    newCal.UserId = ((ApplicationUser)cmbUsers.SelectedItem).ID;
                    newCal.Result = Convert.ToDouble(txtResult.Text);
                    newCal.UpdatedAt = DateTime.UtcNow;
                    var result = calRepo.Update(newCal);
                   
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Düzenleme başarılı. Son düzenlenen hesaplama sonucu : "+result.Result.Result;
                            ucEditCalculations_Load(sender,e);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (ICalculationRepository calRepo= new CalculationRepository(new BeamDeflectionDbContext()))
                {
                    BeamDeflection.Domain.Model.BeamDeflectionDb.Calculation oldCal = calRepo.Get(x=>x.ID == _Calculation.ID).Result;
                    if (oldCal==null)
                    {
                        lblMessage.Text = "Silmek istediğiniz hesaplamayı seçiniz.";
                        return;
                    }
                    var result = calRepo.Delete(oldCal);
                    switch (result.State)
                    {
                        case Basecore.Model.Enums.BusinessResultType.NotSet:
                            lblMessage.Text = result.Message;
                            break;
                        case Basecore.Model.Enums.BusinessResultType.Success:
                            lblMessage.Text = "Silme işlemi başarılı.";
                            ucEditCalculations_Load(sender,e);
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

        private void dgvCalculations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            _Calculation = ((BeamDeflection.Domain.Model.BeamDeflectionDb.Calculation)dgvCalculations.Rows[e.RowIndex].DataBoundItem);
            _Load = ((BeamDeflection.Domain.Model.BeamDeflectionDb.Load)dgvCalculations.Rows[e.RowIndex].Cells["Load"].Value);
            _Unit = ((Unit)dgvCalculations.Rows[e.RowIndex].Cells["Unit"].Value);
            _User = ((ApplicationUser)dgvCalculations.Rows[e.RowIndex].Cells["AppUser"].Value);
            foreach (Load item in cmbLoads.Items)
            {
                if (item.ID==_Load.ID)
                {
                    cmbLoads.SelectedItem = item;
                    break;
                }
            }
            foreach (Unit item in cmbUnits.Items)
            {
                if (item.ID == _Unit.ID)
                {
                    cmbUnits.SelectedItem = item;
                    break;
                }
            }
            foreach (ApplicationUser item in cmbUsers.Items)
            {
                if (item.ID == _User.ID)
                {
                    cmbUsers.SelectedItem = item;
                    break;
                }
            }
            txtResult.Text = dgvCalculations.Rows[e.RowIndex].Cells["Result"].Value.ToString();
            chkIsActive.Checked = (bool)dgvCalculations.Rows[e.RowIndex].Cells["IsActive"].Value;
            chkIsDeleted.Checked = (bool)dgvCalculations.Rows[e.RowIndex].Cells["IsDeleted"].Value;
          
        }
    }
}
