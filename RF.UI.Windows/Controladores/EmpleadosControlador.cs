using RF.App.Aplicacion.ClasesServicio;
using RF.Dominio.Model.Entidades;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.Controladores
{
    public class EmpleadosControlador
    {
        private EmpleadosServicio servicio;

        public EmpleadosControlador()
        {
            servicio = new EmpleadosServicio();
        }

        public bool InsertarEmpleados(EmpleadosVistaModelo empleadosVistaModelo)
        {
            Empleados nuevoEmpleado = new Empleados(); //objeto de la BD
            try
            {
                nuevoEmpleado.Nombres = empleadosVistaModelo.Nombres;
                nuevoEmpleado.Apellidos = empleadosVistaModelo.Apellidos;
                nuevoEmpleado.Cedula = empleadosVistaModelo.Cedula;
                nuevoEmpleado.NumeroCuentaEmpleado = empleadosVistaModelo.NumeroCuentaEmpleado;
                nuevoEmpleado.FechaNacimiento = empleadosVistaModelo.FechaNacimiento;
                nuevoEmpleado.EmpleadoActivo = empleadosVistaModelo.EmpleadoActivo;
                nuevoEmpleado.Email = empleadosVistaModelo.Email;
                servicio.insertarEmpleado(nuevoEmpleado);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarEmpleados(int id)
        {

            try
            {
                servicio.eliminarEmpleado(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarEmpleados(EmpleadosVistaModelo empleadosVistaModelo)
        {
            Empleados nuevoEmpleado = new Empleados(); //objeto de la BD
            try
            {
                nuevoEmpleado.Nombres = empleadosVistaModelo.Nombres;
                nuevoEmpleado.Apellidos = empleadosVistaModelo.Apellidos;
                nuevoEmpleado.Cedula = empleadosVistaModelo.Cedula;
                nuevoEmpleado.NumeroCuentaEmpleado = empleadosVistaModelo.NumeroCuentaEmpleado;
                nuevoEmpleado.FechaNacimiento = empleadosVistaModelo.FechaNacimiento;
                nuevoEmpleado.EmpleadoActivo = empleadosVistaModelo.EmpleadoActivo;
                nuevoEmpleado.EmpleadoId = empleadosVistaModelo.EmpleadoId;
                nuevoEmpleado.Email = empleadosVistaModelo.Email;
                servicio.modificarEmpleado(nuevoEmpleado);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<EmpleadosVistaModelo> ListarEmpleados()
        {
            var listaEmpleados = servicio.listarTodo();
            List<EmpleadosVistaModelo> listaVistaModelo = new List<EmpleadosVistaModelo>();
            foreach (var item in listaEmpleados)
            {
                listaVistaModelo.Add(new EmpleadosVistaModelo
                {
                    EmpleadoId = item.EmpleadoId,
                    Nombres = item.Nombres,
                    Apellidos = item.Apellidos,
                    Cedula = item.Cedula,
                    NumeroCuentaEmpleado = item.NumeroCuentaEmpleado,
                    FechaNacimiento = item.FechaNacimiento,
                    EmpleadoActivo = item.EmpleadoActivo,
                    Email = item.Email,

                });
            }
            return listaVistaModelo;
        }
    }
}
