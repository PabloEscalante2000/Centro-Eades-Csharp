namespace CentroEades_GUI
{
    partial class ProfesionalMan01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfesionalMan01));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dtgProfesionales = new System.Windows.Forms.DataGridView();
            this.Cod_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ape_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sue_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fech_ing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Antiguedad_Años = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese Apellidos del Profesional :";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(230, 16);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(261, 23);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // dtgProfesionales
            // 
            this.dtgProfesionales.AllowUserToAddRows = false;
            this.dtgProfesionales.AllowUserToDeleteRows = false;
            this.dtgProfesionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgProfesionales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_pro,
            this.Nom_pro,
            this.Ape_pro,
            this.Sue_pro,
            this.Fech_ing,
            this.Antiguedad_Años,
            this.Email_pro,
            this.Estado});
            this.dtgProfesionales.Location = new System.Drawing.Point(12, 54);
            this.dtgProfesionales.Name = "dtgProfesionales";
            this.dtgProfesionales.ReadOnly = true;
            this.dtgProfesionales.RowHeadersVisible = false;
            this.dtgProfesionales.RowTemplate.Height = 25;
            this.dtgProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProfesionales.Size = new System.Drawing.Size(1260, 386);
            this.dtgProfesionales.TabIndex = 2;
            // 
            // Cod_pro
            // 
            this.Cod_pro.DataPropertyName = "Cod_pro";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cod_pro.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cod_pro.HeaderText = "Codigo";
            this.Cod_pro.Name = "Cod_pro";
            this.Cod_pro.ReadOnly = true;
            // 
            // Nom_pro
            // 
            this.Nom_pro.DataPropertyName = "Nom_pro";
            this.Nom_pro.HeaderText = "Nombre";
            this.Nom_pro.Name = "Nom_pro";
            this.Nom_pro.ReadOnly = true;
            // 
            // Ape_pro
            // 
            this.Ape_pro.DataPropertyName = "Ape_pro";
            this.Ape_pro.HeaderText = "Apellidos";
            this.Ape_pro.Name = "Ape_pro";
            this.Ape_pro.ReadOnly = true;
            // 
            // Sue_pro
            // 
            this.Sue_pro.DataPropertyName = "Sue_pro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Sue_pro.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sue_pro.HeaderText = "Sueldo";
            this.Sue_pro.Name = "Sue_pro";
            this.Sue_pro.ReadOnly = true;
            // 
            // Fech_ing
            // 
            this.Fech_ing.DataPropertyName = "Fech_ing";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.Fech_ing.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fech_ing.HeaderText = "Fecha Ingreso";
            this.Fech_ing.Name = "Fech_ing";
            this.Fech_ing.ReadOnly = true;
            // 
            // Antiguedad_Años
            // 
            this.Antiguedad_Años.DataPropertyName = "Antiguedad_Años";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Antiguedad_Años.DefaultCellStyle = dataGridViewCellStyle4;
            this.Antiguedad_Años.HeaderText = "Antiguedad en Años";
            this.Antiguedad_Años.Name = "Antiguedad_Años";
            this.Antiguedad_Años.ReadOnly = true;
            // 
            // Email_pro
            // 
            this.Email_pro.DataPropertyName = "Email_pro";
            this.Email_pro.HeaderText = "Email";
            this.Email_pro.Name = "Email_pro";
            this.Email_pro.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Estado.DefaultCellStyle = dataGridViewCellStyle5;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRegistros.Location = new System.Drawing.Point(1207, 450);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(64, 26);
            this.lblRegistros.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1123, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Registros : ";
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertar.Location = new System.Drawing.Point(859, 492);
            this.btnInsertar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(88, 27);
            this.btnInsertar.TabIndex = 5;
            this.btnInsertar.Text = "Agregar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(1186, 492);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 27);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(968, 492);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 27);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(1078, 492);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 27);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ProfesionalMan01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 531);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgProfesionales);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfesionalMan01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Profesionales";
            this.Load += new System.EventHandler(this.ProfesionalMan01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtFiltro;
        private DataGridView dtgProfesionales;
        private Label lblRegistros;
        private Label label3;
        private Button btnInsertar;
        private Button btnSalir;
        private Button btnActualizar;
        private Button btnEliminar;
        private DataGridViewTextBoxColumn Cod_pro;
        private DataGridViewTextBoxColumn Nom_pro;
        private DataGridViewTextBoxColumn Ape_pro;
        private DataGridViewTextBoxColumn Sue_pro;
        private DataGridViewTextBoxColumn Fech_ing;
        private DataGridViewTextBoxColumn Antiguedad_Años;
        private DataGridViewTextBoxColumn Email_pro;
        private DataGridViewTextBoxColumn Estado;
    }
}