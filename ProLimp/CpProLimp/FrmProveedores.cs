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
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProveedorCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombreEmpresa"].HeaderText = "Nombre de la empresa";
            dgvLista.Columns["telefono"].HeaderText = "Telefono";
            dgvLista.Columns["direccion"].HeaderText = "Dirección";
            dgvLista.Columns["email"].HeaderText = "Email";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            listar();
        }


    }
}
