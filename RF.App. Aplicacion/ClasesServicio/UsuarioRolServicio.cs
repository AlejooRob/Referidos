using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using RF.Infraestructura.AccesoDatos.Repositorio.implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.App.Aplicacion.ClasesServicio
{
    public class UsuarioRolServicio
    {
        readonly IUsuarioRol usuarioRolRepositorio;

        public UsuarioRolServicio()
        {
            usuarioRolRepositorio = new UsuarioRolRepositorioImpl();
        }

        public void insertarUsuarioRoles(UsuarioRol usuarioRol)
        {
            try
            {
                usuarioRolRepositorio.Add(usuarioRol);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarUsuarioRoles(UsuarioRol usuarioRol)
        {
            try
            {
                usuarioRolRepositorio.Modify(usuarioRol);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarUsuarioRoles(int idUsuarioRol)
        {
            try
            {
                usuarioRolRepositorio.Delete(idUsuarioRol);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<UsuarioRol> listarTodo()
        {
            try
            {
                return usuarioRolRepositorio.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
    }
}
