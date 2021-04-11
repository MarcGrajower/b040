
namespace B040.ExcelAddin
{
    partial class RibbonB040 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonB040()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.B040 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.MaandelijkseFacturatieStatitiekButton = this.Factory.CreateRibbonButton();
            this.TestButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.B040.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // B040
            // 
            this.B040.Groups.Add(this.group2);
            this.B040.Label = "B040";
            this.B040.Name = "B040";
            // 
            // group2
            // 
            this.group2.Items.Add(this.MaandelijkseFacturatieStatitiekButton);
            this.group2.Items.Add(this.TestButton);
            this.group2.Label = "B040 Group";
            this.group2.Name = "group2";
            // 
            // MaandelijkseFacturatieStatitiekButton
            // 
            this.MaandelijkseFacturatieStatitiekButton.Label = "Maandelijkse Facturatie Statistiek";
            this.MaandelijkseFacturatieStatitiekButton.Name = "MaandelijkseFacturatieStatitiekButton";
            this.MaandelijkseFacturatieStatitiekButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MaandelijkseFacturatieStatitiekButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Label = "Test";
            this.TestButton.Name = "TestButton";
            this.TestButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TestButton_Click);
            // 
            // RibbonB040
            // 
            this.Name = "RibbonB040";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.B040);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.B040.ResumeLayout(false);
            this.B040.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab B040;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton MaandelijkseFacturatieStatitiekButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TestButton;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonB040 Ribbon1
        {
            get { return this.GetRibbon<RibbonB040>(); }
        }
    }
}
