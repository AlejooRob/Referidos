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
    public partial class FrmEmpleados : Form
    {
        private EmpleadosControlador servicio;
        private EmpleadosVistaModelo empleadoVM;
        private RolesControlador servicioRoles;
        public FrmEmpleados()
        {
            InitializeComponent();
            servicio = new EmpleadosControlador();
            servicioRoles = new RolesControlador();
            empleadoVM = new EmpleadosVistaModelo();

            //dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            ListarDatos();
        }
        public void ListarDatos()
        {
            dataGridView1.DataSource = servicio.ListarEmpleados();
        }
        public void InsertarEmpleado()
        {
            if (!ValidarCampos())
            {
                return;
            }
            if (ckEmpleadoEstado.Checked)
            {
                empleadoVM.EmpleadoActivo = true;
            }
            else
            {
                empleadoVM.EmpleadoActivo = false;
            }
            empleadoVM.Nombres = txtNombre.Text;
            empleadoVM.Apellidos = txtApellido.Text;
            empleadoVM.Cedula = txtCedula.Text;
            empleadoVM.NumeroCuentaEmpleado = txtCuenta.Text;
            empleadoVM.Cedula = txtCedula.Text;
            empleadoVM.FechaNacimiento = dateTimePicker1.Value.Date;
            empleadoVM.Email = txtEmail.Text;

            if (txtID.Text == "")
            {
                if (servicio.InsertarEmpleados(empleadoVM))
                {
                    MessageBox.Show("Registro Insertado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se puede insetar el registro");
                }
            }
            else
            {
                empleadoVM.EmpleadoId = int.Parse(txtID.Text);
                if (servicio.ActualizarEmpleados(empleadoVM))
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
            dateTimePicker1.Value = DateTime.Now;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCuenta.Text = "";
            txtID.Text = "";
            txtEmail.Text = "";
            ckEmpleadoEstado.Checked = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            InsertarEmpleado();
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
                servicio.EliminarEmpleados(int.Parse(txtID.Text));
                limpiar();
                ListarDatos();
            }
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                txtNombre.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtApellido.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtCedula.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
                txtCuenta.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;
                txtEmail.Text = selectedRow.Cells[7].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(selectedRow.Cells[5].Value?.ToString(), out DateTime fechaNacimiento))
                {
                    dateTimePicker1.Value = fechaNacimiento;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }

                if (bool.TryParse(selectedRow.Cells[6].Value?.ToString(), out bool empleadoActivo))
                {
                    ckEmpleadoEstado.Checked = empleadoActivo;
                }
                else
                {
                    ckEmpleadoEstado.Checked = false; 
                }
            }
        }


        //Validaciones
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El campo Apellido es obligatorio.");
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El campo Cédula es obligatorio.");
                txtCedula.Focus();
                return false;
            }
            if (!int.TryParse(txtCedula.Text, out int cedula) || cedula <= 0)
            {
                MessageBox.Show("El monto debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCuenta.Text))
            {
                MessageBox.Show("El campo Cuenta es obligatorio.");
                txtCuenta.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El campo Email es obligatorio.");
                txtEmail.Focus();
                return false;
            }
            if (!EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email no es válido.");
                txtEmail.Focus();
                return false;
            }
            return true;
        }


    }
}
