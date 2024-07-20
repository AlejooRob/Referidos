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
    public partial class FrmRoles : Form
    {
        private RolesControlador servicio;
        private RolesVistaModelo RolVM;
        public FrmRoles()
        {
            InitializeComponent();
            servicio = new RolesControlador();
            RolVM = new RolesVistaModelo();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            ListarDatos();
        }

        public void ListarDatos()
        {
            dataGridView1.DataSource = servicio.ListarRoles();
        }

        public void InsertarRol()
        {
            if (!ValidarDatos())
            {
                return;
            }
            if (ckRolEstado.Checked)
            {
                RolVM.Activo = true;
            }
            else
            {
                RolVM.Activo = false;
            }
            RolVM.NombreRol = txtNombre.Text;
            RolVM.DescripcionRol = txtDesc.Text;

            if (txtID.Text == "")
            {
                if (servicio.InsertarRoles(RolVM))
                {
                    MessageBox.Show("Registro Insertado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se inserto el registro");
                }
            }
            else
            {
                RolVM.RolId = int.Parse(txtID.Text);
                if (servicio.ActualizarRoles(RolVM))
                {
                    MessageBox.Show("Registro Actualizado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se Actualizo el registro");
                }
            }
            ListarDatos();
        }
        private void limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDesc.Text = "";
            ckRolEstado.Checked = true;

        }
  

        private void iconButton1_Click(object sender, EventArgs e)
        {
            InsertarRol();
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
                servicio.EliminarRoles(int.Parse(txtID.Text));
                limpiar();
                ListarDatos();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int item = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (item > 0)
            {
                txtID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtDesc.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                ckRolEstado.Checked = Boolean.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());

            }
        }

     

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                txtNombre.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtDesc.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;

                if (bool.TryParse(selectedRow.Cells[3].Value?.ToString(), out bool empleadoActivo))
                {
                    ckRolEstado.Checked = empleadoActivo;
                }
                else
                {
                    ckRolEstado.Checked = false; 
                }
            }
        }
        private bool ValidarDatos()
        {
            // Validación del NombreRol
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del rol no puede estar vacío.");
                return false;
            }

            // Validación de la DescripciónRol
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("La descripción del rol no puede estar vacía.");
                return false;
            }
            return true;
        }
        }
    }
