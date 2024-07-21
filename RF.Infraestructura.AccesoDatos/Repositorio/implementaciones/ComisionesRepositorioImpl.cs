using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class ComisionesRepositorioImpl : BaseRepositorioImpl<Comisiones>, IComisiones
    {
        public IEnumerable<Comisiones> obtenerComisionesActivas()
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from com in context.Comisiones
                                 where com.ComisionActiva == true
                                 select com;
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro registros activos", e);
            }
        }

        public Comisiones obtenerPorNombre(string nombre)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from com in context.Comisiones
                                 where com.NombreComision == nombre
                                 select com;
                    return result.Single();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: no se encontro registro por Nombre", e);
            }
        }
        public Comisiones obtenerPorId(int id)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var resultado = from com in context.Comisiones
                                    where com.ComisionId == id
                                    select com;
                    return resultado.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro ese registro", e);
            }
        }
    }
}
