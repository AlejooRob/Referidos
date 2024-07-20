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
    public class RolesServicio
    {
        readonly IRoles rolesRepositorio;
        public RolesServicio()
        {
            rolesRepositorio = new RolesRepositorioImpl();
        }

        public void insertarRoles(Roles roles)
        {
            try
            {
                rolesRepositorio.Add(roles);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarRoles(Roles roles)
        {
            try
            {
                rolesRepositorio.Modify(roles);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarRoles(int idPago)
        {
            try
            {
                rolesRepositorio.Delete(idPago);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Roles> listarTodo()
        {
            try
            {
                return rolesRepositorio.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
        public IEnumerable<Roles> obtenerRolesActivos()
        {
            try
            {
                return rolesRepositorio.obtenerRolesActivos();
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
        public IEnumerable<Roles> obtenerRolesPorUsuario(int usuarioId)
        {
            try
            {
                return rolesRepositorio.obtenerRolesPorUsuario(usuarioId);
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
        public Roles obtenerRolPorNombre(string nombre)
        {
            try
            {
                return rolesRepositorio.obtenerRolPorNombre(nombre);
            }
            catch (Exception e)
            {
                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }
    }
}
