using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMatrixData.Models;

namespace CarMatrixCore.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelsContainer _container;
        private IDbSet<T> _entities;

        public Repository(ModelsContainer container)
        {
            this._container = container;
        }

        public T Find(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Create(T t)
        {
            try
            {
                if (t == null)
                    throw new ArgumentNullException("T");

                this.DbSet.Add(t);

                this._container.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T t)
        {
            try
            {
                if (t == null)
                    throw new ArgumentNullException("T");

                var entry = this._container.Entry(t);
                if (entry.State == EntityState.Detached)
                {
                    this.DbSet.Attach(t);
                    entry.State = EntityState.Modified;
                }

                this._container.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(T t)
        {
            try
            {
                if (t == null)
                    throw new ArgumentNullException("T");

                this.DbSet.Remove(t);
                this._container.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T> GetEntities
        {
            get
            {
                return this.DbSet;
            }
        }

        private IDbSet<T> DbSet
        {
            get
            {
                if (this._entities == null)
                    this._entities = _container.Set<T>();
                return this._entities;
            }
        }
    }
}
