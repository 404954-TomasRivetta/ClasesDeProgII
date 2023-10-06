namespace problema1_1
{
    partial class FrmNuevoPlanDeEstudio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboMateria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numCuatrimestre = new System.Windows.Forms.NumericUpDown();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDetalleCarrera = new System.Windows.Forms.DataGridView();
            this.Columna1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnioCursado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCuatrimestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBotones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblProximaCarrera = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtAnioCursado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCuatrimestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMateria
            // 
            this.cboMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMateria.FormattingEnabled = true;
            this.cboMateria.Location = new System.Drawing.Point(153, 189);
            this.cboMateria.Name = "cboMateria";
            this.cboMateria.Size = new System.Drawing.Size(256, 21);
            this.cboMateria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Materias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año cursado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuatrimestre";
            // 
            // numCuatrimestre
            // 
            this.numCuatrimestre.Location = new System.Drawing.Point(153, 153);
            this.numCuatrimestre.Name = "numCuatrimestre";
            this.numCuatrimestre.Size = new System.Drawing.Size(110, 20);
            this.numCuatrimestre.TabIndex = 4;
            // 
            // txtCarrera
            // 
            this.txtCarrera.Location = new System.Drawing.Point(153, 47);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(256, 20);
            this.txtCarrera.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Carrera";
            // 
            // dgvDetalleCarrera
            // 
            this.dgvDetalleCarrera.AllowUserToAddRows = false;
            this.dgvDetalleCarrera.AllowUserToDeleteRows = false;
            this.dgvDetalleCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCarrera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna1,
            this.ColMateria,
            this.ColAnioCursado,
            this.ColCuatrimestre,
            this.ColBotones});
            this.dgvDetalleCarrera.Location = new System.Drawing.Point(47, 226);
            this.dgvDetalleCarrera.Name = "dgvDetalleCarrera";
            this.dgvDetalleCarrera.ReadOnly = true;
            this.dgvDetalleCarrera.Size = new System.Drawing.Size(444, 206);
            this.dgvDetalleCarrera.TabIndex = 8;
            this.dgvDetalleCarrera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleCarrera_CellContentClick);
            // 
            // Columna1
            // 
            this.Columna1.HeaderText = "Materia";
            this.Columna1.Name = "Columna1";
            this.Columna1.ReadOnly = true;
            this.Columna1.Visible = false;
            // 
            // ColMateria
            // 
            this.ColMateria.HeaderText = "Materia";
            this.ColMateria.Name = "ColMateria";
            this.ColMateria.ReadOnly = true;
            // 
            // ColAnioCursado
            // 
            this.ColAnioCursado.HeaderText = "Año Cursado";
            this.ColAnioCursado.Name = "ColAnioCursado";
            this.ColAnioCursado.ReadOnly = true;
            // 
            // ColCuatrimestre
            // 
            this.ColCuatrimestre.HeaderText = "Cuatrimestre";
            this.ColCuatrimestre.Name = "ColCuatrimestre";
            this.ColCuatrimestre.ReadOnly = true;
            // 
            // ColBotones
            // 
            this.ColBotones.HeaderText = "Acciones";
            this.ColBotones.Name = "ColBotones";
            this.ColBotones.ReadOnly = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(132, 441);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Titulo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(153, 84);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(256, 20);
            this.txtTitulo.TabIndex = 11;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(416, 189);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 21);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblProximaCarrera
            // 
            this.lblProximaCarrera.AutoSize = true;
            this.lblProximaCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProximaCarrera.Location = new System.Drawing.Point(46, 9);
            this.lblProximaCarrera.Name = "lblProximaCarrera";
            this.lblProximaCarrera.Size = new System.Drawing.Size(92, 20);
            this.lblProximaCarrera.TabIndex = 14;
            this.lblProximaCarrera.Text = "Carrera N°";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(334, 441);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtAnioCursado
            // 
            this.txtAnioCursado.Location = new System.Drawing.Point(153, 120);
            this.txtAnioCursado.Name = "txtAnioCursado";
            this.txtAnioCursado.Size = new System.Drawing.Size(110, 20);
            this.txtAnioCursado.TabIndex = 16;
            // 
            // FrmNuevoPlanDeEstudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 472);
            this.Controls.Add(this.txtAnioCursado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblProximaCarrera);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvDetalleCarrera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCarrera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numCuatrimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMateria);
            this.Name = "FrmNuevoPlanDeEstudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevoPlanDeEstudio";
            this.Load += new System.EventHandler(this.FrmNuevoPlanDeEstudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCuatrimestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCarrera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMateria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCuatrimestre;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDetalleCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnioCursado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCuatrimestre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewButtonColumn ColBotones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblProximaCarrera;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtAnioCursado;
    }
}

