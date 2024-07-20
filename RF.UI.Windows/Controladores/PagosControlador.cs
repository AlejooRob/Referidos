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
    public class PagosControlador
    {
        private PagosServicio servicio;

        public PagosControlador()
        {
            servicio = new PagosServicio();
        }

        public bool InsertarPago(PagosVistaModelo pagosVistaModelo)
        {
            Pagos nuevoPago = new Pagos();
            try
            {
                nuevoPago.EmpleadoId = pagosVistaModelo.EmpleadoId;
                nuevoPago.ComisionId = pagosVistaModelo.ComisionId;
                nuevoPago.FechaPago = pagosVistaModelo.FechaPago;
                nuevoPago.MontoPago = pagosVistaModelo.MontoPago;
                servicio.insertarPagos(nuevoPago);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarPago(int id)
        {

            try
            {
                servicio.eliminarPago(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarPago(PagosVistaModelo pagosVistaModelo)
        {
            Pagos nuevoPago = new Pagos();
            try
            {
                nuevoPago.EmpleadoId = pagosVistaModelo.EmpleadoId;
                nuevoPago.ComisionId = pagosVistaModelo.ComisionId;
                nuevoPago.FechaPago = pagosVistaModelo.FechaPago;
                nuevoPago.PagoId = pagosVistaModelo.PagoId;
                servicio.modificarPago(nuevoPago);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<PagosVistaModelo> ListarPagos()
        {
            var listaPagos = servicio.listarTodo();
            List<PagosVistaModelo> listaVistaModelo = new List<PagosVistaModelo>();
            foreach (var item in listaPagos)
            {
                listaVistaModelo.Add(new PagosVistaModelo
                {
                    PagoId = item.PagoId,
                    EmpleadoId = item.EmpleadoId,
                    ComisionId = item.ComisionId,
                    FechaPago = item.FechaPago,
                    MontoPago = item.MontoPago,
                });
            }
            return listaVistaModelo;
        }

        public decimal ObtenerTotalPagosMes(int mes, int year)
        {
            try
            {
                // Llama al servicio para obtener el total de pagos
                return servicio.obtenerTotalPagosMes(mes, year);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("Error al obtener el total de pagos.", ex);
            }
        }

        public decimal ObtenerComisionPorVentas(int empleadoId, int comisionId, int mes, int anio)
        {
            try
            {
                return servicio.ObtenerComisionPorVentas(empleadoId, comisionId, mes, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }


        public decimal ObtenerSumaVentasEmpleadoFechas(int empleadoId, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                return servicio.ObtenerSumaVentasEmpleadoFechas(empleadoId, fechaInicio, fechaFinal);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return 0;
            }
        }
    }
}
