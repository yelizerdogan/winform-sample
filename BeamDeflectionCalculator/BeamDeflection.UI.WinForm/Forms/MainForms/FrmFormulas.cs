using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Forms.MainForms
{
    public partial class FrmFormulas : Form
    {
        public FrmFormulas()
        {
            InitializeComponent();
        }

        private void FrmFormulas_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width / 2;
        }
    }
}
