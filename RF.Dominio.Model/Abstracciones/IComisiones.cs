using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IComisiones : IBaseRepository<Comisiones>
    {
        IEnumerable<Comisiones> obtenerComisionesActivas();
        Comisiones obtenerPorNombre(string nombre);
        Comisiones obtenerPorId(int Id);
    }
}
