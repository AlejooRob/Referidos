using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IPagos : IBaseRepository<Pagos>
    {
        IEnumerable<Pagos> obtenerPagosRangoFecha(DateTime fechaInicio, DateTime fechaFinal);
        IEnumerable<Pagos> obtenerPagosPorEmpleado(int empleadoId);
        decimal obtenerTotalPagosMes(int mes, int year);
        decimal ObtenerVentasConComision(int empleadoId, int comisionId, int mes, int anio);
        decimal ObtenerSumaVentasPorEmpleado(int empleadoId, DateTime fechaInicio, DateTime fechaFin);

    }
}

