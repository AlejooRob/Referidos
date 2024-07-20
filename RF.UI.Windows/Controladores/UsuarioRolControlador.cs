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
    public class UsuarioRolControlador
    {
        private UsuarioRolServicio servicio;

        public UsuarioRolControlador() 
        {
            servicio = new UsuarioRolServicio();    
        }
        public bool InsertarUsuarioRoles(UsuarioRolvistaModelo usuarioRolvistaModelo)
        {
            UsuarioRol usuarioRol = new UsuarioRol();
            try
            {
                usuarioRol.UsuarioId = usuarioRolvistaModelo.UsuarioId;
                usuarioRol.RolId = usuarioRolvistaModelo.RolId;
                
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarUsuarioRol(int id)
        {

            try
            {
                servicio.eliminarUsuarioRoles(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarRoles(UsuarioRolvistaModelo usuarioRolvistaModelo)
        {
            UsuarioRol usuarioRol = new UsuarioRol();
            try
            {
                usuarioRol.UsuarioId = usuarioRolvistaModelo.UsuarioId;
                usuarioRol.RolId = usuarioRolvistaModelo.RolId;
                usuarioRol.UsuarioRolId = usuarioRolvistaModelo.UsuarioRolId;
                servicio.modificarUsuarioRoles(usuarioRol);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<UsuarioRolvistaModelo> ListarUsuarioRol()
        {
            var listaUsuariosRol = servicio.listarTodo();
            List<UsuarioRolvistaModelo> listaVistaModelo = new List<UsuarioRolvistaModelo>();
            foreach (var item in listaUsuariosRol)
            {
                listaVistaModelo.Add(new UsuarioRolvistaModelo
                {
                    UsuarioRolId = item.UsuarioRolId,
                    UsuarioId = item.UsuarioId,
                    RolId = item.RolId
                });
            }
            return listaVistaModelo;
        }
    }
}
