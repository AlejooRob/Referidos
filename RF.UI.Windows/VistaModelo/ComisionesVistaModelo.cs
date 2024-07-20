using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.VistaModelo
{
    public class ComisionesVistaModelo
    {
        public int ComisionId { get; set; }
        public string NombreComision { get; set; }
        public decimal Monto { get; set; }
        public int ValorComision { get; set; }
        public string DescripcionComision { get; set; }
        public bool ComisionActiva { get; set; }
    }
}
