using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.VistaModelo
{
    public class PagosVistaModelo
    {
        public int PagoId { get; set; }
        public int EmpleadoId { get; set; }
        public Nullable<int> ComisionId { get; set; }
        public System.DateTime FechaPago { get; set; }
        public Nullable<decimal> MontoPago { get; set; }
    }
}
