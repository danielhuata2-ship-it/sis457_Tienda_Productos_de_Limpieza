using CadProLimp;
using ClnProLimp;
using cpProLimp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CpProLimp
{
    public partial class FrmVentas : Form
    {
        public class ItemVenta
        {
            public int idProducto { get; set; }
            public string nombre { get; set; }
            public decimal precioUnitario { get; set; }
            public decimal cantidad { get; set; }
            public decimal subtotal { get; set; }
        }
        List<ItemVenta> detalle = new List<ItemVenta>();

        private int idClienteSeleccionado = 0;

        private decimal porcentajeDescuento = 0;



        public FrmVentas()
        {
            InitializeComponent();
        }
        private void listarProductos()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());

            dgvLista.DataSource = lista;

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["idunidadMedida"].Visible = false;
            dgvLista.Columns["idproveedor"].Visible = false;
            dgvLista.Columns["idcategoria"].Visible = false;
            dgvLista.Columns["idmarca"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["categoria"].Visible = false;
            dgvLista.Columns["unidadMedida"].Visible = false;
            dgvLista.Columns["fechaVencimiento"].Visible = false;
            dgvLista.Columns["precioCompra"].Visible = false;
            dgvLista.Columns["cantidadMinimaStock"].Visible = false;
            dgvLista.Columns["proveedor"].Visible = false;
            dgvLista.Columns["usuarioRegistro"].Visible = false;
            dgvLista.Columns["fechaRegistro"].Visible = false;
            dgvLista.Columns["marca"].Visible = false;
            dgvLista.Columns["codigo"].HeaderText = "Código";
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["stock"].HeaderText = "Stock";
            dgvLista.Columns["precioVenta"].HeaderText = "Precio Unitario";
        }

        private void calcularTotal()
        {
            decimal subtotal = detalle.Sum(x => x.subtotal);

            decimal montoDescuento = subtotal * porcentajeDescuento / 100;

            decimal total = subtotal - montoDescuento;

            lblSubtotal.Text = subtotal.ToString("0.00");

            lblDescuentoMonto.Text = montoDescuento.ToString("0.00");

            lblTotal.Text = total.ToString("0.00");
        }

        private void refrescarDetalle()
        {
            dgvVenta.DataSource = null;
            dgvVenta.DataSource = detalle;

            dgvVenta.Columns["idProducto"].Visible = false;

            dgvVenta.Columns["nombre"].HeaderText = "Producto";
            dgvVenta.Columns["precioUnitario"].HeaderText = "Precio";
            dgvVenta.Columns["cantidad"].HeaderText = "Cantidad";
            dgvVenta.Columns["subtotal"].HeaderText = "Subtotal";

            calcularTotal();
        }


        private int obtenerIdClientePorCI(string ci)
        {
            porcentajeDescuento = 0;

            lblDescuento.Text = "0%";
            lblComprasCliente.Text = "Compras realizadas: 0";
            lblTipoCliente.Text = "Cliente estándar";

            if (string.IsNullOrWhiteSpace(ci))
                return -1;

            var lista = ClienteCln.listarPa("");

            var cliente = lista.FirstOrDefault(x => x.cedulaIdentidad.Trim() == ci.Trim());

            if (cliente != null)
            {
                if (cliente.cedulaIdentidad == "0")
                {
                    lblCliente.Text = cliente.razonSocial;
                    lblCliente.ForeColor = Color.Green;

                    lblComprasCliente.Text = "-";

                    lblTipoCliente.Text = "Consumidor Final";
                    lblTipoCliente.ForeColor = Color.Blue;

                    porcentajeDescuento = 0;
                    lblDescuento.Text = "0%";

                    calcularTotal();

                    return cliente.id;
                }
                lblCliente.Text = cliente.razonSocial;
                lblCliente.ForeColor = Color.Green;

                int compras = VentaCln.ContarComprasCliente(cliente.id);

                lblComprasCliente.Text = $"Compras realizadas: {compras}";

                if (compras >= 5)
                {
                    lblTipoCliente.Text = "⭐️ Cliente Frecuente";

                    lblTipoCliente.ForeColor = Color.DarkGreen;

                    porcentajeDescuento = 5;
                    lblDescuento.Text = "5%";
                }
                else
                {
                    lblTipoCliente.Text = "Cliente Estándar";

                    lblTipoCliente.ForeColor =Color.Black;

                    porcentajeDescuento = 0;
                    lblDescuento.Text = "0%";
                }

                return cliente.id;
            }

            lblCliente.Text = "Cliente no encontrado";
            lblCliente.ForeColor = Color.Red;

            return -1;
        }


        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblEmpleado.Text = Util.empleado.nombres + " " + Util.empleado.primerApellido;
            lblUsuario.Text = Util.empleado.usuario;
            dtpFechaVenta.Value = DateTime.Now;
            dtpFechaVenta.Enabled = false;

            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;

            listarProductos();
        }



        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCiCliente.Text))
            {
                MessageBox.Show(
                    "Ingrese el CI del cliente.",
                    "ProLimp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            idClienteSeleccionado = obtenerIdClientePorCI(txtCiCliente.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un producto.",
                    "ProLimp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idProd = Convert.ToInt32(
                dgvLista.CurrentRow.Cells["id"].Value);

            string nombre =
                dgvLista.CurrentRow.Cells["nombre"].Value.ToString();

            decimal precio = Convert.ToDecimal(dgvLista.CurrentRow.Cells["precioVenta"].Value);

            decimal cantidad = nudCantidad.Value;

            int stock = Convert.ToInt32(dgvLista.CurrentRow.Cells["stock"].Value);

            var existente = detalle.FirstOrDefault(x => x.idProducto == idProd);

            if (existente != null)
            {
                if (existente.cantidad + cantidad > stock)
                {
                    MessageBox.Show(
                        $"Stock insuficiente.\nStock disponible: {stock}",
                        "ProLimp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                existente.cantidad += cantidad;

                existente.subtotal = existente.cantidad * existente.precioUnitario;
            }
            else
            {
                if (cantidad > stock)
                {
                    MessageBox.Show(
                        $"Stock insuficiente.\nStock disponible: {stock}",
                        "ProLimp",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ItemVenta item = new ItemVenta
                {
                    idProducto = idProd,
                    nombre = nombre,
                    precioUnitario = precio,
                    cantidad = cantidad,
                    subtotal = precio * cantidad
                };

                detalle.Add(item);
            }
            refrescarDetalle();

            nudCantidad.Value = 1;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            new FrmClientes().ShowDialog();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if (dgvVenta.CurrentRow == null)
                return;

            int idProducto = Convert.ToInt32(dgvVenta.CurrentRow.Cells["idProducto"].Value);

            var item = detalle.FirstOrDefault(x => x.idProducto == idProducto);

            if (item != null)
            {
                var filaProducto = dgvLista.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => Convert.ToInt32(r.Cells["id"].Value) == idProducto);

                if (filaProducto != null)
                {
                    int stock = Convert.ToInt32(filaProducto.Cells["stock"].Value);

                    if (item.cantidad + 1 > stock)
                    {
                        MessageBox.Show($"Stock insuficiente.\nStock disponible: {stock}", "ProLimp",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                item.cantidad++;

                item.subtotal = item.cantidad * item.precioUnitario;

                refrescarDetalle();

                foreach (DataGridViewRow fila in dgvVenta.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["idProducto"].Value)
                        == idProducto)
                    {
                        fila.Selected = true;
                        dgvVenta.CurrentCell = fila.Cells["nombre"];
                        break;
                    }
                }
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (dgvVenta.CurrentRow == null)
                return;

            int idProducto =
                Convert.ToInt32(dgvVenta.CurrentRow.Cells["idProducto"].Value);

            var item = detalle.FirstOrDefault(x => x.idProducto == idProducto);

            if (item != null)
            {
                if (item.cantidad > 1)
                {
                    item.cantidad--;

                    item.subtotal = item.cantidad * item.precioUnitario;

                    refrescarDetalle();

                    foreach (DataGridViewRow fila in dgvVenta.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idProducto"].Value) == idProducto)
                        {
                            fila.Selected = true;
                            dgvVenta.CurrentCell = fila.Cells["nombre"];
                            break;
                        }
                    }
                }
                else
                {
                    detalle.Remove(item);
                    refrescarDetalle();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto del detalle.", "ProLimp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idProducto =
                Convert.ToInt32(dgvVenta.CurrentRow.Cells["idProducto"].Value);

            var item = detalle.FirstOrDefault(x => x.idProducto == idProducto);

            if (item != null)
            {
                detalle.Remove(item);
                refrescarDetalle();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (detalle.Count == 0)
                return;

            DialogResult r = MessageBox.Show("¿Desea vaciar toda la venta?", "ProLimp",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                detalle.Clear();
                refrescarDetalle();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           DialogResult r = MessageBox.Show("¿Desea cancelar la venta?", "ProLimp",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (r == DialogResult.Yes) Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (detalle.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un producto.",
                    "::: Mensaje - ProLimp :::",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idCliente = obtenerIdClientePorCI(txtCiCliente.Text);

            if (idCliente == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente válido.",
                    "::: Mensaje - ProLimp :::",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                Venta venta = new Venta();

                venta.idcliente = idCliente;
                venta.idempleado = Util.empleado.id;
                venta.fecha = DateTime.Now;

                decimal subtotal = detalle.Sum(x => x.subtotal);

                decimal descuento =
                    subtotal * porcentajeDescuento / 100;

                venta.total = subtotal - descuento;

                venta.usuarioRegistro = Util.empleado.usuario;
                venta.fechaRegistro = DateTime.Now;
                venta.estado = 1;

                int idVenta = VentaCln.insertar(venta);

                foreach (var item in detalle)
                {
                    DetalleVenta det = new DetalleVenta();

                    det.idventa = idVenta;
                    det.idproducto = item.idProducto;
                    det.cantidad = item.cantidad;
                    det.precioUnitario = item.precioUnitario;
                    det.subtotal = item.subtotal;

                    det.usuarioRegistro = Util.empleado.usuario;
                    det.fechaRegistro = DateTime.Now;
                    det.estado = 1;

                    DetalleVentaCln.insertar(det);

                    ProductoCln.actualizarStock(
                        item.idProducto,
                        item.cantidad);
                }

                string nombreClienteTemp = lblCliente.Text;
                string ciClienteTemp = txtCiCliente.Text;

                List<ItemVenta> detalleTemp =
                    new List<ItemVenta>(detalle);

                MessageBox.Show(
                    $"Venta registrada correctamente.\n\n",
                    "::: Venta Exitosa :::",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FrmFactura factura = new FrmFactura(
                    idVenta,
                    nombreClienteTemp,
                    ciClienteTemp,
                    DateTime.Now,
                    subtotal,
                    descuento,
                    venta.total,
                    detalleTemp
                );

                factura.ShowDialog();

                detalle.Clear();

                refrescarDetalle();

                txtCiCliente.Clear();

                lblCliente.Text = "Cliente no seleccionado";
                lblComprasCliente.Text = "Compras Realizadas: 0";
                lblTipoCliente.Text = "Cliente estándar";

                lblTotal.Text = "0.00";
                lblSubtotal.Text = "0.00";
                lblDescuentoMonto.Text = "0.00";
                lblDescuento.Text = "0%";

                porcentajeDescuento = 0;

                listarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "::: Error :::",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) 
            { 
                listarProductos();
                e.Handled = true;
            }
        }
    }
}
