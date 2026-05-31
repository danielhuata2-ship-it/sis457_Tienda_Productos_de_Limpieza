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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
