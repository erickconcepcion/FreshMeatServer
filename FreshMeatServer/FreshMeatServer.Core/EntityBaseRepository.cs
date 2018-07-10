using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using LinqKit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FreshMeatServer.Core
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
      where T : class, IEntityBase, new()
    {
        private DbContext _context;
        private DbSet<T> _set;
        private IValidator<T> Validator;
        

        public EntityBaseRepository(DbContext context, IValidator<T> validator)
        {
            Validator = validator;
            _context = context;
            _set = context.Set<T>();
        }
        

        public virtual IEnumerable<T> Get()
        {
            return _set.AsEnumerable();
        }

        public virtual IEnumerable<T> GetIncluding(string includedProps ="")
        {
            
            return GetAll(includeProperties: includedProps);
        }


        public virtual GetPaging<T> Get(int page,
            int pagesize,
            string searchPredicate,
            string logicalOperator,
            string orderBy,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set;//.Where(x => x.Deleted == false);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            //
            var predicateQuery = PredicateBuilder.New<T>(true);

            if (!string.IsNullOrEmpty(searchPredicate))
            {
                predicateQuery = searchPredicate.AsPredicate<T>((logicalOperator == "AND" ? AndOrOperator.And : AndOrOperator.Or));
                query = query.Where(predicateQuery);
            }
            query = !string.IsNullOrEmpty(orderBy) ? query.GetOrderBy(orderBy) : query.OrderBy(a => a.Id);
            //
            var data = query
                .Skip((page - 1) * pagesize)
                .Take(pagesize)
                .AsEnumerable();
            //
            return new GetPaging<T>(data, page, _set.Count(predicateQuery), pagesize);
        }

        private IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "", bool includeDeleted = false)
        {
            IQueryable<T> query = (includeDeleted) ? _set.AsQueryable() : _set.AsQueryable();//.Where(x => x.Deleted == false).AsQueryable();


            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Aggregate(query, (current, includeProperty) =>
                                                       current.Include(includeProperty));

            if (filter == null)
                filter = PredicateBuilder.New<T>(true);

            //filter.And(a => a.Deleted);
            //// Solo registros Reales

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }

            return query;
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return GetAll(predicate)
                .AsNoTracking()
                .Count();
        }


        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set;//.Where(x => x.Deleted == false);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public T Find(Guid id)
        {
            return _set.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public T Find(Guid id, string includeProperties = "")
        {
            return GetAll(x => x.Id == id, includeProperties).FirstOrDefault();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _set.AsNoTracking().FirstOrDefault(predicate);//.Where(x => x.Deleted == false).FirstOrDefault(predicate);
        }

        public T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _set;//.Where(x => x.Deleted == false);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }
        
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate);//.Where(x => x.Deleted == false).Where(predicate);
        }


        public virtual EntityActionResult Add(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            /*Guid user = new Guid("ABC12300-0000-0000-0000-000000000000");

            PropertyInfo prop = entity.GetType().GetProperty("ModifiedDate");
            if (prop != null)
            {
                prop.SetValue(entity, DateTimeOffset.Now);
            }

            PropertyInfo prop1 = entity.GetType().GetProperty("CreatedDate");
            if (prop1 != null)
            {
                prop1.SetValue(entity, DateTimeOffset.Now);
            }

            PropertyInfo prop2 = entity.GetType().GetProperty("CreatedBy");

            if (prop2 != null)
            {
                prop2.SetValue(entity, user);
            }

            PropertyInfo prop3 = entity.GetType().GetProperty("ModifiedBy");

            if (prop3 != null)
            {
                prop3.SetValue(entity, user);
            }*/

            var results = Validator.Validate(entity);
            if (results.IsValid)
            {


                _set.Add(entity);
                return new EntityActionResult() { ErrorCode = 0, Success = true, Id = entity.Id };
            }
            var errosMsg = results.Errors.Select(e=>e.ErrorMessage);
            return new EntityActionResult() { ErrorCode = 500, Success = false, Messages = errosMsg };
        }

        public virtual EntityActionResult Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);

            Guid user = Guid.Empty;
            PropertyInfo prop = entity.GetType().GetProperty("ModifiedDate");
            if (prop != null)
            {
                prop.SetValue(entity, DateTimeOffset.Now);
            }

            PropertyInfo prop1 = entity.GetType().GetProperty("ModifiedBy");

            if (prop1 != null)
            {
                prop1.SetValue(entity, user);
            }

            var results = Validator.Validate(entity);
            if (results.IsValid)
            {
                dbEntityEntry.State = EntityState.Modified;
                return new EntityActionResult() { ErrorCode = 0, Success = true, Id = entity.Id };
            }
            var errosMsg = results.Errors.Select(e => e.ErrorMessage);
            return new EntityActionResult() { ErrorCode = 500, Success = false, Messages = errosMsg };
        }

        public virtual EntityActionResult Remove(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);


            dbEntityEntry.State = EntityState.Modified;
            //entity.Deleted = true;
            
            return new EntityActionResult() { ErrorCode = 0, Success = true, Id = entity.Id };
            
        }

        public virtual IEnumerable<EntityActionResult> RemoveWhereDelete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _set.Where(predicate);
            List<EntityActionResult> results = new List<EntityActionResult>();
            foreach (var entity in entities)
            {
                Remove(entity);
                results.Add(new EntityActionResult() { ErrorCode = 0, Success = true, Id = entity.Id });
            }
            return results;
        }


        public virtual void RemoveWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _set.Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public virtual void RemoveCollection(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
               Remove(entity);
            }
        }
        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void DeleteRange(IEnumerable<T>entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public virtual bool Save()
        {
            return _context.SaveChanges()>0;
        }
    }
}
