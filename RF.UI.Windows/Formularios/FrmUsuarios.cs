using RF.Dominio.Model.Entidades;
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
    
    public partial class FrmUsuarios : Form
    {
        private EmpleadosControlador empleadosControlador;
        private EmpleadosVistaModelo empleadosVistaModelo;
        private RolesVistaModelo rolesVistaModelo;
        private RolesControlador rolesControlador;
        private UsuariosControlador servicio;
        private UsuariosVistaModelo usuariosVM;
        public FrmUsuarios()
        {
            InitializeComponent();
            servicio = new UsuariosControlador();  
            usuariosVM = new UsuariosVistaModelo();
            empleadosControlador = new EmpleadosControlador();
            rolesControlador = new RolesControlador();
            ListarDatos();
            leerEmpleado();
            leerRoles();
        }

        public void ListarDatos()
        {
            dataGridView1.DataSource = servicio.ListarUsuario();
        }

        public void InsertarUsuario()
        {

            if (!ValidarDatos())
            {
                return; 
            }

            if (ckActivo.Checked)
            {
                usuariosVM.Activo = true;
            }
            else
            {
                usuariosVM.Activo = false;
            }
            usuariosVM.EmpleadoId = (int?)comboBoxEmpleado.SelectedValue;
            usuariosVM.NombreUsuario = txtNombre.Text;
            usuariosVM.PasswordUsuario = txtpsw.Text;

            if (txtID.Text == "")
            {
                MessageBox.Show("Solo se pueden modificar los usuarios");
            }
            else
            {
                usuariosVM.UsuarioId = int.Parse(txtID.Text);
                if (servicio.ActualizarUsuario(usuariosVM))
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
            txtpsw.Text = "";
            ckActivo.Checked = true;
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxRoles.SelectedIndex = -1;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            InsertarUsuario();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Asignar los valores de las celdas a los controles correspondientes
                txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                int empleadoId = (int)selectedRow.Cells[1].Value;
                comboBoxEmpleado.SelectedValue = empleadoId;
                txtNombre.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtpsw.Text = selectedRow?.Cells[3].Value?.ToString() ?? string.Empty;
                

                // Manejo de estado del empleado para CheckBox
                if (bool.TryParse(selectedRow.Cells[6].Value?.ToString(), out bool empleadoActivo))
                {
                    ckActivo.Checked = empleadoActivo;
                }
                else
                {
                    ckActivo.Checked = false; // Valor predeterminado si la conversión falla
                }
            }
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
                servicio.EliminarUsuario(int.Parse(txtID.Text));
                limpiar();
                ListarDatos();
            }
        }
        
        private void leerEmpleado()
        {
            comboBoxEmpleado.DataSource = empleadosControlador.ListarEmpleados();
            comboBoxEmpleado.DisplayMember = "Nombres";
            comboBoxEmpleado.ValueMember = "EmpleadoId";


        }

        private void leerRoles()
        {
            comboBoxRoles.DataSource = rolesControlador.ListarRolesActivos();
            comboBoxRoles.DisplayMember = "NombreRol";
            comboBoxRoles.ValueMember = "RolId";
        }
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtpsw.Text))
            {
                MessageBox.Show("La contraseña no puede estar vacía.");
                return false;
            }

            if (comboBoxEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado.");
                return false;
            }

            return true;
        }
    }


}
