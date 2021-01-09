using BeamDeflection.Datacore.Infrastructure;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.UI.WinForm.Controls.UserControls.Calculation.Loads;
using BeamDeflection.UI.WinForm.Controls.UserControls.Formula;
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
    public partial class FrmCalculation : Form
    {
        public ApplicationUser CurrentUser { get; set; }
        public FrmCalculation(ApplicationUser currentUser)
        {
            CurrentUser = currentUser;
            InitializeComponent();
        }

        private void FrmCalculation_Load(object sender, EventArgs e)
        {
            try
            {
             
                using (IBeamRepository beamRepo= new BeamRepository(new Datacore.Data.BeamDeflectionDbContext()))
                {
                    var result = beamRepo.GetList();
                    if (result==null)
                    {
                        return;
                    }
                    cmbBeams.DataSource = result.Result;
                    cmbBeams.DisplayMember = "Name";
                   
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbLoads_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbLoads.SelectedIndex==-1)
            {
                return;
            }
            pnlMain.Controls.Clear();
            pnlButtom.Controls.Clear();
            switch (cmbLoads.Text)
            {
                case "Ortadan yük":
                    ucMidspanLoad midspanLoad = new ucMidspanLoad();
                    midspanLoad.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(midspanLoad);
                    ucCalMidspanLoad calMidspanLoad = new ucCalMidspanLoad(CurrentUser,(Load)cmbLoads.SelectedItem);
                    calMidspanLoad.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calMidspanLoad);
                    break;
                    
                case "Herhangi bir noktadan yük":
                    ucLoadAtAnyPoint loadAtAnyPoint = new ucLoadAtAnyPoint();
                    loadAtAnyPoint.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(loadAtAnyPoint);
                    ucCalLoadAtAnyPoint calLoadAtAnyPoint = new ucCalLoadAtAnyPoint(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calLoadAtAnyPoint.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calLoadAtAnyPoint);
                    break;
                case "Düzgün yük":
                    ucUniformLoad uniformLoad = new ucUniformLoad();
                    uniformLoad.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(uniformLoad);
                    ucCalUniformLoad calUniformLoad = new ucCalUniformLoad(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calUniformLoad.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calUniformLoad);
                    break;
                case "Düzgün değişen yük":
                    ucUniformlyVaring uniformlyVaring = new ucUniformlyVaring();
                    uniformlyVaring.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(uniformlyVaring);
                    ucCalUniformlyVaring calUniformlyVaring = new ucCalUniformlyVaring(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calUniformlyVaring.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calUniformlyVaring);
                    break;
                case "Üçgen yük":
                    ucTriangularLoad triangularLoad = new ucTriangularLoad();
                    triangularLoad.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(triangularLoad);
                    ucCalTriangularLoad calTriangularLoad = new ucCalTriangularLoad(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calTriangularLoad.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calTriangularLoad);
                    break;
                case "Tek destekte moment yükü":
                    ucMomentLoadAtOneSupport momentLoadAtOneSupport = new ucMomentLoadAtOneSupport();
                    momentLoadAtOneSupport.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(momentLoadAtOneSupport);
                    ucCalMomentLoadAtOneSupport calMomentLoadAtOneSupport = new ucCalMomentLoadAtOneSupport(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calMomentLoadAtOneSupport.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calMomentLoadAtOneSupport);
                    break;
                case "Sona yük":
                    ucEndLoad endLoad = new ucEndLoad();
                    endLoad.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(endLoad);
                    ucCalEndLoad calEndLoad = new ucCalEndLoad(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calEndLoad.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calEndLoad);
                    break;
                case "Herhangi bir noktaya yük":
                    ucLoadAtAnyPointSecond loadAtAnyPointSecond = new ucLoadAtAnyPointSecond();
                    loadAtAnyPointSecond.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(loadAtAnyPointSecond);
                    ucCalLoadAtAnyPointSecond calLoadAtAnyPointSecond = new ucCalLoadAtAnyPointSecond(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calLoadAtAnyPointSecond.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calLoadAtAnyPointSecond);
                    break;
                case "Düzgün yayılan yük":
                    ucUniformLoadSecond uniformLoadSecond = new ucUniformLoadSecond();
                    uniformLoadSecond.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(uniformLoadSecond);
                    ucCalUniformLoadSecond calUniformLoadSecond = new ucCalUniformLoadSecond(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calUniformLoadSecond.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calUniformLoadSecond);
                    break;
                case "Düzgün değişen yük (Durum 1)":
                    ucUniformlyVaringLoadFirstCase uniformlyVaringLoadFirstCase = new ucUniformlyVaringLoadFirstCase();
                    uniformlyVaringLoadFirstCase.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(uniformlyVaringLoadFirstCase);
                    ucCalUniformlyVaringLoadFirstCase calUniformlyVaringLoadFirstCase = new ucCalUniformlyVaringLoadFirstCase(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calUniformlyVaringLoadFirstCase.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calUniformlyVaringLoadFirstCase);
                    break;
                case "Düzgün değişen yük (Durum 2)":
                    ucUniformlyVaringLoadSecondCase uniformlyVaringLoadSecondCase = new ucUniformlyVaringLoadSecondCase();
                    uniformlyVaringLoadSecondCase.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(uniformlyVaringLoadSecondCase);
                    ucCalUniformlyVaringLoadSecondCase calUniformlyVaringLoadSecondCase = new ucCalUniformlyVaringLoadSecondCase(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calUniformlyVaringLoadSecondCase.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calUniformlyVaringLoadSecondCase);
                    break;
                case "Sonunda moment yükü":
                    ucMomentLoadAtEnd momentLoadAtEnd = new ucMomentLoadAtEnd();
                    momentLoadAtEnd.Dock = DockStyle.Fill;
                    pnlMain.Controls.Add(momentLoadAtEnd);
                    ucCalMomentLoadAtEnd calMomentLoadAtEnd = new ucCalMomentLoadAtEnd(CurrentUser, (Load)cmbLoads.SelectedItem);
                    calMomentLoadAtEnd.Dock = DockStyle.Fill;
                    pnlButtom.Controls.Add(calMomentLoadAtEnd);
                    break;
                default:
                    
                    break;
            }
        }

        private void lblGetAllFormulas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmFormulas frmFormulas = new FrmFormulas();
            frmFormulas.Show();
        }

        private void cmbBeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBeams.SelectedIndex == -1)
            {
                return;
            }
            pnlMain.Controls.Clear();
            pnlButtom.Controls.Clear();
            using (ILoadRepository loadRepo = new LoadRepository(new Datacore.Data.BeamDeflectionDbContext()))
            {
                var loads = loadRepo.FindList(x => x.BeamId == ((Beam)cmbBeams.SelectedItem).ID);
                if (loads == null)
                {
                    return;
                }
                cmbLoads.DataSource = loads.Result;
                cmbLoads.DisplayMember = "Name";
               

            }
        }
    }
}
