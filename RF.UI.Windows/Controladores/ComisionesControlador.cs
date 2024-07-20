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
    public class ComisionesControlador
    {
        private ComisionesServicio servicio;

         public ComisionesControlador()
        {
            servicio = new ComisionesServicio();
        }

        public bool InsertarComision(ComisionesVistaModelo comisionesVistaModelo)
        {
            Comisiones nuevaComisiones = new Comisiones(); //objeto de la BD
            try
            {
                nuevaComisiones.NombreComision = comisionesVistaModelo.NombreComision;
                nuevaComisiones.ValorComision = comisionesVistaModelo.ValorComision;
                nuevaComisiones.DescripcionComision = comisionesVistaModelo.DescripcionComision;
                nuevaComisiones.Monto = comisionesVistaModelo.Monto;
                nuevaComisiones.ComisionActiva = comisionesVistaModelo.ComisionActiva;
                servicio.insertarComision(nuevaComisiones);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool EliminarComision(int id)
        {

            try
            {
                servicio.eliminarComision(id);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ActualizarComision(ComisionesVistaModelo comisionesVistaModelo)
        {
            Comisiones nuevaComisiones = new Comisiones(); //objeto de la BD
            try
            {
                nuevaComisiones.NombreComision = comisionesVistaModelo.NombreComision;
                nuevaComisiones.ValorComision = comisionesVistaModelo.ValorComision;
                nuevaComisiones.DescripcionComision = comisionesVistaModelo.DescripcionComision;
                nuevaComisiones.ComisionId = comisionesVistaModelo.ComisionId;
                nuevaComisiones.Monto = comisionesVistaModelo.Monto;
                nuevaComisiones.ComisionActiva = comisionesVistaModelo.ComisionActiva;
                servicio.modificarComision(nuevaComisiones);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public IEnumerable<ComisionesVistaModelo> ListarComisiones()
        {
            var listaComisiones = servicio.listarTodo();
            List<ComisionesVistaModelo> listaVistaModelo = new List<ComisionesVistaModelo>();
            foreach (var item in listaComisiones)
            {
                listaVistaModelo.Add(new ComisionesVistaModelo
                {
                    ComisionId = item.ComisionId,
                    NombreComision = item.NombreComision,
                    DescripcionComision = item.DescripcionComision,
                    ComisionActiva = item.ComisionActiva,
                    ValorComision = item.ValorComision,
                    Monto = item.Monto,

                });
            }
            return listaVistaModelo;
        }

        public int obtenerValorComision(int id)
        {
            var resultado = servicio.obtenerPorId(id);

            return resultado.ValorComision;

        }
    }
}
