namespace ProyectoIngenieriaSoftware.Reportes
{
    partial class frmDashboard
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pcAuditoriasPlanificadas = new LiveCharts.WinForms.PieChart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pcNumActivos = new LiveCharts.WinForms.PieChart();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.asdasd = new System.Windows.Forms.Label();
            this.pcAuditoriasRealizadas = new LiveCharts.WinForms.PieChart();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pcEmpleadosArea = new LiveCharts.WinForms.PieChart();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pcEmpleadosPuntoVenta = new LiveCharts.WinForms.PieChart();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pcActivosPuntoVenta = new LiveCharts.WinForms.PieChart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pcMantenimientosArea = new LiveCharts.WinForms.PieChart();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pcMantenimientosPuntoVenta = new LiveCharts.WinForms.PieChart();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.pcAuditoriasPlanificadas);
            this.panel4.Location = new System.Drawing.Point(90, 1273);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(865, 518);
            this.panel4.TabIndex = 222;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(25, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(482, 29);
            this.label5.TabIndex = 219;
            this.label5.Text = "Auditorias planificadas pendientes por area:";
            // 
            // pcAuditoriasPlanificadas
            // 
            this.pcAuditoriasPlanificadas.Location = new System.Drawing.Point(-1, 79);
            this.pcAuditoriasPlanificadas.Name = "pcAuditoriasPlanificadas";
            this.pcAuditoriasPlanificadas.Size = new System.Drawing.Size(861, 438);
            this.pcAuditoriasPlanificadas.TabIndex = 218;
            this.pcAuditoriasPlanificadas.Text = "pieChart1";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.pcNumActivos);
            this.panel3.Location = new System.Drawing.Point(90, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(865, 518);
            this.panel3.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(25, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 29);
            this.label4.TabIndex = 219;
            this.label4.Text = "Activos por area (equipo):";
            // 
            // pcNumActivos
            // 
            this.pcNumActivos.Location = new System.Drawing.Point(-1, 79);
            this.pcNumActivos.Name = "pcNumActivos";
            this.pcNumActivos.Size = new System.Drawing.Size(861, 438);
            this.pcNumActivos.TabIndex = 218;
            this.pcNumActivos.Text = "pieChart1";
            this.pcNumActivos.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pcNumActivos_ChildChanged);
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpFinal.Location = new System.Drawing.Point(920, 16);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(506, 35);
            this.dtpFinal.TabIndex = 213;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(758, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 29);
            this.label3.TabIndex = 212;
            this.label3.Text = "Fecha final:";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpInicial.Location = new System.Drawing.Point(217, 15);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(506, 35);
            this.dtpInicial.TabIndex = 211;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(32, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 29);
            this.label2.TabIndex = 210;
            this.label2.Text = "Fecha inicial:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.asdasd);
            this.panel1.Controls.Add(this.pcAuditoriasRealizadas);
            this.panel1.Location = new System.Drawing.Point(90, 1844);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 518);
            this.panel1.TabIndex = 223;
            // 
            // asdasd
            // 
            this.asdasd.AutoSize = true;
            this.asdasd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.asdasd.Location = new System.Drawing.Point(25, 18);
            this.asdasd.Name = "asdasd";
            this.asdasd.Size = new System.Drawing.Size(338, 29);
            this.asdasd.TabIndex = 219;
            this.asdasd.Text = "Auditorias realizadas por area:";
            // 
            // pcAuditoriasRealizadas
            // 
            this.pcAuditoriasRealizadas.Location = new System.Drawing.Point(-1, 79);
            this.pcAuditoriasRealizadas.Name = "pcAuditoriasRealizadas";
            this.pcAuditoriasRealizadas.Size = new System.Drawing.Size(861, 438);
            this.pcAuditoriasRealizadas.TabIndex = 218;
            this.pcAuditoriasRealizadas.Text = "pieChart1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(1542, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 46);
            this.button1.TabIndex = 224;
            this.button1.Text = "Actualizar graficas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.ClientSizeChanged += new System.EventHandler(this.button1_ClientSizeChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(986, 2323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 132);
            this.panel2.TabIndex = 225;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dtpInicial);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.dtpFinal);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(90, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1796, 79);
            this.panel5.TabIndex = 226;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.pcEmpleadosArea);
            this.panel6.Location = new System.Drawing.Point(1021, 137);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(865, 518);
            this.panel6.TabIndex = 227;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 29);
            this.label1.TabIndex = 219;
            this.label1.Text = "Empleados por area:";
            // 
            // pcEmpleadosArea
            // 
            this.pcEmpleadosArea.Location = new System.Drawing.Point(-1, 79);
            this.pcEmpleadosArea.Name = "pcEmpleadosArea";
            this.pcEmpleadosArea.Size = new System.Drawing.Size(861, 438);
            this.pcEmpleadosArea.TabIndex = 218;
            this.pcEmpleadosArea.Text = "pieChart1";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.pcEmpleadosPuntoVenta);
            this.panel7.Location = new System.Drawing.Point(1021, 702);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(865, 518);
            this.panel7.TabIndex = 228;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 29);
            this.label6.TabIndex = 219;
            this.label6.Text = "Empleados por punto de venta:";
            // 
            // pcEmpleadosPuntoVenta
            // 
            this.pcEmpleadosPuntoVenta.Location = new System.Drawing.Point(-1, 79);
            this.pcEmpleadosPuntoVenta.Name = "pcEmpleadosPuntoVenta";
            this.pcEmpleadosPuntoVenta.Size = new System.Drawing.Size(861, 438);
            this.pcEmpleadosPuntoVenta.TabIndex = 218;
            this.pcEmpleadosPuntoVenta.Text = "pieChart1";
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.pcActivosPuntoVenta);
            this.panel8.Location = new System.Drawing.Point(90, 702);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(865, 518);
            this.panel8.TabIndex = 229;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(25, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 29);
            this.label7.TabIndex = 219;
            this.label7.Text = "Activos por punto de venta";
            // 
            // pcActivosPuntoVenta
            // 
            this.pcActivosPuntoVenta.Location = new System.Drawing.Point(-1, 79);
            this.pcActivosPuntoVenta.Name = "pcActivosPuntoVenta";
            this.pcActivosPuntoVenta.Size = new System.Drawing.Size(861, 438);
            this.pcActivosPuntoVenta.TabIndex = 218;
            this.pcActivosPuntoVenta.Text = "pieChart1";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.pcMantenimientosArea);
            this.panel9.Location = new System.Drawing.Point(1021, 1273);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(865, 518);
            this.panel9.TabIndex = 230;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(25, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(558, 29);
            this.label8.TabIndex = 219;
            this.label8.Text = "Mantenimientos a activos llevados a cabo por area:";
            // 
            // pcMantenimientosArea
            // 
            this.pcMantenimientosArea.Location = new System.Drawing.Point(-1, 79);
            this.pcMantenimientosArea.Name = "pcMantenimientosArea";
            this.pcMantenimientosArea.Size = new System.Drawing.Size(861, 438);
            this.pcMantenimientosArea.TabIndex = 218;
            this.pcMantenimientosArea.Text = "pieChart1";
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.pcMantenimientosPuntoVenta);
            this.panel10.Location = new System.Drawing.Point(1021, 1844);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(865, 518);
            this.panel10.TabIndex = 231;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(25, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(667, 29);
            this.label9.TabIndex = 219;
            this.label9.Text = "Mantenimientos a activos llevados a cabo por punto de venta:";
            // 
            // pcMantenimientosPuntoVenta
            // 
            this.pcMantenimientosPuntoVenta.Location = new System.Drawing.Point(-1, 79);
            this.pcMantenimientosPuntoVenta.Name = "pcMantenimientosPuntoVenta";
            this.pcMantenimientosPuntoVenta.Size = new System.Drawing.Size(861, 438);
            this.pcMantenimientosPuntoVenta.TabIndex = 218;
            this.pcMantenimientosPuntoVenta.Text = "pieChart1";
            // 
            // frmDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private LiveCharts.WinForms.PieChart pcNumActivos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private LiveCharts.WinForms.PieChart pcAuditoriasPlanificadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label asdasd;
        private LiveCharts.WinForms.PieChart pcAuditoriasRealizadas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.PieChart pcEmpleadosArea;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private LiveCharts.WinForms.PieChart pcEmpleadosPuntoVenta;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private LiveCharts.WinForms.PieChart pcActivosPuntoVenta;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private LiveCharts.WinForms.PieChart pcMantenimientosArea;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label9;
        private LiveCharts.WinForms.PieChart pcMantenimientosPuntoVenta;
    }
}