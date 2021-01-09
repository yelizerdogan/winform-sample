
namespace BeamDeflection.UI.WinForm.Controls.UserControls.Calculation.Loads
{
    partial class ucCalUniformLoad
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
            this.cmbI = new System.Windows.Forms.ComboBox();
            this.cmbE = new System.Windows.Forms.ComboBox();
            this.cmbw = new System.Windows.Forms.ComboBox();
            this.cmbL = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtI = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtw = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBefore = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cmbI
            // 
            this.cmbI.FormattingEnabled = true;
            this.cmbI.Location = new System.Drawing.Point(541, 174);
            this.cmbI.Name = "cmbI";
            this.cmbI.Size = new System.Drawing.Size(76, 28);
            this.cmbI.TabIndex = 29;
            // 
            // cmbE
            // 
            this.cmbE.FormattingEnabled = true;
            this.cmbE.Location = new System.Drawing.Point(541, 123);
            this.cmbE.Name = "cmbE";
            this.cmbE.Size = new System.Drawing.Size(76, 28);
            this.cmbE.TabIndex = 28;
            // 
            // cmbw
            // 
            this.cmbw.FormattingEnabled = true;
            this.cmbw.Location = new System.Drawing.Point(541, 73);
            this.cmbw.Name = "cmbw";
            this.cmbw.Size = new System.Drawing.Size(76, 28);
            this.cmbw.TabIndex = 27;
            // 
            // cmbL
            // 
            this.cmbL.FormattingEnabled = true;
            this.cmbL.Location = new System.Drawing.Point(541, 26);
            this.cmbL.Name = "cmbL";
            this.cmbL.Size = new System.Drawing.Size(76, 28);
            this.cmbL.TabIndex = 26;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(281, 222);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(336, 46);
            this.btnCalculate.TabIndex = 25;
            this.btnCalculate.Text = "HESAPLA";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtI
            // 
            this.txtI.Location = new System.Drawing.Point(281, 174);
            this.txtI.Name = "txtI";
            this.txtI.Size = new System.Drawing.Size(254, 26);
            this.txtI.TabIndex = 24;
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(281, 123);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(254, 26);
            this.txtE.TabIndex = 23;
            // 
            // txtw
            // 
            this.txtw.Location = new System.Drawing.Point(281, 73);
            this.txtw.Name = "txtw";
            this.txtw.Size = new System.Drawing.Size(254, 26);
            this.txtw.TabIndex = 22;
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(281, 26);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(254, 26);
            this.txtL.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Moment of Inertia (I) : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Modules of Elasticity (E) : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Uniform Load (w) : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Span Length (L) : ";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(281, 274);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(336, 38);
            this.txtResult.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(55, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 31);
            this.label6.TabIndex = 45;
            this.label6.Text = "SONUÇ  :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(637, 26);
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
            this.txtBefore.Location = new System.Drawing.Point(641, 57);
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.Size = new System.Drawing.Size(270, 255);
            this.txtBefore.TabIndex = 47;
            this.txtBefore.Text = "";
            // 
            // ucCalUniformLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBefore);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbI);
            this.Controls.Add(this.cmbE);
            this.Controls.Add(this.cmbw);
            this.Controls.Add(this.cmbL);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtI);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtw);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucCalUniformLoad";
            this.Size = new System.Drawing.Size(943, 337);
            this.Load += new System.EventHandler(this.ucCalUniformLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbI;
        private System.Windows.Forms.ComboBox cmbE;
        private System.Windows.Forms.ComboBox cmbw;
        private System.Windows.Forms.ComboBox cmbL;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtI;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtw;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtBefore;
    }
}
