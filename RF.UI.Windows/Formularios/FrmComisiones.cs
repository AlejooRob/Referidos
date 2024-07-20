using RF.UI.Windows.Controladores;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RF.UI.Windows.Formularios
{
    public partial class FrmComisiones : Form
    {
        private ComisionesControlador servicio;
        private ComisionesVistaModelo comisionesVM;
        public FrmComisiones()
        {
            InitializeComponent();
            servicio = new ComisionesControlador();
            comisionesVM = new ComisionesVistaModelo();
            listarDatos();
        }

        public void listarDatos()
        {
            dataGridView1.DataSource = servicio.ListarComisiones();
        }
        public void InsertarComision()
        {
            if (!ValidarCampos())
            {
                return; 
            }
            if (ckComisionEstado.Checked)
            {
                comisionesVM.ComisionActiva = true;
            }
            else
            {
                comisionesVM.ComisionActiva = false;
            }

            comisionesVM.NombreComision = txtNombre.Text;
            comisionesVM.Monto = decimal.Parse(txtMonto.Text);
            comisionesVM.ValorComision = int.Parse(txtValuePer.Text);
            comisionesVM.DescripcionComision = txtDescripcion.Text;


            if (txtID.Text == "")
            {
                if (servicio.InsertarComision(comisionesVM))
                {
                    MessageBox.Show("Registro Insertado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se pudo insertar el registro");
                }
            }
            else
            {
                comisionesVM.ComisionId = int.Parse(txtID.Text);
                if (servicio.ActualizarComision(comisionesVM))
                {
                    MessageBox.Show("Registro Actualizado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se Actualizo el registro");
                }
            }
            listarDatos();
        }
        private void limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtMonto.Text = "";
            txtValuePer.Text = "";
            txtDescripcion.Text = "";
            ckComisionEstado.Checked = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            InsertarComision();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID antes de eliminar.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea eliminar Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                servicio.EliminarComision(int.Parse(txtID.Text));
                limpiar();
                listarDatos();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int item = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (item > 0)
            {
                txtID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtMonto.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtValuePer.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                txtDescripcion.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                ckComisionEstado.Checked = Boolean.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                txtNombre.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtMonto.Text = selectedRow?.Cells[2].Value?.ToString() ?? string.Empty;
                txtValuePer.Text = selectedRow?.Cells[3].Value?.ToString() ?? string.Empty;
                txtDescripcion.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;

                if (bool.TryParse(selectedRow.Cells[5].Value?.ToString(), out bool empleadoActivo))
                {
                    ckComisionEstado.Checked = empleadoActivo;
                }
                else
                {
                    ckComisionEstado.Checked = false;
                }
            }
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("El campo Monto es obligatorio.");
                txtMonto.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtValuePer.Text))
            {
                MessageBox.Show("El campo  Porcentaje es obligatorio.");
                txtMonto.Focus();
                return false;
            }

            if (!int.TryParse(txtValuePer.Text, out int valor) || valor < 0)
            {
                MessageBox.Show("El Porcentaje debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtValuePer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo Descripción es obligatorio.");
                txtDescripcion.Focus();
                return false;
            }

            return true; 
        }
    }
}
