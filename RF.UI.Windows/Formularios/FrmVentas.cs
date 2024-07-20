using RF.App.Aplicacion.ClasesServicio;
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
    public partial class FrmVentas : Form
    {
        EmpleadosControlador empleadosControlador;
        private VentasControlador servicio;
        private VentasVistaModelo ventasVm;
        public FrmVentas()
        {
            InitializeComponent();
            servicio = new VentasControlador();
            ventasVm = new VentasVistaModelo();
            empleadosControlador = new EmpleadosControlador();
            ListarDatos();
            leerEmpleado();
        }
        public void ListarDatos()
        {
            dataGridView1.DataSource = servicio.ListarVentas();
        }

        public void InsertarVenta()
        {
            if (!ValidarDatos())
            {
                return;
            }
            ventasVm.EmpleadoId = (int)cEmpleados.SelectedValue;
            //ventasVm.EmpleadoId = cEmpleados.SelectedIndex;
            ventasVm.Monto = decimal.Parse(txtMonto.Text);
            ventasVm.FechaVenta = dateTimePicker1.Value.Date;

            if (txtID.Text == "")
            {
                if (servicio.InsertarVenta(ventasVm))
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
                ventasVm.VentaId = int.Parse(txtID.Text);
                if (servicio.ActualizarVenta(ventasVm))
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
            cEmpleados.SelectedValue = -1;
            txtMonto.Text = "";
            dateTimePicker1.Text = "";

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            InsertarVenta();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                //cEmpleados. = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtMonto.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;

                int empleadoId = (int)selectedRow.Cells[1].Value;
                cEmpleados.SelectedValue = empleadoId;

                if (DateTime.TryParse(selectedRow.Cells[3].Value?.ToString(), out DateTime fechaNacimiento))
                {
                    dateTimePicker1.Value = fechaNacimiento;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
            }

          
        }  
        private void leerEmpleado()
            {
            
                cEmpleados.DataSource = empleadosControlador.ListarEmpleados();
                cEmpleados.DisplayMember = "Nombres";
                cEmpleados.ValueMember = "EmpleadoId";

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
                servicio.EliminarVenta(int.Parse(txtID.Text));
                limpiar();
                ListarDatos();
            }
        }

        private bool ValidarDatos()
        {
            if (cEmpleados.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado.");
                return false;
            } 
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("El monto de pago no puede estar vacío.");
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out _))
            {
                MessageBox.Show("El monto debe ser un número válido.");
                return false;
            }
           

            return true;
        }
    }
}
