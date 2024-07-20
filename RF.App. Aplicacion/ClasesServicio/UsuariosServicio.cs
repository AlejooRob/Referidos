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
    public class UsuariosServicio
    {
        readonly IUsuarios usuariosRepositorio;

        public UsuariosServicio()
        {
            usuariosRepositorio = new UsuariosRepositorioImpl();
        }

        public void insertarUsuario(Usuarios usuario)
        {
            try
            {
                usuariosRepositorio.Add(usuario);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarUsuario(Usuarios usuario)
        {
            try
            {
                usuariosRepositorio.Modify(usuario);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarUsuario(int idUsuario)
        {
            try
            {
                usuariosRepositorio.Delete(idUsuario);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Usuarios> listarTodo()
        {
            try
            {
                return usuariosRepositorio.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encontraron registros", e);
            }
        }

        public Usuarios buscarPorEmail(string email)
        {
            try
            {
                return usuariosRepositorio.obtenerPorEmail(email);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }

        public IEnumerable<Usuarios> obtenerUsuariosActivos()
        {
            try
            {
                return usuariosRepositorio.obtenerUsuariosActivos();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }

        public int verificarCredenciales(string email, string password)
        {
            try
            {
                return usuariosRepositorio.verificarCredenciales(email, password);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se encuentra el registro", e);
            }
        }
    }
}
