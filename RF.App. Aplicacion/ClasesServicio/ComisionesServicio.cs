using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using RF.Infraestructura.AccesoDatos.Repositorio.implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RF.App.Aplicacion.ClasesServicio
{
    public class ComisionesServicio
    {
        protected readonly IComisiones comisionesRepositorio;

        public ComisionesServicio()
        {
            comisionesRepositorio = new ComisionesRepositorioImpl();
        }

        public void insertarComision(Comisiones comision)
        {
            try
            {
                comisionesRepositorio.Add(comision);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede insertar registro", e);
            }
        }

        public void modificarComision(Comisiones comision)
        {
            try
            {
                comisionesRepositorio.Modify(comision);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede modificar el registro", e);
            }
        }

        public void eliminarComision(int idComision)
        {
            try
            {
                comisionesRepositorio.Delete(idComision);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede eliminar el registro", e);
            }
        }
        public IEnumerable<Comisiones> listarTodo()
        {
            try
            {
                return comisionesRepositorio.GetAll();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros", e);
            }
        }

        public IEnumerable<Comisiones> ListarActivos()
        {
            try
            {
                return comisionesRepositorio.obtenerComisionesActivas();
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros activos", e);
            }
        }
        public Comisiones obtenerPorNombre(string nombre)
        {
            try
            {
                return comisionesRepositorio.obtenerPorNombre(nombre);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros activos", e);
            }
        }

        public Comisiones obtenerPorId(int id)
        {
            try
            {
                return comisionesRepositorio.obtenerPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception("Error Servicio: No se puede encontraron registros activos", e);
            }
        }
    }
}
