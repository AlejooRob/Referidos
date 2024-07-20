using RF.Dominio.Model.Entidades;
using RF.UI.Windows.Controladores;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RF.UI.Windows.Formularios
{
    public partial class FrmPagos : Form
    {
        ComisionesControlador comisionesControlador;
        EmpleadosControlador empleadosControlador;
        private PagosControlador servicio;
        private PagosVistaModelo pagosVM;
        public FrmPagos()
        {
            InitializeComponent();
            servicio = new PagosControlador();
            pagosVM = new PagosVistaModelo();
            empleadosControlador = new EmpleadosControlador();
            comisionesControlador = new ComisionesControlador();
            ListarDatos();
            leerEmpleado();
            leerComision();
            comboBoxComision.SelectedIndexChanged += new EventHandler(this.comboBoxComision_SelectedIndexChanged);
            

        }
        public void ListarDatos()
        {
            dataGridView1.DataSource = servicio.ListarPagos();
        }

        public void InsertarPago()
        {
            if (!ValidarDatos())
            {
                return; 
            }
            decimal totalVenta;
            if (decimal.TryParse(txtMonto.Text, out totalVenta))
            {
                Console.WriteLine($"El total del pago es: {totalVenta}");
            }
            else
            {
                MessageBox.Show("El valor ingresado no es un número válido.", "Error de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pagosVM.EmpleadoId = (int)comboBoxEmpleado.SelectedValue;
            pagosVM.ComisionId = (int)comboBoxComision.SelectedValue;
            pagosVM.FechaPago = DateTime.Now;
            pagosVM.MontoPago = totalVenta;

            if (string.IsNullOrEmpty(txtPagoId.Text))
            {
                if (servicio.InsertarPago(pagosVM))
                {
                    MessageBox.Show("Registro Insertado Correctamente");
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error: No se puede insertar el registro.");
                }
            }
            else
            {
                pagosVM.EmpleadoId = int.Parse(txtPagoId.Text);
                if (servicio.ActualizarPago(pagosVM))
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
            comboBoxEmpleado.SelectedIndex = -1;
            comboBoxComision.SelectedIndex = -1;
            txtTotVent.Text = "";
            txtPagoId.Text = "";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var monto = servicio.ObtenerSumaVentasEmpleadoFechas((int)comboBoxEmpleado.SelectedValue, dateTimePicker1.Value, dateTimePicker2.Value);
            txtTotVent.Text = monto.ToString();
            CalcularComision();
        }

        private void leerEmpleado()
        {
            comboBoxEmpleado.DataSource = empleadosControlador.ListarEmpleados();
            comboBoxEmpleado.DisplayMember = "Nombres";
            comboBoxEmpleado.ValueMember = "EmpleadoId";


        }
        private void leerComision()
        {
            comboBoxComision.DataSource = comisionesControlador.ListarComisiones();
            comboBoxComision.DisplayMember = "NombreComision";
            comboBoxComision.ValueMember = "ComisionId";
            


        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPagoId.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID antes de eliminar.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Seguro que desea eliminar Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                servicio.EliminarPago(int.Parse(txtPagoId.Text));
                limpiar();
                ListarDatos();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtPagoId.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                //comboBoxEmpleado.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                //comboBoxComision.Text =selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtTotVent.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;

                int empleadoId = (int)selectedRow.Cells[1].Value;
                comboBoxEmpleado.SelectedValue = empleadoId; 

                int comisionId = (int)selectedRow.Cells[2].Value;
                comboBoxComision.SelectedValue = comisionId; 


                if (DateTime.TryParse(selectedRow.Cells[3].Value?.ToString(), out DateTime fechaPago))
                {
                    dateTimePicker1.Value = fechaPago;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }


            }

        }
        private void comboBoxEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CalcularComision();
        }

        private void comboBoxComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CalcularComision();

        }
        private void CalcularComision()
        {
            decimal totalVenta;
            if (string.IsNullOrWhiteSpace(txtTotVent.Text) || comboBoxComision.SelectedValue == null)
            {
                MessageBox.Show("Calcule tel total de ventas por fecha y una comisión valida");
            }
            else
            {

                if (decimal.TryParse(txtTotVent.Text, out totalVenta))
                {
                    decimal valPag = totalVenta * (comisionesControlador.obtenerValorComision((int)comboBoxComision.SelectedValue))/100;
                    txtMonto.Text = valPag.ToString();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es un número válido.", "Error de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private bool ValidarDatos()
        {
            

            if (comboBoxEmpleado.SelectedValue == null || comboBoxComision.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un empleado y una comisión válida.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTotVent.Text))
            {
                MessageBox.Show("El monto de pago no puede estar vacío.");
                return false;
            }

            

            return true; 
        }

        private void comboBoxEmpleado_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmPagos_Load(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            InsertarPago();
        }
    }
}

