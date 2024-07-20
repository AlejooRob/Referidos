using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IVentas : IBaseRepository<Ventas>
    {
        IEnumerable<Ventas> obtenerVentasPorEmpleado(int empleadoId);
        decimal calcularTotalVentasEmpleado(int empleadoId);
        Ventas obtenerVentaporId(int ventaId);
        IEnumerable<Ventas> ObtenerFechasPorRango(DateTime fechaInicio, DateTime fechaFinal);
    }
}
