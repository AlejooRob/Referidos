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
    public class VentasServicio
    {
        readonly IVentas ventasRepositorio;
        public VentasServicio()
        {
            ventasRepositorio = new VentasRepositorioImpl();
        }
        public void insertarVenta(Ventas venta)
        {
            try
            {
                ventasRepositorio.Add(venta);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarVenta(Ventas venta)
        {
            try
            {
                ventasRepositorio.Modify(venta);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarVenta(int idVenta)
        {
            try
            {
                ventasRepositorio.Delete(idVenta);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Ventas> listarTodo()
        {
            try
            {
                return ventasRepositorio.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }

        public decimal calcularTotalVentasEmpleado(int idEmpleado)
        {
            try
            {
                return ventasRepositorio.calcularTotalVentasEmpleado(idEmpleado);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se pudo calcular el total", e);
            }
        }
        public IEnumerable<Ventas> listarPorFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                return ventasRepositorio.ObtenerFechasPorRango(fechaInicio, fechaFinal);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
    }
}
