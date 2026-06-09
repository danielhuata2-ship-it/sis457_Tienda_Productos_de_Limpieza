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
    public partial class FrmReProductos : Form
    {
        public FrmReProductos()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["id_unidad_medida"].Visible = false;
            dgvLista.Columns["id_proveedor"].Visible = false;
            dgvLista.Columns["id_categoria"].Visible = false;
            dgvLista.Columns["id_marca"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["codigo"].HeaderText = "Código";
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["categoria"].HeaderText = "Categoria";
            dgvLista.Columns["marca"].HeaderText = "Marca";
            dgvLista.Columns["unidad_medida"].HeaderText = "Unidad de Medida";
            dgvLista.Columns["stock"].HeaderText = "Stock";
            dgvLista.Columns["precio_venta"].HeaderText = "Precio Venta";
            dgvLista.Columns["fecha_vencimiento"].HeaderText = "Fecha de Vencimiento";
            dgvLista.Columns["cantidad_minima_stock"].HeaderText = "Cantidad Mínima Stock";
            dgvLista.Columns["proveedor"].HeaderText = "Proveedor";
            dgvLista.Columns["usuario_registro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fecha_registro"].HeaderText = "Fecha Registro";
        }

        private void FrmReProductos_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
    }


}
