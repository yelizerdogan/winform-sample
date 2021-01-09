
namespace BeamDeflection.UI.WinForm.Controls.UserControls.Calculation.Loads
{
    partial class ucCalMidspanLoad
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
            this.lblSpanLength = new System.Windows.Forms.Label();
            this.lblPointLoad = new System.Windows.Forms.Label();
            this.lblModulesOfElasticity = new System.Windows.Forms.Label();
            this.lblMomentOfInertia = new System.Windows.Forms.Label();
            this.txtL = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtI = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.cmbP = new System.Windows.Forms.ComboBox();
            this.cmbE = new System.Windows.Forms.ComboBox();
            this.cmbI = new System.Windows.Forms.ComboBox();
            this.txtBefore = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmbL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSpanLength
            // 
            this.lblSpanLength.AutoSize = true;
            this.lblSpanLength.Location = new System.Drawing.Point(44, 41);
            this.lblSpanLength.Name = "lblSpanLength";
            this.lblSpanLength.Size = new System.Drawing.Size(136, 20);
            this.lblSpanLength.TabIndex = 0;
            this.lblSpanLength.Text = "Span Length (L) : ";
            // 
            // lblPointLoad
            // 
            this.lblPointLoad.AutoSize = true;
            this.lblPointLoad.Location = new System.Drawing.Point(44, 88);
            this.lblPointLoad.Name = "lblPointLoad";
            this.lblPointLoad.Size = new System.Drawing.Size(121, 20);
            this.lblPointLoad.TabIndex = 1;
            this.lblPointLoad.Text = "Point Load (P) : ";
            // 
            // lblModulesOfElasticity
            // 
            this.lblModulesOfElasticity.AutoSize = true;
            this.lblModulesOfElasticity.Location = new System.Drawing.Point(44, 138);
            this.lblModulesOfElasticity.Name = "lblModulesOfElasticity";
            this.lblModulesOfElasticity.Size = new System.Drawing.Size(190, 20);
            this.lblModulesOfElasticity.TabIndex = 2;
            this.lblModulesOfElasticity.Text = "Modules of Elasticity (E) : ";
            // 
            // lblMomentOfInertia
            // 
            this.lblMomentOfInertia.AutoSize = true;
            this.lblMomentOfInertia.Location = new System.Drawing.Point(44, 189);
            this.lblMomentOfInertia.Name = "lblMomentOfInertia";
            this.lblMomentOfInertia.Size = new System.Drawing.Size(165, 20);
            this.lblMomentOfInertia.TabIndex = 3;
            this.lblMomentOfInertia.Text = "Moment of Inertia (I) : ";
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(268, 33);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(254, 26);
            this.txtL.TabIndex = 4;
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(268, 80);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(254, 26);
            this.txtP.TabIndex = 5;
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(268, 130);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(254, 26);
            this.txtE.TabIndex = 6;
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(268, 181);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(254, 26);
            this.txtI.TabIndex = 7;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(268, 229);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(336, 46);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "HESAPLA";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbP
            // 
            this.cmbP.FormattingEnabled = true;
            this.cmbP.Location = new System.Drawing.Point(528, 78);
            this.cmbP.Name = "cmbP";
            this.cmbP.Size = new System.Drawing.Size(76, 28);
            this.cmbP.TabIndex = 10;
            // 
            // cmbE
            // 
            this.cmbE.FormattingEnabled = true;
            this.cmbE.Location = new System.Drawing.Point(528, 128);
            this.cmbE.Name = "cmbE";
            this.cmbE.Size = new System.Drawing.Size(76, 28);
            this.cmbE.TabIndex = 11;
            // 
            // cmbI
            // 
            this.cmbI.FormattingEnabled = true;
            this.cmbI.Location = new System.Drawing.Point(528, 179);
            this.cmbI.Name = "cmbI";
            this.cmbI.Size = new System.Drawing.Size(76, 28);
            this.cmbI.TabIndex = 12;
            // 
            // txtBefore
            // 
            this.txtBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBefore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBefore.Location = new System.Drawing.Point(647, 64);
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.Size = new System.Drawing.Size(255, 255);
            this.txtBefore.TabIndex = 13;
            this.txtBefore.Text = "";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(643, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Önceki Sonuçlar : ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(42, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 31);
            this.label6.TabIndex = 15;
            this.label6.Text = "SONUÇ  :";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(268, 281);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(336, 38);
            this.txtResult.TabIndex = 16;
            // 
            // cmbL
            // 
            this.cmbL.FormattingEnabled = true;
            this.cmbL.Location = new System.Drawing.Point(528, 31);
            this.cmbL.Name = "cmbL";
            this.cmbL.Size = new System.Drawing.Size(76, 28);
            this.cmbL.TabIndex = 17;
            // 
            // ucCalMidspanLoad
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
            this.Controls.Add(this.cmbP);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtI);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.lblMomentOfInertia);
            this.Controls.Add(this.lblModulesOfElasticity);
            this.Controls.Add(this.lblPointLoad);
            this.Controls.Add(this.lblSpanLength);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucCalMidspanLoad";
            this.Size = new System.Drawing.Size(926, 338);
            this.Load += new System.EventHandler(this.ucCalMidspanLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpanLength;
        private System.Windows.Forms.Label lblPointLoad;
        private System.Windows.Forms.Label lblModulesOfElasticity;
        private System.Windows.Forms.Label lblMomentOfInertia;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ComboBox cmbP;
        private System.Windows.Forms.ComboBox cmbE;
        private System.Windows.Forms.ComboBox cmbI;
        private System.Windows.Forms.RichTextBox txtBefore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cmbL;
    }
}
