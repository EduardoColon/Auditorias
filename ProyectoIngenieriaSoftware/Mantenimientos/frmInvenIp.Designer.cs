namespace ProyectoIngenieriaSoftware.Mantenimientos
{
    public partial class frmInvenIp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvenIp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimizar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Btn_ingresar = new System.Windows.Forms.Button();
            this.Btn_modificar = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.tc_Clientes = new System.Windows.Forms.TabControl();
            this.tp_datos = new System.Windows.Forms.TabPage();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.dgv_clientes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tp_abc = new System.Windows.Forms.TabPage();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtIpInalambrica = new System.Windows.Forms.TextBox();
            this.txtIpCableada = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.gpb_estado = new System.Windows.Forms.GroupBox();
            this.rdb_inactivo = new System.Windows.Forms.RadioButton();
            this.rdb_actio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tc_Clientes.SuspendLayout();
            this.tp_datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).BeginInit();
            this.tp_abc.SuspendLayout();
            this.gpb_estado.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btn_minimizar);
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 49);
            this.panel1.TabIndex = 201;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimizar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.Location = new System.Drawing.Point(926, 7);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.Size = new System.Drawing.Size(37, 37);
            this.btn_minimizar.TabIndex = 1;
            this.btn_minimizar.UseVisualStyleBackColor = false;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.Location = new System.Drawing.Point(969, 5);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(41, 41);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento de direcciones IP";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cancelar.FlatAppearance.BorderSize = 0;
            this.Btn_cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_cancelar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cancelar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_cancelar.Image")));
            this.Btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_cancelar.Location = new System.Drawing.Point(570, 16);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(129, 124);
            this.Btn_cancelar.TabIndex = 211;
            this.Btn_cancelar.Text = "CANCELAR";
            this.Btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Btn_ingresar
            // 
            this.Btn_ingresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ingresar.FlatAppearance.BorderSize = 0;
            this.Btn_ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Btn_ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_ingresar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ingresar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_ingresar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_ingresar.Image")));
            this.Btn_ingresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_ingresar.Location = new System.Drawing.Point(18, 16);
            this.Btn_ingresar.Name = "Btn_ingresar";
            this.Btn_ingresar.Size = new System.Drawing.Size(132, 124);
            this.Btn_ingresar.TabIndex = 210;
            this.Btn_ingresar.Text = "NUEVO";
            this.Btn_ingresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_ingresar.UseVisualStyleBackColor = false;
            this.Btn_ingresar.Click += new System.EventHandler(this.Btn_ingresar_Click);
            // 
            // Btn_modificar
            // 
            this.Btn_modificar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_modificar.FlatAppearance.BorderSize = 0;
            this.Btn_modificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Btn_modificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_modificar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_modificar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_modificar.Image")));
            this.Btn_modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_modificar.Location = new System.Drawing.Point(298, 16);
            this.Btn_modificar.Name = "Btn_modificar";
            this.Btn_modificar.Size = new System.Drawing.Size(127, 124);
            this.Btn_modificar.TabIndex = 209;
            this.Btn_modificar.Text = "MODIFICAR ";
            this.Btn_modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_modificar.UseVisualStyleBackColor = false;
            this.Btn_modificar.Click += new System.EventHandler(this.Btn_modificar_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_eliminar.FlatAppearance.BorderSize = 0;
            this.Btn_eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Btn_eliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_eliminar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_eliminar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_eliminar.Image")));
            this.Btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_eliminar.Location = new System.Drawing.Point(431, 16);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(133, 124);
            this.Btn_eliminar.TabIndex = 208;
            this.Btn_eliminar.Text = "ELIMINAR";
            this.Btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_guardar.FlatAppearance.BorderSize = 0;
            this.Btn_guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Btn_guardar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_guardar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_guardar.Image")));
            this.Btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_guardar.Location = new System.Drawing.Point(156, 16);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(136, 124);
            this.Btn_guardar.TabIndex = 207;
            this.Btn_guardar.Text = "GUARDAR";
            this.Btn_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // tc_Clientes
            // 
            this.tc_Clientes.Controls.Add(this.tp_datos);
            this.tc_Clientes.Controls.Add(this.tp_abc);
            this.tc_Clientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tc_Clientes.Location = new System.Drawing.Point(0, 250);
            this.tc_Clientes.Name = "tc_Clientes";
            this.tc_Clientes.SelectedIndex = 0;
            this.tc_Clientes.Size = new System.Drawing.Size(1014, 437);
            this.tc_Clientes.TabIndex = 212;
            // 
            // tp_datos
            // 
            this.tp_datos.Controls.Add(this.btn_buscar);
            this.tp_datos.Controls.Add(this.txt_buscar);
            this.tp_datos.Controls.Add(this.dgv_clientes);
            this.tp_datos.Location = new System.Drawing.Point(4, 29);
            this.tp_datos.Name = "tp_datos";
            this.tp_datos.Padding = new System.Windows.Forms.Padding(3);
            this.tp_datos.Size = new System.Drawing.Size(1006, 404);
            this.tp_datos.TabIndex = 0;
            this.tp_datos.Text = "Direcciones IP";
            this.tp_datos.UseVisualStyleBackColor = true;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.Location = new System.Drawing.Point(574, 16);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(122, 44);
            this.btn_buscar.TabIndex = 3;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(307, 25);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(250, 26);
            this.txt_buscar.TabIndex = 1;
            // 
            // dgv_clientes
            // 
            this.dgv_clientes.AllowUserToAddRows = false;
            this.dgv_clientes.AllowUserToDeleteRows = false;
            this.dgv_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column3});
            this.dgv_clientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_clientes.Location = new System.Drawing.Point(3, 86);
            this.dgv_clientes.Name = "dgv_clientes";
            this.dgv_clientes.ReadOnly = true;
            this.dgv_clientes.RowHeadersWidth = 62;
            this.dgv_clientes.Size = new System.Drawing.Size(1000, 315);
            this.dgv_clientes.TabIndex = 0;
            this.dgv_clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_clientes_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Codigo";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 95;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha compra";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 147;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ultima auditoria";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 155;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Empleado";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 117;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Proveedor";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 117;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Ip Cableada";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 131;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Ip inalambrica";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 143;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estado";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 96;
            // 
            // tp_abc
            // 
            this.tp_abc.Controls.Add(this.dtpFecha);
            this.tp_abc.Controls.Add(this.txtIpInalambrica);
            this.tp_abc.Controls.Add(this.txtIpCableada);
            this.tp_abc.Controls.Add(this.label5);
            this.tp_abc.Controls.Add(this.label10);
            this.tp_abc.Controls.Add(this.label7);
            this.tp_abc.Controls.Add(this.cboProveedor);
            this.tp_abc.Controls.Add(this.cboEmpleado);
            this.tp_abc.Controls.Add(this.label8);
            this.tp_abc.Controls.Add(this.txtCodigo);
            this.tp_abc.Controls.Add(this.gpb_estado);
            this.tp_abc.Controls.Add(this.label3);
            this.tp_abc.Controls.Add(this.label2);
            this.tp_abc.Location = new System.Drawing.Point(4, 29);
            this.tp_abc.Name = "tp_abc";
            this.tp_abc.Padding = new System.Windows.Forms.Padding(3);
            this.tp_abc.Size = new System.Drawing.Size(1006, 404);
            this.tp_abc.TabIndex = 1;
            this.tp_abc.Text = "Mantenimiento";
            this.tp_abc.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd-MM-yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(227, 64);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(216, 26);
            this.dtpFecha.TabIndex = 1;
            // 
            // txtIpInalambrica
            // 
            this.txtIpInalambrica.Location = new System.Drawing.Point(668, 67);
            this.txtIpInalambrica.Name = "txtIpInalambrica";
            this.txtIpInalambrica.Size = new System.Drawing.Size(216, 26);
            this.txtIpInalambrica.TabIndex = 5;
            // 
            // txtIpCableada
            // 
            this.txtIpCableada.Location = new System.Drawing.Point(668, 35);
            this.txtIpCableada.Name = "txtIpCableada";
            this.txtIpCableada.Size = new System.Drawing.Size(216, 26);
            this.txtIpCableada.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "IP Cableada:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "IP Inalambrica:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Proveedor mantenimiento:";
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(227, 130);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(216, 28);
            this.cboProveedor.TabIndex = 3;
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(227, 96);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(216, 28);
            this.cboEmpleado.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Empleado asignado:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(227, 32);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(216, 26);
            this.txtCodigo.TabIndex = 6;
            // 
            // gpb_estado
            // 
            this.gpb_estado.Controls.Add(this.rdb_inactivo);
            this.gpb_estado.Controls.Add(this.rdb_actio);
            this.gpb_estado.Location = new System.Drawing.Point(327, 286);
            this.gpb_estado.Name = "gpb_estado";
            this.gpb_estado.Size = new System.Drawing.Size(369, 57);
            this.gpb_estado.TabIndex = 5;
            this.gpb_estado.TabStop = false;
            this.gpb_estado.Text = "Estado";
            // 
            // rdb_inactivo
            // 
            this.rdb_inactivo.AutoSize = true;
            this.rdb_inactivo.Location = new System.Drawing.Point(180, 30);
            this.rdb_inactivo.Name = "rdb_inactivo";
            this.rdb_inactivo.Size = new System.Drawing.Size(89, 24);
            this.rdb_inactivo.TabIndex = 1;
            this.rdb_inactivo.TabStop = true;
            this.rdb_inactivo.Text = "Inactivo";
            this.rdb_inactivo.UseVisualStyleBackColor = true;
            // 
            // rdb_actio
            // 
            this.rdb_actio.AutoSize = true;
            this.rdb_actio.Location = new System.Drawing.Point(88, 30);
            this.rdb_actio.Name = "rdb_actio";
            this.rdb_actio.Size = new System.Drawing.Size(77, 24);
            this.rdb_actio.TabIndex = 0;
            this.rdb_actio.TabStop = true;
            this.rdb_actio.Text = "Activo";
            this.rdb_actio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha compra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codigo:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Btn_ingresar);
            this.panel2.Controls.Add(this.Btn_guardar);
            this.panel2.Controls.Add(this.Btn_cancelar);
            this.panel2.Controls.Add(this.Btn_eliminar);
            this.panel2.Controls.Add(this.Btn_modificar);
            this.panel2.Location = new System.Drawing.Point(135, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 158);
            this.panel2.TabIndex = 213;
            // 
            // frmInvenIp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 687);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tc_Clientes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInvenIp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMantenimientoEmpleado";
            this.Load += new System.EventHandler(this.frmInvenIp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tc_Clientes.ResumeLayout(false);
            this.tp_datos.ResumeLayout(false);
            this.tp_datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clientes)).EndInit();
            this.tp_abc.ResumeLayout(false);
            this.tp_abc.PerformLayout();
            this.gpb_estado.ResumeLayout(false);
            this.gpb_estado.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_minimizar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Btn_cancelar;
        public System.Windows.Forms.Button Btn_ingresar;
        public System.Windows.Forms.Button Btn_modificar;
        public System.Windows.Forms.Button Btn_eliminar;
        public System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.TabControl tc_Clientes;
        private System.Windows.Forms.TabPage tp_datos;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.DataGridView dgv_clientes;
        private System.Windows.Forms.TabPage tp_abc;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox gpb_estado;
        private System.Windows.Forms.RadioButton rdb_inactivo;
        private System.Windows.Forms.RadioButton rdb_actio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIpInalambrica;
        private System.Windows.Forms.TextBox txtIpCableada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}