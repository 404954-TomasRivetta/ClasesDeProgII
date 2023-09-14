namespace PresupuestoCarpinteria.Presentacion
{
    partial class FrmListadoProductos
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
            this.tAPRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSProductos = new PresupuestoCarpinteria.Presentacion.Reportes.DSProductos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tA_PRODUCTOSTableAdapter = new PresupuestoCarpinteria.Presentacion.Reportes.DSProductosTableAdapters.TA_PRODUCTOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tAPRODUCTOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // tAPRODUCTOSBindingSource
            // 
            this.tAPRODUCTOSBindingSource.DataMember = "TA_PRODUCTOS";
            this.tAPRODUCTOSBindingSource.DataSource = this.dSProductos;
            this.tAPRODUCTOSBindingSource.CurrentChanged += new System.EventHandler(this.tAPRODUCTOSBindingSource_CurrentChanged);
            // 
            // dSProductos
            // 
            this.dSProductos.DataSetName = "DSProductos";
            this.dSProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tAPRODUCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PresupuestoCarpinteria.Presentacion.Reportes.RptListadoProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(631, 449);
            this.reportViewer1.TabIndex = 0;
            // 
            // tA_PRODUCTOSTableAdapter
            // 
            this.tA_PRODUCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // FrmListadoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmListadoProductos";
            this.Text = "Listado de Productos";
            this.Load += new System.EventHandler(this.FrmListadoProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tAPRODUCTOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSProductos dSProductos;
        private System.Windows.Forms.BindingSource tAPRODUCTOSBindingSource;
        private Reportes.DSProductosTableAdapters.TA_PRODUCTOSTableAdapter tA_PRODUCTOSTableAdapter;
    }
}