using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IRoles : IBaseRepository<Roles>
    {
        IEnumerable<Roles> obtenerRolesPorUsuario(int usuarioId);
        IEnumerable<Roles> obtenerRolesActivos();
        Roles obtenerRolPorNombre(string nombre);
    }
}
