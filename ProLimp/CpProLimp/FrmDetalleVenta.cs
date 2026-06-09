using ClnProLimp;
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
    public partial class FrmDetalleVenta : Form
    {
        private int idVenta;

        private void cargarDetalle() 
        {
            var venta = VentaCln.obtenerPorId(idVenta);

            if (venta == null)
            {
                MessageBox.Show("La venta no existe.");
                Close();
                return;
            }

            var cliente = ClienteCln.obtenerPorId(venta.id_cliente);

            var empleado = EmpleadoCln.obtenerPorId(venta.id_empleado);

            var detalle = DetalleVentaCln.listarPorVenta(idVenta);

            this.Text = $"Detalle Venta N° {venta.id}";

            lblNumero.Text = $"N° {venta.id.ToString("00000")}";

            lblFecha.Text = $"Fecha: {venta.fecha:dd/MM/yyyy HH:mm}";

            lblCliente.Text = $"Cliente: {cliente.razon_social}";

            lblCI.Text = $"CI: {cliente.cedula_identidad}";

            dgvDetalle.DataSource = detalle;

            dgvDetalle.Columns["id_producto"].Visible = false;

            dgvDetalle.Columns["nombre"].HeaderText = "Producto";

            dgvDetalle.Columns["cantidad"].HeaderText = "Cantidad";

            dgvDetalle.Columns["precio_unitario"].HeaderText = "Precio Unit.";

            dgvDetalle.Columns["subtotal"].HeaderText = "Subtotal";

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.ReadOnly = true;

            lblTotal.Text = $"TOTAL: Bs. {venta.total:N2}";
        }

        public FrmDetalleVenta(int id_venta)
        {
            InitializeComponent();
            this.idVenta = id_venta;
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            cargarDetalle();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
