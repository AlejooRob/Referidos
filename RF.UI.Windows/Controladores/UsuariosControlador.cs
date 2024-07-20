using RF.App.Aplicacion.ClasesServicio;
using RF.Dominio.Model.Entidades;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.Controladores
{
    public class UsuariosControlador
    {
        private UsuariosServicio servicio;

        public UsuariosControlador()
        {
            servicio = new UsuariosServicio();
        }

        public bool InsertarUsuario(UsuariosVistaModelo usuariosVistaModelo)
        {
            Usuarios nuevoUsuario = new Usuarios();
            try
            {
                nuevoUsuario.EmpleadoId = usuariosVistaModelo.EmpleadoId;
                nuevoUsuario.NombreUsuario = usuariosVistaModelo.NombreUsuario;
                nuevoUsuario.PasswordUsuario = usuariosVistaModelo.PasswordUsuario;
                nuevoUsuario.FechaCreacion = usuariosVistaModelo.FechaCreacion;
                nuevoUsuario.Activo = usuariosVistaModelo.Activo;
                servicio.insertarUsuario(nuevoUsuario);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarUsuario(int id)
        {

            try
            {
                servicio.eliminarUsuario(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarUsuario(UsuariosVistaModelo usuariosVistaModelo)
        {
            Usuarios nuevoUsuario = new Usuarios();
            try
            {
                nuevoUsuario.EmpleadoId = usuariosVistaModelo.EmpleadoId;
                nuevoUsuario.NombreUsuario = usuariosVistaModelo.NombreUsuario;
                nuevoUsuario.PasswordUsuario = usuariosVistaModelo.PasswordUsuario;
                nuevoUsuario.FechaActualizacion = usuariosVistaModelo.FechaActualizacion;
                nuevoUsuario.Activo = usuariosVistaModelo.Activo;
                nuevoUsuario.UsuarioId = usuariosVistaModelo.UsuarioId;
                servicio.modificarUsuario(nuevoUsuario);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<UsuariosVistaModelo> ListarUsuario()
        {
            var listaUsuarios = servicio.listarTodo();
            List<UsuariosVistaModelo> listaVistaModelo = new List<UsuariosVistaModelo>();
            foreach (var item in listaUsuarios)
            {
                listaVistaModelo.Add(new UsuariosVistaModelo
                {
                    UsuarioId = item.UsuarioId,
                    EmpleadoId = item.EmpleadoId,
                    NombreUsuario = item.NombreUsuario,
                    PasswordUsuario = item.PasswordUsuario,
                    FechaCreacion = item.FechaCreacion,
                    FechaActualizacion = item.FechaActualizacion,
                    Activo = item.Activo
                });
            }
            return listaVistaModelo;
        }
        public int verificarUsurioPassword(string email, string password)
        {
            return servicio.verificarCredenciales(email, password);
        }
    }
}
