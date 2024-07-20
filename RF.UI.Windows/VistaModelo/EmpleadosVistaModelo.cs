using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.VistaModelo
{
    public class EmpleadosVistaModelo
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string NumeroCuentaEmpleado { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public bool EmpleadoActivo { get; set; }
        public string Email { get; set; }
    }
}
