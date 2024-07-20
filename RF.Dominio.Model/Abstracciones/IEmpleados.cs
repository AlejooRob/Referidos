using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IEmpleados : IBaseRepository<Empleados>
    {
        Empleados buscarPorCI(string ci);
        Empleados buscarPorNombre(string nombre);
        Empleados buscarPorApellido(string apellido);
        IEnumerable<Empleados> obtenerEmpleadosActivos();
    }
}
