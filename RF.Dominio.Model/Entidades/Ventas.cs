//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RF.Dominio.Model.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ventas
    {
        public int VentaId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime FechaVenta { get; set; }
    
        public virtual Empleados Empleados { get; set; }
    }
}
