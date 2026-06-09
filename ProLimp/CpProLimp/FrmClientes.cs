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
    public partial class FrmClientes : Form
    {
        private bool esNuevo = false;
        public FrmClientes()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = ClienteCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["razon_social"].HeaderText = "Razon Social";
            dgvLista.Columns["cedula_identidad"].HeaderText = "Cédula de Identidad";
            dgvLista.Columns["usuario_registro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fecha_registro"].HeaderText = "Fecha de Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["cedula_identidad"];
            btnEditar.Enabled = lista.Count > 0;
            btnBorrar.Enabled = lista.Count > 0;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Size = new Size(961, 482);
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(961, 592);
            txtRazonSocial.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(961, 592);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var cliente = ClienteCln.obtenerUno(id);
            txtRazonSocial.Text = cliente.razon_social;
            txtCedulaIdentidad.Text = cliente.cedula_identidad;

            txtRazonSocial.Focus();
        }
        private void limpiar()
        {
            txtRazonSocial.Clear();
            txtCedulaIdentidad.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
        private bool validar()
        {
            erpRazonSocial.Clear();
            erpCedulaIdentidad.Clear();
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) &&
                string.IsNullOrWhiteSpace(txtCedulaIdentidad.Text))
            {
                erpRazonSocial.SetError(txtRazonSocial, "Debe ingresar al menos un dato del cliente");
                erpCedulaIdentidad.SetError(txtCedulaIdentidad, "Debe ingresar al menos un dato del cliente");
                return false;
            }
            int? idActual = esNuevo ? (int?)null : (int)dgvLista.CurrentRow.Cells["id"].Value;
            var ced = txtCedulaIdentidad.Text.Trim();
            if (!string.IsNullOrWhiteSpace(ced) && ClienteCln.ExisteCedula(ced, idActual))
            {
                erpCedulaIdentidad.SetError(txtCedulaIdentidad, "La cédula ya está registrada.");
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;
            try
            {
                var cliente = new Cliente();
                cliente.razon_social = txtRazonSocial.Text.Trim();
                cliente.cedula_identidad = txtCedulaIdentidad.Text.Trim();
                cliente.usuario_registro = Util.empleado.usuario;
                if (esNuevo)
                {
                    cliente.fecha_registro = DateTime.Now;
                    cliente.estado = 1;
                    ClienteCln.insertar(cliente);
                }
                else
                {
                    cliente.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ClienteCln.actualizar(cliente);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Cliente guardado correctamente", "::: Mensaje - ProLimp :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string cedulaIdentidad = dgvLista.CurrentRow.Cells["cedulaIdentidad"].Value.ToString();
            string razonSocial = dgvLista.CurrentRow.Cells["razonSocial"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el cliente {razonSocial}?",
                "::: Mensaje - ProLimp :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ClienteCln.eliminar(id, Util.empleado.usuario);
                listar();
                MessageBox.Show("Cliente dado de baja correctamente", "::: Mensaje - ProLimp :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(961, 482);
            pnlAcciones.Enabled = true;
            limpiar();
        }
    }
}
