using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class RolesRepositorioImpl : BaseRepositorioImpl<Roles>, IRoles
    {
        public IEnumerable<Roles> obtenerRolesActivos()
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from rol in context.Roles
                                 where rol.Activo == true
                                 select rol;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }

        public IEnumerable<Roles> obtenerRolesPorUsuario(int usuarioId)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from urol in context.UsuarioRol
                                 join r in context.Roles on urol.RolId equals r.RolId
                                 where urol.UsuarioId == usuarioId
                                 select r;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }


        public Roles obtenerRolPorNombre(string nombre)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from rol in context.Roles
                                 where rol.NombreRol == nombre
                                 select rol;
                    return result.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontraron registros", e);
            }
        }
    }
}
