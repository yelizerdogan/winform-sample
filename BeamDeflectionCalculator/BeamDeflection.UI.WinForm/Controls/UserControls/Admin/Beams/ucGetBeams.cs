using BeamDeflection.Datacore.Data;
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

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Admin.Beams
{
    public partial class ucGetBeams : UserControl
    {
        public ucGetBeams()
        {
            InitializeComponent();
        }

        private void ucGetBeams_Load(object sender, EventArgs e)
        {
            using (IBeamRepository beamRepo=new BeamRepository(new BeamDeflectionDbContext()))
            {
                var result = beamRepo.GetList();
                if (result != null)
                {
                    dgvBeams.DataSource = result.Result;
                    dgvBeams.Columns["ID"].Visible = false;
                    dgvBeams.Columns["Loads"].Visible = false;
                    dgvBeams.Columns["Name"].HeaderText = "Kiriş Tipi";
                    dgvBeams.Columns["CreatedAt"].HeaderText = "Oluşturulma Tarihi";
                    dgvBeams.Columns["UpdatedAt"].HeaderText = "Düzenlenme Tarihi";
                    dgvBeams.Columns["IsDeleted"].HeaderText = "Silinme";
                    dgvBeams.Columns["IsActive"].HeaderText = "Aktiflik";
                }

            }


        }
    }
}
