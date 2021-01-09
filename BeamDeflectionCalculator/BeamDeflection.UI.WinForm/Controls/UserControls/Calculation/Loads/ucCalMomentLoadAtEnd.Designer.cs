
namespace BeamDeflection.UI.WinForm.Controls.UserControls.Calculation.Loads
{
    partial class ucCalMomentLoadAtEnd
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbL = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBefore = new System.Windows.Forms.RichTextBox();
            this.cmbI = new System.Windows.Forms.ComboBox();
            this.cmbE = new System.Windows.Forms.ComboBox();
            this.cmbM = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtI = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.lblMomentOfInertia = new System.Windows.Forms.Label();
            this.lblModulesOfElasticity = new System.Windows.Forms.Label();
            this.lblPointLoad = new System.Windows.Forms.Label();
            this.lblSpanLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbL
            // 
            this.cmbL.FormattingEnabled = true;
            this.cmbL.Location = new System.Drawing.Point(512, 25);
            this.cmbL.Name = "cmbL";
            this.cmbL.Size = new System.Drawing.Size(76, 28);
            this.cmbL.TabIndex = 51;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(252, 275);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(336, 38);
            this.txtResult.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(26, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 31);
            this.label6.TabIndex = 49;
            this.label6.Text = "SONUÇ  :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "Önceki Sonuçlar : ";
            // 
            // txtBefore
            // 
            this.txtBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBefore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBefore.Location = new System.Drawing.Point(631, 58);
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.Size = new System.Drawing.Size(255, 255);
            this.txtBefore.TabIndex = 47;
            this.txtBefore.Text = "";
            // 
            // cmbI
            // 
            this.cmbI.FormattingEnabled = true;
            this.cmbI.Location = new System.Drawing.Point(512, 173);
            this.cmbI.Name = "cmbI";
            this.cmbI.Size = new System.Drawing.Size(76, 28);
            this.cmbI.TabIndex = 46;
            // 
            // cmbE
            // 
            this.cmbE.FormattingEnabled = true;
            this.cmbE.Location = new System.Drawing.Point(512, 122);
            this.cmbE.Name = "cmbE";
            this.cmbE.Size = new System.Drawing.Size(76, 28);
            this.cmbE.TabIndex = 45;
            // 
            // cmbM
            // 
            this.cmbM.FormattingEnabled = true;
            this.cmbM.Location = new System.Drawing.Point(512, 72);
            this.cmbM.Name = "cmbM";
            this.cmbM.Size = new System.Drawing.Size(76, 28);
            this.cmbM.TabIndex = 44;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(252, 223);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(336, 46);
            this.btnCalculate.TabIndex = 43;
            this.btnCalculate.Text = "HESAPLA";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(252, 175);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(254, 26);
            this.txtI.TabIndex = 42;
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(252, 124);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(254, 26);
            this.txtE.TabIndex = 41;
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(252, 74);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(254, 26);
            this.txtM.TabIndex = 40;
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(252, 27);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(254, 26);
            this.txtL.TabIndex = 39;
            // 
            // lblMomentOfInertia
            // 
            this.lblMomentOfInertia.AutoSize = true;
            this.lblMomentOfInertia.Location = new System.Drawing.Point(28, 183);
            this.lblMomentOfInertia.Name = "lblMomentOfInertia";
            this.lblMomentOfInertia.Size = new System.Drawing.Size(165, 20);
            this.lblMomentOfInertia.TabIndex = 38;
            this.lblMomentOfInertia.Text = "Moment of Inertia (I) : ";
            // 
            // lblModulesOfElasticity
            // 
            this.lblModulesOfElasticity.AutoSize = true;
            this.lblModulesOfElasticity.Location = new System.Drawing.Point(28, 132);
            this.lblModulesOfElasticity.Name = "lblModulesOfElasticity";
            this.lblModulesOfElasticity.Size = new System.Drawing.Size(190, 20);
            this.lblModulesOfElasticity.TabIndex = 37;
            this.lblModulesOfElasticity.Text = "Modules of Elasticity (E) : ";
            // 
            // lblPointLoad
            // 
            this.lblPointLoad.AutoSize = true;
            this.lblPointLoad.Location = new System.Drawing.Point(28, 82);
            this.lblPointLoad.Name = "lblPointLoad";
            this.lblPointLoad.Size = new System.Drawing.Size(146, 20);
            this.lblPointLoad.TabIndex = 36;
            this.lblPointLoad.Text = "Moment Load (M) : ";
            // 
            // lblSpanLength
            // 
            this.lblSpanLength.AutoSize = true;
            this.lblSpanLength.Location = new System.Drawing.Point(28, 35);
            this.lblSpanLength.Name = "lblSpanLength";
            this.lblSpanLength.Size = new System.Drawing.Size(136, 20);
            this.lblSpanLength.TabIndex = 35;
            this.lblSpanLength.Text = "Span Length (L) : ";
            // 
            // ucCalMomentLoadAtEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbL);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBefore);
            this.Controls.Add(this.cmbI);
            this.Controls.Add(this.cmbE);
            this.Controls.Add(this.cmbM);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtI);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.lblMomentOfInertia);
            this.Controls.Add(this.lblModulesOfElasticity);
            this.Controls.Add(this.lblPointLoad);
            this.Controls.Add(this.lblSpanLength);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucCalMomentLoadAtEnd";
            this.Size = new System.Drawing.Size(913, 339);
            this.Load += new System.EventHandler(this.ucCalMomentLoadAtEnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbL;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtBefore;
        private System.Windows.Forms.ComboBox cmbI;
        private System.Windows.Forms.ComboBox cmbE;
        private System.Windows.Forms.ComboBox cmbM;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.Label lblMomentOfInertia;
        private System.Windows.Forms.Label lblModulesOfElasticity;
        private System.Windows.Forms.Label lblPointLoad;
        private System.Windows.Forms.Label lblSpanLength;
    }
}
