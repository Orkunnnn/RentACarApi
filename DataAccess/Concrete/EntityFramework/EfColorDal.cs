using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IEntityRepository<Color>
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
        }

        public Color Get(Expression<Func<Color, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return context.Set<Color>().SingleOrDefault(filter);
        }

        public Color GetById(int id)
        {
            using var context = new ReCapContext();
            return context.Set<Color>().SingleOrDefault(c => c.ColorId == id
            );
        }

        public void Add(Color entity)
        {
            using var context = new ReCapContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(Color entity)
        {
            using var context = new ReCapContext();
            var modifiedEntity = context.Entry(entity);
            modifiedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Color entity)
        {
            using var context = new ReCapContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
