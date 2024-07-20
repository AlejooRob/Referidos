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
    public class PagosServicio
    {
        readonly IPagos pagosRepositorio;
        public PagosServicio()
        {
            pagosRepositorio = new PagosRepositorioImpl();
        }

        public void insertarPagos(Pagos pago)
        {
            try
            {
                pagosRepositorio.Add(pago);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarPago(Pagos pago)
        {
            try
            {
                pagosRepositorio.Modify(pago);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarPago(int idPago)
        {
            try
            {
                pagosRepositorio.Delete(idPago);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Pagos> listarTodo()
        {
            try
            {
                return pagosRepositorio.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
        public IEnumerable<Pagos> obtenerPagosPorEmpleado(int idEmpleado)
        {
            try
            {
                return pagosRepositorio.obtenerPagosPorEmpleado(idEmpleado);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encontraron registros", e);
            }
        }

        public IEnumerable<Pagos> obtenerPagosRangoFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                return pagosRepositorio.obtenerPagosRangoFecha(fechaInicio, fechaFinal);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encontraron registros", e);
            }
        }
        public decimal obtenerTotalPagosMes(int mes, int year)
        {
            try
            {
                return pagosRepositorio.obtenerTotalPagosMes(mes, year);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encontraron registros", e);
            }
        }

        public decimal ObtenerComisionPorVentas(int empleadoId, int comisionId, int mes, int anio)
        {
            try
            {
                return pagosRepositorio.ObtenerVentasConComision(empleadoId, comisionId, mes, anio);
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se pudo obtener la comisión", e);
            }
        }


        public decimal ObtenerSumaVentasEmpleadoFechas(int empleadoId,DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return pagosRepositorio.ObtenerSumaVentasPorEmpleado(empleadoId, fechaInicio, fechaFin);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se pudo obtener la la Suma de los montos de Ventas", e); ;
            }
        }

    }
}
