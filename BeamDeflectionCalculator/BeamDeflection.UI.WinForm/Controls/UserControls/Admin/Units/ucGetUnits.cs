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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Units
{
    public partial class ucGetUnits : UserControl
    {
        public ucGetUnits()
        {
            InitializeComponent();
        }

        private void ucGetUnits_Load(object sender, EventArgs e)
        {
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = unitRepo.GetList();
                    if (result.Result==null)
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
