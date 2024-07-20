using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class PagosRepositorioImpl : BaseRepositorioImpl<Pagos>, IPagos
    {
        public IEnumerable<Pagos> obtenerPagosPorEmpleado(int empleadoId)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var result = from pag in context.Pagos
                                 where pag.EmpleadoId == empleadoId
                                 select pag;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public IEnumerable<Pagos> obtenerPagosRangoFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var result = from pag in context.Pagos
                                 where pag.FechaPago >= fechaInicio && pag.FechaPago <= fechaFinal
                                 select pag;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public decimal obtenerTotalPagosMes(int mes, int year)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var result = context.Pagos.Where(p => p.FechaPago.Month == mes && p.FechaPago.Year == year).Sum(p => p.MontoPago);
                    return (decimal)result;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public decimal ObtenerVentasConComision(int empleadoId, int comisionId, int mes, int anio)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    // Obtener el total de ventas del empleado
                    var totalVentas = context.Ventas
                        .Where(v => v.EmpleadoId == empleadoId && v.FechaVenta.Month == mes && v.FechaVenta.Year == anio)
                        .Sum(v => (decimal?)v.Monto) ?? 0;

                    // Verificar totalVentas
                    Console.WriteLine($"Total Ventas para EmpleadoId {empleadoId} en Mes {mes} y Año {anio}: {totalVentas}");

                    // Obtener el porcentaje de comisión específico
                    var porcentajeComision = context.Comisiones
                        .Where(c => c.ComisionId == comisionId && c.ComisionActiva)
                        .Select(c => (decimal?)c.ValorComision)
                        .FirstOrDefault() ?? 0;

                    // Depuración: Verificar porcentajeComision
                    Console.WriteLine($"Porcentaje Comisión para ComisionId {comisionId}: {porcentajeComision}");

                    // Calcular la comisión
                    var comisionCalculada = totalVentas * (porcentajeComision / 100.0m);

                    // Depuración: Verificar comisionCalculada
                    Console.WriteLine($"Comisión Calculada: {comisionCalculada}");

                    return comisionCalculada;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: no se pudo obtener la comisión", e);
            }
        }

        public decimal ObtenerSumaVentasPorEmpleado(int empleadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var sumaMontos = context.Ventas
                        .Where(v => v.EmpleadoId == empleadoId && v.FechaVenta >= fechaInicio && v.FechaVenta <= fechaFin)
                        .Sum(v => v.Monto);

                    return sumaMontos;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: no se encontraron registros", e);
            }
        }



    }
}
