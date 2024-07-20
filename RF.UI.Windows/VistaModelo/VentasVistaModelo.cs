using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.VistaModelo
{
    public class VentasVistaModelo
    {
        public int VentaId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime FechaVenta { get; set; }
    }
}
