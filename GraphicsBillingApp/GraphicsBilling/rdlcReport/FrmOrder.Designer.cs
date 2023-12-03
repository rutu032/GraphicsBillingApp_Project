namespace GraphicsBilling.rdlcReport
{
    partial class FrmOrder
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTableOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSOrder = new GraphicsBilling.rdlcReport.DSOrder();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTableOrderBindingSource
            // 
            this.DataTableOrderBindingSource.DataMember = "DataTableOrder";
            this.DataTableOrderBindingSource.DataSource = this.DSOrder;
            // 
            // DSOrder
            // 
            this.DSOrder.DataSetName = "DSOrder";
            this.DSOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            reportDataSource1.Name = "DSOrder";
            reportDataSource1.Value = this.DataTableOrderBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "GraphicsBilling.rdlcReport.OrderReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(-1, 1);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1366, 765);
            this.reportViewer2.TabIndex = 1;
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.reportViewer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrder";
            this.Text = "FrmOrder";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource DataTableOrderBindingSource;
        private DSOrder DSOrder;
    }
}