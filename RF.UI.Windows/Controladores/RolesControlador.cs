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
    public class RolesControlador
    {
        private RolesServicio servicio;

        public RolesControlador()
        {
            servicio = new RolesServicio();
        }

        public bool InsertarRoles(RolesVistaModelo rolesVistaModelo)
        {
            Roles nuevoRol = new Roles();
            try
            {
                nuevoRol.NombreRol = rolesVistaModelo.NombreRol;
                nuevoRol.DescripcionRol = rolesVistaModelo.DescripcionRol;
                nuevoRol.Activo = rolesVistaModelo.Activo;
                servicio.insertarRoles(nuevoRol);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarRoles(int id)
        {

            try
            {
                servicio.eliminarRoles(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarRoles(RolesVistaModelo rolesVistaModelo)
        {
            Roles nuevoRol = new Roles();
            try
            {
                nuevoRol.NombreRol = rolesVistaModelo.NombreRol;
                nuevoRol.DescripcionRol = rolesVistaModelo.DescripcionRol;
                nuevoRol.Activo = rolesVistaModelo.Activo;
                nuevoRol.RolId = rolesVistaModelo.RolId;
                servicio.modificarRoles(nuevoRol);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<RolesVistaModelo> ListarRoles()
        {
            var listaUsuarios = servicio.listarTodo();
            List<RolesVistaModelo> listaVistaModelo = new List<RolesVistaModelo>();
            foreach (var item in listaUsuarios)
            {
                listaVistaModelo.Add(new RolesVistaModelo
                {
                    RolId = item.RolId,
                    NombreRol = item.NombreRol,
                    DescripcionRol = item.DescripcionRol,
                    Activo = item.Activo
                });
            }
            return listaVistaModelo;
        }

        public IEnumerable<RolesVistaModelo> ListarRolesActivos()
        {
            var listaUsuarios = servicio.obtenerRolesActivos();
            List<RolesVistaModelo> listaVistaModelo = new List<RolesVistaModelo>();
            foreach (var item in listaUsuarios)
            {
                listaVistaModelo.Add(new RolesVistaModelo
                {
                    RolId = item.RolId,
                    NombreRol = item.NombreRol,
                    DescripcionRol = item.DescripcionRol,
                    Activo = item.Activo
                });
            }
            return listaVistaModelo;
        }
    }
}
