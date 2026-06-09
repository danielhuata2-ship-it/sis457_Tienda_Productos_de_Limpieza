namespace CpProLimp
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCiCliente = new System.Windows.Forms.TextBox();
            this.lblClienteTexto = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblComprasCliente = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblInfoVenta = new System.Windows.Forms.Label();
            this.lblEmpleadoTexto = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblUsuarioTexto = new System.Windows.Forms.Label();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaTexto = new System.Windows.Forms.Label();
            this.lblListaProductos = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDetalleVenta = new System.Windows.Forms.Label();
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnMenos = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnMas = new System.Windows.Forms.Button();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblDescuentoTexto = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblDescuentoMonto = new System.Windows.Forms.Label();
            this.lblDescuentoMontoTexto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalTexto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(5, -1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1531, 63);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Registro de Ventas - ProLimp";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(648, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nueva venta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cliente";
            // 
            // txtCiCliente
            // 
            this.txtCiCliente.Location = new System.Drawing.Point(141, 120);
            this.txtCiCliente.Multiline = true;
            this.txtCiCliente.Name = "txtCiCliente";
            this.txtCiCliente.Size = new System.Drawing.Size(165, 27);
            this.txtCiCliente.TabIndex = 36;
            // 
            // lblClienteTexto
            // 
            this.lblClienteTexto.AutoSize = true;
            this.lblClienteTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteTexto.Location = new System.Drawing.Point(13, 122);
            this.lblClienteTexto.Name = "lblClienteTexto";
            this.lblClienteTexto.Size = new System.Drawing.Size(122, 20);
            this.lblClienteTexto.TabIndex = 34;
            this.lblClienteTexto.Text = "CI del Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.ForeColor = System.Drawing.Color.Green;
            this.lblCliente.Location = new System.Drawing.Point(17, 150);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(240, 27);
            this.lblCliente.TabIndex = 38;
            this.lblCliente.Text = "Cliente no seleccionado";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComprasCliente
            // 
            this.lblComprasCliente.AutoSize = true;
            this.lblComprasCliente.Location = new System.Drawing.Point(14, 184);
            this.lblComprasCliente.Name = "lblComprasCliente";
            this.lblComprasCliente.Size = new System.Drawing.Size(172, 18);
            this.lblComprasCliente.TabIndex = 39;
            this.lblComprasCliente.Text = "Compras Realizadas: 0";
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.AutoSize = true;
            this.lblTipoCliente.ForeColor = System.Drawing.Color.DimGray;
            this.lblTipoCliente.Location = new System.Drawing.Point(14, 211);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(122, 18);
            this.lblTipoCliente.TabIndex = 40;
            this.lblTipoCliente.Text = "Cliente estándar";
            // 
            // lblInfoVenta
            // 
            this.lblInfoVenta.AutoSize = true;
            this.lblInfoVenta.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoVenta.Location = new System.Drawing.Point(1232, 87);
            this.lblInfoVenta.Name = "lblInfoVenta";
            this.lblInfoVenta.Size = new System.Drawing.Size(206, 22);
            this.lblInfoVenta.TabIndex = 41;
            this.lblInfoVenta.Text = "Información de Venta";
            // 
            // lblEmpleadoTexto
            // 
            this.lblEmpleadoTexto.AutoSize = true;
            this.lblEmpleadoTexto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleadoTexto.Location = new System.Drawing.Point(1189, 124);
            this.lblEmpleadoTexto.Name = "lblEmpleadoTexto";
            this.lblEmpleadoTexto.Size = new System.Drawing.Size(92, 19);
            this.lblEmpleadoTexto.TabIndex = 42;
            this.lblEmpleadoTexto.Text = "Empleado:";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(1287, 124);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(138, 18);
            this.lblEmpleado.TabIndex = 43;
            this.lblEmpleado.Text = "Nombre empleado";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(1287, 151);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 18);
            this.lblUsuario.TabIndex = 45;
            this.lblUsuario.Text = "usuario";
            // 
            // lblUsuarioTexto
            // 
            this.lblUsuarioTexto.AutoSize = true;
            this.lblUsuarioTexto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioTexto.Location = new System.Drawing.Point(1189, 151);
            this.lblUsuarioTexto.Name = "lblUsuarioTexto";
            this.lblUsuarioTexto.Size = new System.Drawing.Size(75, 19);
            this.lblUsuarioTexto.TabIndex = 44;
            this.lblUsuarioTexto.Text = "Usuario:";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVenta.Location = new System.Drawing.Point(1290, 175);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(183, 26);
            this.dtpFechaVenta.TabIndex = 47;
            // 
            // lblFechaTexto
            // 
            this.lblFechaTexto.AutoSize = true;
            this.lblFechaTexto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTexto.Location = new System.Drawing.Point(1189, 180);
            this.lblFechaTexto.Name = "lblFechaTexto";
            this.lblFechaTexto.Size = new System.Drawing.Size(66, 19);
            this.lblFechaTexto.TabIndex = 46;
            this.lblFechaTexto.Text = "Fecha: ";
            // 
            // lblListaProductos
            // 
            this.lblListaProductos.AutoSize = true;
            this.lblListaProductos.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaProductos.Location = new System.Drawing.Point(12, 258);
            this.lblListaProductos.Name = "lblListaProductos";
            this.lblListaProductos.Size = new System.Drawing.Size(185, 22);
            this.lblListaProductos.TabIndex = 48;
            this.lblListaProductos.Text = "Lista de Productos";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(164, 289);
            this.txtParametro.Multiline = true;
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(191, 27);
            this.txtParametro.TabIndex = 50;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.AutoSize = true;
            this.lblBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarProducto.Location = new System.Drawing.Point(12, 291);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(146, 20);
            this.lblBuscarProducto.TabIndex = 49;
            this.lblBuscarProducto.Text = "Buscar producto:";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(11, 331);
            this.dgvLista.MultiSelect = false;
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 51;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(689, 375);
            this.dgvLista.TabIndex = 52;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::CpProLimp.Properties.Resources.carrito_de_compras;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.Location = new System.Drawing.Point(706, 529);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgregar.Size = new System.Drawing.Size(96, 82);
            this.btnAgregar.TabIndex = 53;
            this.btnAgregar.Text = "Agregar al carrito";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::CpProLimp.Properties.Resources.buscar;
            this.btnBuscar.Location = new System.Drawing.Point(361, 278);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(48, 47);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.Image = global::CpProLimp.Properties.Resources.buscar;
            this.btnBuscarCliente.Location = new System.Drawing.Point(312, 109);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscarCliente.Size = new System.Drawing.Size(48, 47);
            this.btnBuscarCliente.TabIndex = 37;
            this.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Image = global::CpProLimp.Properties.Resources.anadir;
            this.btnNuevoCliente.Location = new System.Drawing.Point(366, 109);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(53, 47);
            this.btnNuevoCliente.TabIndex = 35;
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = global::CpProLimp.Properties.Resources.Pro_Limp1_Photoroom;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblDetalleVenta
            // 
            this.lblDetalleVenta.AutoSize = true;
            this.lblDetalleVenta.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVenta.Location = new System.Drawing.Point(1070, 292);
            this.lblDetalleVenta.Name = "lblDetalleVenta";
            this.lblDetalleVenta.Size = new System.Drawing.Size(178, 24);
            this.lblDetalleVenta.TabIndex = 54;
            this.lblDetalleVenta.Text = "Detalle de Venta:";
            // 
            // dgvVenta
            // 
            this.dgvVenta.AllowUserToAddRows = false;
            this.dgvVenta.AllowUserToDeleteRows = false;
            this.dgvVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta.Location = new System.Drawing.Point(804, 331);
            this.dgvVenta.MultiSelect = false;
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.RowHeadersWidth = 51;
            this.dgvVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenta.Size = new System.Drawing.Size(670, 375);
            this.dgvVenta.TabIndex = 55;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(712, 472);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(86, 20);
            this.lblCantidad.TabIndex = 59;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // btnMenos
            // 
            this.btnMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenos.Location = new System.Drawing.Point(1480, 548);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(46, 46);
            this.btnMenos.TabIndex = 57;
            this.btnMenos.Text = "-";
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(713, 497);
            this.nudCantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(82, 26);
            this.nudCantidad.TabIndex = 58;
            // 
            // btnMas
            // 
            this.btnMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMas.Location = new System.Drawing.Point(1480, 487);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(46, 46);
            this.btnMas.TabIndex = 56;
            this.btnMas.Text = "+";
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.AutoSize = true;
            this.lblTotalTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTexto.Location = new System.Drawing.Point(1189, 252);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(92, 25);
            this.lblTotalTexto.TabIndex = 60;
            this.lblTotalTexto.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1340, 252);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 25);
            this.lblTotal.TabIndex = 61;
            this.lblTotal.Text = "0.00";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.btnRegistrar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnBorrar);
            this.pnlAcciones.Location = new System.Drawing.Point(867, 712);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(539, 51);
            this.pnlAcciones.TabIndex = 62;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Image = global::CpProLimp.Properties.Resources.cajero_automatico;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(273, 3);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRegistrar.Size = new System.Drawing.Size(117, 45);
            this.btnRegistrar.TabIndex = 10;
            this.btnRegistrar.Text = "Registrar Venta";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::CpProLimp.Properties.Resources.cerrar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(408, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancelar.Size = new System.Drawing.Size(115, 45);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::CpProLimp.Properties.Resources.escoba;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(155, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiar.Size = new System.Drawing.Size(97, 45);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Image = global::CpProLimp.Properties.Resources.bote_de_basura;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(16, 3);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBorrar.Size = new System.Drawing.Size(118, 45);
            this.btnBorrar.TabIndex = 7;
            this.btnBorrar.Text = "Borrar Producto";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblDescuentoTexto
            // 
            this.lblDescuentoTexto.AutoSize = true;
            this.lblDescuentoTexto.Location = new System.Drawing.Point(14, 236);
            this.lblDescuentoTexto.Name = "lblDescuentoTexto";
            this.lblDescuentoTexto.Size = new System.Drawing.Size(91, 18);
            this.lblDescuentoTexto.TabIndex = 63;
            this.lblDescuentoTexto.Text = "Descuento: ";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(107, 236);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(31, 18);
            this.lblDescuento.TabIndex = 64;
            this.lblDescuento.Text = "0%";
            // 
            // lblDescuentoMonto
            // 
            this.lblDescuentoMonto.AutoSize = true;
            this.lblDescuentoMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoMonto.Location = new System.Drawing.Point(1330, 228);
            this.lblDescuentoMonto.Name = "lblDescuentoMonto";
            this.lblDescuentoMonto.Size = new System.Drawing.Size(45, 24);
            this.lblDescuentoMonto.TabIndex = 66;
            this.lblDescuentoMonto.Text = "0.00";
            // 
            // lblDescuentoMontoTexto
            // 
            this.lblDescuentoMontoTexto.AutoSize = true;
            this.lblDescuentoMontoTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentoMontoTexto.Location = new System.Drawing.Point(1215, 228);
            this.lblDescuentoMontoTexto.Name = "lblDescuentoMontoTexto";
            this.lblDescuentoMontoTexto.Size = new System.Drawing.Size(106, 24);
            this.lblDescuentoMontoTexto.TabIndex = 65;
            this.lblDescuentoMontoTexto.Text = "Descuento:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(1331, 204);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(45, 24);
            this.lblSubtotal.TabIndex = 68;
            this.lblSubtotal.Text = "0.00";
            // 
            // lblSubtotalTexto
            // 
            this.lblSubtotalTexto.AutoSize = true;
            this.lblSubtotalTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalTexto.Location = new System.Drawing.Point(1216, 204);
            this.lblSubtotalTexto.Name = "lblSubtotalTexto";
            this.lblSubtotalTexto.Size = new System.Drawing.Size(82, 24);
            this.lblSubtotalTexto.TabIndex = 67;
            this.lblSubtotalTexto.Text = "Subtotal:";
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1529, 766);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblSubtotalTexto);
            this.Controls.Add(this.lblDescuentoMonto);
            this.Controls.Add(this.lblDescuentoMontoTexto);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblDescuentoTexto);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalTexto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.dgvVenta);
            this.Controls.Add(this.lblDetalleVenta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.lblBuscarProducto);
            this.Controls.Add(this.lblListaProductos);
            this.Controls.Add(this.dtpFechaVenta);
            this.Controls.Add(this.lblFechaTexto);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblUsuarioTexto);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.lblEmpleadoTexto);
            this.Controls.Add(this.lblInfoVenta);
            this.Controls.Add(this.lblTipoCliente);
            this.Controls.Add(this.lblComprasCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtCiCliente);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.lblClienteTexto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Ventas - Pro-Limp :::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtCiCliente;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Label lblClienteTexto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblComprasCliente;
        private System.Windows.Forms.Label lblTipoCliente;
        private System.Windows.Forms.Label lblInfoVenta;
        private System.Windows.Forms.Label lblEmpleadoTexto;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblUsuarioTexto;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.Label lblFechaTexto;
        private System.Windows.Forms.Label lblListaProductos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDetalleVenta;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblDescuentoTexto;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblDescuentoMonto;
        private System.Windows.Forms.Label lblDescuentoMontoTexto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalTexto;
    }
}