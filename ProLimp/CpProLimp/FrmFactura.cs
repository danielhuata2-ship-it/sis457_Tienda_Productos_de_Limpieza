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
    public partial class FrmFactura : Form
    {
        private int idVenta;
        private string nombreCliente;
        private string ciCliente;
        private DateTime fechaVenta;
        private decimal totalVenta;
        private List<FrmVentas.ItemVenta> detalleVenta;
        private decimal subtotalVenta;
        private decimal descuentoVenta;

        public FrmFactura(
            int idVenta,
            string cliente,
            string ci,
            DateTime fecha,
            decimal subtotal,
            decimal descuento,
            decimal total,
            List<FrmVentas.ItemVenta> detalle)
        {
            InitializeComponent();

            this.idVenta = idVenta;
            this.nombreCliente = cliente;
            this.ciCliente = ci;
            this.fechaVenta = fecha;
            this.subtotalVenta = subtotal;
            this.descuentoVenta = descuento;
            this.totalVenta = total;
            this.detalleVenta = detalle;
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            this.Text = $"Factura N° {idVenta}";
            lblTitulo.Text = "FACTURA DE VENTA";
            lblNumero.Text = $"N° {idVenta.ToString("00000")}";
            lblFecha.Text = $"Fecha: {fechaVenta:dd/MM/yyyy HH:mm}";
            lblCliente.Text = $"Cliente: {nombreCliente}";
            lblCI.Text = $"CI: {ciCliente}";
            dgvDetalle.DataSource = detalleVenta;
            dgvDetalle.Columns["idProducto"].Visible = false;
            dgvDetalle.Columns["nombre"].HeaderText = "Producto";
            dgvDetalle.Columns["cantidad"].HeaderText = "Cantidad";
            dgvDetalle.Columns["precioUnitario"].HeaderText = "Precio Unit.";
            dgvDetalle.Columns["subtotal"].HeaderText = "Subtotal";
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ReadOnly = true;
            lblSubtotal.Text = $"Subtotal: Bs. {subtotalVenta:N2}";
            lblDescuento.Text = $"Descuento: Bs. {descuentoVenta:N2}";
            lblTotal.Text = $"TOTAL: Bs. {totalVenta:N2}";
            lblTotal.Font = new Font(lblTotal.Font.FontFamily, 14, FontStyle.Bold);
            lblTotal.ForeColor = Color.Green;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
