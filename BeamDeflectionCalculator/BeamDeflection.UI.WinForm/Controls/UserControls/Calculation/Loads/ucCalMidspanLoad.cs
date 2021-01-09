using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.UI.WinForm.Formulas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamDeflection.UI.WinForm.Controls.UserControls.Calculation.Loads
{
    public partial class ucCalMidspanLoad : UserControl
    {
        public ApplicationUser CurrentUser { get; set; }
        public Load _Load { get; set; }
        public Unit ResultUnit { get; set; }
        public ucCalMidspanLoad(ApplicationUser currentUser, Load load)
        {
            _Load = load;
            CurrentUser = currentUser;
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtE.Text==String.Empty || txtI.Text == String.Empty || txtL.Text == String.Empty || txtP.Text == String.Empty)
            {
                MessageBox.Show("Hesaplama yapmak için boş alanları doldurunuz.");
                return;
            }
            double E = Convert.ToDouble(txtE.Text),
                I = Convert.ToDouble(txtI.Text),
                L = Convert.ToDouble(txtL.Text),
                P = Convert.ToDouble(txtP.Text);

            if (cmbL.Text=="cm")
            {
                L = L / 100;
            }
            if (cmbP.Text=="N")
            {
                P = P / 1000;
            }
            if (cmbE.Text=="Pa")
            {
                E = E / 1000000;
            }
            if (cmbI.Text== "cm⁴")
            {
                I = I / 100000000;
            }

            double result = CalculateCaseFirst.MidSpanLoad(L, P, E, I);
         
            txtResult.Text = result + " mm";
            try
            {
                Domain.Model.BeamDeflectionDb.Calculation cal = null;
                using (ICalculationRepository calRepo = new CalculationRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    
                    var calResult = calRepo.Insert(new Domain.Model.BeamDeflectionDb.Calculation
                    {
                        Result = result,
                        LoadId = _Load.ID,
                        UserId = CurrentUser.ID,
                        IsActive = true,
                        IsDeleted = false,
                        UnitId=ResultUnit.ID
                    });
                    cal = calResult.Result;
                    var allResult = calRepo.FindList(x=>x.UserId==CurrentUser.ID);
                    if (allResult.Result!=null)
                    {
                        allResult.Result.Reverse();
                        txtBefore.Text = String.Empty;
                        int count = 0;
                        allResult.Result.ForEach(x => {
                            if (count==10)
                            {
                                return;
                            }

                            txtBefore.AppendText(x.Result + "\n");

                            count++;
                        });
                    }
                }
                using (IVariableRepository variableRepo = new VariableRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    List<Variable> variables = new List<Variable> {
                        new Variable
                        {
                            Name="Span Length",
                            Display="L",
                            CalculationId=cal.ID,
                            IsActive=true,
                            IsDeleted=false,
                            Value=Convert.ToDouble(txtL.Text),
                            UnitId=((Unit)cmbL.SelectedItem).ID
                        },
                        new Variable
                        {
                            Name="Point Load",
                            Display="P",
                            CalculationId=cal.ID,
                            IsActive=true,
                            IsDeleted=false,
                            Value=Convert.ToDouble(txtP.Text),
                            UnitId=((Unit)cmbP.SelectedItem).ID
                        },
                        new Variable
                        {
                            Name="Modules of Elasticity",
                            Display="E",
                            CalculationId=cal.ID,
                            IsActive=true,
                            IsDeleted=false,
                            Value=Convert.ToDouble(txtE.Text),
                            UnitId=((Unit)cmbE.SelectedItem).ID
                        },
                        new Variable
                        {
                            Name="Moment of Inertia",
                            Display="I",
                            CalculationId=cal.ID,
                            IsActive=true,
                            IsDeleted=false,
                            Value=Convert.ToDouble(txtI.Text),
                            UnitId=((Unit)cmbI.SelectedItem).ID
                        }
                    };
                    variableRepo.InsertList(variables);
                }

            }
            catch (Exception)
            {

                return;
            }
        }

        private void ucCalMidspanLoad_Load(object sender, EventArgs e)
        {
            try
            {
                using (IUnitRepository unitRepo = new UnitRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    cmbL.Items.Add(unitRepo.Get(x => x.Name == "meters").Result);
                    cmbL.Items.Add(unitRepo.Get(x => x.Name == "centimeters").Result);
                    cmbL.DisplayMember = "Display";
                    cmbL.SelectedIndex = 0;

                    cmbP.Items.Add(unitRepo.Get(x => x.Name == "kilonewtons").Result);
                    cmbP.Items.Add(unitRepo.Get(x => x.Name == "newtons").Result);
                    cmbP.DisplayMember = "Display";
                    cmbP.SelectedIndex = 0;

                    cmbE.Items.Add(unitRepo.Get(x => x.Name == "megapascals").Result);
                    cmbE.Items.Add(unitRepo.Get(x => x.Name == "pascals").Result);
                    cmbE.DisplayMember = "Display";
                    cmbE.SelectedIndex = 0;

                    cmbI.Items.Add(unitRepo.Get(x => x.Name == "meters to fourth power").Result);
                    cmbI.Items.Add(unitRepo.Get(x => x.Name == "centimeters to fourth power").Result);
                    cmbI.DisplayMember = "Display";
                    cmbI.SelectedIndex = 0;

                   var resultunit= unitRepo.Get(x => x.Name == "milimeters").Result;
                    if (resultunit!=null)
                    {
                        ResultUnit = resultunit;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
