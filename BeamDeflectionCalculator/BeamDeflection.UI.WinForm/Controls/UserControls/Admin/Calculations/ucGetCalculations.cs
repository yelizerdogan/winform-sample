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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin
{
    public partial class ucGetCalculations : UserControl
    {
        public ucGetCalculations()
        {
            InitializeComponent();
        }

        private void ucGetCalculations_Load(object sender, EventArgs e)
        {

            try
            {
                using (ICalculationRepository calRepo = new CalculationRepository(new BeamDeflectionDbContext()))
                {
                    var result = calRepo.GetList("Load","Unit","AppUser");
                    if (result.Result==null)
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
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
