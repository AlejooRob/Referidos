using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.VistaModelo
{
    public class UsuariosVistaModelo
    {
        public int UsuarioId { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public bool Activo { get; set; }
    }
}
