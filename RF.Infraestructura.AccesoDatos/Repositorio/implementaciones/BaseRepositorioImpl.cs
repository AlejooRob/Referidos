using RF.Dominio.Model.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace RF.Infraestructura.AccesoDatos.Repositorio.implementaciones
{
    public class BaseRepositorioImpl<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: No se puede insertar el registro", e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: No se puede eliminar el registro", e);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    return context.Set<TEntity>().ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: no se pudo listar los registros", e);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    return context.Set<TEntity>().Find(id);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: No se pudo recuperar el registro", e);
            }
        }

        public void Modify(TEntity entity)
        {
            try
            {
                using (var context = new ReferidsEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error: No se puede insertar el registro", e);
            }
        }
    }
}
