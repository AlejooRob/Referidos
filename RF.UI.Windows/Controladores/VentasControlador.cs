using RF.App.Aplicacion.ClasesServicio;
using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.Controladores
{
    public class VentasControlador
    {
        private VentasServicio servicio;
        public VentasControlador()
        {
            servicio = new VentasServicio();
        }

        public bool InsertarVenta(VentasVistaModelo ventasVistaModelo)
        {
            Ventas nuevaventa = new Ventas();
            try
            {
                nuevaventa.EmpleadoId = ventasVistaModelo.EmpleadoId;
                nuevaventa.Monto = ventasVistaModelo.Monto;
                nuevaventa.FechaVenta = ventasVistaModelo.FechaVenta;
                servicio.insertarVenta(nuevaventa);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarVenta(int id)
        {

            try
            {
                servicio.eliminarVenta(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarVenta(VentasVistaModelo ventasVistaModelo)
        {
            Ventas nuevaventa = new Ventas();
            try
            {
                nuevaventa.VentaId = ventasVistaModelo.VentaId;
                nuevaventa.EmpleadoId = ventasVistaModelo.EmpleadoId;
                nuevaventa.Monto = ventasVistaModelo.Monto;
                nuevaventa.FechaVenta = ventasVistaModelo.FechaVenta;
                servicio.modificarVenta(nuevaventa);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<VentasVistaModelo> ListarVentas()
        {
            var listaVentas = servicio.listarTodo();
            List<VentasVistaModelo> listaVistaModelo = new List<VentasVistaModelo>();
            foreach (var item in listaVentas)
            {
                listaVistaModelo.Add(new VentasVistaModelo
                {
                    VentaId = item.VentaId,
                    EmpleadoId = item.EmpleadoId,
                    Monto = item.Monto,
                    FechaVenta = item.FechaVenta,
                });
            }
            return listaVistaModelo;
        }
    }
}
