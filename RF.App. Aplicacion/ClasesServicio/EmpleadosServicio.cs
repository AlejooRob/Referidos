using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using RF.Infraestructura.AccesoDatos.Repositorio.implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.App.Aplicacion.ClasesServicio
{
    public class EmpleadosServicio
    {
        readonly IEmpleados empleadosRepositorio;
        public EmpleadosServicio()
        {
            empleadosRepositorio = new EmpleadosRepositorioImpl();
        }

        public void insertarEmpleado(Empleados empleado)
        {
            try
            {
                empleadosRepositorio.Add(empleado);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarEmpleado(Empleados empleado)
        {
            try
            {
                empleadosRepositorio.Modify(empleado);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarEmpleado(int idEmpleado)
        {
            try
            {
                empleadosRepositorio.Delete(idEmpleado);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Empleados> listarTodo()
        {
            try
            {
                return empleadosRepositorio.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }

        public Empleados buscarPorCI(string cedula)
        {
            try
            {
                return empleadosRepositorio.buscarPorCI(cedula);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }
        public Empleados buscarPorNombre(string nombre)
        {
            try
            {
                return empleadosRepositorio.buscarPorCI(nombre);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }
        public Empleados buscarPorApellido(string apellido)
        {
            try
            {
                return empleadosRepositorio.buscarPorCI(apellido);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }
        public IEnumerable<Empleados> ListarActivos()
        {
            try
            {
                return empleadosRepositorio.obtenerEmpleadosActivos();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
    }
}
