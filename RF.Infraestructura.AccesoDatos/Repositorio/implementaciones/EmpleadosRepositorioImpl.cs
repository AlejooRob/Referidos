using RF.Dominio.Model.Abstracciones;
using RF.Dominio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class EmpleadosRepositorioImpl : BaseRepositorioImpl<Empleados>, IEmpleados
    {
        public Empleados buscarPorApellido(string apellido)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from emple in context.Empleados
                                 where emple.Apellidos == apellido
                                 select emple;
                    return result.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro un registro con ese numero de cedula", e);
            }
        }

        public Empleados buscarPorCI(string ci)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from emple in context.Empleados
                                 where emple.Cedula == ci
                                 select emple;
                    return result.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro un registro con ese numero de cedula", e);
            }
        }

        public Empleados buscarPorNombre(string nombre)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = from emple in context.Empleados
                                 where emple.Nombres == nombre
                                 select emple;
                    return result.Single();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro un registro con ese numero de cedula", e);
            }
        }


        public IEnumerable<Empleados> obtenerEmpleadosActivos()
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var result = context.Empleados.Where(rs => rs.EmpleadoActivo == true);
                    return result.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: no se encontro un registro con ese numero de cedula", e);
            }
        }
    }
}
