using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IEntityRepository<Brand>
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return context.Set<Brand>().SingleOrDefault(filter);
        }

        public Brand GetById(int id)
        {
            using var context = new ReCapContext();
            return context.Set<Brand>().SingleOrDefault(b => b.BrandId == id);
        }

        public void Add(Brand entity)
        {
            using var context = new ReCapContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Modified;
        }

        public void Update(Brand entity)
        {
            using var context = new ReCapContext();
            var modifiedEntity = context.Entry(entity);
            modifiedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            using var context = new ReCapContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
