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
    public partial class ucGetLoads : UserControl
    {
        public ucGetLoads()
        {
            InitializeComponent();
        }

        private void ucGetLoads_Load(object sender, EventArgs e)
        {
            try
            {
                using (ILoadRepository loadRepo = new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = loadRepo.GetList("Beam");
                    if (result.Result==null)
                    {
                        return;
                    }
                    dgvLoads.DataSource = result.Result;
                    dgvLoads.Columns["Calculations"].Visible = false;
                    dgvLoads.Columns["ID"].Visible = false;

                    dgvLoads.Columns["Name"].HeaderText = "Yük Adı";
                    dgvLoads.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvLoads.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvLoads.Columns["IsDeleted"].HeaderText = "Silinme";
                    dgvLoads.Columns["IsActive"].HeaderText = "Aktiflik";

                }
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
    }
}
