using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class UsuariosRepositorioImpl : BaseRepositorioImpl<Usuarios>, IUsuarios
    {
        public Usuarios obtenerPorEmail(string email)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from usu in context.Usuarios
                                 where usu.NombreUsuario == email
                                 select usu;
                    return result.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro un registro con ese usuario", e);
            }
        }

        public IEnumerable<Usuarios> obtenerUsuariosActivos()
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from usu in context.Usuarios
                                 where usu.Activo == true
                                 select usu;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se pudo obtener usuarios activos", e);
            }
        }

        public int verificarCredenciales(string email, string password)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var usuarioID = (from u in context.Usuarios
                                    where u.NombreUsuario == email && u.PasswordUsuario == password
                                    select u).FirstOrDefault();
                    if(usuarioID != null)
                    {
                        return usuarioID.UsuarioId;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: Las credenciales no son correctas", e);
            }
        }
    }
}
