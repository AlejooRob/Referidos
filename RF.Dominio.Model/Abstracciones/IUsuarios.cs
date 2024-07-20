using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Dominio.Model.Abstracciones
{
    public interface IUsuarios : IBaseRepository<Usuarios>
    {
        Usuarios obtenerPorEmail(string email);
        IEnumerable<Usuarios> obtenerUsuariosActivos();
        int verificarCredenciales(string email, string password);
    }
}
