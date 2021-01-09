
namespace BeamDeflection.UI.WinForm.Forms.MainForms
{
    partial class FrmAdmin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Listele");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Yeni Kullanıcı");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Düzenle");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Kullanıcı", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Roller");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Rol Ekle");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Rol Düzenle");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Rol", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Kiriş Tipleri");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Kiriş Tipi Ekle");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Kiriş Tiplerini Düzenle");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Kiriş", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Yük Tipleri");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Yük Tipi Ekle");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Yük Tiplerini Düzenle");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Yük", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Değişkenler");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Değişken Düzenle");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Değişken", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Birimler");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Birim Ekle");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Birim Düzenle");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Birim", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Hesaplamalar");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Hesaplama Düzenle");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Hesaplama", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25});
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.trvAdmin = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.trvAdmin);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(230, 547);
            this.pnlMenu.TabIndex = 0;
            // 
            // trvAdmin
            // 
            this.trvAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.trvAdmin.ItemHeight = 40;
            this.trvAdmin.Location = new System.Drawing.Point(0, 0);
            this.trvAdmin.Name = "trvAdmin";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Listele";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Yeni Kullanıcı";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Düzenle";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Kullanıcı";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Roller";
            treeNode6.Name = "Node3";
            treeNode6.Text = "Rol Ekle";
            treeNode7.Name = "Node4";
            treeNode7.Text = "Rol Düzenle";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Rol";
            treeNode9.Name = "Node5";
            treeNode9.Text = "Kiriş Tipleri";
            treeNode10.Name = "Node6";
            treeNode10.Text = "Kiriş Tipi Ekle";
            treeNode11.Name = "Node7";
            treeNode11.Text = "Kiriş Tiplerini Düzenle";
            treeNode12.Name = "Node9";
            treeNode12.Text = "Kiriş";
            treeNode13.Name = "Node8";
            treeNode13.Text = "Yük Tipleri";
            treeNode14.Name = "Node9";
            treeNode14.Text = "Yük Tipi Ekle";
            treeNode15.Name = "Node10";
            treeNode15.Text = "Yük Tiplerini Düzenle";
            treeNode16.Name = "Node10";
            treeNode16.Text = "Yük";
            treeNode17.Name = "Node11";
            treeNode17.Text = "Değişkenler";
            treeNode18.Name = "Node13";
            treeNode18.Text = "Değişken Düzenle";
            treeNode19.Name = "Node11";
            treeNode19.Text = "Değişken";
            treeNode20.Name = "Node14";
            treeNode20.Text = "Birimler";
            treeNode21.Name = "Node15";
            treeNode21.Text = "Birim Ekle";
            treeNode22.Name = "Node16";
            treeNode22.Text = "Birim Düzenle";
            treeNode23.Name = "Node12";
            treeNode23.Text = "Birim";
            treeNode24.Name = "Node17";
            treeNode24.Text = "Hesaplamalar";
            treeNode25.Name = "Node18";
            treeNode25.Text = "Hesaplama Düzenle";
            treeNode26.Name = "Node13";
            treeNode26.Text = "Hesaplama";
            this.trvAdmin.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode12,
            treeNode16,
            treeNode19,
            treeNode23,
            treeNode26});
            this.trvAdmin.Size = new System.Drawing.Size(230, 547);
            this.trvAdmin.TabIndex = 0;
            this.trvAdmin.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvAdmin_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1124, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 547);
            this.panel2.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlHeader.Location = new System.Drawing.Point(230, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(894, 62);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(26, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(60, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "label1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCalculation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel4.Location = new System.Drawing.Point(230, 482);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(894, 65);
            this.panel4.TabIndex = 3;
            // 
            // btnCalculation
            // 
            this.btnCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculation.Location = new System.Drawing.Point(722, 7);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(166, 46);
            this.btnCalculation.TabIndex = 0;
            this.btnCalculation.Text = "HESAPLAMA YAP";
            this.btnCalculation.UseVisualStyleBackColor = true;
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(230, 62);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(894, 420);
            this.pnlMain.TabIndex = 4;
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 547);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMenu);
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdmin";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TreeView trvAdmin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnCalculation;
    }
}