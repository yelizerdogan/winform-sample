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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Variables
{
    public partial class ucGetVariables : UserControl
    {
        public ucGetVariables()
        {
            InitializeComponent();
        }

        private void ucGetVariables_Load(object sender, EventArgs e)
        {
            try
            {
                using (IVariableRepository variableRepo = new VariableRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = variableRepo.GetList("Calculation","Unit");
                    if (result.Result==null)
                    {
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
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
