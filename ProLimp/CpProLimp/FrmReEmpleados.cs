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
    public partial class FrmReEmpleados : Form
    {
        public FrmReEmpleados()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = EmpleadoCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombres"].HeaderText = "Nombres";
            dgvLista.Columns["primer_apellido"].HeaderText = "Primer Apellido";
            dgvLista.Columns["segundo_apellido"].HeaderText = "Segundo Apellido";
            dgvLista.Columns["usuario"].HeaderText = "Usuario";
            dgvLista.Columns["telefono"].HeaderText = "Teléfono/Celular";
            dgvLista.Columns["usuario_registro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fecha_registro"].HeaderText = "Fecha de Registro";
        }

        private void FrmReEmpleados_Load(object sender, EventArgs e)
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
