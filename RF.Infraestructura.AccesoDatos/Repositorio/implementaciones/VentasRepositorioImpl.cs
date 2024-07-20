using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class VentasRepositorioImpl : BaseRepositorioImpl<Ventas> , IVentas
    {
        public decimal calcularTotalVentasEmpleado(int empleadoId)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var resultado = context.Ventas.Where(rs => rs.EmpleadoId == empleadoId).Sum(rs => rs.Monto);
                    return resultado;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public IEnumerable<Ventas> ObtenerFechasPorRango(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var resultado = from ven in context.Ventas
                                    where ven.FechaVenta >= fechaInicio && ven.FechaVenta <= fechaFinal
                                    select ven;
                    return resultado;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public Ventas obtenerVentaporId(int ventaId)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var resultado = context.Ventas.Where(rs => rs.VentaId == ventaId);
                    return resultado.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public IEnumerable<Ventas> obtenerVentasPorEmpleado(int empleadoId)
        {
            try
            {
                using (var context = new ReferidosEntitiesModel())
                {
                    var resultado = context.Ventas.Where(rs => rs.EmpleadoId == empleadoId);
                    return resultado;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }
    }
}
