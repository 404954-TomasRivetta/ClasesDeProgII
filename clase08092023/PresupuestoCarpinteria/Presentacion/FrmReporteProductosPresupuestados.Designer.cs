namespace PresupuestoCarpinteria.Presentacion
{
    partial class FrmReporteProductosPresupuestados
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
            this.dTProductosPresupuestadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSProductosPresupuestados = new PresupuestoCarpinteria.Presentacion.Reportes.DSProductosPresupuestados();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpFecDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.dtpFecHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dTProductosPresupuestadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProductosPresupuestados)).BeginInit();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dTProductosPresupuestadosBindingSource
            // 
            this.dTProductosPresupuestadosBindingSource.DataMember = "DTProductosPresupuestados";
            this.dTProductosPresupuestadosBindingSource.DataSource = this.dSProductosPresupuestados;
            // 
            // dSProductosPresupuestados
            // 
            this.dSProductosPresupuestados.DataSetName = "DSProductosPresupuestados";
            this.dSProductosPresupuestados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dTProductosPresupuestadosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PresupuestoCarpinteria.Presentacion.Reportes.RptReporteProductosPresupuestados.rd" +
    "lc";
            this.reportViewer1.Location = new System.Drawing.Point(14, 118);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(684, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtpFecDesde
            // 
            this.dtpFecDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDesde.Location = new System.Drawing.Point(167, 45);
            this.dtpFecDesde.Name = "dtpFecDesde";
            this.dtpFecDesde.Size = new System.Drawing.Size(86, 20);
            this.dtpFecDesde.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Desde:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(495, 44);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(113, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.dtpFecHasta);
            this.grpFiltros.Controls.Add(this.label2);
            this.grpFiltros.Controls.Add(this.dtpFecDesde);
            this.grpFiltros.Controls.Add(this.btnGenerar);
            this.grpFiltros.Controls.Add(this.label1);
            this.grpFiltros.Location = new System.Drawing.Point(14, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(684, 100);
            this.grpFiltros.TabIndex = 4;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // dtpFecHasta
            // 
            this.dtpFecHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHasta.Location = new System.Drawing.Point(362, 45);
            this.dtpFecHasta.Name = "dtpFecHasta";
            this.dtpFecHasta.Size = new System.Drawing.Size(86, 20);
            this.dtpFecHasta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Hasta:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(623, 385);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmReporteProductosPresupuestados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 420);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteProductosPresupuestados";
            this.Text = "Reporte de Productos Presupuestados";
            this.Load += new System.EventHandler(this.FrmReporteProductosPresupuestados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dTProductosPresupuestadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSProductosPresupuestados)).EndInit();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpFecDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.DateTimePicker dtpFecHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.BindingSource dTProductosPresupuestadosBindingSource;
        private Reportes.DSProductosPresupuestados dSProductosPresupuestados;
    }
}