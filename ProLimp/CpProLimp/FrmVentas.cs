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
    }
}
