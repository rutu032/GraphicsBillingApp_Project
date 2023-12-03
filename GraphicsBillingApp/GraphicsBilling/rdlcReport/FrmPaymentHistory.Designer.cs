namespace GraphicsBilling.rdlcReport
{
    partial class FrmPaymentHistory
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
            this.DataTableCustomerBIllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPayementHistory = new GraphicsBilling.rdlcReport.DataSetPayementHistory();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCustomerBIllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPayementHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTableCustomerBIllBindingSource
            // 
            this.DataTableCustomerBIllBindingSource.DataMember = "DataTableCustomerBIll";
            this.DataTableCustomerBIllBindingSource.DataSource = this.DataSetPayementHistory;
            // 
            // DataSetPayementHistory
            // 
            this.DataSetPayementHistory.DataSetName = "DataSetPayementHistory";
            this.DataSetPayementHistory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DSCustomerBilling";
            reportDataSource1.Value = this.DataTableCustomerBIllBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GraphicsBilling.rdlcReport.CustomerBIllReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1363, 764);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPaymentHistory";
            this.Text = "FrmPaymentHistory";
            this.Load += new System.EventHandler(this.FrmPaymentHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCustomerBIllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPayementHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTableCustomerBIllBindingSource;
        private DataSetPayementHistory DataSetPayementHistory;
    }
}